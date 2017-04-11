
        <?php

        $rgb = 0;


        for ($row = 1; $row <= 5; $row++) {
            for ($col = 1; $col <= 10; $col++) {

                echo "<div style=\"background-color: rgb($rgb, $rgb, $rgb);\"></div>";
                $rgb += 5;
            }


            $rgb ++;

            echo "<br>";
        }
        ?>

