(: C Devolver los autores que tienen correo electr�nico
:)
for $libro in doc("C:\Users\metho\OneDrive\Escritorio\1�_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 2\Biblioteca.xml")//autores
where contains($libro/email,'@')
return $libro