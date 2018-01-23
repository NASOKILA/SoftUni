namespace TeamBuilder.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
   
    public class Team
    {
        public Team()
        {
            this.EventTeams = new List<EventTeam>();
            this.Invitations = new List<Invitation>();
            this.UserTeams = new List<UserTeam>();
        }

        public int Id { get; set; }

        [MaxLength(25)]
        public string Name { get; set; }

        [MaxLength(32)]
        public string Description { get; set; }
        
        [StringLength(3)]
        public string Acronym { get; set; }

        public User Creator { get; set; }
        public int CreatorId { get; set; }

        public ICollection<EventTeam> EventTeams { get; set; }

        public ICollection<UserTeam> UserTeams { get; set; }

        public ICollection<Invitation> Invitations { get; set; }

    }
}
