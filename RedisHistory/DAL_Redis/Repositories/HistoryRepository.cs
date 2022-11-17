using System.Text.Json.Serialization;
using DAL_Redis.Entities;
using DAL_Redis.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace DAL_Redis.Repositories;

public class HistoryRepository : IHistoryRepository
{
    private readonly IDistributedCache _redisCache;

    public HistoryRepository(IDistributedCache cache)
    {
        _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
    }
    public History GetHistory(string userName)
    {
        var history = _redisCache.GetString(userName);
        if (String.IsNullOrEmpty(history))
            return null;
        return JsonConvert.DeserializeObject<History>(history);

    }

    public History UpdateHistory(History history)
    {
        _redisCache.SetString(history.UserName, JsonConvert.SerializeObject(history));
        return GetHistory(history.UserName);
    }

    public async Task DeleteHistory(string userName)
    {
        await _redisCache.RemoveAsync(userName);
    }
}