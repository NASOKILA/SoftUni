<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
</head>
<body>
<?php

for ($i = 1; $i <= 5; $i++) {
    echo "<button style='background-color: blue;'>1</button>";
}
for ($a = 1; $a <= 3; $a++) {

    echo "<br/>";
    echo "<button style='background-color: blue;'>1</button>";
    for ($t = 1; $t <= 4; $t++) {
        echo "<button>0</button>";
    }
}
echo "<br/>";
for ($i = 1; $i <= 5; $i++) {
    echo "<button style='background-color: blue;'>1</button>";
}
for ($a = 1; $a <= 3; $a++) {

    echo "<br/>";

    for ($t = 1; $t <= 4; $t++) {
        echo "<button>0</button>";
    }
    echo "<button style='background-color: blue;'>1</button>";
}
echo "<br/>";
for ($i = 1; $i <= 5; $i++) {
    echo "<button style='background-color: blue;'>1</button>";
}

?>

<br/><br/><br/><br/>

<!-- STAVA I PO SLEDNIQ NACHIN-->

<?php

    $buttons = [
        [1,1,1,1,1],
        [1,0,0,0,0], [1,0,0,0,0], [1,0,0,0,0],
        [1,1,1,1,1],
        [0,0,0,0,1], [0,0,0,0,1], [0,0,0,0,1],
        [1,1,1,1,1]
    ];

for ($row = 0; $row < count($buttons); $row++) {

    for ($col = 0; $col < 5; $col++) {

        $currentElement = $buttons[$row][$col];
        if($currentElement == 1)
        {
            echo "<button style='background-color: blue'>1</button>";
        }
        else
        {
            echo "<button>0</button>";
        }

    }
    echo "<br/>";
}

?>

</body>
</html>




