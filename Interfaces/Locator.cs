///////////////////////////////////////////////////////////
//  Locator.cs
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
	/// The <b>Locator</b> interface provides a way to locate ServD Core Instances that 
	/// expose the <b>Search</b> interface for a requested Coverage Area.<br/>
	/// In simplest terms it is an indexer of <b>ServD Core</b> instances based on Coverage Areas.
	/// Each Coverage Area can have one or more relationships with any other Coverage Area, as defined
	/// by the CTS2 reference list 'ServD.CA', which can be found at the URL returned by a call to
	/// <b>GetReferenceListDetails('ServD.CA')</b>
	/// </summary>
	[ServiceContract(Namespace = Constants.ServDNamespace)]
	public interface Locator
	{
		/// <summary>
		/// This method locates web service URL(s) for ServD Core instances that implement the
		/// <b>Search</b> Interface<br/>
		/// <i>Finds the URL of the Web Server that is providing the search interface
		/// details for the specified information.</i>
		/// </summary>
		/// <param name="CoverageAreaCode">
		/// The Code of the Coverage Area to find <b>ServD Core</b> endpoints that have data relevant to that Area.
		/// <cts2code scope='ServD.CA'>ServD.CTS2.References</cts2code>
		/// </param>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>A list of <b>ServD Core</b> endpoint URLs that implement the <b>ServD Search</b> interface</returns>
		[OperationContract]
		ServD.Common.ArrayOfString LocateSearchEndpointsForCoverageArea(String CoverageAreaCode, string APIkey);

		/// <summary>
		/// This method is used locate the URL(s) of the CTS2 reference list(s) of the defined type(s).
		/// These can be used to populate drop down lists, create look-a-head while typing
		/// user interactions or validation user input prior to issuing a call to the
		/// Search operations.
		/// </summary>
		/// <param name="ReferenceListTypes">The list of cts2 domain(s) of lookup list details to be retrieved.
		/// </param>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>
		/// A list of the details of the cts2 reference list(s), specifically its web address URL 
		/// so that it can be accessed for user interfaces to retrieve the reference codes/descriptions.
		/// </returns>
		/// <param name="InterfaceFormat">
		/// The Interface format of the interfaces supported by the URLs returned.
		/// <example>CST2-REST, CST2-WSDL</example>
		/// </param>
		[OperationContract]
		ReferenceListDetail[] GetReferenceListDetails(ServD.Common.ArrayOfString ReferenceListTypes, string InterfaceFormat, string APIkey);
	}

	/// <summary>
	/// The <b>Locator</b> interface provides a way to locate ServD Core instances that
	/// expose the <b>Search</b> interface for a requested Coverage Area.
	/// </summary>
	[ServiceContract(Namespace = Constants.ServDNamespace)]
	public interface LocatorMaintenance
	{
		/// <summary>
		/// Register a <b>ServD Core</b> instance with the <b>ServD Locator</b>
		/// </summary>
		/// <param name="Address">
		/// The URL of a <b>ServD Core</b> implements the <b>ServD Search</b> interface
		/// </param>
		/// <param name="CoverageAreaCodes">
		/// A Collection of Coverage Areas to associate with the specified <b>ServD Core</b>
		/// <cts2code scope='ServD.CA'>ServD.CTS2.References</cts2code>
		/// </param>
		/// <param name="RemoveExistingEntries">
		/// If this parameter is true, then any entries not in the list provided will be removed from the configuration.
		/// </param>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>
		/// A simple summary of the number of records that were affected
		/// </returns>
		[OperationContract]
		LocatorUpdateResult RegisterSearchEndpointForCoverageArea(String Address, ServD.Common.ArrayOfString CoverageAreaCodes, bool RemoveExistingEntries, string APIkey);

		/// <summary>
		/// Remove all coverage areas allocated to this <b>ServD Core</b> endpoint.
		/// </summary>
		/// <param name="Address">
		/// The URL of a <b>ServD Core</b> implements the <b>ServD Search</b> interface that wishes to
		/// un-register all data from the Locator's index.
		/// </param>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>
		/// A simple summary of the number of records that were affected
		/// </returns>
		[OperationContract]
		LocatorUpdateResult UnregisterSearchEndpointForAllCoverageAreas(String Address, string APIkey);

		/// <summary>
		/// Remove a set of CoverageAreaCode(s) from the index for a specific <b>ServD Core</b> endpoint.
		/// </summary>
		/// <param name="Address">
		/// The URL of a <b>ServD Core</b>
		/// </param>
		/// <param name="CoverageAreaCodes">
		/// The Code(s) of the Coverage Area(s) to associate with <b>ServD Core</b> endpoint
		/// <cts2code scope='ServD.CA'>ServD.CTS2.References</cts2code>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// </param>
		/// <returns>
		/// A simple summary of the number of records that were affected
		/// </returns>
		[OperationContract]
		LocatorUpdateResult UnregisterSearchEndpointForCoverageArea(string Address, ServD.Common.ArrayOfString CoverageAreaCodes, string APIkey);
	}
}
