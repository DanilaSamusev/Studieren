<?php

for($i=0;$i<30;$i++){
    $mas[]=rand(1, 10);
};

print_r($mas);

$sqrts = [];

for($i=0;$i<30;$i++){
    array_push($sqrts, sqrt($mas[$i]));
};

echo "<br> sqrts: ";
print_r($sqrts);

ceilAndFloor($sqrts);

function ceilAndFloor($sqrts){
    $resultArray = [
        "floor" => [],
        "ceil" => []
    ];
    
    $floor = [];
    for($i=0;$i<30;$i++){
        array_push($floor, floor($sqrts[$i]));
    };
    
    $ceil = [];
    for($i=0;$i<30;$i++){
        array_push($ceil, ceil($sqrts[$i]));
    };
    
    $resultArray["floor"] = $floor;
    $resultArray["ceil"] = $ceil;
    
    echo "<br><br> floor: ";
    print_r($resultArray["floor"]);
    echo "<br><br> ceil: ";
    print_r($resultArray["ceil"]);
}

?>