(: B Obtener los nombres de los bailes que se realizan o han realizado en la sala 1.:)
for $resultado in doc("D:\Users\alumno1718\Desktop\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio1_Bailes.xml")/Bailes/baile
where $resultado/sala = "1" 
return $resultado