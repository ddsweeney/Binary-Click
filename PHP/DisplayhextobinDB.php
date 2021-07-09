<?php
$configs = include('config.php'); //Collects the database connection information



$conn = new mysqli($servername, $username, $password, $dbname); //Makes connection

if ($conn->connect_error) {
    die('1: Connection Failed');
}

//Request the data
$name = $_REQUEST['name'];
$score = $_REQUEST['score'];

$sql = "SELECT name, score FROM hextobinhighscores ORDER BY score DESC LIMIT 5";//Selects the data from the correct table 


$stmt  = $conn -> stmt_init();

//Prepared statement for the query
if ($stmt -> prepare($sql)){

    $stmt -> bind_param('si', $name, $score);
    $stmt -> execute();

    $result = $stmt -> get_result() or die ('2: Failed load');

    //Formats data into a table format
    if ($result->num_rows > 0) {
        while($row = $result->fetch_assoc()) {
            echo $row['name']." ".$row['score']." ";
        }
    }
    else {
            echo $row['']." ".$row['']." ";;
        }

}
$stmt -> close();

//closes connection
$conn->close();
?>