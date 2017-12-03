namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class AddTagToCommand 
    {
        // AddTagTo <albumName> <tag>
        public static string Execute(string[] args)
        {

            string albumName = args[1];
            string tagName = args[2];


            if (Session.User == null)
                throw new InvalidOperationException("Invalid Credentials!");


            using (PhotoShareContext context = new PhotoShareContext())
            {

                Album album = context.Albums.SingleOrDefault(a => a.Name == albumName);
                Tag tag = context.Tags.SingleOrDefault(t => t.Name == tagName);
                
                if (tag == null || album == null)
                    throw new ArgumentException($"Either tag or album do not exist!");
                

                AlbumTag albumTag = new AlbumTag() {
                    Album = album,
                    Tag = tag
                };


                if (context.AlbumTags.Any(at => at.Album == album && at.Tag == tag))
                    throw new ArgumentException($"Album {album.Name} already contains tag {tag.Name}!");
                


                context.AlbumTags.Add(albumTag);
                context.SaveChanges();
            }


            return $"Tag {tagName} added to {albumName}!";

        }
    }
}
