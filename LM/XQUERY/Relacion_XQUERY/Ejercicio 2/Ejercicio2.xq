(: Devolver los títulos de todos los libros publicados después de 1997 :)
for $libro in doc("C:\Users\metho\OneDrive\Escritorio\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 2\Biblioteca.xml")//libro
return $libro[$libro//anio > 1997]