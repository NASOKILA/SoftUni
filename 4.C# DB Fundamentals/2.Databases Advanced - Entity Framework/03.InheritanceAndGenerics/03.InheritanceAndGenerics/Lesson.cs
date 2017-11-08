using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Comments
{
    static void Main(string[] args)
    {
        /*       
                 Comments:

                 Shte si govorim za :

                 1.Inheritance v C# (Nasledqvane v C#)
                 2.Class Hierarchies (klasicheska ierarhiq)
                 3.Accessing Members of the Base Class (dostup do chlenove na bazoviq klas)
                 4.Virtual Classes (Virtualni metodi)
                 5.Overriding Methods (Prezapisvane na metodi)
                 6.Generic Classess (Generic klasove i kolekcii)
         */

        /*
        1. Nasledqvane:
        imame bazov klas (Base Class) (Parent Class) (SuperClass) i - predava na child klasa ! 
        podklas (SubCalss) (Child Class) - vzima ot base klasa !       
        
        podklasa moje da si ima i sobstveni dopulnitelni propertita


        PRIMER: Imame klas Person() (base class) koito e nasleden ot klas Employee i klas Student (child classes)
        No Child klasovete mogat da si imat i te sobstveni propertita
        NASLEDQVA SE S:       : Person


        V praktikata shte imamo mnogo po zadulbocheni primeri ot tova !!!
        
        
            
        */


        //SEGA KLASA Dog IMA VSICHKI NESHTA OT KLASA Animal BEZ DA SME MU GI DOBAVQI.
        Dog dog = new Dog("Gafy", 9, 15);
        Console.WriteLine(dog.Name);
        Console.WriteLine(dog.Age);
        dog.Eat();



        //SEGA TOVA PUPPY IMA VSICHKO OT PREDISHNITE KLASOVE NAD NEGO.
        Puppy puppy = new Puppy("Jaky", 16, 5);
        puppy.Eat();
        puppy.Weep(); // plache


        //Kotkata nasledqva samo klasa Animal !!!
        Cat cat = new Cat("Sisa", 7, 4);
        cat.Eat();
        cat.Meaw();



        //KONSTRUKTORITE SE PREIZPOLZVAT !!!
        /*
            Nasledqvaneto e proces kato stupalo.
            NQMAME MULTIPLE INHERITANCE V C#, TRQBVA DA SA EDNO SLED DRUGO !
            
            NE MOJEM PROSTO DA NAPISHEM : Puppy : Dog : Animal
         */






        /*
         
        S 'override' prezapisvame metodi !
        VIRTUALNITE METODI MOGAT DA SE PREZAPISVAT !
          
        VIRTUALNI METODI:
        ToString() e edin vgraden virtualen metod !

        Ponqkoga ni trqbva da mojem da promenqme metodi ot klasus koito 
        nasledqvame.

        Virtualnite metodi mogat da se promenqt 
        POZVOLQVAT NI DA GI PREZAPISVAME I DA IM PROMENQME LOGIKATA!
        pishet se s dumata 'virtual' !
        */

        Console.WriteLine(); Console.WriteLine();
        //PRIMER :  Prezapisvame metoda Eating za vseki klas 
        //Prezapisahme virtualniq metod ot klasa Animal !!!
        dog.Eat(); // pokazva Dog Eating ...
        puppy.Eat();
        cat.Eat();

        Animal animal = new Animal("Lion", 20, 250);
        animal.Eat(); // pokazva Animal Eating ...






        /*
            Interfeisi:
            Te sa neshto kato klasove 
            i se krushtavat zpochvaiki s 'I' i polse sushtestvitelno .
            Primerno : 
            1.IList t.e. sudurja samo spisuci,
            2.IDictionary t.e. sudurja samo rechnici.

            public interface IMovable
            {
                . . .
            }
            
         */

        // Tuk si izvikvame metoda koito polzva interfeisa IMovable koito suzdadohme
        MoveObject(cat, 10);
            



        /*
        Generic Collections:
        
        tuk govorim za system.collection.generic
        TE SA KATO PLACEHOLDERI KOITO POLZVAME Z DA SLAGAME TIPOVE DANNI,
        Mojem da si slagame kakuvto tip danni si iskame, DAJE I KLASOVE KOITO
        SME SI NAPRAVILI MOGAT DA SA TIPOVE DANNI I MOJEM DA PRAVIM KOLEKCII OT TQH !!! 
        
        
         */

        /*SUMMARY:
        1.Nasledqvaneto e nestho mnogo nujno i polezno.
            Imame base class i child class.
            Child klasovete mogat da prezapisvat virtualni metodi ot baze klasa.
        2.interfeisa e kato dokument koito ni pokazva koi klaza za kakvo e, ulesnqva ni rabotata. 

        3.Generic kolekciite sa konteineri za vsqkauv tip danni daje i pt tip klas koito sme suzdali.
            Ne mojem da im slagame drug tip danni ot tozi koito sme im zadali.
         
         
         */

    }

    //Pravim si metod koito priema IMovable obekt i distanciq, mojem da go
    //vikame v main metoda.
    public static void MoveObject(IMovable obj, int distance)
    {
        obj.Move(distance);
    }

}
















