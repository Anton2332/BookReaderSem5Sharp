using Domain.Entities;
using Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Persistence;

public class DataContext : IDataContext
{
    private readonly IMongoDatabase db;

    public DataContext(IOptions<DataConfiguration> options)
    {
        var client = new MongoClient(options.Value.ConnectionString);
        db = client.GetDatabase(options.Value.Database);
    }


    public IMongoCollection<Bookmarks> Bookmarks => db.GetCollection<Bookmarks>("Bookmarks");
    public IMongoCollection<TypeBookmarks> TypeBookmarks => db.GetCollection<TypeBookmarks>("TypeBookmarks");
    public IMongoCollection<Notification> Notifications => db.GetCollection<Notification>("Notifications");
}