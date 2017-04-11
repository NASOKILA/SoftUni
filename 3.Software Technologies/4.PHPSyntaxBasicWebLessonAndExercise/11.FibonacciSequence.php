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

    $seq = 1;
    $result = 1;
    echo $seq;
    echo " " . $seq . " ";
    for ($i = 1; $i <= $n-2;$i++)
    {
        $result = $seq + $result;
        echo $result . " ";
        $seq = $result - $seq;

    }

    ?>

</form>
</body>
</html>