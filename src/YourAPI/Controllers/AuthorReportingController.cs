using Microsoft.AspNetCore.Mvc;
using YourAPI.ApiIntergration;
using YourAPI.Model;

namespace YourAPI.Controllers;

[ApiController]
[Route("author-reporting")]
public class AuthorReportingController : Controller
{
    private readonly IAuthorApiClient _authorApiClient;

    public AuthorReportingController(IAuthorApiClient authorApiClient)
    {
        _authorApiClient = authorApiClient;
    }

    [HttpGet("ListAuthor")]
    public async Task<IActionResult> GetListAuthor([FromQuery] List<int> id)
    {
        var authors = new List<Author>();
        for (int i = 0; i < id.Count; i++)
        {
            var author = await _authorApiClient.GetAuthorById(id[i]);
            var books = await _authorApiClient.GetBookByAuthorId(author.Id);
            var newAuthor = new Author()
            {
                Id = author.Id,
                Followers = author.Followers,
                Name = author.Name,
                Books = new List<Book>(await Task.WhenAll(books.Select(async x => new Book
                {
                    Id = x.Id,
                    Name = x.Name,
                    Stars = x.Stars,
                    Reviews = await _authorApiClient.GetReview(author.Id, x.Id)
                })))
            };

            Dictionary<int, object> dictionary = new Dictionary<int, object>()
            {
                
            };
            authors.Add(newAuthor);
        }
        return Ok(authors);
    }
}