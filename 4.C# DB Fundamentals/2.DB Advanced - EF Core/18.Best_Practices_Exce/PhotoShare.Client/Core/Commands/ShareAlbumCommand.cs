namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public static class ShareAlbumCommand
    {

        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public static string Execute(string[] args)
        {

            int albumId = int.Parse(args[1]);
            string username = args[2];
            string permission = args[3];

            if (permission != "Owner" && permission != "Viewer")
                throw new ArgumentException($"Permission must be either “Owner” or “Viewer”!");
           
            using (var db = new PhotoShareContext())
            {

                Album album = db.Albums
                    .SingleOrDefault(a => a.Id == albumId);

                User user = db.Users
                    .SingleOrDefault(u => u.Username == username);


                if (album == null)
                    throw new ArgumentException($"User {username} not found!");


                if (user == null)
                    throw new ArgumentException($"Album {albumId} not found!");


                if (Session.User == null)
                    throw new InvalidOperationException("Invalid Credentials!");


                if (permission == "Owner")
                {
                    AlbumRole albumRole = new AlbumRole()
                    {
                        User = user,
                        Album = album,
                        Role = Role.Owner
                    };

                    db.AlbumRoles.Add(albumRole);

                }
                else if (permission == "Viewer")
                {
                    AlbumRole albumRole = new AlbumRole()
                    {
                        User = user,
                        Album = album,
                        Role = Role.Viewer
                    };

                    db.AlbumRoles.Add(albumRole);

                }

                db.SaveChanges();

                return $"Username {username} added to album {album.Name} ({permission})";
            }
            
        }
    }
}








