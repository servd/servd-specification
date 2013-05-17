///////////////////////////////////////////////////////////
//  OrganizationSearchItem.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using ServD.DataModel;
using ServD.Common;
using System.Collections.Generic;

namespace ServD.Results
{
	/// <summary>
	/// The Organization Search Item contains a subset of the Organization information that has been restricted down 
	/// into an atomized form that can be displayed. Generic information can be populated into the base class SearchItem's Summary properties
	/// as desired by a ServD Core instance or component.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class OrganizationSearchItem : SearchItem
	{
		/// <summary>
		/// ID of the Organization
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public String OrganizationId { get; set; }

		#region << Preferred Name >>
		/// <summary>
		/// The name referenced.<br/>
		/// From the Organization Name record where Purpose = "Search result"
		/// </summary>
		[DataMember]
		public string Name { get; set; }
		#endregion

		/// <summary>
		/// Details the Organization’s web address.<br/>
		/// The exact web address (URL) required to find the website on any internet
		/// browser. From the Contact Point where Contact Point Type is the ServD Federation's Profile defined
		/// type for Web Contract References, and has the Purpose provided in the Organization Search Parameter.
		/// </summary>
		[DataMember]
		public string WebAddress { get; set; }
		
		/// <summary>
		/// Brief description of what is offered by an Organization, as a link to further
		/// information
		/// </summary>
		[DataMember]
		public string Comment { get; set; }

		#region << Primary Address >>
		/// <summary>
		/// Civic address part. It may contain multiple lines.
		/// </summary>
		/// <example>355 Spencer St</example>
		/// <remarks>Some systems may store this data in separated lines such as AddressLine1, AddressLine2</remarks>
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

		#region << Contact Points >>
		/// <summary>
		/// Collection of Contact points for this Site
		/// </summary>
		[DataMember]
		public ContactPoint[] ContactPoints { get; set; }
		#endregion
	}
}