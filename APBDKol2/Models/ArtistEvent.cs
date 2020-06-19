using System;

namespace APBDKol2.Models
{
    public class ArtistEvent
    {
        public int IdEvent { get; set; }
        public int IdArtist { get; set; }
        public Event Event { get; set; } 
        public Artist Artist { get; set; }
        public DateTime PerformanceDate { get; set; }
    }
}