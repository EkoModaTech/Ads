using FestivaNow.Ads.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FestivaNow.Ads.Controllers;

[ApiController]
[Route(("/create"))]
public class AdCreationController: ControllerBase{
    
    [HttpPost]
    public IActionResult CreateAd(CreateAdRequest request){
        return Ok(request); 
    }
}