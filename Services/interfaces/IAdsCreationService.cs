using FestivaNow.Ads.Contracts;

namespace FestivaNow.Ads.Services.Interfaces;

public interface IAdsCreationService{
    public CreateAdResponse CreateAd(CreateAdRequest request);
}