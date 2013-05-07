<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:uml="http://www.omg.org/spec/UML/20110701" 
	xmlns:thecustomprofile="http://www.sparxsystems.com/profiles/thecustomprofile/1.0"
	xmlns:EAUML="http://www.sparxsystems.com/profiles/EAUML/1.0"
	xmlns:SoaML="http://www.sparxsystems.com/profiles/SoaML/1.0"
	xmlns:xmi="http://www.omg.org/spec/XMI/20110701"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl SoaML EAUML"
>
    <xsl:output method="xml" indent="yes"/>

	<!-- Remove the attributes that came from the .net stuff -->
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[EnumMember]']" />
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[DataMember]']" />
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[DataMember];[Required]']" />
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[DataMember];[StringLength(50)]']" />
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[DataMember];[StringLength(50)];[Required]']" />
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[DataMember];[StringLength(64)]']" />
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[DataMember];[StringLength(64)];[Required]']" />
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[DataMember];[StringLength(100)]']" /> <!-- Service Type is this long???? -->
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[DataMember];[StringLength(250)]']" />
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[DataMember];[StringLength(250)];[Required]']" />
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[DataMember];[StringLength(256)]']" />
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[DataMember];[StringLength(500)]']" />
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[DataMember];[StringLength(1000)]']" />
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[DataMember];[StringLength(1024)]']" />
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[DataMember];[StringLength(2048)]']" />
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[DataMember];[StringLength(2048)];[Required]']" />
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[DataMember];[StringLength(458)]']" />
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[DataContract(Namespace = Constants.ServDNamespace)]']" />
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[DataContract(Namespace = Constants.ServDNamespace, Name = &quot;DaysOfWeek&quot;)]']" />
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[System.Xml.Serialization.XmlElement(DataType = &quot;time&quot;)];[DataMember]']" />
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[OperationContract]']" />
	<xsl:template match ="thecustomprofile:Attribute[./@Attribute='[ServiceContract(Namespace = Constants.ServDNamespace)]']" />

	<!-- Remove some other custom EA bits added in -->
	<xsl:template match="EAUML:enumeration[./@base_Enumeration]" />
	<xsl:template match ="thecustomprofile:Attribute[./@base_Enumeration]" />

	<xsl:template match ="thecustomprofile:operation_guid[./@base_Message and ./@operation_guid]" />
	<xsl:template match ="thecustomprofile:interface[./@base_Lifeline]" />

	<!-- Remove the Use Cases section from the XMI -->
	<xsl:template match ="packagedElement[@name='Use Cases - Activity Diagrams']" />
	<xsl:template match ="packagedElement[@name='B2B Components / Interfaces']" />
	<xsl:template match ="packagedElement[@name='Profile Binding / Federation']" />

	<!-- Tag the Parameters that are actually Array parameters -->
	<xsl:template match="ownedParameter[./@xmi:id=/xmi:XMI/thecustomprofile:Array/@base_Parameter]">
		<xsl:copy>
			<!--<xsl:attribute name="isarray">true</xsl:attribute>-->
			<xsl:apply-templates select="@*"/>
			<xsl:if test="not(./lowerValue)">
				<xsl:element name="lowerValue" >
					<xsl:attribute name="xmi:type">uml:LiteralInteger</xsl:attribute>
					<xsl:attribute name="xmi:id">DCAl_<xsl:value-of disable-output-escaping="yes" select="./@xmi:id" />
					</xsl:attribute>
					<xsl:attribute name="value">0</xsl:attribute>
				</xsl:element>
			</xsl:if>
			<xsl:element name="upperValue" >
				<xsl:attribute name="xmi:type">uml:LiteralUnlimitedNatural</xsl:attribute>
				<xsl:attribute name="xmi:id">DCAh_<xsl:value-of disable-output-escaping="yes" select="./@xmi:id" />
				</xsl:attribute>
				<xsl:attribute name="value">*</xsl:attribute>
			</xsl:element>
			<xsl:apply-templates select="node()"/>
		</xsl:copy>
		<!--<test isarray="true"/>-->
	</xsl:template>

	<!-- Once the below arrays are tagges into conformant XMI/UML I'll know what is really meant to be here-->
	<xsl:template match ="thecustomprofile:Array" />

	<!-- Tag the Parameters that are actually Array return values -->
	<xsl:template match="ownedParameter[./@name='return' and ./../@xmi:id=/xmi:XMI/thecustomprofile:Array/@base_Operation]">
		<xsl:copy>
			<!--<xsl:attribute name="isarray">true</xsl:attribute>-->
			<xsl:apply-templates select="@*"/>
			<xsl:if test="not(./lowerValue)">
				<xsl:element name="lowerValue" >
					<xsl:attribute name="xmi:type">uml:LiteralInteger</xsl:attribute>
					<xsl:attribute name="xmi:id">DCAl_<xsl:value-of disable-output-escaping="yes" select="./@xmi:id" />
					</xsl:attribute>
					<xsl:attribute name="value">0</xsl:attribute>
				</xsl:element>
			</xsl:if>
			<xsl:element name="upperValue" >
				<xsl:attribute name="xmi:type">uml:LiteralUnlimitedNatural</xsl:attribute>
				<xsl:attribute name="xmi:id">DCAh_<xsl:value-of disable-output-escaping="yes" select="./@xmi:id" />
				</xsl:attribute>
				<xsl:attribute name="value">*</xsl:attribute>
			</xsl:element>
			<xsl:apply-templates select="node()"/>
		</xsl:copy>
		<!--<test isarray="true"/>-->
	</xsl:template>

	<!-- Remove the SoaML bits -->
	<xsl:template match ="SoaML:*" />

	<!-- remove the default lower value entries = "0"-->
	<!-- (This is not included as MagicDraw does not make the assumption that the default value is 0, it assumes 1) -->
	<!--<xsl:template match ="lowerValue[./@xmi:type='uml:LiteralInteger' and ./@value = '0']" />-->

	<!-- Remove the EA extensions -->
	<xsl:template match ="xmi:Extension[@extender='Enterprise Architect']" />

	<!-- Remove any completely empty Classes in a package -->
	<xsl:template match ="packagedElement[count(./*) = 0 and count(./@*) = 2 and ./@xmi:type='uml:Class']" />

	<!-- Make all interface operations public (as that's what the definition of an interface is) -->
	<xsl:template match ="ownedOperation[../@xmi:type='uml:Interface']">
		<xsl:copy>
			<xsl:apply-templates select="@*"/>
			<xsl:attribute name="visibility">public</xsl:attribute>
			<xsl:apply-templates select="node()"/>
		</xsl:copy>
	</xsl:template>

	<!-- Tag the Operations that are arrays with appropriate XMI -->
	<xsl:template match="ownedParameter[./@name='return' and ./../@xmi:id=/xmi:XMI/thecustomprofile:Array/@base_Operation]">
		<xsl:copy>
			<!--<xsl:attribute name="isarray">true</xsl:attribute>-->
			<xsl:apply-templates select="@*"/>
			<xsl:if test="not(./lowerValue)">
				<xsl:element name="lowerValue" >
					<xsl:attribute name="xmi:type">uml:LiteralInteger</xsl:attribute>
					<xsl:attribute name="xmi:id">DCAl_<xsl:value-of disable-output-escaping="yes" select="./@xmi:id" />
					</xsl:attribute>
					<xsl:attribute name="value">0</xsl:attribute>
				</xsl:element>
			</xsl:if>
			<xsl:element name="upperValue" >
				<xsl:attribute name="xmi:type">uml:LiteralUnlimitedNatural</xsl:attribute>
				<xsl:attribute name="xmi:id">DCAh_<xsl:value-of disable-output-escaping="yes" select="./@xmi:id" />
				</xsl:attribute>
				<xsl:attribute name="value">*</xsl:attribute>
			</xsl:element>
			<xsl:apply-templates select="node()"/>
		</xsl:copy>
		<!--<test isarray="true"/>-->
	</xsl:template>

	<!-- This is the part that would put the value of the enumeration into the model -->
	<xsl:template match ="ownedLiteral[./@xmi:type='uml:EnumerationLiteral']">
		<xsl:copy>
			<xsl:apply-templates select="@*"/>
			<!-- Insert the Value from the EA extensions -->
			<!--<xsl:attribute name="slot">
				<xsl:variable name="locateEnumId" select="./@xmi:id" />
				--><!--<xsl:value-of select="../@xmi:id"/>--><!--
				<xsl:value-of select="/xmi:XMI/xmi:Extension//attribute[@xmi:idref=$locateEnumId]/initial/@body"/>
			</xsl:attribute>-->
			<xsl:apply-templates select="node()"/>
		</xsl:copy>
	</xsl:template>
	
	<!-- Remove the profileApplication bits -->
	<xsl:template match ="profileApplication" />
	
	<!-- Pass through all other elements/attributes as is -->
	<xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>

	<!-- Remove any blank lines from the output -->
	<xsl:template match="text()[not(string-length(normalize-space()))]"/>

	<xsl:template match="text()[string-length(normalize-space()) > 0]">
	  <xsl:value-of select="translate(.,'&#xA;&#xD;', '  ')"/>
	</xsl:template>
</xsl:stylesheet>
