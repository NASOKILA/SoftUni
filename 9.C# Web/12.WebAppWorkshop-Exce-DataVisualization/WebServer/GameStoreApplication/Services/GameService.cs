namespace HTTPServer.GameStoreApplication.Services
{
    using Data;
    using Services.Contracts;
    using System.Linq;
    using Models;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class GameService : IGameService
    {

        private readonly GameStoreContext context;

        public GameService()
        {
            this.context = new GameStoreContext();
        }


        public Game FindGameById(int id)
        {
            return this.context.Games.FirstOrDefault(g => g.Id == id);
        }

        public List<Game> GetAllGames()
        {
            return this.context.Games.ToList();
        }

        public bool ExistsByTitle(string title)
        {
            return this.context.Games.Any(g => g.Title == title);
        }

        public void AddGameToDb(Game game)
        {
            this.context.Games.Add(game);
            this.context.SaveChanges();   
        }

        public void RemoveGameFromDb(Game game)
        { 
            this.context.Games.Remove(game);
            this.context.SaveChanges();
        }
        

        public void UpdateGame(Game game)
        {
            this.context.Update(game);
            this.context.SaveChanges();
        }
        
    }
}
