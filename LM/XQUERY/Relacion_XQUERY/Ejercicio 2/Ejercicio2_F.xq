(: F  Listar el t�tulo de cada libro junto con el n�mero de autores :)
for $libro in doc("C:\Users\metho\OneDrive\Escritorio\1�_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio 2\Biblioteca.xml")//libro
where contains($libro/precio,precio)
return ($libro/titulo,<numeroAutores> {count($libro//autor)}</numeroAutores>)