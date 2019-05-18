(: E Sacar a continuación solo los que tengan precio :)
for $libro in doc("C:\Users\metho\OneDrive\Escritorio\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 2\Biblioteca.xml")//libro
where contains($libro/precio,precio)
return $libro