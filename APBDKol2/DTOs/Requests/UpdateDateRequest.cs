using System;

namespace APBDKol2.DTOs.Requests
{
    public class UpdateDateRequest
    {
        public int IdArtist { get; set; }
        public int IdEvent { get; set; }
        public DateTime PerformanceDate { get; set; }
    }
}