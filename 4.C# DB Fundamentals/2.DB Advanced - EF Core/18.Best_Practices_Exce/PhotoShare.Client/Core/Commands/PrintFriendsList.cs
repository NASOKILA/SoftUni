namespace PhotoShare.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;
    using System.Text;

    public class PrintFriendsListCommand 
    {
        // PrintFriendsList <username>
        public static string Execute(string[] data)
        {
            // TODO prints all friends of user with given username.

            string username = data[1];

            using (var db = new PhotoShareContext())
            {
                User user = db.Users
                    .Include(u => u.FriendsAdded)
                    .ThenInclude(f => f.Friend)
                    .SingleOrDefault(u => u.Username == username);

                if (user == null)
                    throw new ArgumentException($"User {username} not found!");

                StringBuilder sb = new StringBuilder();

                foreach (var fr in user.FriendsAdded)
                {
                    sb.AppendLine(fr.Friend.Username);
                }

                if (sb.Length == 0)
                    sb.AppendLine($"No friends for this user. :(");

                return sb.ToString();
            }
            
        }
    }
}


