///////////////////////////////////////////////////////////
//  Search.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.ServiceModel;
using ServD.Parameters;
using ServD.Results;

namespace ServD.Interface
{
	/// <summary>
	/// The <b>Search</b> interface is the core interface in the <b>ServD
	/// </b>specification. It provides operations to search for lists of summary
	/// information about <b>Organizations</b>, <b>Sites</b>, <b>Services </b>and
	/// <b>Providers</b>, and also the URIs of the associated reference lists.<br/>
	/// These reference lists must be used to validate user input for both maintaining
	/// the data, and also including in the search fields.
	/// </summary>
	/// <summary>
	/// Each record in the object model has its own moderation and security policy 
	/// information associated, and the implementation of this Search interface must 
	/// understand the structure of the Security Policy and apply this to any data that 
	/// is returned by the results of the search.
	/// </summary>
	/// <summary>
	/// The Location (URI) of the Service providing the <b>Retrieve Details
	/// </b>interface is provided in the results for each item returned by this
	/// <b>Search </b>interface.
	/// </summary>
	[ServiceContract(Namespace = Constants.ServDNamespace)]
	public interface Search
	{
		/// <summary>
		/// Perform a search for information from the ServD repository.<br/>
		/// </summary>
		/// <param name="SearchParameters">The set filter criteria to perform the search on. Which includes
		/// the scope of the search, which items of information we are interested in retrieving</param>
		/// <param name="ControlParameters">
		/// Search control options such as if Moderated data should be returned, and the page size to be used
		/// </param>
		/// <param name="APIkey">The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>
		/// The returned list of items is not in a hierarchy of Organizations, Sites, Service Sites and providers.
		/// They are returned as a simple list of objects with Ids to reference the other objects in the model.<br/>
		/// This is done so that if a <b>Searching Application</b> is performing searches for Sites repeatedly they 
		/// can do a single call to retrieve the Sites, then a secondary call to retrieve the Organizations 
		/// based on a list of ids, better permitting control over what is requested and cache information
		/// in the Searching application, only requesting for new information if it doesn't already have it loaded.
		/// </returns>
		[OperationContract]
		SearchResults Search(SearchInputParameters SearchParameters, SearchControlParameters ControlParameters, string APIkey);

		/// <summary>
		/// Retrieve the requested page of Organization summary items based on a previous search.
		/// </summary>
		/// <param name="SearchParameters">These search parameters should be the same as those passed into the initial search</param>
		/// <param name="ControlParameters">These control parameters should be the same as those passed into the initial search</param>
		/// <param name="RequestPage">The number of the page to request to load</param>
		/// <param name="APIkey">The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>A page of Organization records to continue loading the results of a previous search</returns>
		[OperationContract]
		OrganizationList MoreOrganizations(SearchInputParameters SearchParameters, SearchControlParameters ControlParameters, int RequestPage, string APIkey);

		/// <summary>
		/// Retrieve the requested page of Site summary items based on a previous search.
		/// </summary>
		/// <param name="SearchParameters">These search parameters should be the same as those passed into the initial search</param>
		/// <param name="ControlParameters">These control parameters should be the same as those passed into the initial search</param>
		/// <param name="RequestPage">The number of the page to request to load</param>
		/// <param name="APIkey">The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>A page of Site records to continue loading the results of a previous search</returns>
		[OperationContract]
		SiteList MoreSites(SearchInputParameters SearchParameters, SearchControlParameters ControlParameters, int RequestPage, string APIkey);

		/// <summary>
		/// Retrieve the requested page of Service Site summary items based on a previous search.
		/// </summary>
		/// <param name="SearchParameters">These search parameters should be the same as those passed into the initial search</param>
		/// <param name="ControlParameters">These control parameters should be the same as those passed into the initial search</param>
		/// <param name="RequestPage">The number of the page to request to load</param>
		/// <param name="APIkey">The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>A page of Service Site records to continue loading the results of a previous search</returns>
		[OperationContract]
		ServiceSiteList MoreServiceSites(SearchInputParameters SearchParameters, SearchControlParameters ControlParameters, int RequestPage, string APIkey);

		/// <summary>
		/// Retrieve the requested page of Provider summary items based on a previous search.
		/// </summary>
		/// <param name="SearchParameters">These search parameters should be the same as those passed into the initial search</param>
		/// <param name="ControlParameters">These control parameters should be the same as those passed into the initial search</param>
		/// <param name="RequestPage">The number of the page to request to load</param>
		/// <param name="APIkey">
		/// The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>A page of Provider records to continue loading the results of a previous search</returns>
		[OperationContract]
		ProviderList MoreProviders(SearchInputParameters SearchParameters, SearchControlParameters ControlParameters, int RequestPage, string APIkey);
	}
}
