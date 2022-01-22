using MongoDB.Driver;

namespace CRUD_Operation_MVC_Mongodb.Models.DBAccess
{
    public class DemoContext
    {
        private readonly IConfiguration configuration;

        public DemoContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(configuration.GetConnectionString("dbConnection"));

            var db = client.GetDatabase("Employee");
            return db.GetCollection<T>(collection);
        }

    }
}
