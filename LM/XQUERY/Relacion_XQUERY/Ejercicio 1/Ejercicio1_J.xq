(: J Haz una estad�stica obteniendo los siguientes datos de los precios: suma, media, m�ximo y m�nimo. La
salida generada tiene que ser similar a esta.:)
let $resultado := doc("C:\Users\metho\OneDrive\Escritorio\1�_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio1_Bailes.xml")//precio
return
<resultado>
  <suma>{sum($resultado)}</suma>
  <media>{avg($resultado)}</media>
  <maximo>{max($resultado)}</maximo>
  <minimo>{min($resultado)}</minimo>
</resultado>