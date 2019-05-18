(: F Crear un XHTML cuyo resultado sea una tabla que nos muestre los siguientes datos: Nombre del profesor,
nombre del baile, nº de la sala y plazas ofertadas :)

<html>
<head>
	<title>Ejercicio 1 G</title>
</head>
<body>
	<h1>Ejercicio 1 G</h1>
	<table border="1">
		<tr>
			<th>Profesor</th>
			<th>Baile</th>
			<th>Sala</th>
			<th>Plazas</th>
		</tr>

	{for $resultado in doc("C:\Users\metho\OneDrive\Escritorio\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 1\Ejercicio1_Bailes.xml")//baile
	return
	<tr>
		<td>{$resultado/profesor}</td>
		<td>{$resultado/nombre}</td>
		<td>{$resultado/sala}</td>
		<td>{$resultado/plazas}</td>
	</tr>		
	}
		
	</table>
</body>
</html>
