namespace TeamBuilder.Client
{
    using System;
    using TeamBuilder.Client.Core;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class Application
    {
        static void Main(string[] args)
        {
            //ResetDatabase();

            Engine engine = new Engine(new Core.CommandDispatcher());
            engine.Run();
        }

        private static void ResetDatabase()
        {
            using (var db = new TeamBuilderContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

        }
    }
}
