using MongoDB.Bson;
using MongoDB.Driver;
using StudentManagementAPI.Constants;
namespace StudentManagementAPI.Database
{
    public class MongoDbClient : IMongoDbClient
    {
        public IConfiguration Configuration { get; set; }
        private readonly IMongoDatabase _database;

        public MongoDbClient(IConfiguration configuration)
        {
            Configuration = configuration;
            var client = new MongoClient(Configuration[DatabaseSettings.ConnectionString]);
            _database = client.GetDatabase(Configuration[DatabaseSettings.DatabaseName]);
        }
        public IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>(typeof(T).Name);
        }
    }
}
