using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Team
{

    private string name;
    private List<int> playersSkillsList = new List<int>();

    public List<Player> players;    
    private int rating;


    public Team()
    {

    }


    public Team(string name)
    {
        this.Name = name;
        players = new List<Player>();
    }


    public string Name
    {
        get { return this.name; }
        set
        {
            if (value == null || value == "" || value == " ")
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }


   

    public void AddPlayer(Player p)
    {
        players.Add(p);
    }

    public void RemovePlayer(Player p)
    {
        players.Remove(p);
    }


    public override string ToString()
    {

        foreach (var p in players)
        {
            playersSkillsList.Add(p.PlayerSkillLevel());
        }

        if (players.Count == 0)
            this.rating = 0;
        else
            this.rating = (int)Math.Round(playersSkillsList.Average());

        return $"{this.Name}" + " - " + this.rating;
    }

}

