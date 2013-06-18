///////////////////////////////////////////////////////////
//  Maintenance.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.ServiceModel;
using ServD.Parameters;
using ServD.DataModel;
using System.Runtime.Serialization;
using ServD.Common;
using ServD.Results;

namespace ServD.Interface
{
	/// <summary>
	/// The <b>Maintenance</b> Interface actions requests to insert and update data requested by an
	/// authorized <b>Maintenance Application</b>.
	/// </summary>
	/// <summary>
	/// Each of the Add/Update routines returns an <code>UpdateRecordResult</code> collection
	/// that includes the identifiers of every new/updated record that was committed to the data store.
	/// This includes an indicator that indicates if the resulting object requires Approval.<br/>
	/// If an Author is not an Approver and attempts to set the RecordStatus to Complete, the 
	/// <b>Maintainable ServD Core</b> will reset the value to RequiresModeration.<br/>
	/// A record is updated in its entirety, attempts to update a partial record will be rejected with 
	/// an error result of type PartialRecordNotUpdatable.<br/>
	/// Refer to the UpdateRecordResult details for further information.
	/// </summary>
	/// <summary>
	/// Each object has an Id that is managed by the <b>Maintainable ServD Core</b> and all operations
	/// on the Interfaces use this Id to identify the record. During an Add it is sent null, and the
	/// return value includes the Id that was allocated.<br/>
	/// This approach is used so that even though the data type of this field is a string(50) it can
	/// be implemented by the service as an integer, GUID or another variant of string.
	/// </summary>
	/// <summary>
	/// For all of the Update operations, when processing the child objects of the object
	/// the service will search for existing items based on the Id. If the Id is null and an
	/// ExternalId is specified, then a new child record will be created.<br/>
	/// If the Id and ExternalId are both null, an error will be returned.<br/>
	/// When child objects are not included, this does not mean they should be deleted, just that
	/// there is no change. To delete a record use the DeleteRecord method.<br/>
	/// </summary>
	/// <summary>
	/// To update a child object without modifying the parent object, set the record status of the 
	/// parent object to <b>DoNotUpdate</b>.
	/// </summary>
	/// <example>When Updating An Organization's Preferred Name set the RecordStatus on the 
	/// Organization object to DoNotUpdate, and the RecordStatus on the OrganizationName object
	/// to Complete. (If the user is only an Author and not an Approver the update will change
	/// this value to CompleteAndRequiresModeration, and the Update result will be 
	/// <b>SuccessRequiresModeration</b>)</example>
	[ServiceContract(Namespace = Constants.ServDNamespace)]
	public interface Maintenance
	{
		/// <summary>
		/// Add a new Organization. This will always create an un-approved Organization record.
		/// Organization records must be approved by the ServD Operator after they have
		/// verified that the Organization details are correct and that they are authorized to
		/// create such a record.<br/>
		/// These records will not be available via the search interfaces until approved by the ServD Operator.
		/// </summary>
		/// <param name="details">
		/// The details of the Organization to be added.<br/>
		/// All object Identifiers (not the Identifiers Collection Objects) must be null, and External Identifiers
		/// populated with values (If you do not require these, just populate with a New GUID value). 
		/// If they are not that item (and its children) will not be saved.
		/// </param>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>
		/// A collection of Identifiers and their Update Status<br/>
		/// Where a parent object fails to save, the child objects may be excluded from this result list.
		/// <exmample>If the Organization fails to save, then the list of Organization Names included can be excluded</exmample>
		/// </returns>
		[OperationContract]
		UpdateRecordResult[] OrganizationAdd(Organization details, string APIkey);

		/// <summary>
		/// Provide the details of an Organization that needs to be updated 
		/// (including any child object information)
		/// </summary>
		/// <param name="details">
		/// The details of the Organization to be updated.<br/>
		/// All object Identifiers must be the values returned from a Search as this is the value
		/// used to retrieve the records to update. The ExternalId values are ignored when locating
		/// records to update.<br/>
		/// Not all child objects need to be included, only those with changes required.
		/// </param>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>
		/// A collection of Identifiers and their Update Status<br/>
		/// Where a parent object fails to save, the child objects may be excluded from this result list.
		/// </returns>
		[OperationContract]
		UpdateRecordResult[] OrganizationUpdate(Organization details, string APIkey);

		/// <summary>
		/// Add a new Site to an Organization
		/// </summary>
		/// <param name="details">
		/// The details of the Site to be added.<br/>
		/// All object Identifiers (not the Identifiers Collection Objects) must be null, and External Identifiers
		/// populated with values (If you do not require these, just populate with a New GUID value). 
		/// If they are not that item (and its children) will not be saved.
		/// </param>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>
		/// A collection of Identifiers and their Update Status<br/>
		/// Where a parent object fails to save, the child objects may be excluded from this result list.
		/// </returns>
		[OperationContract]
		UpdateRecordResult[] SiteAdd(Site details, string APIkey);

		/// <summary>
		/// Update the details of a Site
		/// </summary>
		/// <param name="details">
		/// The details of the Site to be updated.<br/>
		/// All object Identifiers must be the values returned from a Search as this is the value
		/// used to retrieve the records to update. The ExternalId values are ignored when locating
		/// records to update.<br/>
		/// Not all child objects need to be included, only those with changes required.
		/// </param>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>
		/// A collection of Identifiers and their Update Status<br/>
		/// Where a parent object fails to save, the child objects may be excluded from this result list.
		/// </returns>
		[OperationContract]
		UpdateRecordResult[] SiteUpdate(Site details, string APIkey);

		/// <summary>
		/// Add a Service Site to a Site (by Site ID)
		/// </summary>
		/// <param name="details">
		/// The details of the Service Site to be added.<br/>
		/// All object Identifiers (not the Identifiers Collection Objects) must be null, and External Identifiers
		/// populated with values (If you do not require these, just populate with a New GUID value). 
		/// If they are not that item (and its children) will not be saved.
		/// </param>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>
		/// A collection of Identifiers and their Update Status<br/>
		/// Where a parent object fails to save, the child objects may be excluded from this result list.
		/// </returns>
		[OperationContract]
		UpdateRecordResult[] ServiceSiteAdd(ServiceSite details, string APIkey);

		/// <summary>
		/// Update the details of a Service Site
		/// </summary>
		/// <param name="details">
		/// The details of the Service Site to be updated.<br/>
		/// All object Identifiers must be the values returned from a Search as this is the value
		/// used to retrieve the records to update. The ExternalId values are ignored when locating
		/// records to update.<br/>
		/// Not all child objects need to be included, only those with changes required.
		/// </param>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>
		/// A collection of Identifiers and their Update Status<br/>
		/// Where a parent object fails to save, the child objects may be excluded from this result list.
		/// </returns>
		[OperationContract]
		UpdateRecordResult[] ServiceSiteUpdate(ServiceSite details, string APIkey);

		/// <summary>
		/// Add a new Provider.
		/// </summary>
		/// <param name="details">
		/// The details of the Provider to be added.<br/>
		/// All object Identifiers (not the Identifiers Collection Objects) must be null, and External Identifiers
		/// populated with values (If you do not require these, just populate with a New GUID value). 
		/// If they are not that item (and its children) will not be saved.
		/// </param>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>
		/// A collection of Identifiers and their Update Status<br/>
		/// Where a parent object fails to save, the child objects may be excluded from this result list.
		/// </returns>
		[OperationContract]
		UpdateRecordResult[] ProviderAdd(Provider details, string APIkey);

		/// <summary>
		/// Update a Providers Details
		/// </summary>
		/// <param name="details">
		/// The details of the Provider to be updated.<br/>
		/// All object Identifiers must be the values returned from a Search as this is the value
		/// used to retrieve the records to update. The ExternalId values are ignored when locating
		/// records to update.<br/>
		/// Not all child objects need to be included, only those with changes required.
		/// </param>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>
		/// A collection of Identifiers and their Update Status<br/>
		/// Where a parent object fails to save, the child objects may be excluded from this result list.
		/// </returns>
		[OperationContract]
		UpdateRecordResult[] ProviderUpdate(Provider details, string APIkey);

		/// <summary>
		/// Associate an existing Service Site with an existing Provider.
		/// </summary>
		/// <param name="details">The details of the Service Site and Provider to associate</param>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>An Update record result that indicates the update status</returns>
		[OperationContract]
		UpdateRecordResult[] ServiceSiteProviderAdd(ServiceSiteProvider details, string APIkey);

		/// <summary>
		/// Update a specific Service Site Provider record
		/// </summary>
		/// <param name="details">The details of the Service Site Provider association to update</param>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>An Update record result that indicates the update status</returns>
		[OperationContract]
		UpdateRecordResult[] ServiceSiteProviderUpdate(ServiceSiteProvider details, string APIkey);

		/// <summary>
		/// Upload a Public Key Certificate for a Site.
		/// </summary>
		/// <remarks>
		/// This routine does not require Approver access and can be committed immediately.
		/// </remarks>
		/// <param name="SiteId">The Site to update the Public Key for</param>
		/// <param name="PublicKey">Public Key to be Updated on the Site Record</param>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>An Update record result that indicates the update status</returns>
		[OperationContract]
		UpdateRecordResult UploadSiteCertificate(String SiteId, String PublicKey, string APIkey);

		/// <summary>
		/// Upload a Public Key Certificate for a Service Site.
		/// </summary>
		/// <remarks>
		/// This routine does not require Approver access and can be committed immediately.
		/// </remarks>
		/// <param name="ServiceSiteId">The Site to update the Public Key for</param>
		/// <param name="PublicKey">Public Key to be Updated on the Service Site Record</param>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>An Update record result that indicates the update status</returns>
		[OperationContract]
		UpdateRecordResult UploadServiceSiteCertificate(String ServiceSiteId, String PublicKey, string APIkey);

		/// <summary>
		/// What records are outstanding that I have Author or Approver access to.<br/>
		/// Authors who are not Approvers can use this to see what changes have not been
		/// approved yet.
		/// </summary>
		/// <param name="Page">The page number of data to return. (0 for first page of data)</param>
		/// <param name="PageSize">The size to consider as a page of data. This is used to restrict the amount of data that is returned in the results.</param>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>A collection of summary details describing</returns>
		[OperationContract]
		RecordRequiringApproval[] GetRecordsRequiringApproval(int Page, int PageSize, string APIkey);

		/// <summary>
		/// Approve the data as specified in the list of Identifiers.<br/>
		/// This method can only be performed by Approvers.
		/// </summary>
		/// <remarks>
		/// New Organizations added to the ServD instance can only be approved by the
		/// operators of the ServD instance once they have verified the validity of the
		/// Organization record.<br/>
		/// Typically this will be a function of an internal application connected to the 
		/// ServD instance.
		/// </remarks>
		/// <param name="Identifiers">The list of record types and identifiers to be approved</param>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>A collection of the status of all of the record approvals</returns>
		[OperationContract]
		UpdateRecordResult[] ApproveRecords(RecordIndex[] Identifiers, string APIkey);

		/// <summary>
		/// Reject the data as specified in the list of Identifiers.<br/>
		/// This method can only be performed by Approvers.
		/// </summary>
		/// <remarks>
		/// If the specified record is not currently marked for approval, then an ErrorOther result status
		/// will be returned.
		/// </remarks>
		/// <param name="Identifiers">The list of record types and identifiers to be rejected</param>
		/// <param name="Comment">A comment describing the reason that the record update has been rejected.
		/// </param>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>A collection of the status of all of the record rejections</returns>
		[OperationContract]
		UpdateRecordResult[] RejectRecords(RecordIndex[] Identifiers, string Comment, string APIkey);

		/// <summary>
		/// Delete one or more records of a specified record type.
		/// </summary>
		/// <remarks>
		/// Where there are associated child links, these will also be deleted.
		/// Deletions do not automatically get approved. A separate call must be
		/// made to approve these deletions.<br/>
		/// In most implementations the deletion is likely to be a logical deletion
		/// and just not return this data via the interface.<br/>
		/// To "undelete" a deleted record an author must call the relevant Update method 
		/// with an updated RecordStatus property.
		/// </remarks>
		/// <example>
		/// When deleting an Organization Site, all Service Sites, 
		/// and Site Geographical Coordinate records will also be deleted.
		/// </example>
		/// <param name="Identifiers">The list of record type and identifiers to be deleted</param>
		/// <param name="APIkey" >The API key may be included by ServD implementations that wish to restrict
		/// access to the interface to those applications that have registered with a key.<br/>
		/// Similar to how Google Maps, Bing Maps, Facebook apps etc. control app types access.</param>
		/// <returns>A collection of the status of all of the record deletions</returns>
		[OperationContract]
		DeleteRecordResult[] DeleteRecords(RecordIndex[] Identifiers, string APIkey);
	}
}