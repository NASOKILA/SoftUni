namespace ExternalFormatProssessing
{
    using ExternalFormatProssessing.Data;
    using ExternalFormatProssessing.Data.Models;
    using ExternalFormatProssessing.DTOs;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Xml.Linq;

    public class Program
    {
        static void Main(string[] args)
        {

            /*
                Shte govorim za:
                	JSON Data Format
                	Processing JSON  kak se obrabotva json
                	JSON.NET bibliotekata koqto ni pomaga da gi parsvame
                	XML format i kak da go polzvame
                	XML proccessing   kak se obrabotva
                	
                
                JSON Obj: Znaem kakvo sa. Imame key i value moje da sa ot vsqkakva stoinost i 
                Prilcaht na JavaScript obekti moje da ima i masivi.
                	var obj = { "name": "Nasko", "surename": "Kambitov", "Age": 25 };
             */

            Console.WriteLine(); Console.WriteLine();
            using (var db = new ProgramDbContext())
            {
                // db.Database.EnsureCreated();


                //KAK DA PREVRUSHTAME OBEKTI V JSON ?

                //Pravim si obekt
                var product = new Product
                {
                    Name = "Tire",
                    Description = "the best tire ever."
                };


                //Pravim si metod koito da go vrushta kato JSON STRING
                var jsonString = SerializeObject<Product>(product);
                
                Console.WriteLine(jsonString);



                //Kak da go prevurnem ot JSON obekt v normalen obekt v EF ?
                //pak si pravim metoda no na obratno.

                //Seg ni go izpluva kato normalen obekt
                var parsedJson = DeserializeObject<Product>(jsonString);

                //Sega JSON-a e Product s propertita.

                //AKO JSON STRINGA E GRESHEN SHTE GRUMNE





                //Bibliotekata Newtonsoft.Json
                /*
                   PO IZPOLZVANO E Bibliotekata Json.NET koqto q polzvat i Microsoft.
                   Dava ni poveche funkcionalnost, moje da raboti s LINQ.
                   Mojem da parsvame ne samo JSON no i XML.

                   Instalirame go : paketa se kazva Newtonsoft.Json
                   Install-Package Newtonsoft.Json

                   Ot nego se pozva JsonConvert i posle za prevruhtane kum JSON obekt Se polzva SerializeObject(ImeNaObekta)
                   a za obratnoto se polzva DeserializeObject<TipNaObekta>(ImeNaObekta)
                   MNOGO PO LESNO SE RABOTI S NEGO.
                */

                Console.WriteLine(); Console.WriteLine();

                var shokolad = new Product()
                {
                    Name = "Milka",
                    Description = "Nai vkusniq sokolad v bulgaria",
                    Manufacturer = new Manufacturer() { Name = "Michelin"}
                };

                //sled kato sme inztalirali bibliotekata i imame nujniq using mojem da parsvame taka
                //VtORIQ PARAMETUR e Formatting.Indented kato go printirame izglejda po dobre, SAMIQ OBEKT E PODREDEN !
                //TRETIQ PARAMETUR NI IGNORIRA VSICHKI PROPERTITA S NULEVA STOINOST !!!
                var shokoladInJson = JsonConvert
                    .SerializeObject(shokolad, Formatting.Indented, new JsonSerializerSettings() {

                        NullValueHandling = NullValueHandling.Ignore,
                        DefaultValueHandling = DefaultValueHandling.Ignore   //tova e sushtoto kato [ JsonIgnore ] anotaciqta
                        //Tuk mojem da pravim mnogo neshta s tozi JSON vijdame che imame mnogo funkcionalnosti s tazi biblioteka 
                    }); 

                /*VAJNO OSHTE PRI SUZDAVANETO NA DTOto ILI TABLICATA KOQTO SHTe POLZVAME ZA SUZDAVANE NA OBEKTI KOITO POSLE SHTE PARSVAME AKO SLOJIM ANNOTACIQTA [JsonIgnore]
                 POSLE KATo PRINTIRAME NQMA DA SE VIJDA NA KONSOLATA PROPERTITO S TAZI ANOTACIQ !!!!!*/

                Console.WriteLine(shokoladInJson);


                //Taka go vrushtame kum normalnoto : MOJE DA RABOTI I S MASIV OT Product ili dr tip
                var shokoladParsedFomJson = JsonConvert.DeserializeObject<Product>(shokoladInJson);


                Console.WriteLine();
                Console.WriteLine($"Ime na shokolad: {shokoladParsedFomJson.Name}");








                //Mojem da durpame Json obekti ot Internet:
                Console.WriteLine(); Console.WriteLine();
                Console.WriteLine("MOJEM DA DURPAME JSON OBEKTI OT INTERNET: ");
                string json3;
                using (var client = new WebClient())
                {
                    //durpame JSON-a ot daden link
                    json3 = client.DownloadString("http://drone.sumc.bg/api/v1/metro/all");
                }

                //V Kakuv format idvat dannite:
                /*
                 "id": 10,
                 "route_id": 1,
                 "code": 2996,
                 "point_id": 110,
                 "name": "Beli Dunav",
                 "latitude": 42.633463463,
                 "longitude": 23.12314125
                 */
                 //DTO-toKOETO SHTE POLZVAME ZA DA PARSNEM JSON OBEKTA KUM NORMALEN OBEKT TRQBVA DA IMA TAKIVA PROPERTITA INACHE NQMA DA STANE !!!!!!!

                //Sega si go obrushtame na normalen obekt samoche ni trqbva DTO s propertita ednakvi kakto tezi na edin obekt ot 
                //jsona koito poluchavame ot linka
                var stations = JsonConvert.DeserializeObject<StationDto[]>(json3);


                //VAJNOOO !!!!!  Puskame si da mojem da vijdame i stringovete na kirilica:
                Console.OutputEncoding = Encoding.UTF8; //SEGA VIJDAME I NA KIRILICA

                foreach (var station in stations)
                {
                    Console.WriteLine($"{station.Name} {station.Latitude} {station.Longitude}");
                }








                //PARSVANE NA ANONIMNI OBEKTI !!!
                Console.WriteLine(); Console.WriteLine();
                Console.WriteLine("Anonimous objet parse:");

                //Moje i da polzvame normalni obekti:
                var student = new
                {
                    Name = "Pesho",
                    Age = 25,
                    Grades = new[] 
                    {
                        5.50,
                        6.00,
                        3.50,
                        4.50
                    }

                    //NE MOJEM DA SLAGAME null NA ANONIMNI OBEKTI
                };


                var studentInJson = JsonConvert.SerializeObject(student, Formatting.Indented);
                   
                Console.WriteLine(studentInJson);
                


                //AKO E ANONIMEN I TRQBVA DA GO DESIRIALIZIRAME MOJEM DA POLZVAME DeserializeAnonymousType()
                //Kato vtori parametur trqbva da e tova kum kakvoto iskame da go parsnem t.e. kum anonimen tip.

                var template = new {
                    //Tuk vutre trqbva da imame sushtite propertita za da se poluchi.
                    //i posle go podavame ato vtori parametur za da go parsnem 
                    Name = default(string),
                    Age = default(int),
                    Grades = new decimal[]
                    {
                    }
                };

                var parsedStudent = JsonConvert.DeserializeAnonymousType(studentInJson, template);

                Console.WriteLine();
                Console.WriteLine($" Name: {parsedStudent.Name} - Age: {parsedStudent.Age}");







                //Mojem da parsvame obekti i taka:
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("JObject.Parse() :");

                string strToParse = @"{'Name': 'Atanas', 'Age': 25, 'Grades': [ 6.00, 5.50, 'Nqma ocenka' ] }";
                JObject json2 = JObject.Parse(strToParse);

                Console.WriteLine(json2);
                //Tova stava kato polzvame using Newtonsoft.Json.Linq;


                



                //Mojem da printirame i taka:   EDNAKVO E
                Console.WriteLine(); Console.WriteLine();
                Console.WriteLine("Mojem da printirame i taka:");
                foreach (var kvp in json2)
                {
                    var key = kvp.Key;
                    var value = kvp.Value;

                    Console.WriteLine($"{key} {value}");
                }





                //KAK DA SELEKCTIRAME SAMO CHAST OT Json obekta ?
                Console.WriteLine(); Console.WriteLine();
                Console.WriteLine("KAK DA SELEKCTIRAME SAMO CHAST OT Json obekta ?");


                var gradesOfJson = json2["Grades"];
                Console.WriteLine("Grades:");
                Console.WriteLine(gradesOfJson);

                



                //Read from file: SUSHTOTO E SAMOCHE STRINGA GO CHETEM OT FAIL S
                Console.WriteLine(); Console.WriteLine();
                Console.WriteLine("Read From FIle :   SUSHTOTO E SAMOCHE STRINGA GO CHETEM OT FAIL S");
                Console.WriteLine("File.ReadAllText('FilePath.json')");





                /*
                 VAJNOOOO !!!!!!!

                 Kakvo e verbatim string ? 
                 
                 Tova e string s kliomba pred nego @"";
                 RAZLIKATA OT NORMALNIQ STRING E CHE VERBATIMNIQ NQMA NUJDA OT ESKEIPVANE NA SINVOLI !!!!!!! 
                 
                 */

                






                //XML
                Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
                Console.WriteLine("XML:");



                /*
                   EXtensible Markup Language    TOVA E VERSIQTA PREDI DA IZLEZE JSON.
                   PO TEJUK E, PO STAR E, PO GROZEN E I ZAEMA POVECHE PAMET.

                   JSON Obektite izleznaha kogato izlezna ezikut JAVASCRIPT.


                   XML Formata shte go sreshtame poveche v po stari sistemi.
                   XML e ezik koito opisva danni v daden vid, durji danni v nego i moje da 
                   gi transportira.

                   DIZAINA PRILICHA NA TOZI NA JSON OBEKT, PAK IMA Key I Value 
                   SAMOCHE POLZVA TAGOVE <...> KAKTO V HTML.

                   VAJNO !!! :
                   Vseki XML fail zapochva s edin tag koito se naricha prolog tag i e PURVIQ TAG.

                   IZGLEJDA TAKA :  <?xml version="1.0" encoding="UTF-8"?>
                   KAzvame kakva versiq e i kakuv encoding da polzvame s.

                   Ima samo dve versii  1.0   i   1.1  kato 1.1 e po starata versiq obache nqkoi kazvat che raboti po dobre.



                   XML IMA OGROMNA RAZLIKA S HTML ZASHTOTO HTML E ZA VIZUALIZACIQ NA WEB STRANICI 
                   A XML E METAEZIK KOITO OPISVASAMO DANNI A NE WEB DOKUMENTI.

                   PRILICHAT SI PO TOVA CHE I XML POLZVAT HTML TAGOVE

                   V XML NE MOJEM DA PRAVIM SINTAKTICHNI ILI DRUGI GRESHKI 
                   V HTML AKO NAPRAVIM DADENA GRESHKA BRAWSERA NI POKAZVA KUDE E.


                   Advantages of XML:
                       Mojem da go chetem i na oko.
                       Mojem da durjim v nego absolutno vsichko.
                       Mojem da opisvame danni v danni v danni ... zashtoto polzva durvovidna struktura.
                       Poddurja UNICODE.


                   Disadvantages of XML:
                       Prosto e poveche kod i e dva puti po tejuk.
                       Sled kato e po golqm Iska poveche mqsto v pametta.


                   VAJNO !!!!!! :
                       I XML i JSON obektite ne sa dobri za binary dada (grafika, video klipove, kartinki, snimki . . .) 
                       V JSON imame link kum tezi Binary danni, moje da sa nqkude v neta ili nqkude lokalno na nashiq kompiutur.

                */


                /*
                 Kak da parsvame XML danni v C# s Visual Studio ?   MNOGO E LESNO !!!!!
                 Polzvame LINQ to XML.
                 Mojem da tursim iz tqh da gi promenqme ...
                 Imame klasove koito ni go pozvolqvat tova kato:
                    1.XDocument  -  tova e durjo ot elementi 
                    2.XElement  -  opisva samo edin element


                 */
                
                

                string str = //Tuka v nachaloto ni trqbvat Double QUOTES DVA PUTI ZA DA STANE  !!!!
                    @"<?xml version=""1.0""?>  
                    <!-- comment at the root level -->
                    <Student>
                        <Name>Atanas</Name>
                        <Profession>Developer</Profession>
                        <Age>25</Age>
                        <Child>Dont have one yet</Child>
                    </Student>";

                //suzdavame si XDocument i polzvame metoda .Parse() koito chete ot string
                XDocument XMLdoc = XDocument.Parse(str);

                //IMAME I DRUG MEtod .Load($"PutDoFail");  KOITO CHETE OT FAIL.

                //Obache e hubavo da ne zarejdame ot failove a da polzvame promenlivi


                //VAJNO !!!!!!!!!!!!!!!!!
                //Sus Fail.ReadAllText("ImeNaFail");  MOJEM DA PROCHETEM KAKVO IMA V DADENIQ FAIL.
                //I mojem da slojim sudurjanieto na tozi fail v promenliva i da q podadem na .Parse() metoda !!!!


                //Vzimame vsichki elementi
                var rootElements = XMLdoc.Root.Elements();
                
                //Vseki element e ot tip XElement !!!!!!!!!!!!!!!!
                foreach (XElement Xelement in rootElements)
                {

                    /*VAJNO !!!
                     NULL COALESSING OPERATOR : Tova e SLEDNOTO: */

                    var name = Xelement.Element("naaaaaameeeee")?.Value ?? "Value not found !";
                    /*Ako ni vurne 'null' znachi da ni zapishe v promenlivata suobshtenieto ako ne da
                     si ni vurne stoinostta.*/

                    Console.WriteLine(name);

                    //Celiq element
                    Console.WriteLine($"Full element: {Xelement}");

                    //Printiram kontenta na elementa
                    Console.WriteLine($"Value of element: {Xelement.Value}");

                    //element.Document  Printira celiq document v koito se sudurja tozi element
                    //Mojem da printirame oshte mnogo neshta svurzani s tozi element !
                }




                Console.WriteLine(); Console.WriteLine();
                Console.WriteLine("Promenqne na elementi v XML fail: SetElementValue()");
                /*
                   Mojem da promenqme, triem i suzdavame danni.     
                   SetElementValue() e za promenqne na stoinostta na dannite.
                */


                //Mojem da polzvame LINQ za da vzimame dadeni elementi: 
                //Vzimame po imeto na taga
                var nameTag = rootElements.Where(re => re.Name == "Name");
                Console.WriteLine(nameTag.First());

                //vzimme po value na taga
                var profession = rootElements.Where(re => re.Value == "Developer");
                Console.WriteLine(profession.First());


                foreach (XElement Xelement in rootElements)
                {

                    if (Xelement.Value == "Atanas")
                    {    
                        Xelement.SetElementValue("Name", "Nasko");
                        //Bi tRQBVALO DA RABOTI KATO IMAME ELEMENT V ELELENT

                        //Moje i da gi promenim taka:
                        Xelement.Value = "Kambitov";
                        
                    }


                    if (Xelement.Value == "25")
                    {
                        Xelement.Value = "5";
                    }

                    
                    //S .Remove(); triem elementi.
                    if (Xelement.Value == "Developer")
                    {
                        Xelement.Remove();
                        //Veche tozi element go nqma
                    }

                    //Mojem da promenqme attributi s .Attribute


                    Console.WriteLine($"Full element: {Xelement}");

                    Console.WriteLine($"Value of element: {Xelement.Value}");

                }


                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
                Console.WriteLine("Create XML document !");

                
                //Suzdavane na XML Document 
                XDocument xmlDoc = new XDocument();



                //PRI SUZDAVANETO MOJEM DA IZVAJDAME NESHTATA V PROMENLIVI, SHTE STANE
                var bookAuthor = new XElement("author", "Don Box");


                // I sega go pulnim s danni:
                xmlDoc.Add(
                    new XElement("books",
                    new XElement("book", 
                    bookAuthor,
                        new XElement("title", "ASP.NET", new XAttribute("lang", "en"))
                        )));
                //Slojihme optional attribute !!!


                //Printirame si go na konzolata za da si go vidime !
                Console.WriteLine(xmlDoc);


                //MOJEM DA DOBAVIM Books V DOKUMENTA I POSLE V Books DA DOBAVQME NOVI Book i kum tqh da dobavqme Author i Title !!!



                //Kak da go seivnem v daden fail ? 
                //STAVA SAMO AKO FAILA NI E V SAMI PROEKT, MOJESH DA GO VIDISH V DQSNO
                xmlDoc.Save("dokument.xml");

                //Mojem da zapisvame i bez formatirane
                xmlDoc.Save("DokumentBezFormatirane.xml", SaveOptions.DisableFormatting);

            }
        }

        //Tuk zmaem che shte poluchim string 
        private static T DeserializeObject<T>(string obj)
        {
            var jsonBytes = Encoding.UTF8.GetBytes(obj);

            using (var stream = new MemoryStream(jsonBytes))
            {
                //Vsichko dotuk e ednakvo samoche tuk ne mu podavame tiput na obekta a obratnoto
                var serializer = new DataContractJsonSerializer(typeof(T));

                //Kastvame go um T i go vrushtame
                var objToReturn = (T)serializer.ReadObject(stream);
                return objToReturn;
            }


        }


        //Pravim go da e Generic za da moje da raboti sus vseki obekt, a ne samo s Product ili Manufacturer
        private static string SerializeObject<T>(T obj)
        {
            //Polzvame DataContractJsonSerializer na koeto mu podavame TIPUT na obekta.
            var jsonSerializer = new DataContractJsonSerializer(obj.GetType());


            /*Shte polzvame memory stream, ako isame da go zapishem v nqkoi fail shte
             polzvame FileStream(), moje i da go izprashtame nqkude v web*/

            using (var stream = new MemoryStream())
            {
                jsonSerializer.WriteObject(stream, obj);

                //Vzimame resultata ot tova 
                var result = Encoding.UTF8.GetString(stream.ToArray());

                return result;
            }
            
        }



        /*
         Summary: 
            1.JSON i XML Stavat za prenasqne na danni, mojem da gi preobrazuvame.
            2.Te sa CROSSPLATFORM koeto oznachava che ne e zaduljitelno da pishem na C#.
            3.Rabota s XDocument koeto e za parsvane suzdavane ne elementi i t.n.   
         */


    }
}
