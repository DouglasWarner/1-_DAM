for $resultado in doc("C:\Users\metho\OneDrive\Escritorio\1º_DAM\LM\XQUERY\Relacion_XQUERY\Ejercicio1_Bailes.xml")/Bailes/baile
where $resultado/sala = "1"
return $resultado
