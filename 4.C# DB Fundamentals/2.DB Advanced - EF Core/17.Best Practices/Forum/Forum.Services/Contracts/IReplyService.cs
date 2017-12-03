namespace Forum.Services.Contracts
{
    using Forum.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IReplyService
    {
        Reply CreateReply(int postId, string content, User author);

        void DeleteReply(int replyId);

        Reply GetById(int id);
    }
}
