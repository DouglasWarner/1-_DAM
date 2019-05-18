declare namespace mio="asdaosjahd";
declare function local:Saluda()
as xs:string
{
  let $mensaje := "Hola Mundo"
  return $mensaje
};
declare function local:Saluda($frase as xs:string)
as xs:string
{
  let $mensaje := $frase
  return $mensaje
};
declare function local:Factorial($numero as xs:integer)
{
  if($numero = 0) then 1
  else ($numero * local:Factorial($numero - 1))
};

let $libros := doc("C:\Users\metho\OneDrive\Escritorio\Biblioteca.xml")//libro
let $media := sum($libros/precio)
let $n := $libros/precio > 50
(: return (local:Saluda(),local:Saluda(10.20),local:Saluda("----------"),local:Factorial(4)):)
(: Devuelve true o false return <cuenta>{count($n)}</cuenta> :)
return <media>{round($media)}</media>
(: return <salida> {substring(upper-case($resultado/titulo),1,5)} </salida> :)