namespace Forum.App.Commands
{
    using Forum.App.Commands.Contracts;
    using Forum.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ListPostByIdCommand : ICommand
    {
        private readonly IPostService postService;
        
        public ListPostByIdCommand(IPostService IPostService)
        {
            this.postService = IPostService;
        }

        public string Excecute(params string[] args)
        {

            int id = int.Parse(args[0]);

            var post = postService.getById(id);

            if(post == null)
            {
                return $"No such post exixsts !";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{post.Id} {post.Title} {post.Content}");

            foreach (var Reply in post.Replies)
            {
                sb.AppendLine($"-{Reply.Id} {Reply.Author.UserName} {Reply.Content}");
            }
            

            return sb.ToString();

        }
    }
}
