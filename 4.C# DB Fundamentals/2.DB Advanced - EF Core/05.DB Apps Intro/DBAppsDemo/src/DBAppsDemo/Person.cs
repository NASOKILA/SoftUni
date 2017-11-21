using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBAppsDemo
{
    public class Person
    {

        /*TOVA E KLAS V KOITO SHTE PODADEM REZULTATITE OT ZAQVKATA*/
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }

        public Person(string FirstName, string LastName, string JobTitle)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.JobTitle = JobTitle;
        }

        public override string ToString()
        {
            return ($"{this.FirstName} {this.LastName} is a {this.JobTitle}");
        }   
        

    }
}
