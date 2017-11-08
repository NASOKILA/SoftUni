using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DBAppsDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //v .NET Core Trqbva postoqnno da si importvame usingi s CTRL + . 

            // tova shte ni trqbva za vruzka kum baza 
            //Obache trqbva da mu se podade connection string
            /*Sus '.' se svurzvame kum vsichki bazi v daden surver
             sled ';' razdelqme parametri */

            var connection = new SqlConnection(
                "Server=HAL\\MSSQLSERVER2;" +
                "Database=SoftUni;" +
                "Integrated Security=True"  
                );
            /*kazahme na vseki server bazata 'SoftUni', 
              Poslednoto se pomni na izus, podrejdame go s plusove
                za da e po krasivo*/

            //VAJNO:
            //KATO RAZPUNEM 'connection' pod 'State' MOJEM DA VIDIM DALI VRUZKATA E OTVORENA 
            //Pod 'CommandText' vijdame kakva zavka shte se izpulni !
            //Pod 'CommandRimeout' vijdame za kolko vreme se izpulnqva komandate, AKO ZA > 30s ZNACHI IMA GRESHKA

            //Mojem da vidim kakuv tip e zaqvkata, kakva e konekciqta, imame parametri i dr ...
            //MOJEM DA ZAKACHAME I TRANZAKCII


            //02.Sega trqbva da otvorim vruzka sus servera i nakraq trabva da q zatvorim

            /*
             STAVA S:
            connection.Open();
            
                . . .

            connection.Close();             

            NO MOJE I PROSTO SUS 
            
            connection.Open();
            using(connection)
            {
                . . .
            }

              */



            //BEZ DA OTVORIM VRUZKATA NQMA KAK DA STANE !!!

            connection.Open();
            using (connection)
            {
                //pishem koda vutre.


                //03.Pravim si zaqvka : POLZVA SE new SqlCommand( "...", VRUZKA); 
                //Trqbva nakraq da podadem vruzkata koqto polzvame 
                var command = new SqlCommand(
                    "SELECT COUNT(*) FROM Employees", 
                    connection); //ZADULJITELNO TRQBVA DA POSTAVIM 'connection' !!!


                //04. Sega trqbva da q excecutnem: SAMOCHE IMA RAZLICHNI NACHINI ZA EXCECUTVANE
                /*
                 Imame: 
                    1.ExccuteNonQuery - NE VRUSHTa NIKAKUV REZULTAT.
                    2.ExccuteNonQueryAsync - sushtoto samoche raboti asinhronno, t.e. na mnogo nishki.

                    3.ExcecuteReader - VRUSHTA MNOGO REDOVE KOGATO GI IMAME !!!
                    4.ExcecuteReaderAsync - sushtoto samoche raboti asinhronno, t.e. na mnogo nishki.

                    5.ExcecuteScalar - VRUSHTA SAMO EDNA STOINOST  
                    6.ExcecuteScalarAsync - sushtoto samoche raboti asinhronno, t.e. na mnogo nishki.

                    7.ExcecuteXmlReader - NE ZNAM !!!
                    8.ExcecuteXmlReaderAsync - sushtoto samoche raboti asinhronno, t.e. na mnogo nishki.


                 */

                //05. Zapisvame si rezultata v promenliva koqto moje da polzvame, obache rezultata idva kato obekt !
                //ZATOVA TRQBVA DA GO KASTNEM KUM NESHTO, V SLUCHAQ V int ZASHTOTO VRUSHTA BROI!
                var allEmployees = (int)command.ExecuteScalar();


                //Sega mojem da q printirame !
                Console.WriteLine($"EmployeesCount: {allEmployees}");



                //ExecuteScalar() :
                var command2 = new SqlCommand(
                  "SELECT SUM(Salary) FROM Employees",
                  connection);

                var totalSalary = (decimal)command2.ExecuteScalar();
                Console.WriteLine($"Salary sum: {totalSalary:f2}");


                //ExecuteNonQuery() :

                string townNameToInsert = Console.ReadLine();


                var command3 = new SqlCommand(
                  $"INSERT INTO Towns(Name) VALUES('{townNameToInsert}')",
                  connection);

                
                //V SLUCHAQ DOBAVQME EDIN GRAD S IME KOETO MU PODAVAME S Console.ReadLine()
                //NO TRQBVA DA VNIMAVAME ZASHTOTO S SQL INJCTION MOJEM DA HAKVAME MNOGO NESHTA


                //tuk vrushta samo kolko reda sa afektirani, NE VRUSHTA REALEN REZULTAT OT ZAQVKA !

                var insertedRows = command3.ExecuteNonQuery();
                Console.WriteLine($"Rows affected: {insertedRows}");



                //TRANSAKCII

                var transaction = connection.BeginTransaction(); //Taka zapochvame tranzakciq !!!

                // kato napishem transaction.  I NI IZLIZAT VSICHKI METODI KOITO MOJEM DA POLZVAME !
                transaction.Rollback();

                //Kak se zakacha zakomanda ? 
                var command4 = new SqlCommand(
                  $"SELECT * FROM Towns",
                  connection, transaction);    //PROSTO Q ZAKACHAME ZA ZAQVKATA, SLED connection



                //ExcecuteReader()  TOVA NI VRUSHTA MNOGO NESHTA !!!
                    var command5 = new SqlCommand(
                        "SELECT FirstName, LastName, JobTitle FROM Employees",
                        connection
                        );

                var readerResult = command5.ExecuteReader();

                List<Person> people = new List<Person>();

                //ZA DA POKAJEM REZULTATA NI TRQBVA While() CIKUL ZASHtoto NE ZNAEM KOLKO REDA IMA VUTRE !
                while (readerResult.Read())
                {
                    // Read() e bool t.e. vrushta true ili false, AKO NQMA POVECHE ZAPISI VRUSHTA 'false' !
                    var firstName = (string)readerResult["FirstName"];
                    var lastName = (string)readerResult["LastName"];
                    var jobTitle = (string)readerResult["JobTitle"];

                    //Pravim si person obekti on informaciqta koqto ni dava zaqvkata i
                    //gi slagame v spisuk
                     
                    Person person = new Person(firstName, lastName, jobTitle);
                    people.Add(person);
                    
                }


                //Grupirame  i Podrejdame horata
                var groupedPeople = people
                                .GroupBy(p => p.JobTitle)
                                .OrderByDescending(pe => pe.Count())
                                .ToList();

                //SAMOCHE TOVA NE E NORMALEN SPISUK OT HORE, MALKO PO SLOJNO NESHTO VRUSHTA

                foreach (var group in groupedPeople)
                {
                    Console.WriteLine($"{group.Key} :");  // tova e JOB TITLE

                    foreach (var person in group)  
                    {
                        //PRINTIRAME VSEKI CHOVEK V TAQ GRUPA
                        Console.WriteLine(person); //Izvikva ovrridnatiq ToString metod!
                    }
                    Console.WriteLine();
                }


            }

            
        }
    }
}


/*MNOGO VAJNO !!! :
    kato selektirame neshto i natisnem  CTRL + R + R  MOJEM DA PROMENQME IMETO NA VSQKADE 
    KUDETO E SUSHTOTO
*/