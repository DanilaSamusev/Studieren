<?php

$firstKey = 1;
$secondKey = 4;

$a = "19 1 32 19 5 7 5 41 2 6";

$array = array_map('intval', explode(" ", $a));

$firstNumber = $array[$firstKey];
$secondNumber = $array[$secondKey];

$b = 0;

if ($firstNumber <= 5 && $secondNumber <= 5){
    $b = $firstNumber + $secondNumber;
};

if ($firstNumber >= 9 && $secondNumber >= 9){
    $b = $firstNumber - $secondNumber;
}

echo $b;

?>