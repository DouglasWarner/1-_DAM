(: N Crear una tabla HTML con los títulos de todos los libros del documento:)
<html>
<head>
<title>Ejercicio 2 N</title>
</head>
<body>
<h1>Ejercicio 2 N</h1>
<h2>Títulos de libros</h2>

	<table border="1">
	<tr>
		<th>Título</th>
	</tr>
	{for $libro in doc("C:\Users\metho\OneDrive\Escritorio\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 2\Biblioteca.xml")//libro

	return
	<tr>
		<td>{$libro//titulo}</td>
	</tr>}
	</table>
</body>
</html>
