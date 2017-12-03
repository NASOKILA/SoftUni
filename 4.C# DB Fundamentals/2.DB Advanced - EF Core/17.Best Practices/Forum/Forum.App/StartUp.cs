namespace Forum.App
{
    using Forum.Data;
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
              
             Pravim si novi proekti vmesto papkite Data i Models,
             Pravim si i nor Forum.App proekt, V .Data si instalirame paketita na ED CORE OBACHE 
             V MODELS NQMA DA INSTALIRAME NIKAKVI PAKETI NAROCHNO
             na vseki edin proekt, dobavqme si referenciite i nakraq buildvame.
             
             NQMA DA POLZVAME EFCORE ZA TAZI LEKCIQ, SHTE POLZVAME SERVICES.


             Taka kato vsichko e razcepeno e nezavisimo i moje da se polzva i 
             ot drugi proekti.
             */


            /*
            SEGA NQMA DA POLZVAME EFCORE ZASHTOTO ISKAME NASHETO PRILOJENIE DA MOJE DA RABOTI
            S NQKAKVA FUNKCIONALNOST VMESTO SAMO S BAZATA NI, 
            ZATOVA SHTE POLZVAME Services.
            V Forum.App NQMAME NIKAKVI PAKETI INSTALIRANI.

            CELTA E DA NE RABOTIM DIREKTNO S BAZATA KOQTO E V Forum.Data A DA POLZVAME Forum.Services
            KOITO SHTE POLZVA BAZATA.
            ZATOVA V Forum.App NE REFERIRAME Forum.Data A SAMO Forum.Models i Forum.Services


           SUZDAVAME SI .StartUp ili .Client PROEKT KOITO SHTE SE POLZVA OT USERA I NQMA DA IMA FUNKCIONALNOST VUTRE V NEGO,
           TOI SHTE REFERIRA KUM TOVA KOETO SHTE POLZVA.

            */


            /* 
               Design Patterns:  PO LESNO RESHAVANE NA PROBLEMI !!!
                   Tova e nachin za reshavane na problem koito vuznikva postoqnno !

               01.SingleTon  -  Osigurqva che edin klas shte ima samo edna instanciq ot nego i ima
                   samo edin globalen obekt, t.e. mojem da go dostupvame ot vsqkude.

               02.Service Locator  -  Pak ima edna globalna tochka za dostup i moje da namira nashite servisi 
                   (klasove  funkcionalnost)

               03.Command  -  Pozvolqva da imame mnogo klasove s edin metod excecute i vrushat nqkakuv rezultat.



               01.Service Locator  -  Nashata aplikaciq new se dopitva direktno do servicite a do Service Locatora koito
                   se dopitva do servicite, MOJEM DA DOBAVQME SERVISI I DA GI DOSTUPVAME OT SERVICE LOCATORA.

                


            Pravim si Forum.Services v koito si pravim papka Contracts v koqto shte si slojim vsichki interfeisi.
            Shte imame nqkolko interfeisi za vseki service koito shte polzvame.
            
            KAKVO E INTERFEIS ?
            
            */

            //KONFIGURIRAME SI SERVISITE I GI PODAVAME NA ENGINA KOITO SHTE RABOTI S TEH.

            

            //ZA dA SI INStaNCIRAME DADEN Service NI TRQBVA serviceProvider.
            var serviceProvider = ConfigureServices();

            //suzdavame nov engine kato mu podadem providera i posle puskame metoda .Run();
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



            //Dobavqme si i vsichki interfeisi ZADULJITELNO INACHE NE MOJEM DA GI POLZVAME !
            serviceCollection.AddTransient<IUserService, UserService>();

            serviceCollection.AddTransient<IDatabaseInitializeService, DatabaseInitializeService>();

            serviceCollection.AddTransient<IPostService, PostService>();

            serviceCollection.AddTransient<ICategoryService, CategoryService>();

            serviceCollection.AddTransient<IReplyService, ReplyService>();
            
            
            
            //Suzdavame si serviceProvidera i go vrushtame
            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }


    }
}
