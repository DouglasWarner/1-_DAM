(: I Obtener el título y el año de todos los libros publicados por la editorial Planeta después de 1991:)
for $libro in doc("C:\Users\metho\OneDrive\Escritorio\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 2\Biblioteca.xml")//libro
where $libro/anio > 1991
return $libro[editorial = "Planeta"]