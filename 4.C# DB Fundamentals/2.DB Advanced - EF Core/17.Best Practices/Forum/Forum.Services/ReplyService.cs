namespace Forum.Services
{
    using Forum.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Forum.Data.Models;
    using Forum.Data;
    using System.Linq;

    public class ReplyService : IReplyService
    {
        //Trqbva ni contet za da si suzdadem nov post
        private readonly ForumDbContext context;

        public ReplyService(ForumDbContext context)
        {
            this.context = context;
        }

        public Reply CreateReply(int postId, string content, User author)
        {
            Post post = context.Posts.Find(postId);
            
            Reply reply = new Reply()
            {
                Content = content,
                Post = post,
                Author = author
            };
            
            context.Replies.Add(reply);
            context.SaveChanges();

            return reply;
        }

        public void DeleteReply(int replyId)
        {
            Reply reply = context.Replies.Find(replyId);


            context.Replies.Remove(reply);
            context.SaveChanges();
        }

        public Reply GetById(int id)
        {
            Reply reply = context.Replies
                .SingleOrDefault(p => p.Id == id);

            return reply;
        }
    }
}
