using System;

namespace FestivaNow.Ads.Contracts;
public record AdResponse (
    long IdEvent,
    Guid IdAds
);