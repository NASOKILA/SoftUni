namespace HTTPServer.GameStoreApplication.Services.Contracts
{
    using Server.Http.Contracts;
    using Models;
    using System.Collections.Generic;

    public interface IUserService
    {
        bool ExistsByEmail(string email);

        void RegisterUser(User user);

        IHttpResponse LoginUser(User user, IHttpRequest req);

        User FindUser(string email, string password);

        User GetUserById(int id);

        List<User> GetAllUsers();

        bool CheckIfLogedIn(IHttpRequest req);

        User GetCurrentUser(IHttpRequest req);
    }
}
