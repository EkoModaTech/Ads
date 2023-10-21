using System;
using FestivaNow.Ads.Contracts;
using FestivaNow.Ads.Entity;
using FestivaNow.Ads.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace FestivaNow.Ads.Services.Impl;

public class AdsService : IAdsService
{
    private readonly IConnectionMultiplexer _redis;
    private readonly ILogger _logger;

    public AdsService(IConnectionMultiplexer connectionMultiplexer, ILogger<AdsService> logger){
        _redis = connectionMultiplexer;
        _logger = logger;
    }
    
    public AdResponse GetAd()
    {
        var db = _redis.GetDatabase();
        var random = db.Execute("RANDOMKEY");

        if(random.IsNull){
            //TODO HANDLE CONNECTION TO EVENT MICROSERVICE TO GAIN A RANDOM ID
            _logger.LogError("NOT IMPLEMENTED");
            return new(0, Guid.NewGuid());
        }

        var json = db.StringGet((RedisKey)random);

        var obj = JsonConvert.DeserializeObject<Ad>(json);

        return new(obj.EventId, Guid.NewGuid());
    }
}