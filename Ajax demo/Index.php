<?php
    //echo $_POST["code_pays"];
	//echo "Pays choisi : " . $_POST["code_pays"];
	include ('Connexion - Hostinger.php');
	if(isset($_POST))
	{
		$codePays = isset($_POST["code_pays"]) ? htmlentities($_POST["code_pays"]) : "Erreur!";
		$reponse = $CNN->prepare('CALL Province(:InCodePays)');
		$reponse -> bindparam('InCodePays', $codePays, pdo::PARAM_INT);
		$reponse->execute();
		echo "Province(s) : <br />";
		while ($donnees = $reponse->fetch())
		{
			echo $donnees['nom_province'] . '<br />';
		}
	}
?>