using System;
using FestivaNow.Ads.Contracts;
using FestivaNow.Ads.Services.Interfaces;
using StackExchange.Redis;
using  FestivaNow.Ads.Entity;
using Newtonsoft.Json;

namespace FestivaNow.Ads.Services.Impl;

public class AdsCreationService : IAdsCreationService
{

private readonly IConnectionMultiplexer _redis;

    public AdsCreationService(IConnectionMultiplexer connectionMultiplexer){
        _redis = connectionMultiplexer;
    }

    private static readonly int MAX_INTERNAL_TIME = 30; //Tiempo en minutos

    public CreateAdResponse CreateAd(CreateAdRequest request)
    {
        var db = _redis.GetDatabase();
        
        var guid = Guid.NewGuid();
        var datetime = DateTime.Now;

        Ad ads = new(request.Id, guid, datetime);

        var json = JsonConvert.SerializeObject(ads);

        db.StringSet(guid.ToString(), json, TimeSpan.FromMinutes(MAX_INTERNAL_TIME));

        return new(guid, datetime);
    }

    
}