namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CreateAlbumCommand
    {
        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public static string Execute(string[] args)
        {
            using (var context = new PhotoShareContext())
            {
                
                string username = args[1];

                var user = context.Users.SingleOrDefault(u => u.Username == username);

                if (user == null)
                    throw new ArgumentException($"User {username} not found!");


                if (Session.User == null)
                    throw new InvalidOperationException("Invalid Credentials!");


                string albumTitle = args[2];
                var albumCheck = context.Albums.SingleOrDefault(u => u.Name == albumTitle);

                if (albumCheck != null)
                    throw new ArgumentException($"Album {albumTitle} exists!");
                

                string backgroundColor = args[3];
               
                Color color;
                
                switch (backgroundColor)
                {
                    case "White":
                        color = Color.White;
                        break;

                    case "Green":
                        color = Color.Green;
                        break;

                    case "Blue":
                        color = Color.Blue;
                        break;

                    case "Pink":
                        color = Color.Pink;
                        break;

                    case "Yellow":
                        color = Color.Yellow;
                        break;

                    case "Black":
                        color = Color.Black;
                        break;

                    case "Cyan":
                        color = Color.Cyan;
                        break;

                    case "Magenta":
                        color = Color.Magenta;
                        break;

                    case "Red":
                        color = Color.Red;
                        break;

                    case "Purple":
                        color = Color.Purple;
                        break;

                    case "WhiteBlackGradient":
                        color = Color.WhiteBlackGradient;
                        break;

                    default:
                        throw new ArgumentException($"Color {backgroundColor} not found!");

                }

                
                List<Tag> tags = new List<Tag>();

                for (int i = 4; i < args.Length; i++)
                {
                    string tagName = args[i];
                    Tag tag = context.Tags.SingleOrDefault(t => t.Name == tagName);

                    if (tag == null)
                    {
                        throw new ArgumentException($"Invalid Tags");
                    }

                    tags.Add(tag);
                }


                //suzdavame si albuma:
                Album album = new Album()
                {
                    Name = albumTitle,
                    BackgroundColor = color
                };

                

                foreach (var t in tags)
                {
                    AlbumTag albumTag = new AlbumTag();
                    albumTag.Album = album;
                    albumTag.Tag = t;
                    context.AlbumTags.Add(albumTag);
                }
                
                context.Albums.Add(album);


                AlbumRole albumRole = new AlbumRole()
                {
                    Album = album,
                    User = user,
                    Role = Role.Owner
                };

                context.AlbumRoles.Add(albumRole);
                context.SaveChanges();

                return $"Album {album.Name} successfully created!";
            }
            
        }
    }
}
