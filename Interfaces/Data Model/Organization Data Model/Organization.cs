///////////////////////////////////////////////////////////
//  Organization.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ServD.Common;

namespace ServD.DataModel
{
	///<value>REVIEW: MF</value>
	/// <summary>
	/// An Organization is any Organization, Agency, or collection of Organizations that participates
	/// in the delivery of health care services. An agency is not an individual service
	/// Provider, though an agency may be the legal representation of an individual
	/// service provider.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class Organization : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		public override string InternalId { get { return OrganizationId; } set { OrganizationId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.Organization; } }

		/// <summary>
		/// The unique reference identifying an Organization.
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string OrganizationId { get; set; }

		/// <summary>
		/// Brief description of what is offered by an Organization, as a link to further
		/// information
		/// </summary>
		[DataMember]
		[StringLength(2048)]
		public string Comment { get; set; }
		
		/// <summary>
		/// Date the Organization was made legally alive.
		/// </summary>
		[DataMember]
		public DateTime? IncorporationDate { get; set; }
		
		/// <summary>
		/// The status of the Organization.<br/>
		/// </summary>
		/// <example>Unapproved, Active, Suspended, Delisted</example>
		/// <cts2code scope='ServD.ORGST'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string Status { get; set; }

		/// <summary>
		/// If there is an image associated with this Organization, its URI can be included here.<br/>
		/// </summary>
		/// <example>If this Organization record was for the Mayo clinic, this value would be:
		/// http://www.mayoclinic.com/mymayo/img/logo.png
		/// </example>
		[DataMember]
		public String ImageURI { get; set; }

		/// <summary>
		/// The Preferred Name of the Organization
		/// </summary>
		[DataMember]
		[Required]
		public OrganizationName PreferredName { get; set; }

		/// <summary>
		/// Collection of Other names the Organization is known as
		/// </summary>
		[DataMember]
		public OrganizationName[] OtherNames { get; set; }

		/// <summary>
		/// Collection of Identifiers associated with this Organization
		/// </summary>
		[DataMember]
		public Identifier[] Identifiers { get; set; }

		/// <summary>
		/// Collection of addresses of this Organization
		/// (not usually the addresses of the sites where service are provided,
		/// often the head office which is not a service providing location)
		/// </summary>
		[DataMember]
		public Address PrimaryAddress { get; set; }

		/// <summary>
		/// Collection of addresses of this Organization
		/// (not usually the addresses of the sites where service are provided,
		/// often the head office which is not a service providing location)
		/// </summary>
		[DataMember]
		public Address[] OtherAddresses { get; set; }

		/// <summary>
		/// Collection of Contact points for this Site
		/// </summary>
		[DataMember]
		public ContactPoint[] ContactPoints { get; set; }

		/// <summary>
		/// Collection of attributes for the Organization
		/// </summary>
		/// <cts2code scope='ServD.ATTT.Org'>ServD.CTS2.References</cts2code>
		[DataMember]
		public Attribute[] Attributes { get; set; }

		/// <summary>
		/// Collections of Affiliations associated with this Organization
		/// </summary>
		[DataMember]
		public OrganizationAffiliation[] Affiliations { get; set; }

		/// <summary>
		/// Collection of Specialties handled by the Organization
		/// </summary>
		/// <cts2code scope='ServD.SPCLTY.Org'>ServD.CTS2.References</cts2code>
		[DataMember]
		public Specialty[] Specialties { get; set; }

		/// <summary>
		/// Collection of catchment areas for this Organization
		/// </summary>
		[DataMember]
		public CatchmentArea[] CatchmentAreas { get; set; }

		/// <summary>
		/// The collection of sites for this Organization
		/// </summary>
		[DataMember]
		public Site[] Sites { get; set; }
	}
}