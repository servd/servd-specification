<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:xmi="http://www.omg.org/spec/XMI/20110701"
	xmlns:uml="http://www.omg.org/spec/UML/20110701"
	xmlns:thecustomprofile="http://www.sparxsystems.com/profiles/thecustomprofile/1.0"
	xmlns:EAUML="http://www.sparxsystems.com/profiles/EAUML/1.0"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
	<xsl:output method="html" indent="yes"/>

	<!-- Remove the Use Cases section from the XMI -->
	<xsl:template match ="packagedElement[@name='Use Cases - Activity Diagrams']" />
	<xsl:template match ="packagedElement[@name='B2B Components / Interfaces']" />
	
	<xsl:template match="xmi:XMI">
		<html>
			<head>
			<style>
			TABLE{
				border-collapse: collapse;
				width: 60%;
			}
			TD{
				font-family: Tahoma;
				font-size: 10pt;
				padding: 3px;
			}
			TH{
				font-family: Tahoma;
				font-size: 10pt;
				border-bottom: solid 1 grey;
				text-align: left;
				padding: 3px;
			}
			.invalid{
				font-weight: bold;
				color: red;
			}
			H1{
				font-family: Tahoma;
			}
			H2{
				font-family: Tahoma;
			}
			H3{
				font-family: Tahoma;
			}
			</style>
			</head>
			<body>
				<h1>Validating the XMI</h1>
				<h2>Invalid Operation Parameter types (<xsl:value-of select="count(//ownedParameter[starts-with(./@type, 'EAnone')])"/>)</h2>
				<table>
					<tr>
						<th>Parameter Name</th>
						<th>Type</th>
						<th>Parent Name</th>
						<th>Parent's Parent Name</th>
					</tr>
				<xsl:for-each select="//ownedParameter[starts-with(./@type, 'EAnone')]">
					<tr>
						<td><xsl:value-of select="./@name"/></td>
						<td class="invalid">
							<xsl:value-of select="./@type"/>
						</td>
						<td>
							<xsl:value-of select="parent::node()/@name"/>
						</td>
						<td>
							<xsl:value-of select="parent::node()/parent::node()/@name"/>
						</td>
					</tr>
				</xsl:for-each>
				</table>
				<h2>Invalid Object property types (<xsl:value-of select="count(//ownedAttribute[starts-with(./type/@xmi:idref, 'EAnone')])"/>)</h2>
				<table>
					<tr>
						<th>Object Name</th>
						<th>Attribute Name</th>
						<th>Type</th>
					</tr>
				<xsl:for-each select="//ownedAttribute[starts-with(./type/@xmi:idref, 'EAnone')]">
					<tr>
						<td>
							<xsl:value-of select="parent::node()/parent::node()/@name"/>.<xsl:value-of select="parent::node()/@name"/>
						</td>
						<td><xsl:value-of select="./@name"/></td>
						<td class="invalid">
							<xsl:value-of select="./type/@xmi:idref"/>
						</td>
					</tr>
				</xsl:for-each>
				</table>

				<h2>
					Invalid Object bounds (<xsl:value-of select="count(//ownedParameter[count(lowerValue) > 1 or count(upperValue) > 1])"/>)
				</h2>
				<table>
					<tr>
						<th>Object Name</th>
						<th>Attribute Name</th>
						<th>Type</th>
					</tr>
					<xsl:for-each select="//ownedParameter[count(lowerValue) > 1 or count(upperValue) > 1]">
						<tr>
							<td>
								<xsl:value-of select="parent::node()/parent::node()/@name"/>.<xsl:value-of select="parent::node()/@name"/>
							</td>
							<td>
								<xsl:value-of select="./@name"/>
							</td>
							<td class="invalid">
								<xsl:value-of select="./type/@xmi:idref"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>

				<h1>Service Model</h1>
				<xsl:for-each select="//packagedElement[./ownedOperation]">
					<p>
						<h2><xsl:value-of select="./@name"/></h2>
						<xsl:for-each select="ownedOperation">
							<h3><xsl:value-of select="./@name"/></h3>
							<table>
								<tr>
									<th>Parameter</th>
									<th>Type</th>
									<th>Cardinality</th>
								</tr>
								<xsl:for-each select="ownedParameter">
									<xsl:variable name="typeLookup" select="./type/@xmi:idref"/>
									<xsl:variable name="typeLookupAttr" select="./@type"/>
									<tr>
										<td><xsl:value-of select="./@name"/></td>
										<td><xsl:choose>
											<xsl:when test="not(//packagedElement[./@xmi:id = $typeLookup or ./@xmi:id = $typeLookupAttr]/@name) and not (type[./@xmi:type = 'uml:PrimitiveType']/@href)"><xsl:attribute name="class">invalid</xsl:attribute><xsl:value-of select="$typeLookup"/></xsl:when>
										</xsl:choose>
										<xsl:value-of select="//packagedElement[./@xmi:id = $typeLookup or ./@xmi:id = $typeLookupAttr]/@name"/>
										<i><xsl:value-of select="substring(type[./@xmi:type = 'uml:PrimitiveType']/@href, string-length('http://www.omg.org/spec/UML/20110701/UML.xmi#') + 1)"/></i></td>
										<td>
											<xsl:choose>
												<xsl:when test="not(./lowerValue/@value) and ./upperValue/@value">
													<i style="color: silver;">0</i> .. <xsl:value-of select="./upperValue/@value"/>
												</xsl:when>
												<xsl:when test="./upperValue/@value"><xsl:value-of select="./lowerValue/@value"/> .. <xsl:value-of select="./upperValue/@value"/></xsl:when>
												<xsl:otherwise>
													<i style="color: silver;">1 .. 1</i>
												</xsl:otherwise>
											</xsl:choose>
										</td>
									</tr>
								</xsl:for-each>
							</table>
							<br/>
						</xsl:for-each>
					</p>
				</xsl:for-each>

				<h1>Enumerations</h1>
				<xsl:for-each select="//packagedElement[./@xmi:type='uml:Enumeration']">
					<p>
						<h3><xsl:value-of select="../@name"/>:<xsl:value-of select="./@name"/></h3>
						<table>
							<tr>
								<th>Entry</th>
								<th>Value</th>
							</tr>
						<xsl:for-each select="ownedLiteral">
							<tr>
								<td><xsl:value-of select="./@name"/></td>
								<td></td>
							</tr>
						</xsl:for-each>
						</table>
					</p>
				</xsl:for-each>

				<h1>Object Model</h1>
				<xsl:for-each select="//packagedElement[./ownedAttribute]">
					<p>
						<h3><xsl:value-of select="../@name"/>:<xsl:value-of select="./@name"/></h3>
						<table>
							<tr>
								<th>Property Name</th>
								<!--<th>Type Ref</th>-->
								<th>Type Name</th>
								<th>Cardinality</th>
							</tr>
						<xsl:for-each select="ownedAttribute">
							<xsl:variable name="typeLookup" select="./type/@xmi:idref"/>
							<xsl:variable name="propName" select="./@name"/>
							<tr>
								<td>
									<xsl:choose><xsl:when test="count(../ownedAttribute[@name = $propName]) &gt; 1"><xsl:attribute name="class">invalid</xsl:attribute></xsl:when></xsl:choose>
								<xsl:value-of select="./@name"/>
								</td>
								<!--<td>
									<xsl:choose>
										<xsl:when test="//packagedElement[./@xmi:id = $typeLookup]/@name">
											<xsl:value-of select="$typeLookup"/>
										</xsl:when>
									</xsl:choose>
								</td>-->
								<td>
									<xsl:choose>
										<xsl:when test="not(//packagedElement[./@xmi:id = $typeLookup]/@name) and not (type[./@xmi:type = 'uml:PrimitiveType']/@href)"><xsl:attribute name="class">invalid</xsl:attribute><xsl:value-of select="$typeLookup"/></xsl:when>
									</xsl:choose>
									<xsl:value-of select="//packagedElement[./@xmi:id = $typeLookup]/@name"/>
									<i><xsl:value-of select="substring(type[./@xmi:type = 'uml:PrimitiveType']/@href, string-length('http://www.omg.org/spec/UML/20110701/UML.xmi#') + 1)"/></i>
								</td>
								<td>
									<xsl:choose>
										<xsl:when test="not(./lowerValue/@value)">
											<i style="color: silver;">0</i></xsl:when>
										<xsl:otherwise><xsl:value-of select="./lowerValue/@value"/></xsl:otherwise>
									</xsl:choose>
									 .. <xsl:value-of select="./upperValue/@value"/>
								</td>
							</tr>
						</xsl:for-each>
						</table>
					</p>
				</xsl:for-each>
		</body>
		</html>

	</xsl:template>

	<xsl:template match="text()[not(string-length(normalize-space()))]"/>

	<xsl:template match="text()[string-length(normalize-space()) > 0]">
		<xsl:value-of select="translate(.,'&#xA;&#xD;', '  ')"/>
	</xsl:template>
</xsl:stylesheet>
