///////////////////////////////////////////////////////////
//  SearchInputParameters.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServD.Parameters
{
	/// <summary>
	/// The Search Input parameters are used by the Search interface operations to filter
	/// data to find the data that they are looking for.<br/>
	/// This can be a generic free text style search using the <b>SearchFor</b> property, or a more specific
	/// filter that explicitly sets filter properties.<br/>
	/// The location or proximity properties must be specified to give a context of where you are looking 
	/// to receive the service.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class SearchInputParameters
	{
		/// <summary>
		/// Simple Address based searching.<br/>
		/// This does not have any direct relevance to the coverage areas used by the <b>Locator</b> Interface<br/>
		/// </summary>
		[DataMember]
		[Required]
		public AddressSearchParameters AddressSearchParameters { get; set; }

		/// <summary>
		/// Geographic point based filtering.<br/>
		/// This does not have any direct relevance to the coverage areas used by the <b>Locator</b> Interface<br/>
		/// </summary>
		[DataMember]
		public ProximitySearchParameters ProximitySearchParameters { get; set; }

		/// <summary>
		/// The Coverage Areas to search within.
		/// (This can be used by the ServD Locator to determine which ServD Core endpoints to search)
		/// <cts2code scope='ServD.CA'>ServD.CTS2.References</cts2code>
		/// </summary>
		[DataMember]
		public String CoverageAreaCode { get; set; }

		/// <summary>
		/// The generic "Google" style search string. This can be interpreted by the Search
		/// Service anyway that it chooses to locate services.
		/// You must select another of the Search flags to indicate which types should be
		/// searched. If none are selected, the search will assume it is searching for
		/// services.<br/>
		/// This can also include be interpreted to search for Keywords.
		/// <u>Reference:</u> 
		/// </summary>
		/// <remarks>This could be used in OpenSearch style interfaces. 
		/// (http://www.opensearch.org/Specifications/OpenSearch/1.1)</remarks>
		/// <remarks>This could also be customized to produce a Search Provider.
		/// http://blogs.msdn.com/b/jonbox/archive/2009/09/09/create-a-simple-ie8-search-provider.aspx
		/// </remarks>
		[DataMember]
		public String SearchFor { get; set; }

		/// <summary>
		/// An Additional Property that can be used as a structured query using techniques 
		/// such as query by example. The actual format of this syntax is not defined by this standard,
		/// and can be defined by the implementer of the Search interface. (Optional)
		/// </summary>
		[DataMember]
		public String StructuredQuery { get; set; }

		/// <summary>
		/// This field is used when the <b>SearchFor </b>parameter is specified
		/// </summary>
		[DataMember]
		public Boolean SearchOrganizations { get; set; }
	
		/// <summary>
		/// This field is used when the <b>SearchFor </b>parameter is specified
		/// </summary>
		[DataMember]
		public Boolean SearchProviders { get; set; }
		
		/// <summary>
		/// This field is used when the <b>SearchFor </b>parameter is specified
		/// </summary>
		[DataMember]
		public Boolean SearchServiceSites { get; set; }
		
		/// <summary>
		/// This field is used when the <b>SearchFor </b>parameter is specified
		/// </summary>
		[DataMember]
		public Boolean SearchSites { get; set; }

		/// <summary>
		/// When specified only include rows where there has been a change after this date
		/// (modification could also be from a child object of this record)
		/// </summary>
		[DataMember]
		public DateTime? ModifiedAfterDate { get; set; }
		/// <summary>
		/// Specifically look for a service that is available at/between the provided times.
		/// </summary>
		[DataMember]
		public Availability[] Availability { get; set; }

		/// <summary>
		/// Search for details explicitly related to Organization properties
		/// </summary>
		[DataMember]
		public OrganizationSearchParameters[] OrganizationSearchParameters { get; set; }

		/// <summary>
		/// Search for details explicitly related to Site properties
		/// </summary>
		[DataMember]
		public SiteSearchParameters[] SiteSearchParameters { get; set; }

		/// <summary>
		/// Search for details explicitly related to Service Site properties
		/// </summary>
		[DataMember]
		public ServiceSiteSearchParameters[] ServiceSiteSearchParameters { get; set; }

		/// <summary>
		/// Search for details explicitly related to Provider properties
		/// </summary>
		[DataMember]
		public ProviderSearchParameters[] ProviderSearchParameters { get; set; }

		/// <summary/>
		public SearchInputParameters()
		{
		}

		///// <summary/>
		//public SearchInputParameters(SearchInputParameters theSearchInputParameters)
		//{
		//	SearchFor = theSearchInputParameters.SearchFor;
		//	SearchOrganizations = theSearchInputParameters.SearchOrganizations;
		//	SearchProviders = theSearchInputParameters.SearchProviders;
		//	SearchServiceSites = theSearchInputParameters.SearchServiceSites;
		//	SearchSites = theSearchInputParameters.SearchSites;

		//	// reset them all
		//	OrganizationSearchParameters = null;
		//	SiteSearchParameters = null;
		//	ProximitySearchParameters = null;
		//	ServiceSiteSearchParameters = null;
		//	Availability = null;
		//	ProviderSearchParameters = null;
		//	LocationSearchParameters = null;

		//	// now clone the content
		//	if (theSearchInputParameters.OrganizationSearchParameters != null)
		//		OrganizationSearchParameters = theSearchInputParameters.OrganizationSearchParameters.Clone();

		//	if (theSearchInputParameters.SiteSearchParameters != null)
		//		SiteSearchParameters = new SiteSearchParameters(theSearchInputParameters.SiteSearchParameters);

		//	if (theSearchInputParameters.ProximitySearchParameters != null)
		//		ProximitySearchParameters = new ProximitySearchParameters(theSearchInputParameters.ProximitySearchParameters);

		//	if (theSearchInputParameters.ServiceSiteSearchParameters != null)
		//		ServiceSiteSearchParameters = new ServiceSiteSearchParameters(theSearchInputParameters.ServiceSiteSearchParameters);

		//	if (theSearchInputParameters.Availability != null)
		//	{
		//		List<Availability> availabilities = new List<Availability>();
		//		foreach (Availability other in theSearchInputParameters.Availability)
		//		{
		//			availabilities.Add(new Availability(other));
		//		}
		//		Availability = availabilities.ToArray();
		//	}

		//	if (theSearchInputParameters.ProviderSearchParameters != null)
		//		ProviderSearchParameters = new ProviderSearchParameters(theSearchInputParameters.ProviderSearchParameters);

		//	if (theSearchInputParameters.LocationSearchParameters != null)
		//		LocationSearchParameters = new LocationSearchParameters(theSearchInputParameters.LocationSearchParameters);
		//}
	}
}