using FestivaNow.Ads.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FestivaNow.Ads.Controllers;

[ApiController]
[Route("/ads")]
public class AdController : ControllerBase
{
    private readonly IAdsService _adsService;

    public AdController(IAdsService adsService){
        _adsService = adsService;
    }
    
    [HttpGet]
    public IActionResult GetAd(){
        var response = _adsService.GetAd();
        return Ok(response);
    }
}