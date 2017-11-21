using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Stats
{

    private const int min = 0;
    private const int max = 100;

    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    private List<int> listStats = new List<int>();

    public Stats(int endurance, int sprint, int dribble,
        int passing, int shooting)
    {
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
        
    }


    public int Endurance
    {
        get { return this.endurance; }
        set
        {
            if(value < min || value > max)
            {
                throw new ArgumentException("Endurance should be between 0 and 100.");
            }

            
            this.endurance = value;
        }
    }

    public int Sprint
    {
        get { return this.sprint; }
        set
        {
            if (value < min || value > max)
            {
                throw new ArgumentException("Sprint should be between 0 and 100.");
            }

            
            this.sprint = value;
        }
    }

    public int Dribble
    {
        get { return this.dribble; }
        set
        {
            if (value < min || value > max)
            {
                throw new ArgumentException("Dribble should be between 0 and 100.");
            }

           
            this.dribble = value;
        }
    }

    public int Passing
    {
        get { return this.passing; }
        set
        {
            if (value < min || value > max)
            {
                throw new ArgumentException("Passing should be between 0 and 100.");
            }

           
            this.passing = value;
        }
    }

    public int Shooting
    {
        get { return this.shooting; }
        set
        {
            if (value < min || value > max)
            {
                throw new ArgumentException($"Shooting should be between 0 and 100.");
            }

            
            this.shooting = value;
        }
    }

    public int AverageStats()
    {
        listStats.Add(Endurance);
        listStats.Add(Sprint);
        listStats.Add(Dribble);
        listStats.Add(Passing);
        listStats.Add(Shooting);

        int res = (int)Math.Round(listStats.Average());
        return res; 
    }

}













