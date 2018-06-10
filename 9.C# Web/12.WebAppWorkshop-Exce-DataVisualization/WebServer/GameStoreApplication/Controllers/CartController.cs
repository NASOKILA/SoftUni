namespace HTTPServer.GameStoreApplication.Controllers
{
    using HTTPServer.GameStoreApplication.Infrastructure;
    using HTTPServer.GameStoreApplication.Models;
    using HTTPServer.GameStoreApplication.Services;
    using HTTPServer.Server.Http.Contracts;
    using HTTPServer.Server.Http.Response;
    using System.Collections.Generic;
    
    public class CartController : Controller
    {
        private readonly UserService userService;
        private readonly GameService gameService;

        private HashSet<Game> cart { get; set; }

        public CartController(UserService userService, GameService gameService, HashSet<Game> cart)
        {
            this.cart = cart;
            this.userService = userService;
            this.gameService = gameService;
        }


        public IHttpResponse ShowCart(IHttpRequest req)
        {

            string result = string.Empty;

            decimal totalPrice = 0;

            foreach (Game game in this.cart)
            {
                totalPrice += game.Price;
                result += $@"<div class=""list-group-item"">
                                <div class=""media"">
                                <a class=""btn btn-outline-danger btn-lg align-self-center mr-3"" href=""/removeFromCart/{game.Id}"">X</a>
                                <img class=""d-flex mr-4 align-self-center img-thumbnail"" height=""127"" src=""{game.ImageThumbnail}""
                                    width=""227"" alt=""Generic placeholder image"">
                                <div class=""media-body align-self-center"">
                                    <a href = ""/details/{game.Id}"">
                                        <h4 class=""mb-1 list-group-item-heading"">{game.Title}</h4>
                                    </a>
                                    <p>{game.Description.Substring(0, 100) + ". . ."}</p>
                                </div>
                                <div class=""col-md-2 text-center align-self-center mr-auto"">
                                    <h2>{game.Price}&euro; </h2>
                                </div>
                            </div>
                        </div>";
            }

            this.ViewData["result"] = result;
            this.ViewData["totalPrice"] = totalPrice.ToString();


            bool loggedIn = userService.CheckIfLogedIn(req);
            if (loggedIn)
            {
                User user = userService.GetCurrentUser(req);

                if (user.IsAdmin)
                    return this.FileViewResponse(@"Cart\cartAdmin");


                return this.FileViewResponse(@"Cart\cartLoggedIn");
            }

            return this.FileViewResponse(@"Cart\cart");
        }

        public IHttpResponse FinishOrder(IHttpRequest req)
        {
            

            bool loggedIn = userService.CheckIfLogedIn(req);

            if (!loggedIn)
            {
                return new RedirectResponse(@"\login");
            }


            if (this.cart.Count < 1)
            {
                return new RedirectResponse(@"\cart");
            }


            User currentUser = userService.GetCurrentUser(req);

            this.ViewData["gamesCount"] = this.cart.Count.ToString();
            
            this.cart.Clear();
            
            if(currentUser.IsAdmin)
                return this.FileViewResponse(@"Cart\orderCompletedAdmin");
            else
                return this.FileViewResponse(@"Cart\orderCompleted");
        }

        public IHttpResponse StoreGameInCart(IHttpRequest req)
        {

            int gameid = int.Parse(req.UrlParameters["id"]);

            Game game = gameService.FindGameById(gameid);
            
            this.cart.Add(game);
            
            return new RedirectResponse(@"/cart");
        }

        public IHttpResponse RemoveFromCart(IHttpRequest req)
        {

            int gameid = int.Parse(req.UrlParameters["id"]);
            Game game = gameService.FindGameById(gameid);

            this.cart.Remove(game);

            return new RedirectResponse(@"/cart");
        }

    }
}
