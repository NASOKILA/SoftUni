using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Diagnostics;

namespace StringsAndRegex2
{
    class StringsAndRegex2
    {
        static void Main(string[] args)
        {


            /* 
            Kakvo e stringBuilder ?   
            To e klas kato string samoche po umen otdelq nqkakva extra pamet koqto 
            se pulni kato dobavqme kum nqkoi string.
            stringBuilder e kato string samoche durji buffer koito mojem da napulnim po razlichen nachin i
            raboti po burzo ot string.

            dostupva se sus System.Text.StringBuilder; NO NA NAS V SLUCHAQ NE NI E NUJNO
            ZASHTOTO GO IMA V System.Text;

            Kakto pri masivi i listove takava e razlikata i pri string i stringBuilder.
            stringovete sa po burzi no za manipulacii STAVAT PO BAVNI ZASHTOTO VSEKI PUT SUZDAVAME NOV STRING I 
            ZA TOVA E PO DOBRE DA SE POLZVA StringBuilser.
            */

            // REVERSE A STRING WITH STRINGBUILDER
            string s = Console.ReadLine();

            StringBuilder sb = new StringBuilder(); // toi e prazen no si ima nqkakuv buffer chakash da se napulni
            // v skobite mojem da napishem kolko length iskame da IMA
            // STringBuildera ima capacity, length i maxLength avtomatichno 
            // avtomatichno slaga length 16 i kogato nadvishim go udvoqva do 32, posle do 64 i t.n.

            for (int i = s.Length - 1; i >= 0; i--) // hodim na dolo
            {
                //vurnim ot zad na pred v stringa i dobavqme elementite v sb
                sb.Append(s[i]); // zakachame za sb
            }
            Console.WriteLine(sb);


            /*
            
            Funkcii v StringBuilder s koito mojem da rabotim :
            
            sb.Append() - zakacha string, obekt ili char nakraq
             
            sb.Remove(int start , int length) - trie charove v daden range
             
            sb.Insert(int index, string str) - dobavq string ili obekt v daden ranges
             
            sb.Replace(string oldString, string newString) - razmenq vsichki podadeni stringove s novite podadeni strngove
            
            sb.ToString() - converts stringBuilder to string
             */






            Console.WriteLine(); Console.WriteLine();
            //String concatenation :

            // PURVO SHTE GO NAPRAVIM SUS STRING I POSLE SHTE GO NAPRAVIM DA E PO BURZO SUS STRINGBUILDER 


            string result = "";
            Stopwatch st = new Stopwatch(); // pravim si stopwatcha
            st.Start(); // startirame go

            for (int i = 0; i < 35000; i++)
            {
                result += (Convert.ToString(i, 2) + "\n");
                // salgame chisloto convetritano v string v DVOICHNA BROINA SISTEMA + NOV RED v resultata
                // suzdaveme ot chisloto edin string i go dobavqme kum resultata
            }

            st.Stop(); // s pirame hronometura
            Console.WriteLine("Sus string:  " + st.Elapsed); // st.Elapsed() ni pokazva kolko vreme e izminalo ot start do end na hronometura ! 



            // ZA 25000 OPERACII NI OTNEMA OKOLO 5 SEKUNDI , AKO POLZVAME STRINGBUILDER SHTE STANE MN PO BURZO
            StringBuilder result2 = new StringBuilder();
            Stopwatch st2 = new Stopwatch();

            st2.Start();
            for (int i = 0; i < 35000; i++)
            {
                result2.Append(Convert.ToString(i, 2) + "\n");      
            }
            st2.Stop();

            Console.WriteLine("Sus StringBuilder:  " + st2.Elapsed);
            // ZA 25000 OPERACII NI OTNEMA 0 SEKUNDI 
            // RABOTI MNOGO PO BURZO






            // REGULAR EXPRESSIONS:

            /*
            Tova e sobstven ezik ne e kato C#, java, javascript i t.n. , toi e ezik za suzdavane na izrazi
            NARICHA SE REGEX I E MNOGO LESEN.

            regulqrniq izraz se izpolzva vurhu nqkakuv string za da nameri neshto v nego.
            MOJEM DA OTIDEM NA SAITA www.regexr.com i da testvame tam
             
            abc - gi namira gledaiki posledobatelnostta
            [a,b,c] - shte nameri sinvolite a,b i c v dadeniq tect ili string bez znachenie ot posledobatelnostta
            [^a,b,c] - namira vsichko koeto ne e  a,b,c  gledaiki posledovatelnostta.
            [0-9] - shte nameri vsichki cifri ot 0 do 9 vkluchitelno

            IMA I DRUGI NACHINI ZA NAMIRANE KOITO SA PO LESNI:
            \w - namira vsichki malki i golqmi bukvi ot 'a' do 'z' i chislata ot 0 do 9
            \W - namira vsichko koeto NE e vsichki malki i golqmi bukvi ot 'a' do 'z' i chislata ot 0 do 9

            \d - hvashta vsichki chisla obache edno po edno 
            \D - vsichko koeto ne e chislo
             
            \s - namira vsichki prazni mesta  i nqkoi sinvoli kato +,.&/\"'><)( i bukvite ot 1 do 9
            \S - vsichko koeto e obratnoto na gornoto

            ZA HVASHTANE NA DUMI POLZVAME KATO DOBAVIM NESHTO NA KRAQ, * , + ILI ?
            [...]+ tursi edin ili poveche ot edin sinvol , moje da ima pone edno chislo
            [...]* tursi 0 ili poveche elem, moje da go nqma moje i da go ima
            [...]? vhashta ili 0 ili edin sinvol


            EDNA TABULACIQ E EDNO NATISKANE NA TAB ILI \t
            PO NQKOGA SHTE SE NALOJI DA POLZVAME TABULACII ZA PODRAVNQVANE, KATO V DOLNIQ PRIMER

            Name: \t\w+\nPhone:\s*\+\d+
            \Name:
            \t - kazva tuk moje da ima tabulaciq
            \w+ - nqkakvo ime s edin ili poveche sinvola
            \n - nov red
            \Phone:
            \s* - prazno mqsto 0, edin ili poveche puti, MOJE DA GO NQMA
            \+ - za telefona
            \d+ - chislo edin ili poveche puti

            I SE POLUCHAVA 
            Name:   Peter
            Phone:  +39588204212 





            //ANCHORS : KOTVI, IMAME KOTVA V NACHALOTO I KOTVA V KRAQ

            ^ - start
            $ - ends


            [^a-z] - Pomnim che tova otricha
            ^[a-z] - shte hvane samo purvata bukva
            ^[a-z]+ - edin ili poveche sinvola, hvashta cqlata duma samoche purvata
            [a-z]+$ - hvashta poslednata duma




            ZA DA NAMERIM Slednoto :
            22-Jan-2016
            10-Nov-2015
            
            PISHEM:
            \(\d{2})-(\w{3})-(\d{4})\g 
            TOVA VUV SKOBITE E GRUPA, V MOMENTA SME SI NAPRAVILI GRUPI ZA DENQ, ZA MESECA I ZA GODINATA




            KAK DA HVANEM SPECIFICHNO NESHTO:
            (?:Hi|Hello), (\w+)
            Hi, Naso

            SINVOLAT '|' OZNACHAVA    ILI


            KAK DA MACGNEM DVA VIDA DATI:
            22-10-1999
            16/11/2006
            \d{2}(-|\/)\d{2}\1\d{4}   TUK OBACHE ESKEIPVAME SINVOLA '\  '

            S \1 VIKAME NAPRAVENATA GRUPICHKA, GRUPITE ZAPOCHVAT OT 1

             */

            





        }
    }
}
