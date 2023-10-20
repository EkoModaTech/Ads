using FestivaNow.Ads.Contracts;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace FestivaNow.Ads.Controllers;

[ApiController]
[Route(("/create"))]
public class AdCreationController: ControllerBase{
    
    [HttpPost]
    public IActionResult CreateAd(CreateAdRequest request){
        return Ok(request); 
    }
}