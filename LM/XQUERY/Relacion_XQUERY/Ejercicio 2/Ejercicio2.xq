(: Devolver los t�tulos de todos los libros publicados despu�s de 1997 :)
for $libro in doc("C:\Users\metho\OneDrive\Escritorio\1�_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 2\Biblioteca.xml")//libro
return $libro[$libro//anio > 1997]