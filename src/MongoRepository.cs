using System;
using System.Collections.Generic;
using Minify.Interfaces;
using Minify.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Minify
{
    public class MongoRepository : IRepository
    {
        private IMongoDatabase database;
        public MongoRepository()
        {
            var client = new MongoClient(
                "mongodb+srv://EpsiEleve:TvxreYSXYCg89lz1@cluster0-b8srw.azure.mongodb.net/test?retryWrites=true&w=majority"
            );
            database = client.GetDatabase("Epsi");
        }
        public void Add(MinifyData minifyData)
        {
            
            database.GetCollection<MinifyData>("Laura")
                .InsertOne(minifyData);
        }

        public void Delete(string token)
        {
            database.GetCollection<MinifyData>("Laura")
                .DeleteOne(data => data.Key == token);
        }

        public IEnumerable<MinifyData> Get()
        {
            return database.GetCollection<MinifyData>("Laura")
                .Find( new BsonDocument())
                .ToList();
        }

        public MinifyData Get(string token)
        {
            return database.GetCollection<MinifyData>("Laura")
                .Find(data => data.Key == token)
                .FirstOrDefault();
        }
    }
}