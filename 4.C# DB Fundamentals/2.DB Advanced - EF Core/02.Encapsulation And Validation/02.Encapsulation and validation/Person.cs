using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Person
{
    //poletata sa private
    private string name;
    private int age;

        /*
            MOJEM DA IMAME POLETA internal KOETO E NESHTO MEJDU 
            private i public, t.e. MOJEMD DA GO POLZVAME SAMO OT 
            KLASOVETE V TEKUSHTIQ PROEKT (INTERFEIS).
         */

    //konstruktor s dva parametura
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    //AKO IMAME POVECHE KONSTRUKTURI KOITO SI PRILICHAT E HUBAVO DA GI 
    //NASLEDQVAME SUS :this() ZA DA NE KOPIRAME KOD


    //trqbva da mojem nie da gi dostupvame zatova si pravim geteri i seteri:

    public string Name
    {
        get { return this.name; } //vzimame name
        set { this.name = value; } // setvame q na podadenata stoinost
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }
    //SEGA VECHE KODA NI E KAPSULIRAN I MOJEM DA GO DOSTUPVAME


    //MOJEM DA POLZVAME this. KATO PARAMETUR NA METOD, I VUV RETURN STATEMENT!

    public string NameAndAge()
    {
        //Mojem da polzvame this. v return
        return "Imeto mi e " + this.name + " i sum na " + this.age + " godini!";
    }
}













