<?php

$files = glob('C:/MAMP/htdocs/test/*');
foreach($files as $file){
  if(is_file($file) && filesize($file) > pow(10, 6)){
    echo "$file deleted<br>";
    unlink($file);
  }
}

?>