using FestivaNow.Ads.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace FestivaNow.Ads.Controllers;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("/ads")]
public class AdController : ControllerBase
{

    [Inject]
    public required IAdsService AdsService { get; set; }
    
    [HttpGet]
    public IActionResult GetAd(){
        return Ok("ADSSSS");
    }
}