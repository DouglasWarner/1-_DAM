(: I Obtener el t�tulo y el a�o de todos los libros publicados por la editorial Planeta despu�s de 1991:)
for $libro in doc("C:\Users\metho\OneDrive\Escritorio\1�_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 2\Biblioteca.xml")//libro
where $libro/anio > 1991
return $libro[editorial = "Planeta"]