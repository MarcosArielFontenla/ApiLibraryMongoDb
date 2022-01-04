using System;
using MongoDB.Driver;

namespace ApiLibraryMongo.DbProvider
{
    public class MongoDbProvider
    {
        public MongoClient client;
        public IMongoDatabase db;

        public MongoDbProvider()
        {
            client = new MongoClient("mongodb://127.0.0.1:27017");
            db = client.GetDatabase("BooksDB");
        }
    }
}
