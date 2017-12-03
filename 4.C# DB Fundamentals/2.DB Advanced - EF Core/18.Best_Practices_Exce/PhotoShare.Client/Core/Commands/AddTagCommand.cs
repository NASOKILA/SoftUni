namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Data;
    using Utilities;
    using System.Linq;

    public class AddTagCommand
    {
        // AddTag <tag>
        public static string Execute(string[] data)
        {
            string tagName = data[1].ValidateOrTransform();

            if (Session.User == null)
                throw new InvalidOperationException("Invalid Credentials!");


            using (PhotoShareContext context = new PhotoShareContext())
            {
                Tag tag = context.Tags.SingleOrDefault(t => t.Name == tagName);

                if (tag != null)
                    return $"Tag already exists!";

                context.Tags.Add(new Tag
                {
                    Name = tagName
                });

                
                context.SaveChanges();
            }

            return "Tag " + tagName + " was added successfully!";
        }
    }
}
