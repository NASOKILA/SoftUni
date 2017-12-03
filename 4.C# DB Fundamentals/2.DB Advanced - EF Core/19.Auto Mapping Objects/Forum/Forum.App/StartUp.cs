namespace Forum.App
{
    using AutoMapper;
    using Forum.App.Models;
    using Forum.Data;
    using Forum.Data.Models;
    using Forum.Services;
    using Forum.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            /*
            
            //Pravim si papka Models vuv Forum.app i q pulnim s DTO-ta
            //HUBAVO E DA GI KRUSHtaVAME TaKA CHE DA Se raZBIRA KUDE SHTE GI POLZVAME !

            
             VIDQHME KAK RABOTAT DBO-tata SEGA OBAHE TRQBVA DA GI NAPULNIM S Automapper


            AUTOMAPPING OBJECTS LESSION :

            AutoMapper : primerno imame obekt ot koito ni interesuva samo
                edna chast, kato go podadem na AutoMappera toi ni vrushta samo 
                tova koeto iskame.

            instalirame si paketa 'Automapper'.
            
            TRABVA DA GO Konfigurirame s :  Mapper.Initialize();
           
             */



            //SAMATO KONFIGURACIQ MOJE DA SE IZNESE V OTDELEN KLAS. KOITO DA NASLEDQVA :Profile OT using Automapping
            //I posle da go izvikame ot tuka.
            //Konfigurirame si automappera da mapva tova koeto nie iskame:
            Mapper.Initialize(conf => {

                //Tuk kazvame koe kum kakvo da se mappva:

                //Post shte mapva kum ListPostDTO
                conf.CreateMap<Post, ListPostDTO>()
                .ForMember(
                    dto => dto.ReplyCount,
                    dest => dest.MapFrom(post => post.Replies.Count));

                //AKO ISKAME PO SLOJNA KONFIGURACIQ POLZVAME .ForMember();
                // V Sluchaq mapnahme ReplyCount za ListPostDTO()
                //Kazvame kakvo mapvam ei ot kude !


                conf.CreateMap<Reply, ReplyDTO>();
                

            });




            /*
             Collection mapping:
             Mapvane n kolekcii:
	            Kogato mapvame kolekcii EF Core ni vrushta IQueryable<T> ot tip generic .
	            Automappera moje s edin metoda da ni mapne cqlata kolekciq ot neshta.
	            .projectTo<PostDto>()

	            Raboti kato avtomatichen .select()


                Otivame v ListPosts za da vidim kak stava s automapper
                Polzva se .projectTo<ImeNaDTO>()

             */


             /*
                SUMMARY:
                    1.Za da imame po malko danni koito predavame kum servera i obratno 
                    polzvame DTO, to polzva samo propertitata koito mu podadem !

                    2.Automapper ni mapva avtomatichno obektite v DTO-tata, toi raboti s dependency injection
                        Spestqva ni pisane na new(), na anonimni obekti i zaqvki kum bazata.            
            
                    3.Mogat da se mapvat i po slojni neshta

                    4.Za da napravim celiq proekt na Automapper e hubavo da polzvame Generic.
             */


            var serviceProvider = ConfigureServices();

            var engine = new Engine(serviceProvider);
            engine.Run(); 
        }

        private static IServiceProvider ConfigureServices()
        {

            //Purvo si pravim kolekciq ot servisi.
            var serviceCollection = new ServiceCollection();

            //Pri suzdavane to kazvame da ni napravi nov DbContext s tozi connectionString;
            serviceCollection.AddDbContext<ForumDbContext>(options => options
                    .UseSqlServer(@"Server=HAL\MSSQLSERVER2;Database=Forum;Integrated Security=True;"));



            serviceCollection.AddTransient<IUserService, UserService>();

            serviceCollection.AddTransient<IDatabaseInitializeService, DatabaseInitializeService>();

            serviceCollection.AddTransient<IPostService, PostService>();

            serviceCollection.AddTransient<ICategoryService, CategoryService>();

            serviceCollection.AddTransient<IReplyService, ReplyService>();
            
            
            
            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }


    }
}
