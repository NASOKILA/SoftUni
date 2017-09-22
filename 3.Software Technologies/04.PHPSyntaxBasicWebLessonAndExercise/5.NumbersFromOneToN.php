<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Title</title>
</head>
<body>

<form>
    N: <input type="number" name="num"/>
    <input type="submit" />

    <?php
        if(isset($_GET['num']))
        {
            $n = intval($_GET['num']);
        }


        for ($i = 1; $i <= $n;$i++)
        {
           echo ' '.$i;
        }
    ?>

</form>

</body>
</html>