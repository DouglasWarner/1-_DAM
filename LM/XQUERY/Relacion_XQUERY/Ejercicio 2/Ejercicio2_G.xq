(: G Listar los t�tulos de los libros con m�s de un autor:)
for $libro in doc("C:\Users\metho\OneDrive\Escritorio\1�_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 2\Biblioteca.xml")//libro
where count($libro//autor)
return $libro/titulo