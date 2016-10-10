<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>Regular Expressions avec Formulaire</title>

<script src="jquery-validation-1.14.0/lib/jquery-1.11.1.js"></script>
<script src="jquery-validation-1.14.0/dist/jquery.validate.min.js"></script>
<script src="jquery-validation-1.14.0/dist/localization/messages_fr.js"></script>
<link rel="stylesheet" href="jquery-validation-1.14.0/demo/marketo/stylesheetperso.css"/>

</head>

<body>
<div class="main-content">
<h1>Formulaire</h1>
<legend>renseignements</legend>
<form id="mon_formu" name="mon_formu" methode ="post" action="autrepage.php">
    <fieldset>
        <section>
            <label for="AddEmail">Email</label>
            <input id="AddEmail" name="AddEmail" type="text"/>
        </section>
        <section>
            <label for="Tel">Téléphone</label>
            <input id="Tel" name="Tel" type="text"/>
        </section>
        <div class="buttonSubmit">
            <input type="submit" value="Envoyer">
        </div>
    </fieldset>
</form>
</div>
<script>
$("#mon_formu").validate({
	rules:{ 
		AddEmail:{ 
			required : true,
			email : true,
			regexp_mon_mail : true},
		Tel:{ 
			required : true,
			regexp_mon_tel : true},
	},
	messages:{
		AddEmail:{ required : "Email obligatoire!",
				email : "Doit respecté le format d'un email!",
				regexp_mon_mail : "Mauvais format mail!"}, 
		Tel:{ required: "Téléphone obligatoire",
				regexp_mon_tel : "Mauvais format tel"}
	}
	});
$.validator.addMethod("regexp_mon_tel", 
		function (value, element){
			return this.optional(element) || /^\(([0-9]{3})\)\s+([0-9]{3})\-([0-9]{4})$/.test(value);
			}, 'Doit avoir deux nombres');
$.validator.addMethod("regexp_mon_mail", 
		function (value, element){
			return this.optional(element) ||  /^[a-zA-Z0-9._-]+[@][a-z0-9.-]{2,}[.][a-zA-Z]{2,4}$/.test(value);
			}, 'Doit avoir deux nombres');

</script>
</body>
</html>