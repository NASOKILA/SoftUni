namespace P01_StudentSystem.Data.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CourseViewModel
    {
            /*
                Tova e nashiq model i vzima samo ime i cena 
                Mojem da go izpolzvame v select()
             */

        //Trqbva ni prazen konstruktor za da mojem dago instancirame
        public CourseViewModel()
        {

        }

        //Trqbva ni i konstruktor v koito shte podavame parametrita koito 
        //Iskame da selektirame ot dadeniq klas
        public CourseViewModel(string name, decimal price)
        {
            this.Course_Name = name;
            this.Course_Price = price;
        }

        
        public string Course_Name { get; set; }

        public decimal Course_Price { get; set; }

        /*
         Polzva se taka:
            var courseNameAndPrice = db.Courses
            .Select(c => new CourseViewModel(c.Name, c.Price));

         */

    }
}
    