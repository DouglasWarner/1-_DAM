(: G Listar los títulos de los libros con más de un autor:)
for $libro in doc("C:\Users\metho\OneDrive\Escritorio\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 2\Biblioteca.xml")//libro
where count($libro//autor)
return $libro/titulo