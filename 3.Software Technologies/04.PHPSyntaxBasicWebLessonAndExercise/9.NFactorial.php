<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Title</title>
</head>
<body>


<form>
    N: <input type="number" name="num"/>
    <input type="submit"/>

    <?php
        if(isset($_GET['num']))
        {
            $n = intval($_GET['num']);
        }
        $fact = 1;
        for($i = $n;$i>0;$i--)
        {
           $fact *= $i;
        }
        echo $fact;

    ?>

</form>


</body>
</html>