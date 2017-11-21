

namespace _02.Encapsulation_and_validation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Dice
    {

        //this sochi kum tekushtiq obekt !!!
        //gettera ni dava dostup do dadeno neshto
        //settera promenq toinostta na tova neshto

        /*
            Encapsulaciq :
                Tova e wrappvane na parche kod koqto nqma smisul da se pokazva na
                usera zashtoto nqma da mu trqbva i ne go interesuva, zatova tazi
                informaciq se kapsulira i ne se dava na usera !!!
         
             KAK STAVA ?
                Purvo se slagat vsichki poleta da sa private !!!
                Ako sa public nishto ne prechi na usera rosto da vleze i da si promeni stoinostite.
                Posle se polzvat geteri i seteri za da gi dostupim !!!
                Mojem da napravim i geterite i seterite da sa private !!!
                
             */

        private Random random = new Random();
        public int sides;


        public Dice(int sides)
        {
            this.Sides = sides;
        }


        //tova e property
        public int Sides
        {
            get
            {
                //vzima promenlivata sides
                return this.sides;
            }
            set
            {
                
                
                //v sluchaq value e podadeniq parametur pri suzdavaneto na obekta.
                this.sides = value;

                //proverqva dali e > 0
                if (sides <= 0)
                {
                    throw new ArgumentException("THere is no dice with < than 1 side you IDIOT !!!");
                }
            }

        }

        //pravim si metod Roll
        public int Roll()
        {

            //shte generira ot 1 do 6
            var rolledResult = random.Next(1, this.sides + 1);

            return rolledResult;
        }
    }
}
