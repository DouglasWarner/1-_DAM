(: E Sacar a continuaci�n solo los que tengan precio :)
for $libro in doc("C:\Users\metho\OneDrive\Escritorio\1�_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 2\Biblioteca.xml")//libro
where contains($libro/precio,precio)
return $libro