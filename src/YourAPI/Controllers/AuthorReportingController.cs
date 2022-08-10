using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Newtonsoft.Json;
using YourAPI.ApiIntergration;

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

    [HttpGet]
    public async Task<IActionResult> GetAuthorById(int id)
    {
        var author = await _authorApiClient.GetAuthorById(id);

        return Ok(author);
    }

    [HttpGet]
    public async Task<IActionResult> GetAuthor()
    {
        var author = await _authorApiClient.GetAuthor();

        return Ok(author);
    }
}