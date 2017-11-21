using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Family
{
    private List<Person> people = new List<Person>();
    List<int> familyAges = new List<int>();

    public Family()
    {

    }

    public Family(List<Person> people)
    {
        
        this.people = People;
    }

    public List<Person> People
    {
        get { return this.people; }
        set
        {

            this.people = value;
        }

    }




    public void AddMember(Person member)
    {
        familyAges.Add(member.Age);
        this.People.Add(member);
    }

    
    public Person GetOldestMember()
    {
         
        foreach (var item in People)
        {
            if (item.Age == familyAges.Max())
            {
                return item;
            }
        }

        
        return People.First();    
    }


    
}





