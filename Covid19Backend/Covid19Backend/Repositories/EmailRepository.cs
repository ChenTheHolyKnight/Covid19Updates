using Covid19Backend.Models.Database;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Repositories
{
    public class EmailRepository: IEmailRepository
    {
        private readonly IMongoCollection<UserProfile> _profiles;
        public EmailRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _profiles = database.GetCollection<UserProfile>(settings.CollectionName);
        }

        public void AddEmail(string email)
        {
            _profiles.InsertOne( new UserProfile()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Email = email                
            });
        }

        public List<UserProfile> Get() =>
            _profiles.Find(item => true).ToList();
    }
}
