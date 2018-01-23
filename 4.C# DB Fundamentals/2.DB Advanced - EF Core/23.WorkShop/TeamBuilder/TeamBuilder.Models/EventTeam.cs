namespace TeamBuilder.Models
{

    public class EventTeam
    {
        public Event Event { get; set; }
        public int EventId { get; set; }

        public Team Team { get; set; }
        public int TeamId { get; set; }
    }
}
