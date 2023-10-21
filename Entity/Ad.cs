using System;
namespace FestivaNow.Ads.Entity;

public record Ad(
    long EventId,
    Guid Id,
    DateTime CreationDate
);