namespace Forum.App.Commands
{
    using Forum.App.Commands.Contracts;
    using Forum.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ListPostsCommand : ICommand
    {
        private readonly IPostService postService;

        public ListPostsCommand(IPostService IPostService, ICategoryService ICategoryService)
        {
            this.postService = IPostService;
        }

        public string Excecute(params string[] args)
        {

            var allPosts = postService.AllPosts()
                .GroupBy(p => p.Category)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var group in allPosts)
            {
                sb.AppendLine(group.Key.Name + ":");
                foreach (var post in group)
                {
                   sb.AppendLine($"-{post.Id} {post.Title} {post.Content} by {post.Author.UserName}");
                }

            }

            return sb.ToString();
        }
    }
}
