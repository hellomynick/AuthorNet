using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Newtonsoft.Json;
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

    [HttpGet("author")]
    public async Task<IActionResult> GetAuthorById( int id)
    {
        var author = await _authorApiClient.GetAuthorById(id);

        return Ok(author);
    }

    [HttpGet("book")]
    public async Task<IActionResult> GetBookByAuthorId(int id)
    {
        var author = await _authorApiClient.GetAuthorById(id);
        var books = await _authorApiClient.GetBookByAuthorId(author.Id);
        var review = await _authorApiClient.GetReview(author.Id, books);

        Author authors = new Author()
        {
            Id = author.Id,
            Followers = author.Followers,
            Name = author.Name,
            Books = books.Select(x => new Book()
            {
                Id = x.Id,
                Name = x.Name,
                Stars = x.Stars,
                Reviews = new List<Review>()
            }),
        };
        return Ok(authors);
    }

    [HttpGet("review")]
    public async Task<IActionResult> GetReview(int authorId)
    {
        var author = await _authorApiClient.GetAuthorById(authorId);
        var books = await _authorApiClient.GetBookByAuthorId(author.Id);
        Author authors = new Author()
        {
            Id = author.Id,
            Followers = author.Followers,
            Name = author.Name,
            Books = new List<Book>(books),
        };
        return Ok(authors);

    }

}