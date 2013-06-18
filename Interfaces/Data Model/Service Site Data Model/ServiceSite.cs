///////////////////////////////////////////////////////////
//  ServiceSite.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ServD.Common;

namespace ServD.DataModel
{
	/// <summary>
	/// The Service as operated at a Site
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class ServiceSite : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		public override string InternalId { get { return ServiceSiteId; } set { ServiceSiteId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.ServiceSite; } }

		/// <summary>
		/// A unique Identifier that is allocated by the saving system
		/// When adding a new Service Site, this is blank and will be allocated
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string ServiceSiteId { get; set; }

		/// <summary>
		/// The Id of the Parent Site Record
		/// </summary>
		/// <remarks>This is not a mandatory field as during an Add operation this field will be filled in</remarks>
		[DataMember]
		[StringLength(50)]
		public String SiteId { get; set; }

		/// <summary>
		/// Identifies the broad category of service being performed or delivered.
		/// Selecting a Service Category then determines the list of relevant service types
		/// that can be selected in the Primary Service Type.
		/// </summary>
		/// <cts2code scope='ServD.SC'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public String ServiceCategory { get; set; }

		/// <summary>
		/// The specific type of service being delivered or performed.
		/// </summary>
		[DataMember]
		public ServiceType PrimaryServiceType { get; set; }

		/// <summary>
		/// Further description of the service
		/// </summary>
		[DataMember]
		[StringLength(500)]
		public string ServiceName { get; set; }

		/// <summary>
		/// Brief description of a Service Site or any specific issues not covered by the
		/// other attributes.
		/// </summary>
		[DataMember]
		[StringLength(2048)]
		public string Comment { get; set; }

		/// <summary>
		/// Extra details about the service that can’t be placed in the other fields.
		/// </summary>
		[DataMember]
		[StringLength(2048)]
		public string ExtraDetails { get; set; }

		/// <summary>
		/// The free provision code provides a link to the Free Provision reference entity
		/// to enable the selection of one free provision type.
		/// </summary>
		/// <cts2code scope='ServD.SSFPC'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string FreeProvisionCode { get; set; }
	
		/// <summary>
		/// Describes the eligibility conditions for the Service Site.
		/// </summary>
		[DataMember]
		public ConditionalIndicatorEnum Eligibility { get; set; }
		
		/// <summary>
		/// Describes the eligibility conditions for the service.<br/>
		/// The description of service eligibility should, in general, not exceed one or
		/// two paragraphs.  It should be sufficient for an prospective consumer to
		/// determine if they are likely to be eligible or not. Where eligibility
		/// requirements and conditions are complex, it may simply be noted that an
		/// eligibility assessment is required.
		/// Where eligibility is determined by an outside source, such as an Act of Parliament, 
		/// this should be noted, preferably with a reference to a commonly available copy 
		/// of the source document such as a web page.
		/// </summary>
		[DataMember]
		[StringLength(2048)]
		public string EligibilityNote { get; set; }
		
		/// <summary>
		/// Indicates whether or not a prospective consumer will require an appointment for
		/// a particular service at a Site.
		/// To be provided by the Organization.
		/// Indicates if an appointment is required for access to this service.
		/// If this flag is 'NotDefined' then this flag is be overridden by the Site’s availability flag.
		/// </summary>
		[DataMember]
		public ConditionalIndicatorEnum AppointmentRequired { get; set; }

		/// <summary>
		/// If there is an image associated with this Service Site, its URI can be included here.
		/// </summary>
		[DataMember]
		public String ImageURI { get; set; }

		/// <summary>
		/// Secondary Service types for this particular service.
		/// </summary>
		[DataMember]
		public ServiceType[] AdditionalServiceTypes { get; set; }

		/// <summary>
		/// A Collection of times that the Service Site is available (overriding the Site values)
		/// </summary>
		[DataMember]
		public Available[] AvailableTimes { get; set; }

		/// <summary>
		/// A Collection of times that the Service Site is not available (overriding the Site values)
		/// </summary>
		[DataMember]
		public NotAvailable[] NotAvailableTimes { get; set; }

		/// <summary>
		/// A description of Site availability exceptions, eg public holiday availability.
		/// Succinctly describing all possible exceptions to normal Site availability as
		/// details in the Available Times and Not Available Times.<br/>
		/// (May contain HTML formatted text)
		/// </summary>
		/// <remarks>This is copied from the Site for consistency</remarks>
		[DataMember]
		[StringLength(1000)]
		public string AvailabilityExceptions { get; set; }

		/// <summary>
		/// The public part of the ‘keys’ allocated to an Organization by an accredited
		/// body to support secure exchange of data over the internet.
		/// To be provided by the Organization, where available.<br/>
		/// The length of this string is undefined and should be of an un-restricted type.
		/// </summary>
		/// <remarks>This is a base64 encoded digital certificate. The ServD Federation's Profile will
		/// specify the type of certificate to be used and its purpose.</remarks>
		[DataMember]
		public string PublicKey { get; set; }

		/// <summary>
		/// Web service address of the ELS server's Lookup interface
		/// </summary>
		/// <example>https://els.yourcompany.com/elslookup.svc</example>
		[DataMember]
		[StringLength(2048)]
		public string ELSURL { get; set; }

		/// <summary>
		/// Program Names that can be used to categorize the service.
		/// </summary>
		[DataMember]
		[StringLength(256)]
		public string ProgramNames { get; set; }
		
		/// <summary>
		/// Collection of Identifiers associated with this Service Site
		/// </summary>
		[DataMember]
		public Identifier[] Identifiers { get; set; }

		/// <summary>
		/// Collection of Contact points for this Site
		/// </summary>
		[DataMember]
		public ContactPoint[] ContactPoints { get; set; }

		/// <summary>
		/// Collection of Characteristics (attributes) for the Service Site
		/// </summary>
		/// <cts2code scope='ServD.ATTT.SS'>ServD.CTS2.References</cts2code>
		[DataMember]
		public Attribute[] Characteristics { get; set; }

		/// <summary>
		/// Collection of Referral Methods for the Service Site
		/// </summary>
		[DataMember]
		public ReferralMethod[] ReferralMethods { get; set; }

		/// <summary>
		/// Collection of Settings for the Service Site
		/// </summary>
		[DataMember]
		public ServiceSiteSetting[] Settings { get; set; }

		/// <summary>
		/// Collection of Target Groups for the Service Site
		/// (The target audience that this service is for)
		/// </summary>
		[DataMember]
		public ServiceSiteTargetGroup[] TargetGroups { get; set; }

		/// <summary>
		/// Collection of coverage areas for this Service Site
		/// </summary>
		[DataMember]
		public CoverageArea[] CoverageAreas { get; set; }

		/// <summary>
		/// Collection of catchment areas for this Service Site
		/// </summary>
		[DataMember]
		public CatchmentArea[] CatchmentAreas { get; set; }

		/// <summary>
		/// Collection of Provider Ids that work at this Service Site
		/// </summary>
		[DataMember]
		public ServiceSiteProvider[] Providers { get; set; }

		/// <summary>
		/// Collection of Specialties handled by the Service Site
		/// </summary>
		/// <cts2code scope='ServD.SPCLTY.SS'>ServD.CTS2.References</cts2code>
		[DataMember]
		public Specialty[] Specialties { get; set; }
	}
}
