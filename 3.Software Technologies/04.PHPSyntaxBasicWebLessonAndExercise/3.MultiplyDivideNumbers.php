<!DOCTYPE html>

<html>
<head>

</head>
<body>
<form>
    N: <input type="text" name="num1"/>
    M: <input type="text" name="num2"/>
    <input type="submit" value="Send"/>

    <?php

    if(isset($_GET['num1']))
    {
        if(isset($_GET['num1']))
        {

            $n = intval($_GET['num1']);
            $m = intval($_GET['num2']);
            if($n > $m)
            {
                $result = $n / $m;
            }
            else
            {
                $result = $n * $m;
            }
        }
    }


    echo "<br/>" . $result;

    ?>

</form>
</body>
</html>