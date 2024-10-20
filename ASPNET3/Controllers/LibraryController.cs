using ASPNET3.Services;

namespace ASPNET3.Controllers;

using Microsoft.AspNetCore.Mvc;
[Route("[controller]")]
[ApiController]
public class LibraryController(LibraryService libraryService) : ControllerBase
{
    public IActionResult Index()
    {
        return Ok("Hello!");
    }
    [HttpGet("Books")]
    public IActionResult Books()
    {
        return Ok(libraryService.GetBooks());
    }

    [HttpGet("Profile/{id?}")]
    public IActionResult Profile(int? id)
    {
        if (id == null)
        {
            return Ok($"Hi, {Environment.UserName}");
        }
        var profile = libraryService.GetProfile((int)id);
        return profile != null ? Ok(profile) : Ok("Profile not found!");
    }
}