namespace HTTPServer.GameStoreApplication.Controllers
{
    using Data;
    using Services;
    using Infrastructure;
    using Models;
    using Server.Http;
    using Server.Http.Contracts;
    using System;
    using System.Linq;

    public class HomeController : Controller
    {

        private readonly UserService userService;
        private readonly GameService gameService;

        public HomeController()
        {
            this.userService = new UserService();
            this.gameService = new GameService();
        }
        
        public IHttpResponse Index(IHttpRequest req)
        {


            var allGames = gameService.GetAllGames();

            string page = "guest";
            int currentUserId = 0;

            //IF WE ARE NOT LOGGED IN
            try
            {
                currentUserId = req.Session.Get<int>(SessionStore.CurrentUserKey);
            }
            catch (Exception)
            {
                return RenderUserHtml(allGames, page);
            }

            currentUserId = req.Session.Get<int>(SessionStore.CurrentUserKey);
            User currentUser = userService.GetUserById(currentUserId);

            //get filter
            string filter = "";
            if (req.UrlParameters.Keys.Contains("fiter"))
            {
                filter = req.UrlParameters["filter"];
            }


            //AKO FILTERA E OWNED VZIMAME SAMO TEZI IGRI KOITO NIE SME SUZDALI
            if (filter == "Owned")
            {
                allGames = gameService.GetAllGames().Where(g => g.CreatorId == currentUserId).ToList();
            }

            //AKO SME LOGNATI I SME ADMINI
            if (currentUser.IsAdmin)
            {

                int count = 0;

                string result = "";

                for (int i = 0; i < allGames.Count; i++)
                {
                    Game currentGame = allGames[i];

                    count++;

                    if (count == 1)
                    {
                        result += $@"<div class=""card-group"">";
                    }

                    string descriptionToShow = currentGame.Description.ToString();
                    if (descriptionToShow.Length > 300)
                    {
                        descriptionToShow = descriptionToShow.Substring(0, 300) + ". . .";
                    }


                    result += $@"<div class=""card col-4 thumbnail"">

                                        <img class=""card-image-top img-fluid img-thumbnail""
                                         onerror=""this.src='https://i.ytimg.com/vi/{currentGame.Trailer}/maxresdefault.jpg';""
                                         src=""{currentGame.ImageThumbnail}"">

                                    <div class=""card-body"">
                                        <h4 class=""card-title"">{currentGame.Title}</h4>
                                        <p class=""card-text""><strong>{currentGame.Price}</strong> - 60&euro;</p>
                                        <p class=""card-text""><strong>{currentGame.Size}</strong> - 62.5 GB</p>
                                        <p class=""card-text"">{descriptionToShow}</p>
                                    </div>

                                    <div class=""card-footer"">
                                        <a class=""card-button btn btn-warning"" name=""edit"" href=""/edit/{currentGame.Id}"">Edit</a>
                                        <a class=""card-button btn btn-danger"" name=""delete"" href=""/delete/{currentGame.Id}"">Delete</a>

                                        <a class=""card-button btn btn-outline-primary"" name=""info"" href=""/details/{currentGame.Id}"">Info</a>
                                        <a class=""card-button btn btn-primary"" name=""buy"" href=""/buy/{currentGame.Id}"">Buy</a>
                                    </div>

                                </div>";


                    if (count == 3 || i == allGames.Count - 1)
                    {
                        count = 0;
                        result += $@"</div>";
                    }

                }

                this.ViewData["result"] = result;

                return this.FileViewResponse(@"Home\admin-home");
            }
           

            page = "user";
            //AKO SME LOGNATI NO NE SME ADMINI
            return RenderUserHtml(allGames, page);
   
        }
        
        private IHttpResponse RenderUserHtml(System.Collections.Generic.List<Game> allGames, string page)
        {
            int count = 0;

            string resultAnonimousUser = "";

            for (int i = 0; i < allGames.Count; i++)
            {
                Game currentGame = allGames[i];

                count++;

                if (count == 1)
                {
                    resultAnonimousUser += $@"<div class=""card-group"">";
                }


                string descriptionToShow = currentGame.Description.ToString();
                if (descriptionToShow.Length > 300)
                {
                    descriptionToShow = descriptionToShow.Substring(0, 300) + ". . .";
                }

                resultAnonimousUser += $@"<div class=""card col-4 thumbnail"">

                                        <img class=""card-image-top img-fluid img-thumbnail""
                                         onerror=""this.src='https://i.ytimg.com/vi/{currentGame.Trailer}/maxresdefault.jpg';""
                                         src=""{currentGame.ImageThumbnail}"">

                                    <div class=""card-body"">
                                        <h4 class=""card-title"">{currentGame.Title}</h4>
                                        <p class=""card-text""><strong>{currentGame.Price}</strong> - 60&euro;</p>
                                        <p class=""card-text""><strong>{currentGame.Size}</strong> - 62.5 GB</p>
                                        <p class=""card-text"">{descriptionToShow}</p>
                                    </div>

                                    <div class=""card-footer"">
                                        <a class=""card-button btn btn-outline-primary"" name=""info"" href=""/details/{currentGame.Id}"">Info</a>
                                        <a class=""card-button btn btn-primary"" name=""buy"" href=""/buy/{currentGame.Id}"">Buy</a>
                                    </div>

                                </div>";


                if (count == 3 || i == allGames.Count - 1)
                {
                    count = 0;
                    resultAnonimousUser += $@"</div>";
                }

            }

            this.ViewData["result"] = resultAnonimousUser;

            return this.FileViewResponse(@"Home\"+ page +"-home");
        }
        
    }
}
