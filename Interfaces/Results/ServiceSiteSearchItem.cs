///////////////////////////////////////////////////////////
//  ServiceSiteSearchItem.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ServD.Common;
using ServD.DataModel;

namespace ServD.Results
{
	/// <summary>
	/// The Service Site Search Item contains a subset of the Service Site information that has been restricted down 
	/// into an atomized form that can be displayed. Generic information can be populated into the base class SearchItem's Summary properties
	/// as desired by a ServD Core instance or component.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class ServiceSiteSearchItem : SearchItem
	{
		/// <summary>
		/// ID of the Service Site
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public String ServiceSiteId { get; set; }

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
		/// A Description of the Availability for this Service Site. 
		/// It is constructed from the Service Site's AvailableTimes collection.
		/// </summary>
		/// <remarks>
		/// If this information is not provided by the Service Site, it should return the values entered
		/// for the Site.
		/// </remarks>
		[DataMember]
		public string ServiceSiteAvailabilityTimeBlock { get; set; }

		/// <summary>
		/// A description of occasions that this Service Site is not available.<br/>
		/// It is constructed from the Service Site's NotAvailableTimes collection, and the AvailabilityExceptions field.
		/// (May contain HTML formatted text)
		/// </summary>
		/// <remarks>
		/// If this information is not provided by the Service Site, it should return the values entered
		/// for the Site.
		/// </remarks>
		/// <example>eg public holidays, seasonal closures.</example>
		[DataMember]
		public string ServiceSiteAvailabilityExceptions { get; set; }

		/// <summary>
		/// Service type from the Primary Service Type on the Service Site record.
		/// </summary>
		[DataMember]
		[StringLength(64)]
		public String ServiceType { get; set; }

		/// <summary>
		/// Further description of the service
		/// </summary>
		[DataMember]
		[StringLength(500)]
		public String ServiceName { get; set; }

		/// <summary>
		/// Collection of Contact points for this Site
		/// </summary>
		[DataMember]
		public ContactPoint[] ContactPoints { get; set; }

		/// <summary/>
		public ServiceSiteSearchItem()
		{
		}

		/// <summary/>
		public ServiceSiteSearchItem(ServiceSiteSearchItem theServiceSiteSearchItem)
		{

		}

		/// <summary/>
		public ServiceSiteSearchItem(ServD.DataModel.ServiceSite theServiceSite)
		{

		}
	}
}