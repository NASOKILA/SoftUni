using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageGrades
{
    public class Student
    {
        public string Name { set; get; }
        public List<double> Grades { set; get; }
        
        public double AverageGrade() {
            double gradeAverage = this.Grades.Average();
            return gradeAverage;
                }  // readOnly

    }
}
