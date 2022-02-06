<?php
    $array = array(1, 2, 3, 4, 10, 11);

    $sum = 0;

    foreach ($array as &$value) {
        if ($value > 0 && $value <10){
            $sum = $sum + $value;
        }
    };

    print_r($array);
    echo "<br>sum:  $sum"
?>