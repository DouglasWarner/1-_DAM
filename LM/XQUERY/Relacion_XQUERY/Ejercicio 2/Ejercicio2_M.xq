(: M Listar todos los libros que tengan al menos un autor:)
for $libro in doc("C:\Users\metho\OneDrive\Escritorio\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 2\Biblioteca.xml")//libro
where count($libro//autor) > 0
return $libro