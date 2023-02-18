using Api.Models;
using Game.Context;
using Newtonsoft.Json.Linq;

namespace Api.Actions;

public class GetPlayerScore : IApiService
{
    private readonly GameContext _gameContext;

    public GetPlayerScore(GameContext gameContext)
    {
        _gameContext = gameContext;
    }

    public async Task<JObject> ProcessAsync(JObject param)
    {
        var uid = param.Value<string>("uid") ?? Guid.NewGuid().ToString();
        var playerModel = await _gameContext.FindAsync<PlayerModel>(uid);
        return new JObject { ["score"] = playerModel?.Score ?? 0 };
    }
}