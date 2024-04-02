using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace record_keeper_dotnet.Dtos.Record
{
    public class UpdateRecordRequestDto
    {

        public int Id { get; set; }
        public string Title { get; set; } = "default title";
        public string Content { get; set; } = "default content";
        public string Artist { get; set; } = "default artist";
        public int Year { get; set; }
        public string? Note { get; set; }
        // public List<Genre>? Genres { get; set; } = new List<Genre>() { Genre.MississippiBlues };
        public List<string> Genres { get; set; } = new List<string>() { "MississipiBlues" };
        //todo - think about how to deal with the changes for genres and songs. Should be able to just add to the list, or change existing data. Might be differnet. 
        public int AlbumRating { get; set; } = 3; //1 bad 3 neutrl 5 good
        public Song? Songs { get; set; }
        public Dictionary<int, float>? EstimatedValues { get; set; }
        public string? ImageLink { get; set; }
    }
}