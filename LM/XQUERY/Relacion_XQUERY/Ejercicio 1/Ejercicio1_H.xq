(: H Mostrar en una tabla de XHTML los siguientes datos: N� de l�nea, nombre del baile, fecha inicio
(dd/mm/aaaa), fecha finalizaci�n (dd/mm/aaaa) y precio-moneda.:)

<html>
<head>
	<title>Ejercicio 1 G</title>
</head>
<body>
	<h1>Ejercicio 1 G</h1>
	<table border="1">
		<tr>
			<th>N� de l�nea</th>
			<th>Nombre</th>
			<th>Fecha inicio</th>
			<th>Fecha fin</th>
			<th>Precio-Moneda</th>
		</tr>

	{for $resultado in doc("C:\Users\metho\OneDrive\Escritorio\1�_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 1\Ejercicio1_Bailes.xml")//baile
		
	return
	<tr>
		<td>{data($resultado/@id)}</td>
		<td>{$resultado/nombre}</td>
		<td>{$resultado/comienzo}</td>
		<td>{$resultado/fin}</td>
		<td>{($resultado/precio, data($resultado/precio/@moneda))}</td>
	</tr>		
	}
		
	</table>
</body>
</html>
