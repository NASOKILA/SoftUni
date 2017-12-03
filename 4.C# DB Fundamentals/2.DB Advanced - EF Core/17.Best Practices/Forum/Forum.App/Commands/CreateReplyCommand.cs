namespace Forum.App.Commands
{
    using Forum.App.Commands.Contracts;
    using Forum.Data.Models;
    using Forum.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CreateReplyCommand : ICommand
    {

        private readonly IPostService postService;
        private readonly IReplyService replyService;

        public CreateReplyCommand(IPostService IPostService, IReplyService IReplyService)
        {
            this.postService = IPostService;
            this.replyService = IReplyService;
        }

        public string Excecute(params string[] args)
        {
            

            int postId = int.Parse(args[0]);
            string content = args[1];

            //Usera trqbva da e lognat za da suzdava replies
            if (Session.User == null)
                return "You are not logged in so you cannot create replies.";

            User author = Session.User;

            Reply reply = replyService.CreateReply(postId, content, author);
            
            return $"Reply with id {reply.Id} successfully created!";

        }
    }
}
