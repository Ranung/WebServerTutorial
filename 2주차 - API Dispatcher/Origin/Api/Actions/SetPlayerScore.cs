using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
namespace Api.Actions;

public class SetPlayerScore : IApiService
{
	private readonly IMemoryCache _memoryCache;

	public SetPlayerScore(IMemoryCache memoryCache)
	{
		_memoryCache = memoryCache;
	}

	public Task<JObject> ProcessAsync(JObject param)
	{
		var addScore = param.Value<int>("score");
		var curScore = _memoryCache.TryGetValue("score", out int cachedScore) ? cachedScore : 0;
		var finalScore = curScore + addScore;
		if (finalScore is < 0 or > 10000)
			return Task.FromResult(new JObject {["status"] = "INVALID_REQUEST"});
		
		_memoryCache.Set("score", finalScore);
		return Task.FromResult(new JObject {["status"] = "success"});
	}
}
