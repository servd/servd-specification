///////////////////////////////////////////////////////////
//  Address.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ServD.Common;

namespace ServD.DataModel
{
	///<value>REVIEW: MF</value>
	/// <summary>
	/// An Organization at a particular Site may specify address information that is in
	/// addition to, or over-rides, the Organization address identified above. Each
	/// address is specified by a type and a purpose.
	/// (When seeking an address of a particular type, begin by searching at the lowest
	/// level (Site) and if not found, progress up the Organization tree until such an
	/// address is found.)
	/// </summary>
	/// <remarks>
	/// Refer to http://schema.org/PostalAddress for a possible schema for this
	/// </remarks>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class Address : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		public override string InternalId { get { return AddressId; } set { AddressId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.Address; } }

		/// <summary>
		/// A unique Identifier allocated by the saving system
		/// When creating a new record, this is blank and will be allocated by the system
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string AddressId { get; set; }

		/// <summary>
		/// Defines the primary type of activity at a location.
		/// </summary>
		/// <example>Residential, Business, Temporary</example>
		/// <cts2code scope='ServD.ADRT'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		[Required]
		public string AddressType { get; set; }

		/// <summary>
		/// Defines the usage of this address in relation to a specific action.
		/// </summary>
		/// <example>Mailing, Delivery, Shipping, Search Results</example>
		/// <cts2code scope='ServD.AP'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		[Required]
		public string AddressPurpose { get; set; }

		/// <summary>
		/// Civic address part. It may contain multiple lines.
		/// </summary>
		/// <example>Level 5, 355 Spencer St</example>
		/// <remarks>Some systems may store this data in separated lines such as AddressLine1, AddressLine2</remarks>
		[DataMember]
		[StringLength(1024)]
		public string StreetAddress { get; set; }

		/// <summary>
		/// (City, Town, Village, Area) points within a hierarchy that travels from Country
		/// down to the lowest level of jurisdiction within the specified country.
		/// </summary>
		/// <example>West Melbourne</example>
		[DataMember]
		[StringLength(256)]
		public string Jurisdiction { get; set; }

		/// <summary>
		/// The region or state of this address.
		/// </summary>
		/// <example>Victoria</example>
		[DataMember]
		[StringLength(256)]
		public string Region { get; set; }

		/// <summary>
		/// The postal Identification Code contains the Zip Code or Postcode<br/>
		/// Usually this is defined by the national postal service.
		/// </summary>
		/// <example>3003</example>
		[DataMember]
		[StringLength(50)]
		public string PostalIdentificationCode { get; set; }

		/// <summary>
		/// The country
		/// </summary>
		/// <example>Australia</example>
		[DataMember]
		[StringLength(256)]
		public string Country { get; set; }

		/// <summary/>
		public Address()
		{
		}

		/// <summary/>
		public Address(Address copyFrom)
		{
			AddressId = copyFrom.AddressId;
			ExternalId = copyFrom.ExternalId;
			RecordStatus = copyFrom.RecordStatus;
			RecordPrivacyPolicy = copyFrom.RecordPrivacyPolicy;
			AddressType = copyFrom.AddressType;
			AddressPurpose = copyFrom.AddressPurpose;
			StreetAddress = copyFrom.StreetAddress;
			Jurisdiction = copyFrom.Jurisdiction;
			Region = copyFrom.Region;
			Country = copyFrom.Country;
			PostalIdentificationCode = copyFrom.PostalIdentificationCode;
			LastModificationDate = copyFrom.LastModificationDate;
			StartDate = copyFrom.StartDate;
			EndDate = copyFrom.EndDate;
		}
	}
}