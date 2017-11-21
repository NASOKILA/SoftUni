using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Song
{
    private string artistName;
    private string songName;
    private TimeSpan songLength;

    public Song()
    {

    }

    public Song(string artistName, string songName, TimeSpan songLength)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
        this.SongLength = songLength;
    }


    public string ArtistName
    {
        get { return this.artistName; }
        set { this.artistName = value; }
    }

    public string SongName
    {
        get { return this.songName; }
        set { this.songName = value; }
    }

    public TimeSpan SongLength
    {
        get { return this.songLength; }
        set { this.songLength = value; }
    }





}

