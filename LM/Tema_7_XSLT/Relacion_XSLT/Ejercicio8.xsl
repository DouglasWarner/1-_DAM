<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

  <xsl:template match="/">
  <xsl:element name="museos">
    <xsl:apply-templates mode="a"/>
  </xsl:element>
    
    <br/>
    
    <xsl:element name="museos">
      <xsl:apply-templates mode="b"/>
    </xsl:element>
    
    <br/>
    
    <xsl:element name="ciudades">
      <xsl:apply-templates mode="c"/>
    </xsl:element>
    
    <br/>
    
    <xsl:element name="paises">
      <xsl:apply-templates mode="d"/>
    </xsl:element>
    
    <br/>
    
    <xsl:element name="lugares">
      <xsl:apply-templates mode="e"/>
    </xsl:element>
  </xsl:template>
  
  <!-- Convertir atributos en etiquetas -->
  <xsl:template match="museo" mode="a">
    <xsl:element name="museo">
      <xsl:element name="nombre"><xsl:value-of select="@nombre"/></xsl:element>
      <xsl:element name="ciudad"><xsl:value-of select="@ciudad"/></xsl:element>
      <xsl:element name="pais"><xsl:value-of select="@pais"/></xsl:element>
    </xsl:element>
  </xsl:template>
  
  <!-- Convertir algunos atributos en etiquetas-->
  <xsl:template match="museo" mode="b">
    <xsl:element name="museo"><xsl:attribute name="ubicacion"><xsl:value-of select="@ciudad"/> (<xsl:value-of select="@pais"/>)</xsl:attribute><xsl:value-of select="@nombre"/></xsl:element>
  </xsl:template>
  
  <!-- Cambiar la estructura del documento y convertir algunos atributos en etiquetas -->
  <xsl:template match="museo" mode="c">
    <xsl:element name="ciudad"><xsl:attribute name="nombre"><xsl:value-of select="@ciudad"/></xsl:attribute>
      <xsl:element name="pais"><xsl:value-of select="@pais"/></xsl:element>
      <xsl:element name="museo"><xsl:value-of select="@nombre"/></xsl:element>
    </xsl:element>
  </xsl:template>
  
  <!-- Cambiar estructura del documento -->
  <xsl:template match="museo" mode="d">
    <xsl:element name="pais"><xsl:attribute name="nombre"><xsl:value-of select="@pais"/></xsl:attribute>
      <xsl:element name="ciudad"><xsl:attribute name="nombre"><xsl:value-of select="@ciudad"/></xsl:attribute>
          <xsl:element name="museo"><xsl:attribute name="nombre"><xsl:value-of select="@nombre"/></xsl:attribute></xsl:element>
      </xsl:element>
    </xsl:element>
  </xsl:template>
  
  <!-- Cambiar la estructura del documento -->
  <xsl:template match="museo" mode="e">
    <xsl:element name="lugar"><xsl:attribute name="tipo"><xsl:value-of select="local-name()"/></xsl:attribute>
      <xsl:element name="ubicacion"><xsl:attribute name="nombre"><xsl:value-of select="local-name(@ciudad)"/></xsl:attribute><xsl:value-of select="@ciudad"/></xsl:element>
      <xsl:element name="ubicacion"><xsl:attribute name="nombre"><xsl:value-of select="local-name(@pais)"/></xsl:attribute><xsl:value-of select="@pais"/></xsl:element>
      <xsl:element name="nombre"><xsl:value-of select="@nombre"/></xsl:element>
    </xsl:element>
  </xsl:template>
</xsl:stylesheet>
