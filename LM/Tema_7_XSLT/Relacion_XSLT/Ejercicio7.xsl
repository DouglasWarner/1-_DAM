<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

  <xsl:template match="/">
    <museos>
    <xsl:apply-templates mode="a" />
    </museos>
    
    <br/>
    
    <museos>
      <xsl:apply-templates mode="b" />
    </museos>
    
    <br/>
    
    <xsl:element name="ciudades">
      <xsl:apply-templates mode="c" />
    </xsl:element>
    
    <br/>
    
    <xsl:element name="ciudades">
      <xsl:apply-templates mode="d" />
    </xsl:element>
    
  </xsl:template>
  
  <!-- Convertir las etiquetas en atributos -->
  <xsl:template match="museo" mode="a">
  <museo>
      <xsl:attribute name="nombre"><xsl:value-of select="nombre"/></xsl:attribute>
      <xsl:attribute name="ciudad"><xsl:value-of select="ciudad"/></xsl:attribute>
      <xsl:attribute name="pais"><xsl:value-of select="pais"/></xsl:attribute>
  </museo>
  </xsl:template>
  
  <!-- Convertir algunos en atributos -->
  <xsl:template match="museo" mode="b">
    <museo>
      <xsl:element name="nombre"><xsl:value-of select="nombre"/></xsl:element>
      
      <xsl:element name="ubicacion">
      <xsl:attribute name="ciudad"><xsl:value-of select="ciudad"/></xsl:attribute>
      <xsl:attribute name="pais"><xsl:value-of select="pais"/></xsl:attribute>
      </xsl:element>
    </museo>
  </xsl:template>
  
  <!-- Cambiar la estructura del documento -->
  <xsl:template match="museo" mode="c">
      <xsl:element name="ciudad">
          <xsl:element name="nombre"><xsl:value-of select="ciudad"/></xsl:element>
          <xsl:element name="pais"><xsl:value-of select="pais"/></xsl:element>
          <xsl:element name="museo"><xsl:value-of select="nombre"/></xsl:element>
      </xsl:element>
  </xsl:template>
  
  <!-- Cambiar la estructura del documento y algunas etiquetas en atributos -->
  
  <xsl:template match="museo" mode="d">
      <xsl:element name="ciudad">
        <xsl:attribute name="ciudad"><xsl:value-of select="ciudad"/></xsl:attribute>
        <xsl:attribute name="pais"><xsl:value-of select="pais"/></xsl:attribute>
        <xsl:element name="museo"><xsl:value-of select="nombre"/></xsl:element>
      </xsl:element>
  </xsl:template>
  
</xsl:stylesheet> 
