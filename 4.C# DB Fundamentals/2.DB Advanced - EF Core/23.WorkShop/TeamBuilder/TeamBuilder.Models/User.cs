namespace TeamBuilder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class User
    {

        public User()
        {
            this.CreatedEvents = new List<Event>();
            this.UserTeams = new List<UserTeam>();
            this.CreatedTeams = new List<Team>();
            this.ReceivedInvitations = new List<Invitation>();
        }

        public int Id { get; set; }
        
        [MinLength(3)]
        public string Username { get; set; }

        [MinLength(6)]
        public string Password { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Event> CreatedEvents { get; set; }
            
        public ICollection<UserTeam> UserTeams { get; set; }
            
        public ICollection<Team> CreatedTeams { get; set; }
        
        public ICollection<Invitation> ReceivedInvitations { get; set; }
            
    }
}



