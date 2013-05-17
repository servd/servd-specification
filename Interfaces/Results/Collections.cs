///////////////////////////////////////////////////////////
//  Collections.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServD.Common;
using ServD.Parameters;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServD.Results
{
	/// <value>REVIEW: MF</value>
	/// <summary>
	/// The Search Results object exposes the results of the Search Operations.<br/>
	/// These collections are provided to permit the searcher to 
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class SearchResults
	{
		/// <summary>
		/// The collection of Organization Summary Items
		/// </summary>
		[DataMember]
		public OrganizationList Organizations { get; set; }

		/// <summary>
		/// The collection of Site Summary Items
		/// </summary>
		[DataMember]
		public SiteList Sites { get; set; }

		/// <summary>
		/// The collection of Service Site Summary Items
		/// </summary>
		[DataMember]
		public ServiceSiteList ServiceSites { get; set; }

		/// <summary>
		/// The collection of Provider Summary Items
		/// </summary>
		[DataMember]
		public ProviderList Providers { get; set; }

		/// <summary/>
		public SearchResults()
		{
		}
	}

	/// <value>REVIEW: MF</value>
	/// <summary>
	/// A Paged List of Organizations returned from the Search method
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class OrganizationList : PagedSearchResults
	{
		/// <summary>
		/// The actual list of Organization items for this page of data
		/// </summary>
		[DataMember]
		public OrganizationSearchItem[] Items { get; set; }
	}

	/// <value>REVIEW: MF</value>
	/// <summary>
	/// A Paged List of Sites returned from the Search method
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class SiteList : PagedSearchResults
	{
		/// <summary>
		/// The actual list of Site items for this page of data
		/// </summary>
		[DataMember]
		public SiteSearchItem[] Items { get; set; }
	}

	/// <value>REVIEW: MF</value>
	/// <summary>
	/// A Paged List of Service Sites returned from the Search method
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class ServiceSiteList : PagedSearchResults
	{
		/// <summary>
		/// The actual list of Service Site items for this page of data
		/// </summary>
		[DataMember]
		public ServiceSiteSearchItem[] Items { get; set; }
	}

	/// <value>REVIEW: MF</value>
	/// <summary>
	/// A Paged List of Providers returned from the Search method
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class ProviderList : PagedSearchResults
	{
		/// <summary>
		/// The actual list of Provider items for this page of data
		/// </summary>
		[DataMember]
		public ProviderSearchItem[] Items { get; set; }
	}

	///// <summary>
	///// 
	///// </summary>
	//[DataContract(Namespace = Constants.ServDNamespace)]
	//public class CoverageAreas
	//{
	//	/// <summary>
	//	/// 
	//	/// </summary>
	//	[DataMember]
	//	public CoverageArea> Results { get; set; }
	//}

	/// <value>REVIEW: MF</value>
	/// <summary>
	/// Retrieve the details of a specific CTS2 Reference list so that
	/// connecting to the list is possible.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class ReferenceListDetail
	{
		/// <summary>
		/// The CTS2 code type for the reference list provided by this address
		/// </summary>
		[Key]
		[Column(Order = 0)]
		[DataMember]
		[StringLength(64)]
		public string CodeType { get; set; }

		/// <summary>
		/// The Interface format of the interfaces supported by the URLs returned.
		/// <example>CST2-REST, CST2-WSDL</example>
		/// </summary>
		[Key]
		[Column(Order = 1)]
		[IgnoreDataMember]
		[StringLength(64)]
		public string InterfaceFormat { get; set; }

		/// <summary>
		/// The Web Address of the Reference List that implements the CTS2 specification
		/// </summary>
		[DataMember]
		public string URL { get; set; }

		/// <summary>
		/// This description can be used on the label to be shown to the user relating to the
		/// user interface component for selecting the value.
		/// </summary>
		[DataMember]
		public string Description { get; set; }
	}
}
