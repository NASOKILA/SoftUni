using System;

using Instagraph.Data;
using System.Collections.Generic;
using Instagraph.Models;
using System.Linq;
using Instagraph.DataProcessor.DtoModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Instagraph.DataProcessor
{
    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var posts = context.Posts
                .Include(p => p.Picture)
                .Include(p => p.User)
                .Where(p => p.Comments.Count == 0)
                .ToArray();


            List<PostsWithoutCommentsDto> postDtosList = new List<PostsWithoutCommentsDto>();

            foreach (var post in posts)
            {
                //mapvame si DTOto
                PostsWithoutCommentsDto postsWhitoutCommentsDto = new PostsWithoutCommentsDto()
                {
                    Id = post.Id,
                    Picture = post.Picture.Path,
                    User = post.User.Username
                };

                postDtosList.Add(postsWhitoutCommentsDto);

            }

            var postsToExport = JsonConvert.SerializeObject(postDtosList, Formatting.Indented);
            
            return postsToExport;
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {
            
            
            var users = context.Users
                .Where(u => u.Posts.Any(p => p.Comments
                        .Any(c => u.Followers
                            .Any(f => f.FollowerId == c.Id))))
                .OrderBy(u => u.Id)
                .Select(c => new {
                    Username = c.Username,
                    Followers = c.Followers.Count
                })
                .ToArray();
            
            //Neshto ne stawa 
            var postsToExport = JsonConvert.SerializeObject(users, Formatting.Indented);
            Console.WriteLine(postsToExport);
            return postsToExport;
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            var users = context.Users
                .Select(u => new
                {
                    Username = u.Username,
                    MostComments = u.Posts.Select(p => p.Comments.Count)
                    .ToArray()
                })
                .ToArray();

            var outputUsers = new List<UserTopCommentsDto>();

            foreach (var u in users)
            {
                int commandCount = 0;
                if (u.MostComments.Any())
                {
                    commandCount = u.MostComments.OrderByDescending(p => p).First();
                }

                var dto = new UserTopCommentsDto()
                {
                    Username = u.Username,
                    MostComments = commandCount
                };

                outputUsers.Add(dto);
            }


            XDocument xDoc = new XDocument();

            var usersElem = new XElement("users");

            foreach (var user in outputUsers.OrderByDescending(u => u.MostComments).ThenBy(u => u.Username))
            {
                var usernameElem = new XElement("Username", $"{user.Username}");

                var mostCommentsElem = new XElement("MostComments", $"{user.MostComments}");

                var userElem = new XElement("user",usernameElem, mostCommentsElem);

                usersElem.Add(userElem);
            }

            xDoc.Add(usersElem);
            string xmlString = xDoc.ToString();
           
            return xmlString;
        }
    }
}
