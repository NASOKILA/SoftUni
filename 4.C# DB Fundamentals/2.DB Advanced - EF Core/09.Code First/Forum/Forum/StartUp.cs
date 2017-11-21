using forum.data.models;
using Forum.Data;
using Forum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Forum
{
    // Pravim go public
    public class Program
    {
        static void Main(string[] args)
        {



            /*
             
            PURVO TRQBVA DA SI INSTALIRAE .NetCore PAKETITE:
                Install-Package Microsoft.EntityFrameworkCore.SqlServer
                Install-Package Microsoft.EntityFrameworkCore.Tools

            database firt suzdava modelite po veche sushtestvuvashta baza.
            Code-forst e obratnoto na database first, nie vzimame definirani klasove 
            koito sme suzdali i gi prevrushtame v tablici.
            Ne e tolkova avtomatichno trqbva da mu pomagame.
            Kazvame mu koe kakva relaciq trqbva da ima, dali e one to one, 
            one to many ili many to many.

            V code first pishem po malko kod.
            Suzdavame si obekti bez nujda da konfigurirame bzata.

            SHTE POLZVAME ANOTACII KATO [Key], [Required] ...  !

            Za code first moela ni trqbvat klasove ot koito da durpame danni.
            Klasovete sa normalni samoche imame NAVIGACIONNO PROPERTY koeto e 
            property ot DTUG KLAS koito ni e vruzkata s druga tablica.
            Tova navigacionno property si ima Id.

            Shte polzvame klass library, tova e otdelen proekt koito sudurja smo klasove.

            Shte napravim prilojenie koeto da ima username, parola i postove.
            vseki post si ima kategoriq vruzkata im e ManyToMany 
            Posta si ima Title, Content, author i Replies(otgovori).
                
            Imame Replyes v koito mojem samo da ishem nqkakuv text, t.e. imae samo
            Content i Author.

            Shte mojem da se Registrirame, da suzdavame postove i otgovori, da
            listvame vsichki postove daje i po kategorii.


            Pravim si papka data i v neq models za da ni durji klasovete koito shte napravim.
            DbContexta shte e v papka Data.

            Zapochvame s Entity Klasovete

             */


            /*
             KAK DA SI BUILDNEM BAZATA I DA SLOJIM TABLICITE VUTRE ?

             Predi tqh trqbva da si buildnem bzata inache ne mojem da 
             polzvame CRUD operacii.
            
             01.TRQBVA DA SA NI INSTALIRANI PAKETITE: 
                Microsoft.EntityFrameworkCore.SqlServer;
                
             02.Trqbva ni connection Stringa svurzan s SqlServer
            
             03.Trqbva da si napravim vsichki relacii v OnModelCreating(ModelBuilder modelBuilder) metoda 
             
             04. Instalirame si paketa MicrosoftEntityFrameworkCore.tools 
            
             05.Za da dobavim i tablicite trqbva da pusnem migracii, sus komanata 
                Add-Migration ImeNaMigraciq
                TOVA NI SUZDAVA NQKOLKO KLASA V EDNA PAPKA Migration KOITO NI DOBAVQT TABLICITE KOITO SUZDADOHME !

                S Remove-Migration mahame Migraciite !    

             06.PISHEM V KONZOLATA 'update-database' TOVA UPDEITVA BAZATA NO AKO Q NQMA NI Q VDIGA SUZDAVA.
                s 'drop-database' MOJEM DA DROPNEM BAZATA

            SEGA VECHE SI VIJDAME TABLICITE V BAZATA.
            Imame i tablica Migration-History i v neq ima vsichki migracii i na koq versiq na EFCORE sa suzdadeni.
             
             
             */

            //IZTRIVANETO NA TABLICI V EFCORE E KASKADNO !

            /*
                CRUD OPERACII:
                    Predi tqh trqbva da si buildnem bzata inache ne mojem 
                    da polzvame CRUD operacii.
             */



            var context = new ForumDbContext();


            /*SHTE NAPRAVIM TAKA CHE VSEKI PUT KATO RUNNEM PROGRAMATA DA
             NI SE DROPVA BAZATA I DA SE SUZDAVA NA NOVA VKARVAIKI TEZI USERI.*/

            //Suzdavame si vutre konstext s metod vutre koito da go pravi tova !
            ResetDatabase(context);


            //Za vsqka kategoriq si vzimame postovete s avtorite im !
            /*
            var categories = context.Categories
                .Include(c => c.Posts)
                .ThenInclude(p => p.Author)
                .Include(c => c.Posts)
                .ThenInclude(p => p.Replies)
                .ThenInclude(p => p.Author)
                .ToArray();
            */

            //Po dobre e obache da polzvame anonimni obekti zashtoto ne natovarvame tolkova sistmata !

            var categories = context.Categories
                .Select(c => new {

                    //TOVA E NASHIQ ANONIMEN OBEKT TRQBVA DA DAVAME IMENA NA NESHTATA KOITO SELEKTIRAME !!!
                    //PLUS TOVA E PO BURZO !!!
                    CategoryName = c.Name,
                    Posts = c.Posts.Select(p => new {

                        //vzimame si ot Posts
                        PostTitle = p.Title,
                        PostContent = p.Content,
                        PostAuthor = p.Author,
                        PostReplies = p.Replies.Select(r => new {

                            //vzimame si ot Replies
                            ReplyAuthor = r.Author,
                            ReplYContent = r.Content
                        })
                    })
                });

            foreach (var category in categories)
            {
                Console.WriteLine($"Category: {category.CategoryName} Posts Count: {category.Posts.Count()}");

                //Vzimame postovete
                foreach (var post in category.Posts)
                {
                    Console.WriteLine($"--Post Title: {post.PostTitle}: {post.PostContent}");
                    Console.WriteLine($"--by Author Name :{post.PostAuthor.UserName}");

                    //Vzimame replies
                    foreach (var reply in post.PostReplies)
                    {
                        Console.WriteLine($"----Reply: {reply.ReplYContent} from {reply.ReplyAuthor.UserName}");
                    }

                }
            }




            



        }


        private static void ResetDatabase(ForumDbContext context)
        {
            context.Database.EnsureDeleted();  //AKO IMA BAZA DA Q IZTRIE !

            //context.Database.EnsureDeleted();  //AKO NQMA BAZA Q SUZDAI OBACHE NAMQ DA IMA MIGRACII!

            //Zatova polzvame:
            context.Database.Migrate();


            //Nakraq siidvame dannite chrez metod koito vzima userite i gi vmukva
            Seed(context);

        }

        private static void Seed(ForumDbContext context)
        {

            var users = new[]   //Users NI E MASIV OT Useri
            {
                //Dobavqme si userite izpolzvaiki dvoiniq konstruktor
                new User("Nasko", 111),
                new User("Asi", 222),
                new User("Toni", 333),
                new User("Toshko", 444),

            };

            //Sega trqbva da gi insertnem v bazata :
            context.AddRange(users);
            

            //Sled Userite dobavqme i Nqkakvi kategorii:
            var categories = new[]
            {
                //Polzvame edinichniq konstruktor
                new Category("C#"),
                new Category("Support"),
                new Category("SQL"),
                new Category("Front-End")
            };

            

            var posts = new[]
            {
                //Polzvame napraveniq konstruktor
                new Post("C# Rules", "Vqrno", categories[0], users[0]),
                new Post("Support Rules", "Pak Vqrno", categories[1], users[1]),
                new Post("SQL Rules", "Mnogo Vqrno", categories[2], users[2]),
                new Post("Front-End Rules", "Oshte po Vqrno", categories[3], users[3]),
            };

            context.Posts.AddRange(posts);

            //Pravim si i Nqkolko Replies n Postovete.

            var replies = new[]
            {
                //Polzvame napraveniq konstruktor
                new Reply("Not the best!", posts[0], users[0]),
                new Reply("Not goot at all", posts[1], users[1]),
                new Reply("Very good", posts[2], users[2])

            };

            context.Relies.AddRange(replies);



            /*
            //Slagame si danni i v Tags
            var tags = new[]
            {
                new Tag {Name = "Tag C#"},
                new Tag {Name = "Tag Praise"},
                new Tag {Name = "Tag Programming"},
                new Tag {Name = "Tag Microsoft"},
            };
            context.Tags.AddRange(tags);

            //Slagame si danni i v PostTags
            var postTags = new[]
            {
                new PostTags {PostId = 1, TagId = 2},
                new PostTags {PostId = 2, TagId = 2},
                new PostTags {PostId = 1, TagId = 1},
            };
            context.PostTags.AddRange(postTags);
            */
            //NAKRAQ VECHE SLED VSICHKO PISHEM SaveChanges();
            context.SaveChanges();

            
            /*
                NESHTO NAKRAQ GO SCHUPIH !!!
             */



        }
    }
}


    /*
        SUMMARY:
            S Code-First mojem da si buildvame baza.
            S Klasovete predstavqme Tablicite.
            Mojem da pravim vruzki mejdu tablicite.
            S Migraciite mojem da updeitvame bazata si bez da gubim dannite ot neq.
                MIGRACIITE SA SHIT !!!

     */






