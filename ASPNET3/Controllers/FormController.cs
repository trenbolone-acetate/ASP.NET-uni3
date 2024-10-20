namespace ASPNET3.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    
    [Route("[controller]")]
    public class FormController : Controller
    {
        private string? CookieName { get; set; }

        [HttpGet("")]
        public IActionResult Index()
        {
            //throw new Exception("This is a test exception");
            
            return View();
        }
    
        [HttpPost("SubmitForm")]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitForm(string? name, string value, DateTime datetime)
        {
            //return Ok("SubmitForm action hit");
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value) || datetime == default)
            {
                return BadRequest("Invalid input");
            }
            CookieName = name;
            HttpContext.Response.Cookies.Append(name, value, new CookieOptions() { Expires = datetime.ToUniversalTime() });
            
            return RedirectToAction("Index");
        }
    
        [HttpGet("CheckCookies")]
        public IActionResult CheckCookies()
        {
            var myAppCookies = Request.Cookies
                .Where(c => c.Key.StartsWith("Lb5_"))
                .ToDictionary(c => c.Key, c => c.Value);
            ViewBag.Cookies = myAppCookies;
            return View();
        }
    }
}