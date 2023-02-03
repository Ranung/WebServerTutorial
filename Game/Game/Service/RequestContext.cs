﻿using Newtonsoft.Json.Linq;

namespace Game.Service;

public class RequestContext
{
    public int SeqId { get; set; }
    public string? Uid { get; set; }
    public JObject[]? Actions { get; set; }

    public string CacheKey => $"{Uid}@{SeqId}";
}