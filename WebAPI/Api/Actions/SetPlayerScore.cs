using Api.Models;
using Game.Context;
using Newtonsoft.Json.Linq;
using Shared;

namespace Api.Actions;

public class SetPlayerScore : IApiService
{
    private readonly GameContext _gameContext;

    public SetPlayerScore(GameContext gameContext)
    {
        _gameContext = gameContext;
    }

    public async Task<JObject> ProcessAsync(JObject param)
    {
        var uid = param.Value<string>(ProtocolKey.Uid);

        if (string.IsNullOrEmpty(uid))
            return new JObject { [ProtocolKey.Status] = StatusKey.InsufficientParameters };

        var score = param.Value<int>(ProtocolKey.Score);
        if (score is < 0 or > 10000)
            return new JObject { [ProtocolKey.Status] = StatusKey.InvalidRequest };

        var playerModel = await _gameContext.FindAsync<PlayerModel>(uid);
        if (playerModel == null)
        {
            playerModel = new PlayerModel
            {
                Uid = uid
            };
            await _gameContext.AddAsync(playerModel);
        }

        playerModel.Score += score;
        await _gameContext.SaveChangesAsync();

        return new JObject { [ProtocolKey.Score] = score };
    }
}