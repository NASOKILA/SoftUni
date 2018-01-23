namespace TeamBuilder.Client.Utilities
{
    using System.Linq;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class CommandHelper
    {

        public static bool IsTeamExisting(string teamName)
        {
            using (var db = new TeamBuilderContext())
            {
                return db.Teams.Any(t => t.Name == teamName);
            }
        }

        public static bool IsUserExisting(string username)
        {
            using (var db = new TeamBuilderContext())
            {
                return db.Users.Any(u => u.Username == username
                    && u.IsDeleted == false);
            }
        }

        public static bool IsInviteExisting(string teamName, User user)
        {
            using (var db = new TeamBuilderContext())
            {
                return db.Invitations.Any(i => i.Team.Name == teamName
                    && i.InvitedUserId == user.Id
                    && i.IsActive == true);
            }

        }

        public static bool IsUserCreatorOfTeam(string teamName, User user)
        {
            using (var db = new TeamBuilderContext())
            {
                return db.Teams.Single(t => t.Name == teamName)
                    .Creator.Id == user.Id;
            }

        }

        public static bool IsUserCreatorOfEvent(string eventName, User user)
        {
            using (var db = new TeamBuilderContext())
            {
                return db.Events.Single(t => t.Name == eventName)
                    .Creator.Id == user.Id;
            }

        }

        public static bool IsMemberOfTeam(string teamName, string username)
        {
            using (var db = new TeamBuilderContext())
            {
                return db.Teams.Single(t => t.Name == teamName)
                    .UserTeams.Any(ut => ut.User.Username == username);
            }

        }

        public static bool IsEventExisting(string eventName)
        {
            using (var db = new TeamBuilderContext())
            {
                return db.Events.Any(e => e.Name == eventName);
            }
        }
        
    }
}
