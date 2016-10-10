<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>Exercice Ajax</title>

<script type="text/JavaScript" src="jquery-1.11.3.min.js"></script>

</head>

<body>   
<form method="post">
        <select name="Pays" id="Pays">
        <?php
            try
            {
				include ('Connexion.php');
				$reponse = $CNN->query('SELECT code_pays, nom_pays from tbl_pays');
				
				while ($donnees = $reponse->fetch())
				{
					echo '<option value="' . $donnees['code_pays'] . '">' . $donnees['nom_pays'] . '</option>';
				}
				$reponse->closeCursor();
            }
            catch (PDOexception $erreur)
            {
                echo 'Erreur : ' . $erreur->getMessage();	
			}
        ?>
        </select>
        <div id="txt_pays"></div>
    </form> 	
	<script>
		$(document).ready(function(){$("#Pays").change(ma_function);});
		function ma_function(){
			var choix = $("#Pays option:selected");
			var output = $.ajax(
			{
			  url : "liste_pays.php",
			  type : 'POST',
			  data : {code_pays:choix.val()},   
			  success : function(output)
						{
				 			$('#txt_pays').html(output);
						}			
			});
		}
	</script>
</body>
</html>