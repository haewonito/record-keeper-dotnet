using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using MongoDB.Bson;
// using MongoDB.Bson.Serialization.Attributes;

namespace record_keeper_dotnet.Models
{
    public class Record
    {
        // [BsonId]
        // [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string Title { get; set; } = "default title";
        public string Content { get; set; } = "default content";
        public string Artist { get; set; } = "default artist";
        public int Year { get; set; }
        public string? Note { get; set; }
        // public List<Genre>? Genres { get; set; } = new List<Genre>() { Genre.MississippiBlues };
        public List<string> Genres { get; set; } = new List<string>() { "MississipiBlues" };
        public int AlbumRating { get; set; } = 3; //1 bad 3 neutrl 5 good
        public Song? Songs { get; set; }
        public Dictionary<int, float>? EstimatedValues { get; set; }
        public string? ImageLink { get; set; }
    }
}


