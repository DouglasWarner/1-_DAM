(: F :)

<html>
<head>
	<title>Ejercicio 1 F</title>
</head>
<body>
	<h1>Ejercicio 1 F</h1>
	<table border="1">
		<tr>
			<th>Profesor</th>
			<th>Baile</th>
			<th>Sala</th>
			<th>Plazas</th>
		</tr>

	{for $resultado in doc("C:\Users\metho\OneDrive\Escritorio\1�_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio1_Bailes.xml")//baile
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
