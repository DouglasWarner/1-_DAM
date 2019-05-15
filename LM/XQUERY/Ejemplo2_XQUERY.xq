for $resultado in doc("D:\Users\alumno1718\Desktop\Editor xQuery + biblioteca_xml\biblioteca.xml")/biblioteca/libro
where $resultado/precio > 45
return $resultado