(: C :)
for $resultado in doc("D:\Users\alumno1718\Desktop\1�_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio1_Bailes.xml")/Bailes/baile
where $resultado/sala = "2" and $resultado/precio < 35
return $resultado