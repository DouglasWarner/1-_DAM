(: G Queremos hacer lo mismo que el ejercicio anterior pero mostrando los que cumplan que la cuota es mensual
y ordenados por el nº de plazas:)

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
	where $resultado/precio/@cuota = "mensual"
	order by $resultado/plazas
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
