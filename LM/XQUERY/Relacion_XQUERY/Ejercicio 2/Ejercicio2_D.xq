(: D Listar el título y precio de los libros cuyos precios sean inferiores a 45 euros:)
for $libro in doc("C:\Users\metho\OneDrive\Escritorio\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 2\Biblioteca.xml")//libro
where $libro/precio < 45
return ($libro/titulo, $libro/precio)