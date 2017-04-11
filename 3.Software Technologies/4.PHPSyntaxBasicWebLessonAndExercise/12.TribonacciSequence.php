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

    $seqOne = 1;
    $seqTwo = 1;
    $resultOne = 2;
    echo $seqOne;
    echo " " . $seqTwo . " ";
    echo $resultOne . " ";
    for ($i = 1; $i <= $n-3;$i++)
    {
        $result = $seqOne + $seqTwo + $resultOne;
        echo $result . " ";
        $seqOne = $seqTwo;
        $seqTwo = $resultOne;
        $resultOne = $result;
    }

    ?>

</form>
</body>
</html>