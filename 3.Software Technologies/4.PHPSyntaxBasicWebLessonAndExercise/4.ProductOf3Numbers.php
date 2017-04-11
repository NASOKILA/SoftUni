<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Title</title>
</head>
<body>

<form>

    N1: <input type="number" name="num1"/>
    N2: <input type="number" name="num2"/>
    N3: <input type="number" name="num3"/>
    <input type="submit" value="Send" />

    <?php
    if(isset($_GET['num1']) && isset($_GET['num2']) && isset($_GET['num3']))
    {
     $n1 = intval($_GET['num1']);
     $n2 = intval($_GET['num2']);
     $n3 = intval($_GET['num3']);

        if(count()){}
       /*  if($n1 >= 0 && $n2 < 0 && $n3 < 0)
            echo "<br/>" . "positive";
         else if($n1 < 0 && $n2 >= 0 && $n3 < 0)
            echo "<br/>" . "positive";
         else if($n1 < 0 && $n2 < 0 && $n3 >= 0)
             echo "<br/>" . "positive";
         else if($n1 >= 0 && $n2 >= 0 && $n3 >= 0)
            echo "<br/>" . "positive";
         else if($n1 < 0 && $n2 < 0 && $n3 < 0)
            echo "<br/>" . "negative";
         else
             echo "<br/>" . "negative";*/
    }

    ?>

</form>

</body>
</html>