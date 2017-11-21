using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DateModifier
{
    private string dateOne;
    private string dateTwo;

    public DateModifier(string dateOne, string dateTwo)
    {
        this.DateOne = dateOne;
        this.DateTwo = dateTwo;
    }

    public string DateOne
    {
        get { return this.dateOne; }
        set { this.dateOne = value; }
    }

    public string DateTwo
    {
        get { return this.dateTwo; }
        set { this.dateTwo = value; }
    }


    public string DateDiff(string d1, string d2)
    {
        DateTime StartDate = Convert.ToDateTime(d1);
        DateTime EndDate = Convert.ToDateTime(d2);
        string result = Math.Abs(((EndDate - StartDate).TotalDays)).ToString();


        return result;
    }

    public override string ToString()
    {
       return DateDiff(this.dateOne, this.dateTwo);

    }


}

