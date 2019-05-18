(: A Devolver el nombre del primer autor de cada libro :)
for $libro in doc("C:\Users\metho\OneDrive\Escritorio\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 2\Biblioteca.xml")//libro
return $libro//autor[position() = 1]/nombre