(: C Devolver los autores que tienen correo electrónico
:)
for $libro in doc("C:\Users\metho\OneDrive\Escritorio\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 2\Biblioteca.xml")//autores
where contains($libro/email,'@')
return $libro