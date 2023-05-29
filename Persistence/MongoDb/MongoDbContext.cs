using Application.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.MongoDb
{
    public class MongoDbContext<T> : IMongoDbContext<T>
    {
        private readonly IMongoDatabase db;
        private readonly IMongoCollection<T> mongoCollection; //colection yek table
        public MongoDbContext()
        {
            var Clite = new MongoClient();
            db = Clite.GetDatabase("VisitorDb");

            mongoCollection = db.GetCollection<T>(typeof(T).Name); // fel konam har entity ke midi ba in name on entoty ro migire;s
        }
        public IMongoCollection<T> GetCollection()
        {
            return mongoCollection;
        }
    }
}

