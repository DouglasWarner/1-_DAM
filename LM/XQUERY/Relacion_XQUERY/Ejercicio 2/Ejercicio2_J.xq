(: J Listar los títulos y precios de los libros de la editorial Planeta:)
for $libro in doc("C:\Users\metho\OneDrive\Escritorio\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 2\Biblioteca.xml")//libro
return ($libro[editorial = "Planeta"]/titulo, $libro[editorial = "Planeta"]/precio)