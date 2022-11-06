using MongoDB.Bson;
using MongoDB.Driver;
namespace StudentManagementAPI.Database
{
    public interface IMongoDbClient
    { 
        IMongoCollection<T> GetCollection<T>();
    }
}
