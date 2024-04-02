using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace record_keeper_dotnet.Models
{
    public class Song
    {
        // [BsonId]
        // [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? AlbumId { get; set; }
        public string? Note { get; set; }
        public int SongRating { get; set; } //1 bad 3 neutrl 5 good

        public bool IsRadioAppropriate { get; set; } = true;
    }
}