using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forum.Data.Models
{
    public class User
    {

        public User()
        {
            //Prazen, chrez nego trqbva sa slojim vsichki propertita
        }

        //Pravim si i takuv konstruktor za po lesno, sega mojem samo da napishem UserName i Password
        //i taka shte si suzdadem nov User obekt.
        public User(string username, int password)
        {
            this.UserName = username;
            this.Password = password;
        }


        //Tuk shte imame propertita koito shte otgovarqt na koloni v baza.

        [Key]       //Tova e anotaciq  
        public int Id { get; set; }  //Tova mu e primary key
        public string UserName { get; set; }
        public int Password { get; set; }

        //Tova sa vsichki postove ZA TOZI USER mojem da gi drupnem i da gi foreachvame primerno !
        //Tova sa ni postovete NO OSHTE GI NQMAME
        public ICollection<Post> Posts { get; set; } = new List<Post>();

        //Inicializirame si kolekciite, DOBRA PRAKTIKA E, SEGA NA USERITE DIREKTNO MOJEM DA IM DOBAVQME POSTOVE I REPLIES

        public ICollection<Reply> Replies { get; set; } = new List<Reply>(); 
        //Po princip bi trqbvalo da gi keshirame.

    }
}
