using FestivaNow.Ads.Contracts;
using FestivaNow.Ads.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FestivaNow.Ads.Controllers;

[ApiController]
[Route("/create")]
public class AdCreationController: ControllerBase{

    
    private readonly IAdsCreationService _adsCreationService;

    public AdCreationController(IAdsCreationService adsCreationService){
        _adsCreationService = adsCreationService;
    }
    
    [HttpPost]
    public IActionResult CreateAd(CreateAdRequest request){
        var response = _adsCreationService.CreateAd(request);
        return Created("/ads", response); 
    }
}