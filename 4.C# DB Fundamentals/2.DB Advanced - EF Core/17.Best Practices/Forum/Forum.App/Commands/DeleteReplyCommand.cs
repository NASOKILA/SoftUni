namespace Forum.App.Commands
{
    using Forum.App.Commands.Contracts;
    using Forum.Data.Models;
    using Forum.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DeleteReplyCommand : ICommand
    {
        private readonly IReplyService replyService;

        public DeleteReplyCommand(IReplyService IReplyService)
        {
            this.replyService = IReplyService;
        }
        
        public string Excecute(params string[] args)
        {
            int replyId = int.Parse(args[0]);

            Reply reply = replyService.GetById(replyId);
            if (reply == null)
                return $"There is no reply with that Id !";
                    
            

            replyService.DeleteReply(replyId);

            
            return $"Reply with Id {replyId} has been removed !";
        }
    }
}



