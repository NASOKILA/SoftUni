namespace Advanced_Querying
{
    using AdvancedQuerying.Data;
    using AdvancedQuerying.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using Z.EntityFramework.Plus;

    class StartUp
    {
        static void Main(string[] args)
        {

            /*
                
            Za kakvo hte govorim:
	            1.Mojem da pishem Chisti SQL direktno prez EFCORE chrez daden DBset.
	            2.Object State i change tracker.
	            3.Batch ili Bulk operacii.
	            4.Proceduri(Stored Procedures) v EF CORE
	            5.Concurrency: Kogato imame dve promeni, kakvo se sluchva.
	            6.Kaskadni operacii.  
             

             */


            //V NASHATa NATIVE SQL ZAQVKA trqBVA DA SE OPISVAT VSICHKI KOLONI !!!!!


            //Pravim si migraciq Initial koqto shte ni vdigne tablichkite v bazata.
            //I sled tova pishem update-database za da ni napravi samoata baza.

            
            using (var db = new EmployeesDbContext())
            {



                /*
                //dobavqme si empoyeeta  SAMO EDIN PUT OBACHE

                var employees = new[]
                {
                    new Employees() { FirstName = "Gosho", LastName = "Ivanov", Salary = 3000 },
                    new Employees() { FirstName = "Pesho", LastName = "Georgiev", Salary = 3500 },
                    new Employees() { FirstName = "Atanas", LastName = "Kambitov", Salary = 2500 }
                };
                db.Employees.AddRange(employees);

                db.SaveChanges();
                */


                //Pravim si query
                var query = @"SELECT * FROM Employees";

                var employees = db.Employees
                    .FromSql(query)  //Vzimame ot tova query
                    .ToArray();

                Console.WriteLine(employees.Length);


                //LIMITACII :    VAJNO !!!  
                /*
                   1. Na EF CORE ne mu puka za JOIN statement, toi tuka nqma da ni posluji.
                   2. Kolonite koito sa Required sa zaduljitelni za selektirane.
                   3. 

                */



                /*
                    Parametri v Native SQL zaqvki
                    Slagame placeholder i posle vmukvame danni v nego kato podadem parametur
                    na .FromSql();

                TOVA NI PREDPAZVA I OT SQL INJECTION
                 */

                var query2 = @"SELECT * FROM Employees WHERE FirstName = {0}";

                var employee = db.Employees
                    .FromSql(query2, "Atanas")  //Vtoriq parametur shte se sloji v placeholdera.
                    .ToArray();

                //TOVA NI PREDPAZVA I OT SQL INJECTION

                Console.WriteLine(employee.Length);

                /*Ako imam povehe placeholderi moga da slagam poveche parametri. */





                /*
                   Object State Tracking:

                   Obktite v EF CORE si imat Sustoqniq ( State ).
                   
                   Primerno :
                   Added,
                   Deleted, 
                   Modified,
                   Attached (tracked) -  Zakachen obekt kum DbContexta, taka mojem da rabotim s nego ,
                   Detached (untracked) -  entity oeto ne prisustva v bazata i e otkacheno ot nashiq DBContext ,
                   Unchaned.

            PRI DEBUGVANE PRIMERNO MOJEM DA GI VIDIM KATO DADEM NA OBEKTA !!!

                   RAZKACHENITE OBEKTI NE SUSHTESTVUVAT V BAZATA, SLEDOVATELNO MOJEM DA SI PRAVIM KAKVOTO SI ISKAME S TQH
                   I DA DADEM SaveChanges() nqma da stane nishto
                        
                    Razkahenite obekti ne sa iztriti.

                */

                //Kak da razkachim neshto ot bazata:
                // EntityName.State = EntityState.Detached;


                /*
                 Watches in debugging :
                    Pri debugvane mojem da slojim nqkakuv expression i da testvame rezultata pri
                    samoto debugvane.
                 */


                //AsNoTracking() GI RAZKACHA OT DBContexta i ne uchastvat v nego
                //Pravim go ako ne iskame stranichni efekti v nashiq kod.
                var employees2 = db.Employees
                      .AsNoTracking()    //Sega state-a im e detached na vsichki !!!
                      .ToArray();

                //Dannite se durjat po sushtiq nachin samoche ne uchastvat v bazata.

                //KAK VZIMAME STATE NA EDIN NQKOI OT TQH ?
                
                var firstEmployeeEntryState = db.Entry(employees2.First()).State;
                
                Console.WriteLine(firstEmployeeEntryState); //Detached
                                                            //Ako mahnem .AsNoTracking() shte ni vurne     //Unchanged

                //No mojem da gi promenqme sus:

                var employees3 = db.Employees.ToArray(); //Vzimame vsichki employees be .AsNoTracking();

                var firstEmployeeEntry = db.Entry(employees3.First()); //Vzimame samo entry-to
                firstEmployeeEntry.State = EntityState.Added; // i mu promenqme sustoqnieto

                Console.WriteLine(firstEmployeeEntry.State); //Detached




                /*
                 Kogato se ipulni dadeno queri v DbContexta vsichki propertita avtomttichno
                 se zakachat i stavat (Attached)
                 Kogato iztriem daden DbContext avtomatichno vsichki propertita se otkachat
                 i stavat (Detached).


                    S : 
                    var employees3 = db.Employees.ToArray();
                    var firstEmployeeEntry = db.Entry(employees3.First());
                    firstEmployeeEntry.State = EntityState.Added;

                 */




                /*
                   STORED PROCEDURES:
                       Kak se izpulnqvat proceduri ot EF CORE.    
                       DA KAJEM CHE VECHE Q IMAME NAPRAVENA, NAPRAVIHME SI 
                            usp_UpdateSalary(@Id int, @Amount decimal(18,2)
                */

                //Sega q izpulnqvame ot tuk
                var execProcedure = @"EXEC usp_UpdateSalary {0}, {1};"; //Mojem i bez placeholderi
                var result = db.Database.ExecuteSqlCommand(execProcedure, 1, 2); //Mojem i bez placeholderi

                //Mahnahme 200 lv ot zaplatata na employee s Id 1
                Employee studentWithIdOneAndWithIncreasedSalary = db.Employees
                    .Where(e => e.Id == 1)
                    .FirstOrDefault();


                Console.WriteLine($"Name: {studentWithIdOneAndWithIncreasedSalary.FirstName} {studentWithIdOneAndWithIncreasedSalary.LastName}  -  Salary: {studentWithIdOneAndWithIncreasedSalary.Salary}");




                /*     
                   Bulk Operacii:

                       EF CORE ne poddurja Bulk Operacii.
                       TRQBVA DA POLZVAME BIBLIOTEKATA 'Z.EntityFramework.Plus.EFCore' T.E.TRQBVA DA SI INSTALIRAME PAKETA.

                       Bulk operacii oznachava da promenqme o mnogo neshta na vednuj v edna baza
                       ili da listvame po mnogo neshta na vdnuj.
                       
                       Primerno iskame da updeitnem zalatite na vsichki entitita.
                       Ili da gi iztriem ili da insertnem danni v mnogo tablici na vednuj

                       Imame :
                           1.Bulk Insert
                           2.Bulk Delete
                           3.Bulk Update
                           4.Bulk Merge     

                */

                //Primerno iskame da iztriem vsichki rabotnici s niski zaplati ot 2500 lv
                
                db.Employees.Where(e => e.Salary < 2500)
                    .Delete(); //Za tozi delete()  polzvame: using Z.EntityFramework.Plus;

                //Iztrihme gi ot bazata bez da sme gi durpali.
                //TOVA BESHE BULK DELETE OPERACIQ.





                //BULK UPDATE  
                //Sega primerno iskame da im updeitnem zaplatite

                /*
                  db
                    .Employees
                    .Where(e => e.Salary < 2500)
                    .Update(e => new Employee() { e.Salary = (e.Salary + 100) });


                db.SaveChanges();
                */
                //NESHTO DAVA EXCEPTION NO MOJE I DA GI UPDEITNEM BEX .Update() !!!




                /*
                 TYPES OF LOADING(tipove zarejdaniq):
                    1.Lazi loading  -  TOVA V DAZITE OZNACHAVA DA DURPAME NESHTATA KOITO NI TRQBVAT V MOMENTA NA 
                        POLZVANETO IM, POLZVA PO MALKO RAM PAMET, ZA DADENI SITUACII E PO DOBRE DA SE POLZVA.  
                        OSHTE GO NQMA V EF CORE !
                        
                    2.Explicit loading  -  TOVA GO POLZVAHME DO SEGA, OZN CHE DURPAME VSICHKATA INFORMACIQ 
                        KOQTO NI TRQBVA SEGA, TOVA STAVA V MOMENTA NA IZPULNENIE NA ZAQVKATA.
                        TOVA STAVA KATO POLZVAME .Inlude() i .ThenInclude() ili sus anonimni obekti !!!

                    3.Eager loading  -  


                    Zarejdaneto oznachava nie da durpame neshto ot bazata i to da idva pri nas.
                    Ne e hubavo da durpame vichki danni ako ne ni trqbvat.
            
                 */

            
            }


            /*
                CONCURRENCY CHECKS:
                    Tova e kogato mnogo ustroistva (tabletiili telefoni primerno) dostupvat edna baza 
                    ednovremenno.
                    V nai loshiq sluchai ednoto ustroistvo prezapisva dannite na drugoto.
             
                V SQL se polzvat Tranzakcii

                V EF CORE NQmame tranzakcii zatova PECHELI POSLEDNIQ CONTEXT KOITO SE IZPULNI. 
             
             */


            //MOJEM DA POLZVAME POVECHE OT EDIN KONTEXT:
            //PECHELI POLEDNIQ KONTEXT KOITO SE IZPULNI !!!

            /*       

                   var context1 = new EmployeesDbContext();
                   var context2 = new EmployeesDbContext();

                   var empFromContext1 = context1.Employees.Find(2); //vzimame vtoriq rabotni
                   var empFromContext2 = context2.Employees.Find(2); //pak vzimame vtoriq rabotni

                   empFromContext1.Salary = 1200;
                   empFromContext2.Salary = 1600;

                   context1.SaveChanges();
                   context2.SaveChanges();
           */


            //PECHELI POSLEDNIQ KOITO SE IZPULNQVA T.E. Zaplatata shte bude 15000
            /*
             Tova mojem da go promenim kato slojim anotaciqta [ConcurrencyCheck]
             vurhu propertito koeto iskame da polzvame.
             Sega ako imame dva kontexta koito da Rabotat s edno property trqbva da se 
             ni hvurli exception.
             
            */




            /*
               Cascadno Iztrivane:
                    KASKADNOTO IZTRIVANE E PUSNATO PO DEFAULT.
                   Mnogo e lesno, ako imame user i toi si ima nqkakvi postove v nqkakuv blok,
                   pri iztrivane na usera nie triem i negovite postove. 

               PUSKAME GO PRI SUZDAVANETO NA VRUZKItE MEJDU TABLICITE KATO NAPISHEM:
                   .OnDelete(DeleteBehaviour.Cascade);

               AKO GO NQMAME .OnDelete(DeleteBehaviour.Cascade); PRI IZTRIVANETO NI HVURLQ EXCEPTION.
               I V TAKUV SLUCHAI ILI SETVAME KLUCHA NA NULLABLE s int? NameOfKey ...  ILI 
               POLZVAME .OnDelete(true) vuv FLUENT API;


                Ako imame NULLABLE FK i .OnDelete(DeleteBehaviour.Cascade); pak shte iztrie vsichko
                po verigata.    

                Ako imame samo NULLABLE FK znachi klucha shte ostane null.


                Imame si razlichni metodi kato DeleteBehaviour:
                .DeleteBehaviour.Cascade; - Pozvolqva triene na related entityes.
                .DeleteBehaviour.Restrict; - Pri opit na kaskadno iztrivane da hvurlq exception 
                .DeleteBehaviour.ClientSetNull  -  vmesto da trie na related entityes, pravi gi da sa sus stoinost NULL; 
                .DeleteBehaviour.SetNull  -  Sushtoto kato gornoto samoche setva i FK kluchovete na NULL.

                KASKADNOTO IZTRIVANE E PUSNATO PO DEFAULT.

         */

            /*
             SUMMARY:
                 1. Mojem da prashtame NATIVE SQL zaqvki kum bazata.
                 2. Vidqhme che modelite si imat sustoqnie i
                 3. Concurrency Checks - sistemata na izpulnenie kogato imame > 1 DbContext i nqkolko ustroistva koito 
                        da polzvat edina i sushta baza po edno i sushto vreme !!!     
                 4. Bulk Operations - mojem da pravim delete, insert, update na dannite v bazata bez da gi durpame ot neq.
                 5. Cascadnite Operacii, pusnati sa po default. 


             */




        }
    }
}

















