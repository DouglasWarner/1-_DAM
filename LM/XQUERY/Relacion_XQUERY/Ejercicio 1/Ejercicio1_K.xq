(: K Crea un documento XHTML con los datos obtenidos en el ejercicio (j) y muestra un informe en una tabla,
ponle un título “Estadísticas de los precios de los bailes”, con letra grande. Para obtener los resultados no se
distingue entre $ y €.:)

<html>
<head>
<title>Ejercicio 1 K </title>
</head>
<body>
<h1>Ejercicio 1 K</h1>

<table border="1">
<caption><h3>Estadísticas de los precios de los bailes</h3></caption>
<tr>
<th>suma</th>
<th>media</th>
<th>maximo</th>
<th>minimo</th>
</tr>

	{
	let $resultado := doc("C:\Users\metho\OneDrive\Escritorio\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 1\Ejercicio1_Bailes.xml")//precio
	return
	<tr>
	  <td>{sum($resultado)}</td>
	  <td>{avg($resultado)}</td>
	  <td>{max($resultado)}</td>
	  <td>{min($resultado)}</td>
	</tr> }
</table>


</body>
</html>