using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Player
{
    private string name;
    private Stats stats;

    public Player()
    {

    }

    public Player(string name, Stats stats)
    {
        this.Name = name;
        this.Stats = stats;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            this.name = value;
        }
    }

    public Stats Stats
    {
        get { return this.stats; }
        set
        {
            this.stats = value;
        }
    }

    public int PlayerSkillLevel()
    {
        return Stats.AverageStats();
    }

}

