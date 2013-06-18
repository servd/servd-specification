///////////////////////////////////////////////////////////
//  Site.cs
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
	/// A Site is some place where service is provided. This may be a bricks-and-mortar
	/// location, a mobile laboratory, a temporary location, or any other relevant Site.
	/// 
	/// In the HCP model this is often referred to as a Service Site.  The term
	/// “service” has been dropped here to avoid confusion with the entity that
	/// contains service information.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class Site : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		public override string InternalId { get { return SiteId; } set { SiteId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.Site; } }

		/// <summary>
		/// A unique Identifier that is allocated by the saving system
		/// When adding a new Site, this is blank and will be allocated
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string SiteId { get; set; }

		/// <summary>
		/// The Id of the Parent Organization Record
		/// </summary>
		/// <remarks>This is not a mandatory field as during an Add operation this field will be filled in</remarks>
		[DataMember]
		[StringLength(50)]
		public String OrganizationId { get; set; }

		/// <summary>
		/// A textual description of the Site
		/// </summary>
		[DataMember]
		[StringLength(250)]
		[Required]
		public string Description { get; set; }

		/// <summary>
		/// Brief description of what is offered/included at a Site, as a link to further
		/// information.<br/>
		/// (May contain HTML formatted text)
		/// </summary>
		[DataMember]
		[StringLength(2048)]
		public string Comment { get; set; }

		/// <summary>
		/// If there is an image associated with this Site, its URI can be included here.<br/>
		/// This could be different to the Organizations Image, for example if a Vision Research wing
		/// had a specific custom logo, it would be included here.
		/// </summary>
		[DataMember]
		public String ImageURI { get; set; }

		/// <summary>
		/// A Collection of times that the Service Site is available (overriding the Site values)
		/// </summary>
		[DataMember]
		public Available[] AvailableTimes { get; set; }

		/// <summary>
		/// A Collection of times that the Service Site is not available (overriding the Site values)
		/// </summary>
		[DataMember]
		public NotAvailable[] NotAvailableTimes { get; set; }

		/// <summary>
		/// A description of Site availability exceptions, e.g. public holiday availability.
		/// Succinctly describing all possible exceptions to normal Site availability as
		/// details in the Available Times and Not Available Times.<br/>
		/// (May contain HTML formatted text)
		/// </summary>
		[DataMember]
		[StringLength(1000)]
		public string AvailabilityExceptions { get; set; }

		/// <summary>
		/// A text location description for the Site.<br/>
		/// A succinct description of the location of the Site.  The description should
		/// include any additional information to help visitors access the Site that is not
		/// immediately obvious from the address information.<br/>
		/// (May contain HTML formatted text)
		/// </summary>
		/// <example>Access to 120 Spencer St is from Frances St</example>
		/// <example>Adjacent to tram stop 45 on line 70</example>
		[DataMember]
		[StringLength(1000)]
		public string LocationDescription { get; set; }

		/// <summary>
		/// Indicates the page and/or grid reference for the Site.
		/// </summary>
		[DataMember]
		[StringLength(100)]
		public string MapReference { get; set; }

		/// <summary>
		/// A Description of the Source of the Map Reference information.
		/// </summary>
		/// <example>Melways</example>
		/// <remarks>
		/// This was not in the reference model, but is useful context 
		/// to present with the Map Reference Field
		/// </remarks>
		[DataMember]
		[StringLength(100)]
		public string MapReferenceSource { get; set; }

		/// <summary>
		/// The public part of the ‘keys’ allocated to an Organization by an accredited
		/// body to support secure exchange of data over the internet.
		/// To be provided by the Organization, where available.<br/>
		/// The length of this string is undefined and should be of an un-restricted type.
		/// </summary>
		/// <remarks>This is a base64 encoded digital certificate. The ServD Federation's Profile will
		/// specify the type of certificate to be used and its purpose.</remarks>
		[DataMember]
		public string PublicKey { get; set; }

		/// <summary>
		/// Web service address of the ELS server's Lookup interface
		/// </summary>
		/// <example>https://els.yourcompany.com/elslookup.svc</example>
		[DataMember]
		[StringLength(2048)]
		public string ELSURL { get; set; }

		/// <summary>
		/// Collection of addresses of this Site
		/// </summary>
		[DataMember]
		public Address PrimaryAddress { get; set; }

		/// <summary>
		/// Collection of addresses of this Site
		/// </summary>
		[DataMember]
		public Address[] OtherAddresses { get; set; }

		/// <summary>
		/// Collection of Identifiers associated with this Site
		/// </summary>
		[DataMember]
		public Identifier[] Identifiers { get; set; }

		/// <summary>
		/// Collection of attributes for the Site
		/// </summary>
		/// <cts2code scope='ServD.ATTT.Site'>ServD.CTS2.References</cts2code>
		[DataMember]
		public Attribute[] Attributes { get; set; }

		/// <summary>
		/// Collection of Contact points for this Site
		/// </summary>
		[DataMember]
		public ContactPoint[] ContactPoints { get; set; }

		/// <summary>
		/// Collection of catchment areas for this Organization
		/// </summary>
		[DataMember]
		public CatchmentArea[] CatchmentAreas { get; set; }

		/// <summary>
		/// Collection of locations that this Site can be found
		/// </summary>
		[DataMember]
		public SiteGeographicalCoordinate[] GeographicalCoordinates { get; set; }

		/// <summary>
		/// Collection of Services provided at this Site
		/// </summary>
		[DataMember]
		public ServiceSite[] ServiceSites { get; set; }
	}
}