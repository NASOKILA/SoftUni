using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentor
{
    class Mentor
    {
        static void Main(string[] args)
        {
            Dictionary<string, Student> Students = new Dictionary<string, Student>();       
            Dictionary<string, List<DateTime>> NamesAndDates = new Dictionary< string, List<DateTime>>();
            Dictionary<string, List<string>> NamesAndComments = new Dictionary<string, List<string>>();

            string namesAndDates = Console.ReadLine();
            GetNamesAndDates(namesAndDates, NamesAndDates);

            string namesAndComments = Console.ReadLine();
            GetNamesAndComments(namesAndComments, NamesAndComments, NamesAndDates);

            SetStudent(NamesAndDates, NamesAndComments, Students);

            PrintResult(Students);
        
        }

        private static void PrintResult(Dictionary<string, Student> Students)
        {
            foreach (var student in Students)
            {
                Console.WriteLine(student.Key);
                Console.WriteLine("Comments:");
                foreach (var comment in student.Value.Comments.OrderBy(c => c))
                {
                    Console.WriteLine("- {0}", comment);
                }
                Console.WriteLine("Dates attended:");
                foreach (var date in student.Value.Dates.OrderBy(d => d))
                {
                    Console.WriteLine("-- {0}", date.ToString("dd/MM/yyyy"));
                }

            }
        }

        private static void SetStudent(Dictionary<string, List<DateTime>> NamesAndDates,
            Dictionary<string, List<string>> NamesAndComments,
            Dictionary<string, Student> Students)
        {
            foreach (var pair in NamesAndDates)
            {
                string name = pair.Key;
                List<DateTime> date = pair.Value;
                List<string> comment = new List<string>();
                foreach (var pair2 in NamesAndComments)
                {
                    if (pair.Key == pair2.Key)
                    {
                        comment = pair2.Value;
                    }
                }

                // List<string> comment = NamesAndComments.

                Student student = new Student()
                {
                    Name = name,
                    Dates = date,
                    Comments = comment,

                };


                Students[name] = student;


            }
        }

        private static void GetNamesAndComments(string namesAndComments,
            Dictionary<string, List<string>> NamesAndComments,
            Dictionary<string, List<DateTime>> NamesAndDates)
        {
            
            while (!namesAndComments.Equals("end of comments"))
            {
                List<string> comment = new List<string>();
                string[] namesAndCommentsArr = namesAndComments
                    .Split('-').ToArray();
                string name = namesAndCommentsArr[0];
                comment.Add( namesAndCommentsArr[1]);

                if (NamesAndDates.ContainsKey(name))
                {
                    // ako toq student nqma data, ne go zapisvai
                    NamesAndComments[name] = comment;
                }


                namesAndComments = Console.ReadLine();
            }
        }

        private static void GetNamesAndDates(string namesAndDates,
            Dictionary<string, List<DateTime>> NamesAndDates)
        {
            while (!namesAndDates.Equals("end of dates"))
            {
                List<DateTime> dates = new List<DateTime>();
                string[] namesAndDatesArr = namesAndDates.Split(' ').ToArray();
                string name = namesAndDatesArr[0];

                string[] datesArr = namesAndDatesArr[1].Split(',').ToArray();
                for (int i = 0; i < datesArr.Length; i++)
                {
                    DateTime date = DateTime.ParseExact(datesArr[i],
                        "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    dates.Add(date);
                }

                NamesAndDates[name] = dates;
                namesAndDates = Console.ReadLine();
            }
        }
    }
}
