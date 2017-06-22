using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.StudentGroups
{

    class Town
    {
        public string Name { get; set; }
        public List<Student> Students{ get; set; }
        public int SeatsCount { get; set; }
        //public Dictionary<string, Dictionary<string, DateTime>> StudentEmailAndDate{ get; set; }
    }

    class Group
    {
        public Town Town { get; set; }
        public List<Student> Students{ get; set; }
    }

    class Student
    {
        public string Name{ get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
    }

    class StudentGroups
    {
        static void Main(string[] args)
        {

           

        }

        private List<Town> ReadTownsAndStudents()
        {
            var towns = new List<Town>();

            // read Towns and stidents 

            string[] input = Console.ReadLine().Split(new string[] { "\r\n","\n"}, StringSplitOptions.None).ToArray();




            return towns;
        }
    }
}
