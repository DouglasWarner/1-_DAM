(: C Obtener los nombres de los bailes que se impartan en la sala 2 y el precio sea menor que 35.:)
for $resultado in doc("D:\Users\alumno1718\Desktop\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio1_Bailes.xml")/Bailes/baile
where $resultado/sala = "2" and $resultado/precio < 35
return $resultado