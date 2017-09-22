<!DOCTYPE html>

<html>
    <head>

    </head>
    <body>

        <form>
            N: <input type="text" name="num" />

            <input type ="submit" />
            <br/>


            <?php
            if(isset($_GET['num']))
            {
                $n = intval($_GET['num']);
            }
            $result = $n * 2;
            echo $result;
            ?>

        </form>

    </body>
</html>