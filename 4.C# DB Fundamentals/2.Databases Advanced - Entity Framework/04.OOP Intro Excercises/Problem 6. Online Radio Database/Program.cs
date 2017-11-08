using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    static void Main(string[] args)
    {
        
       
            int n = int.Parse(Console.ReadLine());

            RadioDB radio = new RadioDB();
       
            for (int i = 0; i < n; i++)
            {

            try
            {
                List<string> input = Console.ReadLine()
                    .Split(';')
                    .ToList();

                string artistName = input[0];
                string songName = input[1];

                string songTimeStr = input[2];
                if (!songTimeStr.Contains(':'))
                {
                    songTimeStr = songTimeStr.Replace(':', '1');  
                    if (songTimeStr.Any(ch => !Char.IsDigit(ch)))
                        throw new ArgumentException("Invalid song length.");
                }

                string[] songTime = input[2].Split(':').ToArray();
                int songMinutes = int.Parse(songTime[0]);
                int songSeconds = int.Parse(songTime[1]);
               

                if(artistName.Length < 3 || artistName.Length > 20)
                    throw new ArgumentException("Artist name should be between 3 and 20 symbols.");

                if (songName.Length < 3 || artistName.Length > 20)
                    throw new ArgumentException("Song name should be between 3 and 30 symbols.");

                if (songMinutes < 0 || songMinutes > 14)
                    throw new ArgumentException("Song minutes should be between 0 and 14.");

                if(songSeconds < 0 || songSeconds > 59)
                    throw new ArgumentException("Song seconds should be between 0 and 59.");

                TimeSpan songLength = new TimeSpan(0, 0, songMinutes, songSeconds, 0);

                Song song = new Song(artistName, songName, songLength);

                radio.AddSong(song);
                Console.WriteLine("Song added.");


            }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

    }

        Console.WriteLine($"Songs added: {radio.Songs.Count}");
        TimeSpan result = new TimeSpan(); 
        foreach (var song in radio.Songs)
        {
            result += song.SongLength;
        }

        Console.WriteLine($"Playlist length: {result.Hours}h {result.Minutes}m {result.Seconds}s");
    }

}





