namespace Forum.Services
{
    using Forum.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Forum.Data.Models;
    using Forum.Data;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class PostService : IPostService
    {

        //Trqbva ni contet za da si suzdadem nov post
        private readonly ForumDbContext context;

        public PostService(ForumDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Post> AllPosts()
        {
            var allposts = context
                .Posts
                .Include(p => p.Author)
                .Include(p => p.Category)
                .ToList();

            return allposts;
        }

        public Post Create(Category category, string title, string content, User author)
        {
            //Suzdavame si samiq post

            Post post = new Post(title, content, category, author);
            context.Add(post);
            context.SaveChanges();

            return post;               
        }

        public void Delete(int postId)
        {
            Post post = context.Posts.SingleOrDefault( p => p.Id == postId);

            context.Posts.Remove(post);
            context.SaveChanges();
        }

        public Post getById(int id)
        {
            var post = context.Posts
                .Include(p => p.Replies)
                .Include(p => p.Author)
                .SingleOrDefault(p => p.Id == id);

                
            return post;
        }
    }
}
