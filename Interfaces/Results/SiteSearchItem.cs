///////////////////////////////////////////////////////////
//  SiteSearchItem.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ServD.Common;
using ServD.DataModel;

namespace ServD.Results
{
	/// <summary>
	/// The Site Search Item contains a subset of the Site's information that has been restricted down into an atomized form 
	/// that can be displayed. Generic information can be populated into the base class SearchItem's Summary properties
	/// as desired by a ServD Core instance or component.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class SiteSearchItem : SearchItem
	{
		/// <summary>
		/// ID of the Site
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public String SiteId { get; set; }

		/// <summary>
		/// ID of the Organization
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public String OrganizationId { get; set; }

		/// <summary>
		/// A textual description of the Service Site
		/// </summary>
		[DataMember]
		public string Description { get; set; }

		/// <summary>
		/// A Description of the Availability for this Site. It is constructed from the Site's AvailableTimes collection.
		/// </summary>
		[DataMember]
		public string SiteAvailabilityTimeBlock { get; set; }

		/// <summary>
		/// A description of occasions that this Site is not available.<br/>
		/// It is constructed from the Site's NotAvailableTimes collection, and the AvailabilityExceptions field.
		/// (May contain HTML formatted text)
		/// </summary>
		/// <example>eg public holidays, seasonal closures.</example>
		[DataMember]
		public string SiteAvailabilityExceptions { get; set; }

		/// <summary>
		/// Indicates the page and/or grid reference for the Site.
		/// </summary>
		[DataMember]
		public string MapReference { get; set; }

		/// <summary>
		/// A text location description for the Site.
		/// A succinct description of the location of the Site.  The description should
		/// include any additional information to help visitors access the Site that is not
		/// immediately obvious from the address information.
		/// (May contain HTML formatted text)
		/// </summary>
		/// <example>Access to 120 Spencer St is from Frances St</example>
		/// <example>Adjacent to tram stop 45 on line 70</example>
		[DataMember]
		public string LocationDescription { get; set; }

		/// <summary>
		/// Brief description of what is offered/included at a Site, as a link to further
		/// information
		/// (May contain HTML formatted text)
		/// </summary>
		[DataMember]
		public string Comment { get; set; }

		/// <summary>
		/// Website URL for the Organization
		/// </summary>
		[DataMember]
		public string WebSite { get; set; }

		/// <summary>
		/// The Latitude of the Site
		/// </summary>
		[DataMember]
		public decimal GISLatitude { get; set; }

		/// <summary>
		/// The Longitude of the Site
		/// </summary>
		[DataMember]
		public decimal GISLongitude { get; set; }
		/// <summary>
		/// The Granularity of the Site
		/// </summary>
		[DataMember]
		public int GISGranularity { get; set; }

		#region << Primary Address >>
		/// <summary>
		/// Civic address part
		/// </summary>
		[DataMember]
		public string StreetAddress { get; set; }
		/// <summary>
		/// (City, Town, Village, Area) points within a hierarchy that travels from Country
		/// down to the lowest level of jurisdiction within the specified country.
		/// </summary>
		[DataMember]
		public string Jurisdiction { get; set; }
		/// <summary>
		/// The region or state of this address.
		/// </summary>
		/// <example>California</example>
		[DataMember]
		public string Region { get; set; }
		/// <summary>
		/// The postal Identification Code contains the Zip Code or Postcode<br/>
		/// Usually this is defined by the national postal service.
		/// </summary>
		/// <example>3003</example>
		[DataMember]
		public string PostalIdentificationCode { get; set; }
		/// <summary>
		/// The country
		/// </summary>
		/// <example>Australia</example>
		[DataMember]
		public string Country { get; set; }
		#endregion

		/// <summary>
		/// Collection of Contact points for this Site
		/// </summary>
		[DataMember]
		public ContactPoint[] ContactPoints { get; set; }
	}
}
