(: D Obtener los nombres de los bailes que se impartan en la sala 2, el precio sea menor que 50 y la moneda €.:)
for $resultado in doc("D:\Users\alumno1718\Desktop\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio1_Bailes.xml")/Bailes/baile
where $resultado/sala = "2" and $resultado/precio < 50 and $resultado/precio/@moneda = "euro"
return $resultado