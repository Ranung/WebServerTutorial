using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
namespace Api.Actions;

public class GetPlayerScore : IApiService
{
	private readonly IMemoryCache _memoryCache;
	
	public GetPlayerScore(IMemoryCache memoryCache)
	{
		_memoryCache = memoryCache;
	}

	public Task<JObject> ProcessAsync(JObject param)
	{
		var score = _memoryCache.TryGetValue("score", out int cachedScore)
			? cachedScore
			: 0;
		return Task.FromResult(new JObject {["score"] = score});
	}
}
