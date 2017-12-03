namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class UploadPictureCommand
    {
        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public static string Execute(string[] data)
        {
            string albumName = data[1];
            string pictureTitle = data[2];
            string pictureFilePath = data[3];

            using (var db = new PhotoShareContext())
            {
                Album album = db.Albums
                    .SingleOrDefault(a => a.Name == albumName);

                if (album == null)
                    throw new ArgumentException($"Album {album} not found!");

                if (Session.User == null)
                    throw new InvalidOperationException("Invalid Credentials!");

                User user = Session.User;

                Picture picture = new Picture()
                {
                    Album = album,
                    Title = pictureTitle,
                    Path = pictureFilePath
                };

                album.Pictures.Add(picture);

                db.SaveChanges();

                return $"Picture {picture.Title} added to {albumName}";

            }
        }
    }
}
