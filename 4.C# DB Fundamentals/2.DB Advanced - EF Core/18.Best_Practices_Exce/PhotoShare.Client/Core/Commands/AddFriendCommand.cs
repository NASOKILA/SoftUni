namespace PhotoShare.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class AddFriendCommand
    {
        // AddFriend <username1> <username2>
        public static string Execute(string[] data)
        {

            string username = data[1];
            string friendUsername = data[2];

            if (Session.User == null)
                throw new InvalidOperationException("Invalid Credentials!");


            using (PhotoShareContext context = new PhotoShareContext())
            {
                User user = context.Users.SingleOrDefault(u => u.Username == username);


                User friend = context.Users
                    .SingleOrDefault(u => u.Username == friendUsername);


                if (user == null)
                    throw new ArgumentException($"{username} not found!");


                if (friend == null)
                    throw new ArgumentException($"{friendUsername} not found!");


                var friendShipExists = context.Friendships
                    .SingleOrDefault(f => f.User == user && f.Friend == friend);
                

                bool alreadyAdded = user.FriendsAdded.Any(u => u.Friend == friend);

                bool accepted = friend.FriendsAdded.Any(f => f.Friend == user);
                

                if (alreadyAdded && !accepted)
                    throw new ArgumentException($"Friend request already sent!");

                if (alreadyAdded && accepted)
                    throw new ArgumentException($"{friendUsername} is already a friend to {username}");

                if (!alreadyAdded && accepted)
                    throw new ArgumentException($"{username} is already a friend to {friendUsername}!");
                

                var friendship = new Friendship()
                {
                    User = user,
                    Friend = friend
                };


                user.FriendsAdded.Add(friendship);
                context.SaveChanges();

                return $"Friend {username} added to {friendUsername}";
            }
        }
    }
}
