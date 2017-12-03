namespace Forum.App.Commands
{
    using Forum.App.Commands.Contracts;
    using Forum.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DeletePostCommand : ICommand
    {

        private readonly IPostService postService;

        public DeletePostCommand(IPostService IPostService)
        {
            this.postService = IPostService;
        }

        public string Excecute(params string[] args)
        {

            int postId = int.Parse(args[0]);

            if (postService.getById(postId) == null)
                return $"No such post exists!";

            postService.Delete(postId);

            return $"Post with id {postId} successfully deleted !";

        }
    }
}
