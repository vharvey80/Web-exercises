<?php
	try
	{
		$CNN = new PDO('mysql:host=localhost;dbname=bd_mondial', 'root', '');
		$CNN->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
	}
	catch (PDOexeption $erreur)
	{
		echo 'Erreur :' .$erreur->getMessage();
	}
?>
