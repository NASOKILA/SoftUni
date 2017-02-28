using System;


namespace ArraysAndLists
{
    public class Arrays
    {

        public static void Increment(int num, int n) {
            num += n;
        }
        public static void IncrementArray(int[] num2, int n)
        {
            num2[0] += n;
        }
        public static void Main(string[] args)
        {
            int num = 5;
            Increment(num, 15);  // tuk num ni vrushta 20 no ne se promenq originalnata promenliva
            Console.WriteLine(num);  // num pak si e 5, ne se promenq 

            int[] num2 = { 5 };  // taka se definira masiv
            IncrementArray(num2, 15);
            Console.WriteLine(num2[0]);  // sega veche ni dava 20, promenihme masiva

            // Reference types: 
            /*Moje 2 promenlivi da sochat kum edno i sushto mqsto, ako promenim purvata
             promenqme i vtorata promenliva.
             takiva sa masivete.
             stringovete sa masivi sus charove.
             Pri pass by reference ako promenim referenciqta promenqme i samata promenliva,
             a pri Pass by value ne moje da promenim originalnata promenliva. 
             
             */

            /*Arrays: 
              TE SA GRUPA ELEMENTI ZAPOCHVASHTI OT 0 I IMAT SAMO EDIN TIP DANNI.
              IMAT TOCHNO OPREDELENA DULJINA OPREDELENA V NACHALOTO I NE MOJE DA SE PROMENI.
              VSICHKI ELEMENTI SA PO DEFAULT SA = NA NULA DOKATO NE IM DADEM STOINOST!
                             
             KAK SE SUZDAVAT : 

            int[] Array = new int[5];
            NIE KAZVAME : MASIV S IME Array E RAVEN NA NOV MASIV S 5 ELEMENTA !
             
             */

            int[] numbers = new int[10]; // taka se definira masiv ot 10 elem
            Console.WriteLine(numbers[5]); // vsichki  sa = na 0, ne sme im dali  stoinost
            for (int i = 0; i < numbers.Length; i++) // puskame edin cikul ot 0 do duljinata na masiva
            {
                numbers[i] = i; // taka davame stoinosti ot 0 do 10 na vs elem

            }
            Console.WriteLine(numbers[5]);

            /*Dnite ot sedmicata mogat da budat zapazeni v masiv:*/

            Console.WriteLine(); Console.WriteLine();

            string[] daysOfWeek = new string[7];
            daysOfWeek[0] = "Monday";
            daysOfWeek[1] = "Tuesday";
            daysOfWeek[2] = "Wednesday";
            daysOfWeek[3] = "Thursday";
            daysOfWeek[4] = "Friday";
            daysOfWeek[5] = "Saturday";
            daysOfWeek[6] = "Sunday";

            for (int i = 0; i < daysOfWeek.Length; i++)
            {
                Console.WriteLine(daysOfWeek[i]);
            }

            Console.WriteLine(); Console.WriteLine();

            /*How to read Arrays from the console :
            
            PURVIQ NACHIN e  da prochetem ot konzolata duljinata na masiva:*/

            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n]; // suzdavame masiv s n elementa

            for (int i = 0; i < n; i++) // ot 0 do n
            {
                arr[i] = int.Parse(Console.ReadLine());
                // na vsqko krugche davame stoinost na sledvashtiq element ot masiva !
            }

            Console.WriteLine("arr[3] = " + arr[1]);


            Console.WriteLine(); Console.WriteLine();


            /* VTORIQ NACHINE E : SUS   .Split()   :*/

            string values = Console.ReadLine();

            string[] items = values.Split(' ');
            // kazvame che e ravno na values mejdu koito sa razdeleni ot   ' ' ,  kogato Split sreshne  ' '  schita elementa za svurshen !!! 

            int[] Arr3 = new int[items.Length]; // suzdavame masiv dulug tolkova kolkoto items
            // Length shte bude tolkova kolkoto mu podadem !

            for (int i = 0; i < items.Length; i++)
            {
                Arr3[i] = int.Parse(items[i]);
                //  parsvame i dobavq kum masiva Arr
            }
            // SEGA masiva Arr3 ima podadeni elementi koito sa parsnati ot razdeleniq ot Split string  values !!! 


            Console.WriteLine(); Console.WriteLine();



            /*KAK PECHATAME TEQ CHISLA NA KONZOLATA :*/
            string[] Arr2 = { "one", "two", "three", "four", "five" }; // TAKA DIREKTNO MU DAVAME STOINOSTI!

            for (int i = 0; i < Arr2.Length; i++)
            {
                Console.WriteLine(Arr2[i]); // pechatame elementite
            }



            /*Math.Floor rounds down, Math.Ceiling rounds up, and Math.Truncate rounds towards zero. 
             * Thus, Math.Truncate is like Math.Floor for positive numbers, and like Math.Ceiling for negative numbers.*/

            //  Math.Round(Arr2[i], RoundingNumbersAwayFromZero)  VAJNO !!!


            Console.WriteLine(); Console.WriteLine();

            //foreach() Loops:      foreach() E PO DOBRE ZA RABOTA S MASIVI !

            int[] arr4 = { 10, 20, 30, 40 };

            
            foreach (var element in arr4) { // da printira vsseki element !!!
                Console.WriteLine(element);
            }

            // REALNO FOREACH PRAVI SLEDNOTO: 
            //  for (int = 0; int < arr4.Length;i++)
            //  {var element = arr4[i];  
            //   Console.WriteLine(element) }


            //string.Join(" separator ", array) :

            Console.WriteLine(string.Join(", ", arr4));  //dobavq tova koeto iskame mejdu elementite
              // pokazva  10, 20, 30, 40   obache gi pechata ne edin red i posle minava na nov

                              






        }
    }
}
