using Domain.Entities;
using MongoDB.Driver;

namespace Infrastructure.Persistence;

public interface IDataContext
{
    IMongoCollection<Bookmarks> Bookmarks { get; }
    IMongoCollection<TypeBookmarks> TypeBookmarks { get; }
    IMongoCollection<Notification> Notifications { get; }
}