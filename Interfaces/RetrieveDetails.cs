///////////////////////////////////////////////////////////
//  RetrieveDetails.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.ServiceModel;
using ServD.DataModel;

namespace ServD.Interface
{
	/// <summary>
	/// The <b>Retrieve Details</b> interface provides operations to retrieve the
	/// detailed information about Organizations, Sites, Service Sites and Providers.
	/// The Location (URI) of this Service is provided in the results for each item
	/// returned by the <b>Search </b>interface.<br/>
	/// </summary>
	/// <summary>
	/// The data returned by these operations MAY be either the public information, or
	/// information that is still subject to Content Management as requested by the use
	/// of the <b>GetUnmoderatedDataWhereAvailable</b> flag being set to true.<br/>
	/// Records must be omitted from results as indicated by the policy defined by the
	/// <b>RecordPrivacyPolicy</b> value on the Record.<br/>
	/// If a parent record is not able to be accessed, then any child object information
	/// will not be accessible either.
	/// </summary>
	[ServiceContract(Namespace = Constants.ServDNamespace)]
	public interface RetrieveDetails
	{
		/// <summary>
		/// Retrieve the complete set of details about the Organization(s) based on the
		/// Identifier(s) returned in a search.
		/// </summary>
		/// <param name="OrganizationId">The Identifier(s) of the Organization(s) to load</param>
		/// <param name="IncludeSiteData">If set to true the Sites collection on the Organization is populated</param>
		/// <param name="IncludeServiceSiteData">If set to true the ServiceSites collection on each Site is populated</param>
		/// <param name="GetUnmoderatedDataWhereAvailable">For Author/Approvers of the data return the Un-moderated data if any exists</param>
		/// <param name="APIkey" >The API key can be included by ServD Implementations that Desire to restrict
		/// Access to the interface to only applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>
		/// A collection of Organization records based on the requested identifiers, with the requested
		/// level of child objects fully populated.<br/>
		/// </returns>
		[OperationContract]
		Organization[] RetrieveOrganizationDetails(
							ServD.Common.ArrayOfString OrganizationId,
							bool IncludeSiteData,
							bool IncludeServiceSiteData,
							bool GetUnmoderatedDataWhereAvailable, string APIkey);

		/// <summary>
		/// Retrieve the Complete set of details about the Site(s) based on the
		/// Identifier(s) returned in a search.
		/// </summary>
		/// <param name="SiteId">The SiteId returned by the Search method</param>
		/// <param name="IncludeServiceSiteData">If set to true the ServiceSites collection on each Site is populated</param>
		/// <param name="GetUnmoderatedDataWhereAvailable">For Author/Approvers of the data return the Un-moderated data if any exists</param>
		/// <param name="APIkey" >The API key can be included by ServD Implementations that Desire to restrict
		/// Access to the interface to only applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>
		/// A collection of Site records based on the requested identifiers, with the requested
		/// level of child objects fully populated.
		/// </returns>
		[OperationContract]
		Site[] RetrieveSiteDetails(
							ServD.Common.ArrayOfString SiteId,
							bool IncludeServiceSiteData,
							bool GetUnmoderatedDataWhereAvailable, string APIkey);

		/// <summary>
		/// Retrieve the Complete set of details about the Service Site(s) based on the
		/// Identifier(s) returned in a search.
		/// </summary>
		/// <param name="ServiceSiteId">The Identifier(s) of the Service Site(s) to load</param>
		/// <param name="GetUnmoderatedDataWhereAvailable">For Author/Approvers of the data return the Un-moderated data if any exists</param>
		/// <param name="APIkey" >The API key can be included by ServD Implementations that Desire to restrict
		/// Access to the interface to only applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>
		/// A collection of Service Site records based on the requested identifiers, with the requested
		/// level of child objects fully populated.
		/// </returns>
		[OperationContract]
		ServiceSite[] RetrieveServiceSiteDetails(
							ServD.Common.ArrayOfString ServiceSiteId,
							bool GetUnmoderatedDataWhereAvailable, string APIkey);

		/// <summary>
		/// Retrieve the Complete set of details about the Provider(s) based on the
		/// Identifier(s) returned in a search.
		/// </summary>
		/// <param name="ProviderId">The Identifier(s) of the Provider(s) to load</param>
		/// <param name="GetUnmoderatedDataWhereAvailable">For Author/Approvers of the data return the Un-moderated data if any exists</param>
		/// <param name="APIkey" >The API key can be included by ServD Implementations that Desire to restrict
		/// Access to the interface to only applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>
		/// A collection of Provider records based on the requested identifiers, with the requested
		/// level of child objects fully populated.
		/// </returns>
		[OperationContract]
		Provider[] RetrieveProviderDetails(
							ServD.Common.ArrayOfString ProviderId,
							bool GetUnmoderatedDataWhereAvailable, string APIkey);

		/// <summary>
		/// Retrieve the Public Key(s) for the requested records based on the Identifier(s)
		/// returned by the Search
		/// </summary>
		/// <summary>
		/// At least one Identifier should be provided; otherwise the function will return an empty collection.
		/// </summary>
		/// <param name="SiteId">The list of Identifiers of the Sites to retrieve the Public Key</param>
		/// <param name="ServiceSiteId">The list of Identifiers of the Service Sites to retrieve the Public Key</param>
		/// <param name="ProviderId">The list of Identifiers of the Providers to retrieve the Public Key</param>
		/// <param name="APIkey" >The API key can be included by ServD Implementations that Desire to restrict
		/// Access to the interface to only applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>The collection of Public keys that have been requested.</returns>
		[OperationContract]
		ServD.Results.PublicKey[] RetrievePublicKeys(
							ServD.Common.ArrayOfString SiteId,
							ServD.Common.ArrayOfString ServiceSiteId,
							ServD.Common.ArrayOfString ProviderId, string APIkey);

		/// <summary>
		/// Retrieve the Complete set of details about the Service Site Provider(s) based on the
		/// Identifier(s) returned in a search.
		/// </summary>
		/// <param name="ServiceSiteProviderId">The Identifier(s) of the Service Site Provider(s) to load</param>
		/// <param name="GetUnmoderatedDataWhereAvailable">For Author/Approvers of the data return the Un-moderated data if any exists</param>
		/// <param name="APIkey" >The API key can be included by ServD Implementations that Desire to restrict
		/// Access to the interface to only applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>
		/// A collection of Service Site Provider records based on the requested identifiers, with the requested
		/// level of child objects fully populated.
		/// </returns>
		[OperationContract]
		ServiceSiteProvider[] RetrieveServiceSiteProviderDetails(
							ServD.Common.ArrayOfString ServiceSiteProviderId,
							bool GetUnmoderatedDataWhereAvailable, string APIkey);
	}
}
