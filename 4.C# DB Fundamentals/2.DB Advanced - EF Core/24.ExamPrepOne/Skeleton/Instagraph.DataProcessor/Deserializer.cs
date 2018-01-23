using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

using Newtonsoft.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Instagraph.Data;
using Instagraph.Models;
using System.IO;
using Instagraph.DataProcessor.DtoModels;

namespace Instagraph.DataProcessor
{
    public class Deserializer
    {

        private static string error = "Error: Invalid data.";

        //Tuk mojem da slagame DTO-ta
        public static string ImportPictures(InstagraphContext context, string jsonString)
        {

            //poluchavame masiv ot snimki kato json
            Picture[] pictures = JsonConvert
                .DeserializeObject<Picture[]>(jsonString);


            List<Picture> validPictures = new List<Picture>();

            StringBuilder sb = new StringBuilder();

            foreach (var pic in pictures)
            {
                //Putq da ne e prazen string i razmera da e > 0   //Trqbva da NE e NULL ili whitespace
                bool isValid = !String.IsNullOrWhiteSpace(pic.Path) && pic.Size > 0;
                

                //Proverqvame dali snimkata sushtestvuva v bazata ili v spisuka s validiranite snimki
                bool pictureExists = context.Pictures.Any(p => p.Path == pic.Path)
                    || validPictures.Any(p => p.Path == pic.Path);

                //Ako snimkata sushtestvuva ili e nevalidna
                if (!isValid || pictureExists)
                {
                    sb.AppendLine(error);
                    continue;
                }


                //Ako snimkata e validna q slagame v spisuka s validni snimki:
                validPictures.Add(pic);
                sb.AppendLine(String.Format($"Successfully imported Picture {pic.Path}."));

            }

            //Sega dobavqme validnite snimki kum azata:
            context.Pictures.AddRange(validPictures);
            context.SaveChanges();

            //vrushtame StringBuildera
            return sb.ToString().TrimEnd();

        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {
            //Tuk mojem da polzvame DTO koeto da sudurja username i 
            //parola na usera i putq na samata snimka !

            //poluchavame masiv ot snimki kato json
            UserDto[] usersInDto = JsonConvert
                .DeserializeObject<UserDto[]>(jsonString);


            List<User> validUsers = new List<User>();

            StringBuilder sb = new StringBuilder();

            foreach (var u in usersInDto)
            {

                bool isNotValid = String.IsNullOrWhiteSpace(u.Username) || u.Username.Length > 30
                    || String.IsNullOrWhiteSpace(u.Password) || u.Password.Length > 20
                    || String.IsNullOrWhiteSpace(u.ProfilePicture);

                //proverqvame dali usera sushtestvuva
                bool userExists = validUsers.Any(us => us.Username == u.Username && us.Password == u.Password);

                //proverqvame dali snimkata sushtestvuva
                bool pictureExistsInDb = context.Pictures.Any(p => p.Path == u.ProfilePicture);

                if (userExists || isNotValid || !pictureExistsInDb)
                {
                    sb.AppendLine(error);
                    continue;
                }

                //Vzimame si snimkata ot bazata 
                Picture picture = context.Pictures
                    .SingleOrDefault(p => p.Path == u.ProfilePicture);
                

                //pravim si usera
                User user = new User()
                {
                    Username = u.Username,
                    Password = u.Password,
                    ProfilePicture = picture
                };

                //I go dobavqme kum validiranite useri
                validUsers.Add(user);
                sb.AppendLine(String.Format($"Successfully imported User {u.Username}."));
            }



            context.Users.AddRange(validUsers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            FollowerDto[] userFollowersInDto = JsonConvert
                .DeserializeObject<FollowerDto[]>(jsonString);


            List<UserFollower> validUserFollowers = new List<UserFollower>();
            
            StringBuilder sb = new StringBuilder();

            foreach (var uf in userFollowersInDto)
            {
                bool userExists = context.Users.Any(u => u.Username == uf.User);

                bool followerExists = context.Users.Any(u => u.Username == uf.Follower);

                if (!userExists || !followerExists)
                {
                    sb.AppendLine(error);
                    continue;
                }


                User user = context.Users.SingleOrDefault(u => u.Username == uf.User);

                User follower = context.Users.SingleOrDefault(u => u.Username == uf.Follower);

                bool alreadyAFollower = validUserFollowers
                    .Any(usfo => usfo.UserId == user.Id && usfo.FollowerId == follower.Id);

                if (alreadyAFollower)
                {
                    sb.AppendLine(error);
                    continue;
                }


                UserFollower userfollower = new UserFollower()
                    {
                        FollowerId = follower.Id,
                        UserId = user.Id
                    };


                    validUserFollowers.Add(userfollower);
                    sb.AppendLine($"Successfully imported Follower {follower.Username} to User {user.Username}.");
                

            }

            context.UsersFollowers.AddRange(validUserFollowers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            XDocument xDoc = XDocument.Parse(xmlString);

            StringBuilder sb = new StringBuilder();

            List<Post> validPosts = new List<Post>();
            
            //foreachvame vsichki elementi
            foreach (var post in xDoc.Root.Elements())
            {

                string caption = post.Element("caption")?.Value;

                var userName = post.Element("user")?.Value;
                bool userExists = context.Users.Any(u => u.Username == userName);
                
                var picturePath = post.Element("picture")?.Value;
                bool pictureExists = context.Pictures.Any(p => p.Path == picturePath);


                //dali se sudurja v spisuka s validirani postove
                bool alreadyInserted = validPosts.Any(vp => vp.Caption == caption
                        && vp.Picture.Path == picturePath
                        && vp.User.Username == userName);

                if (!userExists || !pictureExists || alreadyInserted)
                {
                    sb.AppendLine(error);
                    continue;
                }

                User user = context.Users.SingleOrDefault(u => u.Username == userName);

                Picture picture = context.Pictures.SingleOrDefault(p => p.Path == picturePath);

                Post postCreate = new Post()
                {
                    Caption = caption,
                    UserId = user.Id,
                    PictureId = picture.Id
                };


                validPosts.Add(postCreate);
                sb.AppendLine($"Successfully imported Post {caption}.");
            }


            context.Posts.AddRange(validPosts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {

            XDocument xDoc = XDocument.Parse(xmlString);

            StringBuilder sb = new StringBuilder();

            List<Comment> validComments = new List<Comment>();

            foreach (var comment in xDoc.Root.Elements())
            {
                //VUPROSCHETO NAI OTZAT E MNOGO VAJNO
                string content = comment.Element("content")?.Value;

                string userName = comment.Element("user")?.Value;
                
                string postId = comment.Element("post")?.Attribute("id")?.Value;

                
                if(String.IsNullOrWhiteSpace(content) 
                    || String.IsNullOrWhiteSpace(userName)
                    || String.IsNullOrWhiteSpace(postId))
                {
                    sb.AppendLine(error);
                    continue;
                }

                bool userExists = context.Users
                    .Any(u => u.Username == userName);

                bool postExists = context.Posts
                    .Any(p => p.Id == int.Parse(postId));
                
                if(!postExists || !userExists)
                {
                    sb.AppendLine(error);
                    continue;
                }

                User user = context.Users
                    .SingleOrDefault(u => u.Username == userName);
                
                Post post = context.Posts
                    .SingleOrDefault(p => p.Id == int.Parse(postId));

                Comment commentCreated = new Comment()
                {
                    Content = content,
                    PostId = post.Id,
                    UserId = user.Id
                };

                if(validComments.Contains(commentCreated))
                {
                    sb.AppendLine(error);
                    continue;
                }
                
                validComments.Add(commentCreated);
                sb.AppendLine($"Successfully imported Comment {content}.");

            }

            context.Comments.AddRange(validComments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }
    }
}
