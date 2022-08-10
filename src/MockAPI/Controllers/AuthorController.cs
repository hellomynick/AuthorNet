using Microsoft.AspNetCore.Mvc;
using MockAPI.Services;

namespace MockAPI.Controllers;

[ApiController]
[Route("authors")]
public class AuthorController : ControllerBase
{
    private readonly DataStore _dataStore;
    
    public AuthorController(DataStore dataStore)
    {
        _dataStore = dataStore;
    }

    /// <summary>
    /// THIS ENDPOINT ONLY USING FOR VIEW DATA IN DEVELOPMENT - DON'T USE IT AT YOUR CODE TEST
    /// </summary>
    [HttpGet]
    [Route("")]
    public IActionResult GetAuthors()
    {
        var result = _dataStore.GetAuthors();
        return Ok(result);
    }
    
    [HttpGet]
    [Route("{authorId:int}")]
    public IActionResult GetAuthor(int authorId)
    {
        var authors = _dataStore.GetAuthor(authorId);
        if (authors is null) return NotFound();
        
        return Ok(authors);
    }
    
    [HttpGet]
    [Route("{authorId:int}/books")]
    public IActionResult GetBooks(int authorId)
    {
        var author = _dataStore.GetAuthor(authorId);
        if (author is null) return NotFound("Author not found!");
        
        return Ok(author.Books);
    }
    
    [HttpGet]
    [Route("{authorId:int}/books/{bookId:int}/reviews")]
    public IActionResult GetBookReviews(int authorId, int bookId)
    {
        var author = _dataStore.GetAuthor(authorId);
        if (author is null) return NotFound("Author not found!");

        var book = author.Books.FirstOrDefault(x => x.Id == bookId);
        if (book is null) return NotFound("Book not found!");
        
        return Ok(book.Reviews);
    }
}