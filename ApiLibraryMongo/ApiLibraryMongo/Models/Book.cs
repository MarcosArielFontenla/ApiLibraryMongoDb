using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ApiLibraryMongo.Models
{
    public class Book
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int Stock { get; set; }
    }
}
