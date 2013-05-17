///////////////////////////////////////////////////////////
//  Attribute.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ServD.Common;

namespace ServD.DataModel
{
	/// <summary>
	/// An attribute is a configurable record that can be attached to several other
	/// records to provide an extensible and verifiable name value pair.
	/// These are restricted to a known set of names as defined by the ServD Federation's
	/// Profile.
	/// </summary>
	/// <remarks>
	/// This code type that is applicable to the code Value in this object can 
	/// either be associated with one of the following types depending on the parent of this record;
	/// ServD.ATTT.Org, ServD.ATTT.Site, ServD.ATTT.SS, 
	/// ServD.ATTT.Prov, ServD.ATTT.Prov.Cred, ServD.ATTT.Prov.Qual or ServD.ATTT.Prov.Reg
	/// </remarks>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class Attribute : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		public override string InternalId { get { return AttributeId; } set { AttributeId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.Attribute; } }

		/// <summary>
		/// The unique reference identifying an attribute. This is the primary
		/// key for the attribute entity.
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string AttributeId { get; set; }

		/// <summary>
		/// The type of attribute
		/// </summary>
		/// <remarks>
		/// This has been restricted to 64 chars to support the use of OIDs<br/>
		/// Refer to http://www.hl7.org/oid/index.cfm for other details on the literal 
		/// form of OIDs and why 64 chars has been selected.
		/// </remarks>
		[DataMember]
		[StringLength(64)]
		[Required]
		public string AttributeType { get; set; }

		/// <summary>
		/// The actual value associated with this attribute
		/// </summary>
		[DataMember]
		[StringLength(250)]
		[Required]
		public string AttributeValue { get; set; }

		/// <summary>
		/// The verification status as provided by the external <b>ServD Verifier</b>.
		/// </summary>
		/// <remarks>
		/// If the current date is after the Expiry date and this attribute was verified
		/// by a <b>ServD Verifier</b> to be <b>Verified</b>, then this value should be <b>Expired</b>.
		/// </remarks>
		[DataMember]
		public AttributeVerificationStatusEnum VerificationStatus { get; set; }

		/// <summary>
		/// Additional Notes provided about this attribute by a <b>ServD Verifier</b>.
		/// </summary>
		/// <example>This Provider was delisted on 12/1/2012 for breaches of privacy</example>
		[DataMember]
		[StringLength(2048)]
		public String AdditionalVerifierNotes { get; set; }

		/// <summary>
		/// The date that this record was last verified by the <b>ServD Verifier</b>.<br/>
		/// Must be populated for attribute types that are configured for a <b>Maintainable ServD Core</b>.<br/>
		/// The date will be populated with the current date when saving a record until the 
		/// <b>ServD Verifier</b> has been checked, at which time it will be updated.
		/// </summary>
		/// <remarks>
		/// Some configurations may decide to periodically re-check these credentials to ensure
		/// this information remains up to date.
		/// </remarks>
		[DataMember]
		public DateTime? LastVerificationDate { get; set; }

		/// <summary>
		/// The date that this attribute will expire.<br/>
		/// If this attribute was verified by a <b>ServD Verifier</b> then this date
		/// will be provided by the <b>ServD Verifier</b>.
		/// </summary>
		[DataMember]
		public DateTime? ExpiryDate { get; set; }

		/// <summary>
		/// The Verification String is the concatenation of the AttributeType, AttributeValue, Status, 
		/// Identifier, Name and ExpiryDate Fields (in that order) as received from the sender. 
		/// This can be reconstructed from the base data, but is included in the result to remove
		/// any ambiguity as to what was used to sign and create the DigitalSignature.<br/>
		/// Each field is to be separated by a ":" and the date is to be formatted as YYYY-MM-DD.
		/// </summary>
		/// <example>"ABN:123456789A:Verified:DEN12314:General Healthcare:2012-03-12"</example>
		/// <summary>
		/// If there is no expiry date, then the value included for the date will be an empty string.
		/// </summary>
		/// <example>"ABN:123456789A:Verified:DEN12314:General Healthcare:"</example>
		/// <summary>
		/// For a Provider, the Name field is replaced with the FamilyName and Given names separated by commas
		/// </summary>
		/// <example>"ABN:123456789A:Verified:DEN12314:Smith,Brian:2012-03-12"</example>
		/// <remarks>String Length: 64+1+64+1+1+1+64+250+1+10 (Calculated from the associated fields)</remarks>
		[DataMember]
		[StringLength(458)]
		public string VerificationString { get; set; }

		/// <summary>
		/// The digital signature of the VerificationString as defined using the W3C XML-Signature Syntax and processing.<br/>
		/// The structure of this string is an XML fragment that complies with the XML Signature Schema Instance 
		/// (XSD can be found at: http://www.w3.org/TR/2002/REC-xmldsig-core-20020212/xmldsig-core-schema.xsd)<br/>
		/// The length of this string is undefined and should be of an un-restricted type.
		/// </summary>
		/// <remarks>
		/// Please refer to http://www.w3.org/TR/2002/REC-xmldsig-core-20020212/Overview.html for details on
		/// creating the digital signature and the process for verifying it.<br/>
		/// As the content of this string is not XML, it must be wrapped in a simple XML fragment.
		/// &lt;verified&gt;&lt;[CDATA[.......]]&gt;&lt;/verified&gt; where the .... is replaced with the VerificationString
		/// </remarks>
		/// <example>&lt;verified&gt;&lt;[CDATA[ABN:123456789A:Verified:DEN12314:Smith,Brian:2012-03-12]]&gt;&lt;/verified&gt;</example>
		[DataMember]
		public String DigitalSignature { get; set; }

		/// <summary/>
		public Attribute()
		{
		}

		/// <summary/>
		public Attribute(Attribute theAttribute)
		{
			AttributeId = theAttribute.AttributeId;
			RecordPrivacyPolicy = theAttribute.RecordPrivacyPolicy;
			RecordStatus = theAttribute.RecordStatus;
			AttributeType = theAttribute.AttributeType;
			AttributeValue = theAttribute.AttributeValue;
			VerificationStatus = theAttribute.VerificationStatus;
			LastVerificationDate = theAttribute.LastVerificationDate;
			ExpiryDate = theAttribute.ExpiryDate;
		}
	}
}