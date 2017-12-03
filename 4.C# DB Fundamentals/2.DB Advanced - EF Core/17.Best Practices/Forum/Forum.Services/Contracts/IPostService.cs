namespace Forum.Services.Contracts
{
    using Forum.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IPostService
    {
        Post Create(Category categoryName, string title, string content, User author);

        IEnumerable<Post> AllPosts();

        Post getById(int id);

        void Delete(int postId);

    }
}
