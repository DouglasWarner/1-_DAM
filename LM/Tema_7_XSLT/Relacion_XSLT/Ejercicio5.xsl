<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

  <xsl:template match="/">
  
    <html>
      <head>
        <title>Bailes</title>
      </head>
      
      <body>
        <h1>Ejercicio 5</h1>
        <hr/>
        <h3>Lenguaje de Marcas</h3>
        <br/>
        
        <!-- LISTADO COMPLETO -->
        <table width="40%" style="text-align: left;">
          <tr>
            <th>nombre</th>
            <th>precio</th>
            <th>plazas</th>
            <th>comienzo</th>
            <th>fin</th>
            <th>profesor</th>
            <th>sala</th>
          </tr>
            <xsl:apply-templates select="Bailes/baile" mode="a"/>
          </table>
          
          <br/>
          
          <!-- LISTADO ID ENTRE 3 Y 7 -->
          <table width="40%" style="text-align: left;">
          <tr>
            <th>nombre</th>
            <th>precio</th>
            <th>plazas</th>
            <th>comienzo</th>
            <th>fin</th>
            <th>profesor</th>
            <th>sala</th>
          </tr>
            <xsl:apply-templates mode="b"/>
          </table>
          
          <br/>
          
          <!-- LO MISMO QUE EL ANTERIO Y ORDENADOR POR PLAZAS -->
          <table width="40%" style="text-align: left;">
          <tr>
            <th>nombre</th>
            <th>precio</th>
            <th>plazas</th>
            <th>comienzo</th>
            <th>fin</th>
            <th>profesor</th>
            <th>sala</th>
          </tr>
            <xsl:apply-templates mode="c" />
          </table>
          
          <br/>
          
          <!-- LISTADO ORDENADOR POR COMIENZO -->
          <table width="40%" style="text-align: left;">
          <tr>
            <th>nombre</th>
            <th>precio</th>
            <th>plazas</th>
            <th>comienzo</th>
            <th>fin</th>
            <th>profesor</th>
            <th>sala</th>
          </tr>
            <xsl:apply-templates mode="d"/>
          </table>
          
          <br/>
          
          <!-- TODOS LOS BAILES DE UNA SALA DETERMINADA -->
          <table width="40%" style="text-align: left;">
          <tr>
            <th>nombre</th>
            <th>precio</th>
            <th>plazas</th>
            <th>comienzo</th>
            <th>fin</th>
            <th>profesor</th>
            <th>sala</th>
          </tr>
            <xsl:apply-templates mode="e"/>
          </table>
          
      </body>
    </html>
  </xsl:template>
  
  <xsl:template match="Bailes/baile" mode="a">
    <tr>
      <td><xsl:value-of select="nombre"/> </td>
      <td><xsl:value-of select="precio"/></td>
      <td><xsl:value-of select="plazas"/></td>
      <td><xsl:value-of select="comienzo"/></td>
      <td><xsl:value-of select="fin"/></td>
      <td><xsl:value-of select="profesor"/></td>
      <td><xsl:value-of select="sala"/></td>
    </tr>
</xsl:template>

  <xsl:template match="Bailes/baile" mode="b">
  <xsl:if test="@id &gt; 2 and @id &lt; 8">
    <tr>
      <td><xsl:value-of select="nombre"/> </td>
      <td><xsl:value-of select="precio"/></td>
      <td><xsl:value-of select="plazas"/></td>
      <td><xsl:value-of select="comienzo"/></td>
      <td><xsl:value-of select="fin"/></td>
      <td><xsl:value-of select="profesor"/></td>
      <td><xsl:value-of select="sala"/></td>
    </tr>
    </xsl:if>
</xsl:template>

  <xsl:template match="Bailes" mode="c">
  <xsl:for-each select="baile">
  <xsl:sort select="plazas" data-type="number"/>
    <xsl:if test="@id &gt; 2 and @id &lt; 8">
      <tr>
        <td><xsl:value-of select="nombre"/> </td>
        <td><xsl:value-of select="precio"/></td>
        <td><xsl:value-of select="plazas"/></td>
        <td><xsl:value-of select="comienzo"/></td>
        <td><xsl:value-of select="fin"/></td>
        <td><xsl:value-of select="profesor"/></td>
        <td><xsl:value-of select="sala"/></td>
      </tr>
      </xsl:if>
      </xsl:for-each>
  </xsl:template>
  <xsl:template match="Bailes" mode="d">
    <xsl:for-each select="baile">
    <xsl:sort select="comienzo"/>
        <tr>
          <td><xsl:value-of select="nombre"/> </td>
          <td><xsl:value-of select="precio"/></td>
          <td><xsl:value-of select="plazas"/></td>
          <td><xsl:value-of select="comienzo"/></td>
          <td><xsl:value-of select="fin"/></td>
          <td><xsl:value-of select="profesor"/></td>
          <td><xsl:value-of select="sala"/></td>
        </tr>
        </xsl:for-each>
    </xsl:template>
    
    <xsl:template match="Bailes" mode="e">
    <xsl:for-each select="baile[sala='2']">
        <tr>
          <td><xsl:value-of select="nombre"/> </td>
          <td><xsl:value-of select="precio"/></td>
          <td><xsl:value-of select="plazas"/></td>
          <td><xsl:value-of select="comienzo"/></td>
          <td><xsl:value-of select="fin"/></td>
          <td><xsl:value-of select="profesor"/></td>
          <td><xsl:value-of select="sala"/></td>
        </tr>
        </xsl:for-each>
    </xsl:template>
</xsl:stylesheet>
