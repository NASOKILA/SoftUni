<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Title</title>
</head>
<body>
<form>
    N: <input type="number" name="num1"/>
    M: <input type="number" name="num2"/>
    <input type="submit"/>


</form>
<ul>
    <?php

    if(isset($_GET['num1']) && isset($_GET['num2']))
    {
        $n = intval($_GET['num1']);
        $m = intval($_GET['num2']);
    }


    for ($i = 1; $i <= $n; $i++) {

        echo "<li>" . "List " . $i . "\n";
        echo "\t\t<ul>\n";
        for ($t = 1; $t <= $m; $t++) {
            echo "\t\t\t<li>Element $i.$t</li> \n";
        }
        echo "\t\t</ul>\n";
        echo "\t</li>\n";


    }
    // SLAGAME TABULACII ZA DA IZGLEJDA KODA MNOGO PO DOBRE I LESEN ZA CHETENE ! NE E ZADULJITELNO !
    ?>
</ul>

</body>
</html>







