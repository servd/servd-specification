///////////////////////////////////////////////////////////
//  RecordTypeEnum.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ServD.Common
{
	/// <value>REVIEW: MF</value>
	/// <summary>
	/// The Record Type Enumeration is used by the Maintenance Interface
	/// for handling batches of information for approval, deletions and update statuses
	/// </summary>
	/// <note>
	/// This enumeration does not start at 0 to assist in enforcing that the normal 
	/// default is not used and forces its explicit value to be set.
	/// </note>
	[DataContract(Namespace = Constants.ServDNamespace, Name = "RecordType")]
	public enum RecordTypeEnum
	{
		/// <summary>
		/// Organization Record Type
		/// </summary>
		[EnumMember]
		Organization = 1,

		/// <summary>
		/// Organization Affiliation Record Type
		/// </summary>
		[EnumMember]
		OrganizationAffiliation = 2,

		/// <summary>
		/// Organization Name Record Type
		/// </summary>
		[EnumMember]
		OrganizationName = 3,

		/// <summary>
		/// Provider Record Type
		/// </summary>
		[EnumMember]
		Provider = 10,

		/// <summary>
		/// Provider Language Record Type
		/// </summary>
		[EnumMember]
		ProviderLanguage = 11,

		/// <summary>
		/// Provider Name Record Type
		/// </summary>
		[EnumMember]
		ProviderName = 12,

		/// <summary>
		/// Service Site Record Type
		/// </summary>
		[EnumMember]
		ServiceSite = 20,

		/// <summary>
		/// Service Site Provider Record Type
		/// </summary>
		[EnumMember]
		ServiceSiteProvider = 21,

		/// <summary>
		/// Service Site Setting Record Type
		/// </summary>
		[EnumMember]
		ServiceSiteSetting = 22,

		/// <summary>
		/// Service Site Target Group Record Type
		/// </summary>
		[EnumMember]
		ServiceSiteTargetGroup = 23,

		/// <summary>
		/// Service Type Record Type
		/// </summary>
		[EnumMember]
		ServiceType = 24,

		/// <summary>
		/// Site Record Type
		/// </summary>
		[EnumMember]
		Site = 30,

		/// <summary>
		/// Site Geographical Coordinate Record Type
		/// </summary>
		[EnumMember]
		SiteGeographicalCoordinate = 31,

		/// <summary>
		/// Address Record Type
		/// </summary>
		[EnumMember]
		Address = 40,

		/// <summary>
		/// Attribute Record Type
		/// </summary>
		[EnumMember]
		Attribute = 41,

		/// <summary>
		/// Available Record Type
		/// </summary>
		[EnumMember]
		Available = 42,

		/// <summary>
		/// Contact Point Record Type
		/// </summary>
		[EnumMember]
		ContactPoint = 43,

		/// <summary>
		/// Not Available Record Type
		/// </summary>
		[EnumMember]
		NotAvailable = 44,

		/// <summary>
		/// Keyword Record Type
		/// </summary>
		[EnumMember]
		Keyword = 45,

		/// <summary>
		/// Identifier Record Type
		/// </summary>
		[EnumMember]
		Identifier = 46,

		/// <summary>
		/// Catchment Area Record Type
		/// </summary>
		[EnumMember]
		CatchmentArea = 47,

		/// <summary>
		/// Specialty Record Type
		/// </summary>
		[EnumMember]
		Specialty = 48,

		/// <summary>
		/// Referral Method Record Type
		/// </summary>
		[EnumMember]
		ReferralMethod = 49,

		/// <summary>
		/// Coverage Area Record Type
		/// </summary>
		[EnumMember]
		CoverageArea = 50
	}
}
