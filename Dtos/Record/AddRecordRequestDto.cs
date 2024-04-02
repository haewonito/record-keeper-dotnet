using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace record_keeper_dotnet.Dtos.Record
{
    public class AddRecordRequestDto  //we want dto without an id, so it can be automatically generated
    {
        public string Title { get; set; } = "default title";
        public string Content { get; set; } = "default content";
        public string Artist { get; set; } = "default artist";
        public int Year { get; set; }
        public string? Note { get; set; }
        public List<string> Genres { get; set; } = new List<string>() { "MississipiBlues" };
        public int AlbumRating { get; set; } = 3; //1 bad 3 neutrl 5 good
        public Song? Songs { get; set; }
        public Dictionary<int, float>? EstimatedValues { get; set; }
        public string? ImageLink { get; set; }
    }
}