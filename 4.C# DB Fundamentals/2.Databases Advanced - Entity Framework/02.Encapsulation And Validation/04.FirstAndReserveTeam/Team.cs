using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public Team(string name)
    {
        this.name = name;
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
    }

    public Team(string name, List<Person> firstTeam, List<Person> reserveTeam)
        :this(name)
    {
        this.firstTeam = firstTeam;
        this.reserveTeam = reserveTeam;
    }
    
    //ReadOnlyPoletata mogat da se pipat samo v konstruktora !!!    
    public IReadOnlyCollection<Person> FirstTeam
    {
        get { return this.firstTeam.AsReadOnly(); }
    }

    public IReadOnlyCollection<Person> ReserveTeam
    {
        get { return this.reserveTeam.AsReadOnly(); }
    }

    //Method AddPlayer
    public void AddPlayer(Person person)
    {
        if (person.Age < 40)
        {
            firstTeam.Add(person);
        }
        else
        {
            reserveTeam.Add(person);
        }

    }



}

