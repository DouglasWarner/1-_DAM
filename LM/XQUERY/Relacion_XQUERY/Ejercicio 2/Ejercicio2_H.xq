(: H Obtener el t�tulo y el a�o de todos los libros publicados despu�s del a�o 2000:)
for $libro in doc("C:\Users\metho\OneDrive\Escritorio\1�_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 2\Biblioteca.xml")//libro
where $libro/anio > 2000
return ($libro/titulo, $libro/anio)