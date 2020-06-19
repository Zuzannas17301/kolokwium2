namespace APBDKol2.Models
{
    public class EventOrganiser
    {
        public int IdEvent { get; set; }
        public int IdOrganiser { get; set; }
        public Organiser Organiser { get; set; }
        public Event Event { get; set; }
    }
}