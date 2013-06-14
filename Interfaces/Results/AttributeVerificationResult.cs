///////////////////////////////////////////////////////////
//  AttributeVerificationResult.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ServD.Common;

namespace ServD.Results
{
	/// <summary>
	/// The Attribute Verification Result is returned by the operations on the <b>Verify Details</b> interface
	/// to indicate the validity of a claim of a record to have a specific attribute.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class AttributeVerificationResult
	{
		/// <summary>
		/// The Attribute type that has been Verified
		/// </summary>
		/// <example>business.gov.au</example>
		/// <example>Health Insurance Agency A</example>
		/// <example>AHPRA</example>
		[DataMember]
		[StringLength(64)]
		public string AttributeType { get; set; }

		/// <summary>
		/// The Attribute Value that has been verified
		/// </summary>
		/// <example>ABN</example>
		/// <example>Level A</example>
		/// <example>Dentist</example>
		[DataMember]
		[StringLength(64)]
		public string AttributeValue { get; set; }

		/// <summary>
		/// The result of an Attribute Verification result
		/// </summary>
		[DataMember]
		public AttributeVerificationStatusEnum VerificationStatus { get; set; }

		/// <summary>
		/// Additional Notes provided about this attribute by a <b>ServD Verifier</b>.
		/// </summary>
		/// <example>This Provider was delisted on 12/1/2012 for breaches of privacy</example>
		[DataMember]
		[StringLength(2048)]
		public String AdditionalNotes { get; set; }

		/// <summary>
		/// The identifier that was requested to be verified
		/// </summary>
		/// <example>28 548 551 396</example>
		/// <example>HIA-000321</example>
		/// <example>DEN000123a</example>
		[DataMember]
		[StringLength(64)]
		public string Identifier { get; set; }

		/// <summary>
		/// The name that is stored with this identifier's registration
		/// </summary>
		/// <example>DATABASE CONSULTANTS AUSTRALIA</example>
		[DataMember]
		[StringLength(250)]
		public string Name { get; set; }

		/// <summary>
		/// For Providers, this is their Surname
		/// </summary>
		/// <example>Postlethwaite</example>
		[DataMember]
		public string FamilyName { get; set; }

		/// <summary>
		/// For Providers, this is their given names
		/// </summary>
		/// <example>Brian</example>
		[DataMember]
		public string GivenNames { get; set; }

		/// <summary>
		/// The date that this record will expire
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
		/// This public key that can be used to verify the Digital Signature<br/>
		/// The length of this string is undefined and should be of an un-restricted type.
		/// </summary>
		/// <remarks>This is a base64 encoded digital certificate. The ServD Federation's Profile will
		/// specify the type of certificate to be used and its purpose.</remarks>
		[DataMember]
		public string PublicKey { get; set; }

		/// <summary>
		/// This component is the signed VerificationString as defined above using the PublicKey provided above.
		/// </summary>
		[DataMember]
		public byte[] DigitalSignature { get; set; }

		/// <summary>
		/// Collection of Contact points for this Site
		/// </summary>
		[DataMember]
		public ServD.DataModel.ContactPoint[] ContactPoints { get; set; }

		/// <summary>
		/// Collection of Addresses that are currently registered for this Organization/Site/Provider
		/// </summary>
		[DataMember]
		public ServD.DataModel.Address[] Addresses { get; set; }

		/// <summary/>
		public AttributeVerificationResult()
		{
		}
	}
}
