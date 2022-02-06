<?php
    $faculties = array(
        array(
            array(
                "A" => [],
                "Б" => []
            ),
            array(
                "Д" => [],
                "Ж" => []
            )
        ),
        array(
            array(
                "В" => [],
                "Е" => []
            ),
            array(
                "Ю" => [],
                "И" => []
            )
        )
            );

$names = array();

foreach ($faculties as $faculty)
{
    foreach ($faculty as $cavedra)
    {
        foreach ($cavedra as $name => $value)
        {
            array_push($names, $name);
        }
    }
}

asort($names);

foreach ($names as $key => $val) {
    echo "$val ";
}

?>