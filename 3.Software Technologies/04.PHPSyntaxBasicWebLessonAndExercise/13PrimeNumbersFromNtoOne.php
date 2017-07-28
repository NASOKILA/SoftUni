
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" />
</form>
<?php
if(isset($_GET['num']))
{
    $n = intval($_GET['num']);
}

for ($i = $n; $i > 1; $i--) {

    if ($i % 2 == 1 && ($i % 3 == 1 || $i % 3 == 2))
    {

        echo $i . " ";
    }
    else if($i == 3 || $i == 2)
        echo $i . " ";
}


?>
</body>
</html>



























