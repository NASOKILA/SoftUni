namespace TeamBuilder.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserTeam
    {
        public User User { get; set; }
        public int UserId { get; set; }

        public Team Team { get; set; }
        public int TeamId { get; set; }
    }
}
