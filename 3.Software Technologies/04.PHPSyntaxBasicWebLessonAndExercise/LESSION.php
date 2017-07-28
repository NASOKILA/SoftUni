<!DOCTYPE html></DOCTYPE>

<html>
<head>
    <title>Training</title>
</head>
<body>


<h1>akfbawuiobaongvb</h1>
<?php

echo "<h3> This is from php logic.</h3>";

if (true)
{
    echo "<h5> This is true.</h5>";
}
else
{
    echo "<h5> This is else.</h5>";
}

?>


<h1>We can put html tags between php tags.</h1>

<ol>
    <?php
    for ($i = 1; $i <= 10; $i++) {
        ?>
        <li>This is an element of a list created with a php for cicle !</li>
        <?php
    }
    ?>
</ol>


<?php

/*V php ne pishem tipovete danni predi suzdavaneto na
 promenlivite, stva qsno ot stoinostta koqto i dadem.*/

$PromenlivaInt = 10;
$BolevaPromenliva = true;
$PromenlivaChar = 'y';
$StringovaPromenliva = "Az sum string";

echo "<h1> $StringovaPromenliva </h1>";
echo "<h2> $BolevaPromenliva </h2>";
echo "$PromenlivaInt";

echo "<br/>";    /* slagame nov red*/
echo "$PromenlivaChar";

echo "<br/>";

$strFname = "Atanas";
$strLname = "Kambitov";
echo "$strFname $strLname";

echo "<br/>";

/*Konkatenaciqta v php se pravi sus .  vmesto sus  +

  sus edinichni kavichki nqma da trugne echo samo sus dvoini !*/
echo '$strFname';   /* shte go prieme ne kato promenliva a kato prost string*/
echo "<br/>";
echo '<h1>' . $strFname . '</h1>';   /*Taka stava zashtoto go konkatenirame sus tochka*/
echo "<br/>";
echo '<p>' .$strLname. '</p>';

/* PHP i JAVASCROPT sa DINAMICHNI EZICI a C#  i  JAVA sa STATICHNO EZICI !!!
STATICHNITE ezici sa po lesni za proverka pri kompilaciq i analizaciq, toi kazva AZ SUM LIST OT INTOVE
a pri dinamichnite ezici tipovete se razbirat pri eksekuciqta.

Nedostatuka na Staticnite ezici e che ni ogranichava, v smisul che ako napravim edna promenliva da e int
nie sled tova ne mojem da q promenim v primerno string ili neshto drugo, TQ SI OSTAVA TAKAVA I TRQBVA DA
NAPRAVIM NOVA PROMENLIVA SLEDOVATELNO TE SE NATRUPVAT.
Pri dinamichniq ezik se iziskva po malko kod za da napravim sushtoto neshto i po lesno stava OBACHE NQMA
KOMPILATOR KOITO DA NI KAZVA KADE IMAME GRESHKA I KAKVA E TQ.
*/

echo "<br/>";

/*gettype ni vadi stoinostta na promenlivata NO NE NI TRQBVAT SKOBI.*/
echo gettype($BolevaPromenliva);

/*var_dump vadi informaciq za konkretna promenliva , tip, stoinost, mestopolojenie i oshte!*/
echo var_dump($BolevaPromenliva);
echo "<br/>";
echo var_dump($PromenlivaInt);


/* V dinamichnite ezici nishto ne ni podkazva dali nehto sushtestvuva, sledovatelno za tazi proverka
mojem da izpolzvame isset();
Sus unset(); triem dadena promenliva.
*/

$novaPromenliva = "Naso";
echo isset($novaPrdomenliva);  /*vrushta 1 ILI NISHTO*/

unset($novaPromenliva);
echo isset($novaPromenliva);



/*Imame Switch case i if else            STIGNAH DO     1:24 */
?>


<?php

$month = date("m");
/*Shte mi vurne segashniq mesec obache kato datetime, za da e kato chislo
  trqbva da go parsnem sus intval(); */
echo $month;
echo "<br/>";
echo intval($month);
echo "<br/>";

// stava i po sledniq nachin
$today = intval(date("d"));
echo $today;

echo "<br/>";
echo "<br/>";
?>


<?php



// ciklite sa sushtite
for ($a = 0;$a <= 5; $a++)
{
    echo "<div>$a</div>";
}

echo "<br/>";

$n = 0;
while ($n < 10)
{
    echo "<div>$n<div/>";
    $n++;
}

// imame do while i foreach SAMOCHE VUV FOREACH PURVO KAZVAME KOLEKCIQTA A POSLE PROMENLIVATA !


?>

<?php

echo "<br/>";
// masivi:
$numbers = array(1, 2, 3);
//moje i taka:
$moreNumbers = [4, 5, 6];

foreach ($numbers as $num)
{
    echo "<div>$num</div>";
}

echo "<br/>";
echo "<br/>";
echo "<br/>";
?>

<h1>Zd1 chislata ot 1 do 20</h1>


<ul>
    <?php
    //Vsqka chetna e zelena a vsqka nechetna e sinq !

    for ($i = 0; $i<=20;$i++)
    {
        if($i % 2 == 0){
            $color = "green";
        }
        else{
            $color = "blue";
        }

        echo "<li style ='color: $color'>$i</li>";
        // mojem da polzvame promenlivite i kato css

    }

    echo "<br/>";
    echo "<br/>";
    echo "<br/>";
    ?>
</ul>



<h1>Zadacha 2 </h1>

<style>
    div{

        width: 450px;
    }
</style>

<?php
for ($red = 0; $red <=255; $red = $red+51) {
    for ($green = 0; $green <= 255; $green = $green + 51) {
        for ($blue = 0; $blue <= 255; $blue = $blue + 51) {
            echo "<div style='padding: 10px; margin: 10px; 
                        background-color: rgb($red, $green, $blue)'>
                        
                        rgb($red, $green, $blue)
                        </div>";

        }
    }
}

echo"<br/>";
echo"<br/>";
echo"<br/>";
?>



<h1>Zadacha 3 Obrabotvane na formichki </h1>

<?php

if(isset($_GET['person']))
{
    $personName = $_GET['person']; //setvame promanliva = na getPerson
    echo "<h1>Hi, $personName</h1>";
}
else {

    ?>

    <form >
        Name: <input type = "text" name = "person" />
        <input type = "submit" />
    </form >

<?php }?>

<br/>
<br/>
<h1>Zadacha 4</h1>

<form>
    Name: <br/>
    <input type="text" name="person"/>
    <br/>
    Age: <br/>
    <input type="number" name ="age"/>
    <br/>
    Town: <br/>
    <select name="townId">
        <option value="1">Sofia</option>
        <option value="2">Plovdiv</option>
        <option value="3">Varna</option>
        <option value="4">Blagoevgrad</option>
    </select>
    <br/>
    <input type="submit"/>
</form>

<?php

var_dump($_GET);

?>
<br/><br/>



<h1>Zadacha 5 Subirane na dve chisla</h1>


<form>
    First Number: <br/>
    <input type="number" name="num1"/>
    <br/>
    Second Number: <br/>
    <input type="number" name="num2"/>
    <br/>
    <input type="submit"/>
</form>

<?php
// ot MASIVA GET VADIM INFORMACIQTA
if(isset($_GET['num1']) && isset($_GET['num2'])){ // ako nomerata sushtestvuvat
    $num1 = intval($_GET['num1']); // parsvame gi
    $num2 = intval($_GET['num2']);

    $sum = $num1 + $num2; // subirame gi !
    echo "$num1 + $num2 = $sum";
}
?>

<br/><br/><br/>




<h1>Funkcii v PHP, te sa kato metodi v C#</h1>
<br/>

<?php
function Sum(int $a, int $b) :int
{
    // MOJEM DA NAPISHEM KAKUV TIP PARAMETRI ISKAME DA IMA TAQ FUNKCIQ
    // SUS :int KAZVAME KAKVO DA VRUSHTA  NO SAMO AKO ISKAME

    return $a + $b;
}

// Taka sa izvikva
echo Sum(3, 8) . "<br/>";
echo Sum(5, 2) . "<br/>";

?>
<br/><br/><br/>


<h1>Zadacha 6</h1>

<form>
    Celsius: <br/>
    <input type="number" name="celsius"/>
    <input type="submit" />



    <?php
    function celsiusToFahrenheit($celsius)
    {
        return $celsius * (9 / 5) + 32;
    }

    if(isset($_GET['celsius'])){
        $celsius = floatval($_GET['celsius']);
        // ako celsius sushtestvuva go kastvame v promenliva s floatval()


        $fahrenheit = celsiusToFahrenheit($celsius);
        // i setvame fahrenheit chrez funkciqta
        echo "$celsius &deg;C = $fahrenheit &deg;F";
    }

    ?>
</form>

<form>

    Fahrenheit: <br/>
    <input type="number" name="fahrenheit"/>
    <input type="submit" />


    <?php

    function fahrenheitToCelsius($fahrenheit){
        return ($fahrenheit - 32) / 1.8;
    }

    if(isset($_GET['fahrenheit'])){
        $fahrenheit = floatval($_GET['fahrenheit']);

        $celsius = fahrenheitToCelsius($fahrenheit);

        echo "$fahrenheit &deg;F = $celsius &deg;C";
    }
    ?>

    <form/>



    <h1>KOLEKCII i MASIVI</h1>
    <p>Imame 2 metoda koito se kazvat implode i explode koito sa kato
        split i join v C# Ednoto kombinira a drugoto vadi</p>


    <?php
    $towns = array('Sofia', 'Varna', 'Burgas');
    echo $towns[1] . "<br/>";
    echo implode(", ", $towns). "<br/>";  // raboti kato join()

    echo "<br/>";

    for ($o=0;$o < count($towns); $o++)
    {
        echo $towns[$o] . "<br/>";
    }

    echo "<br/>";
    // explode raboti vurhu textove  i  e TOCHNO KATO split()
    $text = "Nasko, Asi, Toni, Toshko";
    $towns = explode(', ', $text);
    foreach ($towns as $t)
    {
        echo $t . "<br/>";
    }


    // V php count si e count
    // $ImeNaMasiv [] = 1; TOVA DOBAQ ELEMENT NA MASIV
    //TUK VSICHKO E DINAMICHNO TOEST MASIVITE SA KATO SPISUCITE .

    echo "<br/>";echo "<br/>";echo "<br/>";
    ?>





    <h1>Zadacha 7 Sortirane na elementi</h1>

    <?php
    $sortedLines = ""; // prazen string
    if(isset($_GET['lines'])){ // lines e imato na textareata!
        $lines = explode("\n", $_GET['lines']); //splitvame sus nov red
        $lines = array_map('trim',$lines); // TAKA trimvame sus array_map();
        sort($lines, SORT_STRING);
        // KAZVAME CHE SORTIRAME STRINGOVE ZASHTOTO MOJE DA SUSURJA I INTOVE I BOOLEAN I DR.
        // TUK MOJEM DA DOBAVQME KAKVOTO SI ISKAME, PHP NE E TIPIZIRAN EZIK
        $sortedLines = implode("\n", $lines);// joinvame sus nov red i zapisvame v $sortedlines
    }
    ?>

    <form>
        <textarea rows="10" name="lines"><?=$sortedLines?></textarea>
        <!-- TAKA PRIEMAME STOINOSTTA NA $sortedLines v TEXTAREATA -->
        <br/>
        <input type="submit" value="Sort"/>
    </form>
    <br/><br/><br/>

    <h1>Rechnici ili Asiociativni masivi</h1>

    <?php
    // V sintaksisa se izpolzva strelka !
    $ages = ['Pesho' => 10, 'Naso' => 20, 'Asen' => 25];
    echo $ages['Pesho'];
    echo "<br/>";
    echo $ages['Ivan'] = 30; // mojem prosto da si suzdadem nov element
    echo "<br/>";
    echo $ages['Ivan'] += 40; // dobavqme kum ivan 40 godini
    echo "<br/>";
    echo "<br/>";

    foreach ($ages as $key => $value)
    {
        echo $key . " ";
        echo $value;
        echo "<br/>";
    }

    echo "<br/>";

    echo var_dump($ages);
    // VIJDAME CHE E MASIV TUK VSICHKO E MASIV I SPISUKA I RECHNIKA!
    echo "<br/>";

    //strtolower(); pravi daden tekst da e s malki bukvi !
    echo strtolower('NASOKILA');
    echo "<br/>";
    echo strtoupper('nasokila');

    echo "<br/>";echo "<br/>";
    ?>



    <h1>Classes and Objects</h1>


    <?php

    class Person
    {
        private $name;
        private $age;

        // za da gi setnem ni trqbvba konstruktor !

        function __construct($name, $age)
        {
            $this->name = $name;
            $this->age = $age;
        }

        // ZA da iznesem informaciata tuk ne pishem get; set; a pishem funkciq:

        function setName(){
            return $this->name;   // $ e izneseno pred 'this'
        }

        function setAge(){
            return $this->age;
        }

    } // suzdavame klas sus ime i godini



    $person = new Person('Atanas', '24');  // tova e instanciq na tozi klas

    $name = $person->setName(); // TAKA VZIMAME IMETO !
    $age = $person->setAge(); // TAKA VZIMAME I GODINITE !

    // MOJEM DA GI VZEMEM I SUS FUNKCVIQ !

    echo $name;
    echo "<br/>";
    echo $age;
    echo "<br/>";


    // SUS include.php MOJEM DA VKARAME EDIN PHP KOD OT DRUG FAIL V TOZI.
    // PRIMERNO include(ImeNaFail.php);
    ?>





    <br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>
</body>
</html>





