using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IntroToDbAppExcercises
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //ZADACHA 4

            var connection = new SqlConnection(
                "Server=HAL\\MSSQLSERVER2;" +
                "Database=MinionsDB;" +
                "Integrated Security=True;" +
                "MultipleActiveResultSets=true;"
                );
           

            connection.Open();  
            using (connection)
            {

                List<string> inputOne = Console.ReadLine()
                        .Split(' ')
                        .ToList();

                string mName = inputOne[1];
                int mAge = int.Parse(inputOne[2]);
                string town = inputOne[3];

                List<string> inputTwo = Console.ReadLine()
                        .Split(' ')
                        .ToList();

                string villain = inputTwo[1];


                List<string> townNames = new List<string>();
                var allTowns = new SqlCommand(
                    "SELECT Name FROM Towns ", connection
                    );

                var allTownsExec = allTowns.ExecuteReader();

                while (allTownsExec.Read())
                {
                    string tName = (string)allTownsExec["Name"];
                    townNames.Add(tName);
                }
                //vkarahme vsichki imena v spisuka


                if (!townNames.Contains(town))
                {
                    //Ako go nqma tozi grad GO DOBAVQME

                    /*
                     Alter Table Towns
                     Alter Column CountryId INT
                     */

                    var addCity = new SqlCommand(
                        $"INSERT INTO Towns(Name) VALUES('{town}') ", connection);
                    var addCityExcec = addCity.ExecuteNonQuery();
                    Console.WriteLine($"Town {town} was added to the database.");
                }



                //VILLAIN
                List<string> villains = new List<string>();
                var allVillains = new SqlCommand(
                    "SELECT Name FROM Villains ", connection
                    );

                var allVillainsExec = allVillains.ExecuteReader();

                while (allVillainsExec.Read())
                {
                    string vName = (string)allVillainsExec["Name"];
                    villains.Add(vName);
                }
                //vkarahme vsichki imena v spisuka


                if (!villains.Contains(villain))
                {
                    //Ako go nqma tozi grad GO DOBAVQME
                    var addVillain = new SqlCommand(
                    $"INSERT INTO Villains(Name, EvilnessFactorId) VALUES('{villain}', 5) ", connection);

                    var addVillainExcec = addVillain.ExecuteNonQuery();
                    Console.WriteLine($"Villain {villain} was added to the database.");
                }





                //MINION

                List<string> minionsNames = new List<string>();
                var allMinions = new SqlCommand(
                    "SELECT Name FROM Minions ", connection
                    );

                var allMinionsExec = allMinions.ExecuteReader();

                while (allMinionsExec.Read())
                {
                    string name = (string)allMinionsExec["Name"];
                    minionsNames.Add(name);
                }

                //vkarahme vsichki imena v spisuka

                if (!minionsNames.Contains(mName))
                {
                    //Ako go nqma tozi minion GO DOBAVQME KATO ROB NA VILLANA KOITO 
                    //E SUS DEFAULT EvilnessFactor DA E Evil
                        
                    /*
                     ALTER TABLE Minions
                     ALTER COLUMN Age INT

                     ALTER TABLE Minions
                     ALTER COLUMN TownId INT
                     */

                    var addMinion = new SqlCommand(
                     $"INSERT INTO Minions(Name) VALUES('{mName}') ", connection);

                    var addMinionExec = addMinion.ExecuteNonQuery();

                }




                var vallainId = new SqlCommand(
                        $"select Id from Villains where Name = '{villain}'",connection
                    );

                var idOfVillain = (int)vallainId.ExecuteScalar();



                //Proverka ako miniona veche ne e na tozi villain
                var minionVallainId = new SqlCommand(
                        $"select MinionId from MinionsVillains where VillainId = '{idOfVillain}'", connection
                );

                var minionIdsOfVillain = minionVallainId.ExecuteReader();
                List<int> minionsIds = new List<int>();

                while (minionIdsOfVillain.Read())
                {
                    int mID = (int)minionIdsOfVillain["MinionId"];
                    minionsIds.Add(mID);
                }


                var minionID = new SqlCommand(
                       $"select Id from Minions where Name = '{mName}'", connection
               );

                int minionIDExec = (int)minionID.ExecuteScalar();

                if (!minionsIds.Contains(minionIDExec))
                {
                    var addMinionToVillain = new SqlCommand(
                     $"INSERT INTO MinionsVillains " +
                     $"VALUES((select Id from Minions where Name = '{mName}')," +
                     $"(select Id from Villains where Name = '{villain}')) ", connection);

                    var addMinionToVillainExec = addMinionToVillain.ExecuteNonQuery();

                    Console.WriteLine($"Successfully added {mName} to be minion of {villain}.");
                }

            } 


            
        }
    }
}
