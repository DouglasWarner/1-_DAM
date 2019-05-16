(: F :)

<html>
<head>
	<title>Ejercicio 1 F</title>
</head>
<body>
	<h1>Ejercicio 1 F</h1>
	<table>
		<tr>
			<th>Profesor</th>
			<th>Baile</th>
			<th>Sala</th>
			<th>Plazas</th>
		</tr>
		<tr>{for $resultado in doc("D:\Users\alumno1718\Desktop\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio1_Bailes.xml")//baile
		 return <td> {($resultado/profesor,$resultado/nombre,$resultado/sala,$resultado/plazas)} </td>
		}</tr>
	</table>
</body>
</html>
