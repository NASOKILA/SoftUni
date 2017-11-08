using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Box<T> // Tova 'T' e prosto nqakuv placeholder za tip danni koito shte mu podadem
{
    // AKO MU PODADEM PRIMERNO int NAVSQKUDE 'T' STAVA NA int !!!
    //Mojem da mu podadem i klas napraven ot nas PRIMERNO 'Dog'


    /*
      Mojem da imame mnogo parametri v <> !!!
      pri klasovete generik raboti kakto pri metodite !!!
    */


    private T[] data; // tipa danni ni e 'T'
    private int count; //kato dobavqme neshto shte napravim taka che count da se vdiga !

    public Box()
    {
        // suzdavame si nov masiv ot 'T' koito s duljina ot 4
        this.count = 0;
        this.data = new T[4];
        
    }


    public int Count
    {
        get { return this.count; }

        private set // pravim si settera da ni e private
        {
            //ako broq na elementite e > ot duljinata na masiva da ima greshka
            if (this.data.Length < value)
            {
                throw new InvalidOperationException("You have to many elements !");
            }

            this.count = value;

        }
    }



    public T[] Data
    {
        get
        {
            return this.data;
        }
        private set
        {
            this.data = value;
        }
        
    }

    // Trqbvat ni metodite Add i Remove !!!

        //metod Add koito dobavq element na ot kraq
    public void Add(T element) //priema nqkakuv element T
    {

        //ako Count e >= na duljinata na masiva
        if (this.Count >= this.data.Length)
        {
            //suzdavame si masiv dva puti po golqm ot segashniq
            //TAKA PROCEDIRAT SPISUCITE !!!
            var newData = new T[data.Length * 2];

            //kopirame vsichko koeto imame dosega v nego
            this.data.CopyTo(newData, 0);

            this.data = newData;
        }  

        this.Data[this.Count] = element;  //setvame Count na element
        Count++; //Uvelichavame Count zashtoto sme dobavii edin element !
    }


    //pravim si metod Remove koito maha element ot spisuka nai ot kraq
    public T Remove()
    {
        int index = this.Count - 1; //vzimame si indexa
        T element = this.Data[index]; //vzimame si elementa
        this.Data[index] = default(T);
        Count--;  //namalqme si s edin element zashtoto sme mahnali daden element!

        return element;
    }


    //prezapisvame metoda ToString()
    public override string ToString()
    {
        return String.Join(", ", this.Data.Take(this.Count));
    }

}   

