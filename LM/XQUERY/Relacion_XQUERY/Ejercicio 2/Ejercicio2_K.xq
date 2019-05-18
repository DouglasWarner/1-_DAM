(: K Listar los títulos de los libros en los que su autor sea Francisco Charte:)
for $libro in doc("C:\Users\metho\OneDrive\Escritorio\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 2\Biblioteca.xml")//libro
where $libro//autor/nombre = "Francisco" and $libro//autor/apellidos = "Charte"
return $libro/titulo