(: J Haz una estadística obteniendo los siguientes datos de los precios: suma, media, máximo y mínimo. La
salida generada tiene que ser similar a esta.:)
let $resultado := doc("C:\Users\metho\OneDrive\Escritorio\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio1_Bailes.xml")//precio
return
<resultado>
  <suma>{sum($resultado)}</suma>
  <media>{avg($resultado)}</media>
  <maximo>{max($resultado)}</maximo>
  <minimo>{min($resultado)}</minimo>
</resultado>