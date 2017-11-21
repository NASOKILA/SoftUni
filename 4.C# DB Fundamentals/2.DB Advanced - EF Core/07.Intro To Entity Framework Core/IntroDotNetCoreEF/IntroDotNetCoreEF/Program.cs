using IntroDotNetCoreEF.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace IntroDotNetCoreEF
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            
            Kakvo shte razgledame :
            
            1.ORM Framework - pomaga ni za rabota s bazata, rabotim s obekti
                bez da prashtame zaqvki kum bazata, to go pravi vmesto nas. 
                modelite mojem da gi pravim tam.
                Pomaga ni mnogo, pishem po malko kod, ne pishem SQL,
                Mojem da pravim CRUD bez da pishem SQL,
                Po bavno e i ne e tolkova flekxivno.
            
            2.Entity Framework Core
                Veche e STANDARTEN V .NET, nomer 7 e,
                instalirame paketi koito ni trqbvat,
                Mojem da polzvame LINQ i CRUD Operacii,
                Raboti s mnogo razionalni bazi.
                Po leko i burzo e ot predihsnoto.
                VICHKO KOETO E CORE E OPEN SOURCE, mojem da vlezem v github i da vidim smiq kod 
                NESHTATA V BAZTA STAVAT NA OBEKTI KOITO MOJEM DA POLZVAME.


            3.Database FirstModel - da ne pishem direktno zaqvki
            
            4.CRUD operacii s Entity Framework
            
            5.LINQ - znaem go
             
             */


            /* 
                ZA DA INSTALIRAME PAKETITE OTVATQME Package Manager Console  I TAM SI GI INSTALIRAME.
                TRQBVA ZADULJITELNO DA SI INSTALIRAME Entity Framework paketite:
                PISHEM V KONZOLATA: Install-Package Microsoft.EntityFrameworkCore
                KAK DA PRoVERiM DALI VSICHKO E OK ? Pishem DbContext I AKO IMAME INTELLICNCE VS E OK.

                trQBVA NI OSHTE EDIN PKET : Install-Package Microsoft.EntityFrameworkCore.SqlServer
                MOJEM DA INSTALIRAME SAMO TOZI TOI AVTOMATICHNO INSTALIRA I GORNIQ ZASHTOTO ZAVISI OT NEGO.
                    
                ZA DA VIDIM KOI PAKETI SME INSTALIRALI OTIVAME NA Manage NuGet packages
                Hubavo e da proverqvame vsichko.

                hubvo e predi da punem proekta da go buildnem za da restorne vsichi paketi !    
                s db.SaveChanges(); ni seiva v bazata.
             */


            //DA VIDIM KAK SE RABOTI S BAZI TUK.
            /*  
             Tablicite v bazata sa ni klasove.  
             Scaffold-DbContext    Vijda kakvo imame v bazata i ni pravi klasove koito da polzvame za rabota s tqh.
                S TAZI KOMANDA MOJEM DA KAJEM KAKUV NI E Connection Stringa Providera
                KOITO NI E Microsoft.EntityFrameworkCore.SqlServer
                i OutputDir KOETO OAN KUDE ISKAME DA NI SEDAT TEZI KLASOVE.
           
            
                  ZA DA GO POLZVAME TRQBVA DA INSTALIRAME SLEDNITE PAKETI:
                    Install-Package Microsoft.EntityFrameworkCore.SqlServer.Tools
                    Install-Package Microsoft.EntityFrameworkCore.SqlServer.Design
                 TE NI DAVAT DA SUZDAVAME KLASOVE.
       

            Komandata izglejda taka:
                Scaffold-DbContext -Connection "Server=HAL\MSSQLSERVER2;Database=SoftUni;Integrated Security=True;" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data/Models -Context SoftUniDbContext
            

            PRAVIM SI CONNECTION STRINGA, KAZVAME V KOQ BAZA I NA KOI SURVER SE SVURZVAME
            KOI NI E PRIVIDERA, v luchaq ni e : Microsoft.EntityFrameworkCore.SqlServer
            NAPRAVIHME SI I DVE PAPKI Data I V NEQ Models !!!


            VAJNO !!!!
            Hubavo e DbContxta da go izvedem ot papkata Models i da go slojim v papkata Data.
            Toi naslqdqva klasa DbContext.


            DO TUK MNOGO DOBRE VSICHKO RABOTI !!!!!!!!!!!!!!!!!!!!!!!!!
            Instalirahme nqkolko paketa:
                Microsoft.EntityFrameworkCore.SqlServer.Design
                Microsoft.EntityFrameworkCore.Tools
                Microsoft.EntityFrameworkCore.App


            S komandata:
                Scaffold-DbContext -Connection "Server=HAL\MSSQLSERVER2;Database=SoftUni;Integrated Security=True;" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data/Models -Context SoftUniDbContext
     

            si izkarahme dadeni klasove ot bazata tuka.
            Sega mojem da gi polzvame i manipulirame direktno ot tuk.

           
            SoftUniDbContext nasledqva klasa DbContext, TOVA E NAI VAJNOTO 
            OZN CHE MOJEM DA VZIMAME OT BAZATA !!!


            Connection stringa ni e mnogo vajen i e dobre da go skriem
            v nqkoi klas.
            Pravim si klas "Configuration"
       
             */

            /*
                SHTE SE NALOJI DA POIZCHIStiM SoftUniDbContext klasa:
                ZASHTOTO DANNITE SA 
                    KAKVO SUDURJA TOI ?
                        Ima vruzka s bazaa i entity klasove,
                        Mojem da polzvame LINQ
                        Durji cqlata konfiguraciq za nashiq model.
                        Configurira sa s etoda OnConfiguring()
                              
             */




            // IZVIKAME BAZATA, MOJEM DA PODVAME I PARAMETRI
            
            using (var db = new SoftUniDbContext()) 
            {

                //MOJE I TAKA  BEZ USING var db = new SoftUniDbContext();



                //OT context mojem da dostupvame vsichki tablici ot bazata
                //Mojem da polzvame LINQ za rabota s tannite i tablicite
                //Mojem da polzvame i CRUD operacii kum samata baza


                //Durpame vsichki employee-ta
                var employees = db.Employees
                        .Select(e => new
                        {
                            e.FirstName,
                            e.EmployeesProjects.Count
                            //Taka vzimame ot bazata samo purvoto ime i broq na proektite
                            //AVTOMATICHNO SI SUZDAVA ZAQVKA KOQTO DA PRILOJI NA BAZATA !
                        })
                        .ToList();


                var employees2 = db.Employees.
                    Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                    .OrderBy(em => em.JobTitle)
                    .GroupBy(a => a.JobTitle)
                    .ToList();   //GRUPIRAME I SEGA SHTE POLUCHIM GRUPI



                //V SQL SERVER PROFILER VIJDAME CHE NE GI GRUPIRA OT ZAQVKATA, t.e. GI GRUPIRA 
                //OT TUK ZASHTOTO .GroupBy() E LINQ FUNKCIQ

                //GRUPIRANITE DANNI SE POLZVAE TUKA:
                //Foreachvame vsqka grupa i ot vsqka edna vadim informaciqta !!!
                foreach (var group in employees2)
                {
                    //                Ime na grupa     broi na elementi
                    Console.WriteLine($"{group.Key} - {group.Count()}");

                    // Foreacvame grupata
                    foreach (var emp in group)
                    {
                        Console.WriteLine($"{emp.FirstName} {emp.LastName}");
                    }
                    Console.WriteLine();
                }


                /*KATO VLEZEM V SQL SERVER I OTIDEM NA TOOLS/SQL SERVER PROFILER MOJEM DA 
                 VIDIM KOI ZAQVKI SE IZPULNQVAT !!!


                 VAJNOOO!!!
                    Vajno e d selektirame samo tezi neshta koito ni interesuvat zashtoto lesno e
                    da vzemem celiq Employee i posle da foreachvame no ideqta tuk e da 
                    selektirame ot bazata samo tova koeto shte polzvame ZASHTOTO E PO BURZO !!!
                    MOJEM DA GLEDAME DALI ZAQVKITE SA PODREDENI !!!

                 */


                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();



                //Selektirame samo edin rabotnik:  i D APOLZVAME Include() 
                var employeeToFire = db.Employees
                    .Include(e => e.Department)     //SEGA VZIMAME I DEPARTMENT t.e. JOINVAME
                    .FirstOrDefault(e => e.EmployeeId == 1);   
                // Taka namirame po Id kudeto e 1


                //Sega veche mojem da polzvame i Departmenta i neshtata v nego
                Console.WriteLine($"{employeeToFire.FirstName} {employeeToFire.LastName} " +
                    $"from {employeeToFire.Department.Name}");






                /*
                    Sus singleOrDefault() ako imame poveche ot edin ni vrushta exception koeto e dobre  za nas !
                    Ako nqma nito edin vrushta NULL kakto FirstOrDefault();

                 */





                //Shte dobavim nov Grad,  Gradovete v bazata sa kato Spisuk v koito mojem da dobavqme !!!


                /*  DOBAVIHME GO VECHE, AKO NE GO ZAKOMENTIRAM SHTE MI DADE EXCEPTION !!!

                                var town = new Town()
                                {
                                    Name = "Gabrovo"
                                };


                                var address = new Address()
                                {
                                    AddressText = "Hristo Chernopeev 37",
                                    Town = town
                                };

                                town.Addresses.Add(address); //dobavqm si addresa kum grada
                                db.Towns.Add(town);  //Fobavqme si noviq grad 

                                db.SaveChanges();   //Seivame promenite

                                //TOVA KOETO NAPRAVIHME SE KAZVA KASKADEN INSERT t.e. INSERTVAME NQKOLKO 
                                //NESHTA NA VEDNIJ !!!

                */


                /*

                    AKO ISKAME DA IZTRIEM PISHEM : 

                    var townToRemove = db.Towns.SingleOrDefault(t => t.Name == "Gabrovo");
                    db.Remove(townToRemove);
                    db.SaveChanges();

                    */


                Console.WriteLine(); Console.WriteLine();

                // VAJNO !!!         Include()   i  ThenInclude() 
                var allTowns = db.Towns
                    .Include(t => t.Addresses)          // Vzimame adresite 
                    .ThenInclude(a => a.Employees)      // vzimame Rabotnicite
                    .OrderByDescending(t => t.Addresses.Count)
                    .ToList();

                foreach (var towN in allTowns) //Obhojdame cikula s Gradovete
                {
                    Console.WriteLine($"{towN.Name} {towN.Addresses.Count}");

                    foreach (var addr in towN.Addresses)    //Obhojdame cikula s adresite
                    {
                        Console.WriteLine($"{addr.AddressText} {addr.Employees.Count}");

                        foreach (var emp in addr.Employees)   //Obhojdame i cikula s Rabotnicite
                        {
                            Console.WriteLine($"{emp.FirstName} {emp.LastName}");
                        }
                        Console.WriteLine();

                    }

                    Console.WriteLine();
                }



                /*
                   All(),  -  Dali vsichki elementi otgovarqt na dadeno uslovie vrushta true ili false
                   Any(),  -  Dali samo edin element otgovarqt na dadeno uslovie vrushta true ili false
                   Distinct(),  -  Vrushta samo unikalnite elementi
                   Skip() i Take()  -  Mojem da skipnem nqkolko elementi i da vzemen nqkoi sled tqh 


                    KAKVO E ANONIMEN OBEKT ?
                    Tova e obekt koito ne prinadleji na nikoi klas, mojem da si pishem v nego kakvoro si poiskme
            
                    Primer:
                        var anonimousObj = new {   
                            Name = "Dont Know",
                            NumberOfLegs = 12
                        }


                    SUMMARY:
                        Poizchistihme klasovete
                        CRUD Operations: 
                            Add(), 
                            Remove() ili RemoveRange(), 
                            promenqme s  '=',   

                            VINAGI PISHEM       SaveChanges();  
                               
                    S ORM ne pishem zaqvki, te avtomatichno se generirat za nas.
                    EFCore e veche standarten za .NET 

                    Polzvame LINQ za rabota s obekti ot bazata !!!



                
                    
                */


            }


        }
    }
}
















