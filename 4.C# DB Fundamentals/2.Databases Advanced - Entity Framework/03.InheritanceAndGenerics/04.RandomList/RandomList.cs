using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class RandomList : List<string>
{               
    //Nasledqvame klasa List ot stringove

    //Suzdavame si pole koeto e ot klasa Random 
    private Random rnd;

    public RandomList() : base()
    {
        this.rnd = new Random();
    }

    public string RandomElement()
    {
        var rnd = new Random(); // Pravim obekt ot Random Klasa
        string element = this[rnd.Next(0, this.Count)]; // Vzimame si random chilo 
        this.Remove(element); // premahvame elementa ot spisuka
        return element; //vrushtame elementa !
    }

}

    
















