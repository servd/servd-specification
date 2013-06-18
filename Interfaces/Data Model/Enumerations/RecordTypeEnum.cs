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
		Organization,

		/// <summary>
		/// Organization Affiliation Record Type
		/// </summary>
		[EnumMember]
		OrganizationAffiliation,

		/// <summary>
		/// Organization Name Record Type
		/// </summary>
		[EnumMember]
		OrganizationName,

		/// <summary>
		/// Provider Record Type
		/// </summary>
		[EnumMember]
		Provider,

		/// <summary>
		/// Provider Language Record Type
		/// </summary>
		[EnumMember]
		ProviderLanguage,

		/// <summary>
		/// Provider Name Record Type
		/// </summary>
		[EnumMember]
		ProviderName,

		/// <summary>
		/// Service Site Record Type
		/// </summary>
		[EnumMember]
		ServiceSite,

		/// <summary>
		/// Service Site Provider Record Type
		/// </summary>
		[EnumMember]
		ServiceSiteProvider,

		/// <summary>
		/// Service Site Setting Record Type
		/// </summary>
		[EnumMember]
		ServiceSiteSetting,

		/// <summary>
		/// Service Site Target Group Record Type
		/// </summary>
		[EnumMember]
		ServiceSiteTargetGroup,

		/// <summary>
		/// Service Type Record Type
		/// </summary>
		[EnumMember]
		ServiceType,

		/// <summary>
		/// Site Record Type
		/// </summary>
		[EnumMember]
		Site,

		/// <summary>
		/// Site Geographical Coordinate Record Type
		/// </summary>
		[EnumMember]
		SiteGeographicalCoordinate,

		/// <summary>
		/// Address Record Type
		/// </summary>
		[EnumMember]
		Address,

		/// <summary>
		/// Attribute Record Type
		/// </summary>
		[EnumMember]
		Attribute,

		/// <summary>
		/// Available Record Type
		/// </summary>
		[EnumMember]
		Available,

		/// <summary>
		/// Contact Point Record Type
		/// </summary>
		[EnumMember]
		ContactPoint,

		/// <summary>
		/// Not Available Record Type
		/// </summary>
		[EnumMember]
		NotAvailable,

		/// <summary>
		/// Keyword Record Type
		/// </summary>
		[EnumMember]
		Keyword,

		/// <summary>
		/// Identifier Record Type
		/// </summary>
		[EnumMember]
		Identifier,

		/// <summary>
		/// Catchment Area Record Type
		/// </summary>
		[EnumMember]
		CatchmentArea,

		/// <summary>
		/// Specialty Record Type
		/// </summary>
		[EnumMember]
		Specialty,

		/// <summary>
		/// Referral Method Record Type
		/// </summary>
		[EnumMember]
		ReferralMethod,

		/// <summary>
		/// Coverage Area Record Type
		/// </summary>
		[EnumMember]
		CoverageArea
	}
}
