using Microsoft.AspNetCore.Mvc;

namespace FestivaNow.Ads.Controllers;

[ApiController]
public class ErrorController : ControllerBase
{

    [HttpGet("/error")]
    public IActionResult Error(){
        return Problem();
    }
}