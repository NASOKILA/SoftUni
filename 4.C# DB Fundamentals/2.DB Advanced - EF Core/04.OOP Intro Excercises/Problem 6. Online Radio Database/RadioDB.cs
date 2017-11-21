using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RadioDB
{
    private List<Song> songs;

    public RadioDB()
    {
        this.Songs = new List<Song>();
    }

    public RadioDB(List<Song> songs)
    {
        this.Songs = songs;
    }

    public List<Song> Songs
    {
        get { return this.songs; }

        set
        {
            this.songs = value;
        }
    }


    public void AddSong(Song songToAdd)
    {
        songs.Add(songToAdd);
    }


}















