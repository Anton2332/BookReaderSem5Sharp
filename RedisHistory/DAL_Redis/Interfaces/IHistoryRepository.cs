using DAL_Redis.Entities;

namespace DAL_Redis.Interfaces;

public interface IHistoryRepository
{
    History GetHistory(string userName);
    History UpdateHistory(History history);
    Task DeleteHistory(string userName);
}