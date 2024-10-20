using ASPNET3.Services;

namespace ASPNET3.Controllers;

using Microsoft.AspNetCore.Mvc;
[Route("[controller]")]
[ApiController]
public class MathController(CalcService calcService) : ControllerBase
{
    [HttpGet("add/{a}/{b}")]
    public ActionResult<int> Add(int a, int b)
    {
        return calcService.Add(a, b);
    }

    [HttpGet("subtract/{a}/{b}")]
    public ActionResult<int> Subtract(int a, int b)
    {
        return calcService.Subtract(a, b);
    }

    [HttpGet("multiply/{a}/{b}")]
    public ActionResult<int> Multiply(int a, int b)
    {
        return calcService.Multiply(a, b);
    }

    [HttpGet("divide/{a}/{b}")]
    public ActionResult<double> Divide(double a, double b)
    {
        try
        {
            return calcService.Divide(a, b);
        }
        catch (ArgumentException)
        {
            return BadRequest("Cannot divide by zero");
        }
    }
}