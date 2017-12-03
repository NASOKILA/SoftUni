namespace Forum.Services
{
    using Forum.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Forum.Data.Models;
    using Forum.Data;
    using System.Linq;

    public class UserService : IUserService  //Implementirame si Interfeisa koito suzdadohme za Useri
    {

        //TOZI USERSERVICE SE ZANIMAVA SAMO S USERI !!!

        //Pravim si kontexsta koito ni e vruzkata s bazata shte polzvame po nadolo
        private readonly ForumDbContext context; //Pravim go da e readOnly t.e. ne mojem da go promenqme !

        //Pravim si konstruktor koito sa ni suzdava konteksta kato go podadem i posle shte go polzvame.
        public UserService(ForumDbContext context)
        {
            this.context = context;
            //Sega kato suzdvame tozi UserService ot nqkude trqbva da mu podadem ForumDbContext
        }

        //Avtomatichno ni zaduljava da imame sushtite metodi !!!

        public User ById(int id)
        {
            //V METODITE SI PISHEM LOGIKATA : namirame useri po id i gi vrushtame.
            User user = context.Users.SingleOrDefault(u => u.Id == id);
            return user;
        }

        public User ByUsername(string userName)
        {
            User user = context.Users
                .SingleOrDefault(u => u.UserName == userName);  

            /*Ako polzvame .First() i ako imame poveche ot edin user s takuv username shte ni vzeme purviq.
             Ako polzvame .Single() to direktno tursi samo edin i ako nameri poveche ot edin ni vrushta 
             EXCEPTION koeto e dobre v sluchai che imame greshka !!!*/

            return user;
        }

        public User ByUsernameAndPassword(string username, int password)
        {

            User user = context.Users
                .SingleOrDefault(u => u.UserName == username && u.Password == password);
            
            return user;
        }

        public User Create(string username, int password)
        {
            //Suzdavame si usera, i User.cs klasa imame konstruktor koito priema samo username i parola koito shte polzvame
            var user = new User(username, password);
            
            context.Users.Add(user);
            context.SaveChanges();

            return user;
        }

        public void Delete(int id)
        {
            //namirame usera s tova Id i go triem
            var user = context.Users.Find(id);

            context.Users.Remove(user);
            context.SaveChanges();

        }
        
    }
}
