(: H Obtener el título y el año de todos los libros publicados después del año 2000:)
for $libro in doc("C:\Users\metho\OneDrive\Escritorio\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 2\Biblioteca.xml")//libro
where $libro/anio > 2000
return ($libro/titulo, $libro/anio)