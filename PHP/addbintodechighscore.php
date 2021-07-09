<?php
$configs = include('config.php'); //Collects the database connection information



$conn = new mysqli($servername, $username, $password, $dbname); //Makes connection

if ($conn->connect_error) {
    die('1: Connection Failed');
}

//Retrieves data from unity 
$playerName = $_POST["Player"];
$score = $_POST["Score"];


$insertPlayer = "INSERT INTO bintodechighscores ( name, score) VALUES ('" .$playerName. "' , '" .$score. "')";//Query to Insert data into database 

$stmt  = $conn -> stmt_init();

//Prepare query
$stmt -> prepare($insertPlayer);

$stmt -> bind_param('si', $playerName, $score);
$stmt -> execute(); //Executes query

$result = $stmt -> get_result() or die ('2: insert player');
    

$stmt -> close();

$mysql -> close(); //Closes connection
?>