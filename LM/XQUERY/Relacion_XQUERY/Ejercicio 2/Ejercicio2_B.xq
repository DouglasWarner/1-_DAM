(: B Devolver los apellidos de los autores de los libros:)
for $libro in doc("C:\Users\metho\OneDrive\Escritorio\1�_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 2\Biblioteca.xml")//libro
return $libro//autor/apellidos