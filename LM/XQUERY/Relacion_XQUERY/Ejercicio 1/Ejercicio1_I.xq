(: I Obtener la suma total de el precio de los bailes:)
let $resultado := doc("C:\Users\metho\OneDrive\Escritorio\1�_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio1_Bailes.xml")//precio
return sum($resultado)