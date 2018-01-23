namespace TeamBuilder.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Invitation
    {
        public Invitation()
        {
            this.IsActive = true;
        }

        public int Id { get; set; }

        public User InvitedUser { get; set; }
        public int InvitedUserId { get; set; }

        public Team Team { get; set; }
        public int TeamId { get; set; }

        public bool IsActive { get; set; }
    }
}
