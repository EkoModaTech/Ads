using FestivaNow.Ads.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace FestivaNow.Ads.Controllers;

[ApiController]
[Route("/ads")]
public class AdController : ControllerBase
{
    [Inject]
    public IAdsService AdsService { get; set; }
    
    [HttpGet]
    public IActionResult GetAd(){
        return Ok("ADSSSS");
    }
}