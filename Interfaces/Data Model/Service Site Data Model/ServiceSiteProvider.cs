///////////////////////////////////////////////////////////
//  ServiceSiteProvider.cs
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
	/// <value>REVIEW: MF</value>
	/// <summary>
	/// A Provider may work from zero, one or more service sites.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class ServiceSiteProvider : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		public override string InternalId { get { return ServiceSiteProviderId; } set { ServiceSiteProviderId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.ServiceSiteProvider; } }

		/// <summary>
		/// The unique Identifier assigned by the ServD Directory
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string ServiceSiteProviderId { get; set; }

		/// <summary>
		/// The Id of the Service Site that the provider works at.
		/// </summary>
		[DataMember]
		[StringLength(50)]
		[Required]
		public string ServiceSiteId { get; set; }

		/// <summary>
		/// The Id of Provider that is working at this Service Site.
		/// </summary>
		[DataMember]
		[StringLength(50)]
		[Required]
		public string ProviderId { get; set; }

		/// <summary>
		/// Collection of Identifiers associated with this Service Site Provider
		/// </summary>
		/// <exmaple>Provider Number (where a Provider has a different number for each place he works)</exmaple>
		[DataMember]
		public Identifier[] Identifiers { get; set; }
	}
}