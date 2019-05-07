<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

  <xsl:template match="/">
  
    <html>
      <head>
        <title>Ejercicio 6</title>
      </head>
      <body>
        <xsl:apply-templates />
      </body>
    </html>
  </xsl:template>
  
  <xsl:template match="tienda">
    <h1><xsl:value-of select="nombre"/></h1>
        <h3>Teléfono: <xsl:value-of select="telefono"/></h3>
        
        <p><xsl:value-of select="url/@etiqueta"/><a href="@"><xsl:value-of select="url"/></a></p>
        <p><xsl:value-of select="url[@prefijo = 'mailto:']/@etiqueta"/><a href="@"><xsl:value-of select="url[@prefijo = 'mailto:']"/></a></p>
        
        <h3>Nuestros mejores productos</h3>
        
        <table border="1" width="100%" height="40%">
          <tr>
            <th>Código</th>
            <th>Existencias</th>
            <th>Artículo</th>
          </tr>
          <xsl:apply-templates select="producto"/>
        
        </table>
  </xsl:template>
  
  <xsl:template match="producto">
    <tr>
      <td><xsl:value-of select="codigo"/></td>
      <td><xsl:value-of select="cantidad"/></td>
      <td><xsl:value-of select="articulo"/></td>
      <td><p><xsl:value-of select="seccion"/><xsl:value-of select="marca"/><xsl:value-of select="modelo"/></p></td>
      <td><xsl:apply-templates select="caracteristicas"/></td>
      <xsl:apply-templates select="opciones"/>
      <td>Precio: <xsl:value-of select="precio"/><xsl:value-of select="precio/@moneda"/></td>
      
    </tr>
  </xsl:template>
  
  <xsl:template match="caracteristicas">
      <ul>
        <xsl:for-each select="linea">
          <li><xsl:apply-templates /></li>
        </xsl:for-each>
      </ul>
  </xsl:template>

<xsl:template match="opciones">
<td>
  <xsl:if test="@nombre = 'color'">
  <xsl:value-of select="@nombre"/>
  <select>
    <xsl:for-each select="opcion">
      <option><xsl:value-of select="@valor"/></option>
    </xsl:for-each>
  </select>
  </xsl:if>
  <xsl:if test="@nombre = 'forma'">
  <xsl:value-of select="@nombre"/>
    <select>
      <xsl:for-each select="opcion">
        <option><xsl:value-of select="@valor"/></option>
      </xsl:for-each>
    </select>
  </xsl:if>
</td>
</xsl:template>
</xsl:stylesheet>
