///////////////////////////////////////////////////////////
//  VerifyDetails.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.ServiceModel;
using ServD.DataModel;

namespace ServD.Interface
{
	/// <value>REVIEW: MF</value>
	/// <summary>
	/// The Verify Details Interface is exposed by a <b>ServD Verifier</b> to permit a 
	/// <b>Maintainable ServD Core</b> to verify claims made by a <b>Maintenance Application</b>
	/// that they have a specified attribute which is configured to be validated externally.<br/>
	/// This is the mechanism for certification/registration Organizations to be able to 
	/// electronically provide verification services to claims made that they have specific attributes.
	/// </summary>
	/// <remarks>
	/// This could include: Health Practitioner Registration Boards, Insurance company 
	/// coverage information, Departmental coverage (supports DVA services)
	/// </remarks>
	[ServiceContract(Namespace = Constants.ServDNamespace)]
	public interface VerifyDetails
	{
		/// <summary>
		/// Verify this Organization has the claimed attribute
		/// </summary>
		/// <param name="AttributeValue" validation="mandatory">
		/// The value that the Organization is claiming to have
		/// </param>
		/// <param name="AttributeType" validation="mandatory">
		/// The type of Attribute that is being claimed that the Organization has
		/// </param>
		/// <param name="OrganizationIdentifier" validation="mandatory">
		/// This is a specific Identifier attached to the Organization, not the OrganizationId from the ServD repository
		/// </param>
		/// <param name="Name" validation="optional">The name of the Organization claimed to have the attribute specified (Optional)</param>
		/// <param name="addresses">The current addresses of the Organization (Optional)</param>
		/// <param name="contacts">The current contacts of the Organization (Optional)</param>
		/// <param name="APIkey" >The API key can be included by ServD Implementations that Desire to restrict
		/// Access to the interface to only applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>
		/// The results of the Verification of the attribute, including signed data for the purpose of non-repudiation
		/// </returns>
		[OperationContract]
		ServD.Results.AttributeVerificationResult VerifyOrganization(String AttributeType, String AttributeValue, string OrganizationIdentifier, string Name, ServD.DataModel.Address[] addresses, ServD.DataModel.ContactPoint[] contacts, string APIkey);

		/// <summary>
		/// Verify this Provider has the claimed attribute
		/// </summary>
		/// <param name="AttributeValue" validation="mandatory">The value that the Provider is claiming to have</param>
		/// <param name="AttributeType" validation="mandatory">The type of Attribute that is being claimed that the Provider has</param>
		/// <param name="ProviderIdentifier" validation="mandatory">This is a specific Identifier attached to the Provider, not the ProviderId from the ServD repository.</param>
		/// <param name="FamilyName">The Family Name of the Provider claimed to have the attribute specified (Optional)</param>
		/// <param name="GivenNames">The Given Name(s) of the Provider claimed to have the attribute specified (Optional)</param>
		/// <param name="addresses">The current addresses of the Provider (Optional)</param>
		/// <param name="contacts">The current contacts of the Provider (Optional)</param>
		/// <param name="APIkey" >The API key can be included by ServD Implementations that Desire to restrict
		/// Access to the interface to only applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>
		/// The results of the check of the attribute, including signed data when the attribute is verified
		/// </returns>
		[OperationContract]
		ServD.Results.AttributeVerificationResult VerifyProvider(String AttributeType, String AttributeValue, string ProviderIdentifier, string FamilyName, string GivenNames, ServD.DataModel.Address[] addresses, ServD.DataModel.ContactPoint[] contacts, string APIkey);

		/// <summary>
		/// Verify this Site has the claimed attribute
		/// </summary>
		/// <param name="AttributeValue" validation="mandatory">The value that the Site is claiming to have</param>
		/// <param name="AttributeType" validation="mandatory">The type of Attribute that is being claimed that the Site has</param>
		/// <param name="SiteIdentifier" validation="mandatory">This is a specific Identifier attached to the Site, not the SiteId from the ServD repository.</param>
		/// <param name="Name">The name of the Site claimed to have the attribute specified (Optional)</param>
		/// <param name="addresses">The current addresses of the Site (Optional)</param>
		/// <param name="contacts">The current contacts of the Site (Optional)</param>
		/// <param name="APIkey" >The API key can be included by ServD Implementations that Desire to restrict
		/// Access to the interface to only applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>
		/// The results of the check of the attribute, including signed data when the attribute is verified
		/// </returns>
		[OperationContract]
		ServD.Results.AttributeVerificationResult VerifySite(String AttributeType, String AttributeValue, string SiteIdentifier, string Name, ServD.DataModel.Address[] addresses, ServD.DataModel.ContactPoint[] contacts, string APIkey);
	}
}
