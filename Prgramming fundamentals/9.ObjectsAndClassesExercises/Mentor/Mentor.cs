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
          
			
			/*
			nakov 22/08/2016,20/08/2016
			simeon10 22/08/2016
			end of dates
			nakov-Excellent algorithmetic thinking.
			Gesh4o-Total noob.
			end of comments
			*/

			string namesAndDates = Console.ReadLine();
            GetNamesAndDates(namesAndDates, Students);

            string namesAndComments = Console.ReadLine();
            GetNamesAndComments(namesAndComments, Students);


            PrintResult(Students);
        
        }

        private static void PrintResult(Dictionary<string, Student> Students)
        {
            foreach (var student in Students.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);
                Console.WriteLine("Comments:");
				if (!student.Value.Comments.Contains(null)); // ako broikata na kometarite ne e 0
				{// PROBLEMA E TUKA
					foreach (var comment in student.Value.Comments)
					{
						Console.WriteLine("- {0}", comment);
					}
				}

				Console.WriteLine("Dates attended:");
                foreach (var date in student.Value.Dates.OrderBy(d => d))
                {
                    Console.WriteLine("-- {0}", date.ToString("dd/MM/yyyy"));
                }

            }
        }


        private static void GetNamesAndComments(string namesAndComments,
			Dictionary<string, Student> Students)
		{
            
            while (!namesAndComments.Equals("end of comments"))
            {
                List<string> comments = new List<string>();
                string[] namesAndCommentsArr = namesAndComments
                    .Split('-').ToArray();
                string name = namesAndCommentsArr[0];

				if (!comments.Contains(namesAndCommentsArr[1]))
				{
					comments.Add(namesAndCommentsArr[1]);
					
					
				}


				foreach (var student in Students.Values)
				{
					if (student.Name.Equals(name))
					{
						student.Comments = comments;
					}
				}
                


                namesAndComments = Console.ReadLine();
            }
        }

        private static void GetNamesAndDates(string namesAndDates, 
			Dictionary<string, Student> Students)
        {

			while (!namesAndDates.Equals("end of dates"))
			{
				List<DateTime> dates = new List<DateTime>();

				Student student = new Student();

				string[] namesAndDatesArr = namesAndDates.Split(' ').ToArray();
				string name = namesAndDatesArr[0];

				string[] datesArr = namesAndDatesArr[1].Split(',').ToArray();
				for (int i = 0; i < datesArr.Length; i++)
				{
					DateTime date = DateTime.ParseExact(datesArr[i],
						"dd/MM/yyyy", CultureInfo.InvariantCulture);

					if (!dates.Contains(date)) { dates.Add(date); }   // ako q nqma taq data q sloji
				}

				student.Name = name;
				student.Dates = dates;
				Students[name] = student;
                namesAndDates = Console.ReadLine();
            }
        }
    }
}
