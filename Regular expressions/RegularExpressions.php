<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>Regular Expressions</title>
</head>

<body>
	<?php
		$chaine = "HALS12345678";
		$regex = "#^[a-zA-Z]{4}[0-9]{8}$#"; //	"#^[a-zA-Z]{4}\d{8}$#"; --> \d correspond aux chiffres
		if (preg_match($regex,$chaine) == true)
			echo "La chaîne de caractère est valide!"; 
		else
			echo "La chaîne de caractère n'est pas valide...";
	?>
</body>
</html>