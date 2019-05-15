(: F :)
<html>
	<head>
		<title>Ejercicio 1 F</title>
	</head>
	<body>
		<h1>Ejercicio 1 F</h1>
		<table>
			<tr>
				<thProfesor></th>
				<th>Baile</th>
				<th>Sala</th>
				<th>Plazas</th>
			</tr>
			<tr>
			{ $resultado in doc("D:\Users\alumno1718\Desktop\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio1_Bailes.xml")/Bailes/baile
				<td>{data($resultado/profesor)}</td>
				<td>{data($resultado/nombre)}</td>
				<td>{data($resultado/sala)}</td>
				<td>{data($resultado/plazas)}</td>
			}
			</tr>
		</table>
	</body>
</html>
