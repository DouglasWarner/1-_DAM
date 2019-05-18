(: E Saber los nombres de los profesores que dan clase en la sala 1 y su cuota es mensual:)
for $resultado in doc("D:\Users\alumno1718\Desktop\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio1_Bailes.xml")/Bailes/baile
where $resultado/sala = "1" and $resultado/precio/@cuota = "mensual"
return $resultado/profesor