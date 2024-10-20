using ASPNET3.Services;

namespace ASPNET3.Controllers;

using Microsoft.AspNetCore.Mvc;


[Route("[controller]")]
[ApiController]
public class TimeAnalyzerController(ITimeAnalyzerService timeAnalyzerService) : ControllerBase
{
    [HttpGet("time")]
    public IActionResult GetTimeOfDayMessage()
    {
        var message = timeAnalyzerService.GetMessageBasedOnTimeOfDay();
        
        return Ok(message);
    }
}