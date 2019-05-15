<html>
<head>
<title>Ejemplo 1 de XQUERY</title>
</head>
<body>
<h1>Listado de libros de biblioteca</h1>
<hr/>
<ul>
{
for $libro in doc("D:\Users\alumno1718\Desktop\Editor xQuery + biblioteca_xml\biblioteca.xml")/biblioteca/libro
where $libro/precio >= 30
order by $libro/titulo descending
return <il>{
	if($libro/@categoria="Informatica")
	then data($libro/titulo)
	else data($libro/precio)}</il>
}
</ul>
</body>
</html>