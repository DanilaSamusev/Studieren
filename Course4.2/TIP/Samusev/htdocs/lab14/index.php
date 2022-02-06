<?php
    echo 'Hello, \n World!   ';
    echo "Hello,\f World!   ";
    echo <<<END
      a
     b
    c
    END;

    $array = array(
        "1" => "bar",
        "2" => "foo",
    );

    echo "<br>";
    echo $array;

    echo "<br>";
    print $array;

    echo "<br>";
    print_r($array);

    echo "<br>";
    echo serialize($array);

    # (6) 6, 18, 30, 42
    echo "<br> ltrim: <br>";
    echo ltrim("    These are a few words :) ...  ");

    echo "<br> str_split: <br>";
    print_r(str_split("These are a few words"));

    echo "<br> strrev: <br>";
    echo strrev("These are a few words");

    echo "<br> trim: <br>";
    echo trim("   These are a few words   ");
?>