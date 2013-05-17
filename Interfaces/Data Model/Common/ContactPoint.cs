///////////////////////////////////////////////////////////
//  ContactPoint.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ServD.Common;

namespace ServD.DataModel
{
	/// <value>REVIEW: MF</value>
	/// <summary>
	/// An Organization at a particular Site will have different contact information
	/// (perhaps) than the information held at the Organization level independent of
	/// Site. This entity provides for any number of contact points that relate
	/// specifically to the Organization at that Site. Each contact point is identified
	/// through a type and a purpose.
	/// </summary>
	/// <remarks>
	/// <span color="red">The Contact_Point_Format_String field has been removed from this type.<br/>
	/// It was intended to be used to assist in formatting of the string, however it appears
	/// that it was populated with a regular expression and thus more relevant for validation,
	/// which is not something that should be on the object</span>
	/// </remarks>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class ContactPoint : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		public override string InternalId { get { return ContactPointId; } set { ContactPointId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.ContactPoint; } }

		/// <summary>
		/// A unique Identifier that is allocated by the saving system
		/// When adding a new contact point, this is blank and will be allocated
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string ContactPointId { get; set; }

		/// <summary>
		/// The Type of the contact point
		/// </summary>
		/// <example>Phone, Fax, Pager, email, Web</example>
		/// <cts2code scope='ServD.CPT'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		[Required]
		public string ContactPointType { get; set; }

		/// <summary>
		/// Description of the Purpose or usage of this contact point
		/// </summary>
		/// <example>Reception, Billing, Referrals, Administration</example>
		/// <cts2code scope='ServD.CPP'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		[Required]
		public string ContactPointPurpose { get; set; }

		/// <summary>
		/// The preferred Order of usage
		/// </summary>
		/// <remarks>This was added to permit the ordering of contact lists in terms of preference.</remarks>
		[DataMember]
		public int ContactOrderPreference { get; set; }

		/// <summary>
		/// Type of physical apparatus that is attached to a phone, where applicable.
		/// </summary>
		/// <example>Cell, Fixed Line, TTY, NA</example>
		/// <cts2code scope='ServD.CPEQ'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string EquipmentCode { get; set; }

		/// <summary>
		/// The Textual value of the Contact Point
		/// </summary>
		/// <example>For Phone number: (555) 123 4565</example>
		/// <example>For email: person@theorganization.com</example>
		/// <example>For web: www.omg.org</example>
		[DataMember]
		[StringLength(2048)]
		[Required]
		public string Value { get; set; }

		/// <summary/>
		public ContactPoint()
		{
		}

		/// <summary/>
		public ContactPoint(ContactPoint theContactPoint)
		{

		}
	}
}