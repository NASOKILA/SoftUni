<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Title</title>
    </head>
    <body>

    <form>
            N: <input type="text" name="num1"/>
            M: <input type="text" name="num2"/>

            <input type="submit" value="Send">

            <?php
            if(isset($_GET['num1']))
            {
                if(isset($_GET['num2']))
                {
                 $n = intval($_GET['num1']);
                 $m = intval($_GET['num2']);
                 $result = $n * $m;
                }
            }
            echo $result;

            ?>
        </form>

    </body>
</html>