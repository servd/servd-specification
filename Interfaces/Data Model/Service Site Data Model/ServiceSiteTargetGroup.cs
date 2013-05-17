///////////////////////////////////////////////////////////
//  ServiceSiteTargetGroup.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ServD.Common;

namespace ServD.DataModel
{
	/// <value>REVIEW: MF</value>
	/// <summary>
	/// Some service sites are directed to specific target groups: the Site might be on
	/// a reserve and available to First Nations peoples. A Site might be in existence
	/// to serve the HIV community, and so on. This entity allows a Site to be
	/// classified if required.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class ServiceSiteTargetGroup : ModeratedRecord
	{		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		public override string InternalId { get { return ServiceSiteTargetGroupId; } set { ServiceSiteTargetGroupId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.ServiceSiteTargetGroup; } }
		
		/// <summary>
		/// A unique Identifier that is allocated by the saving system.<br/>
		/// When adding a new record, this is blank and will be allocated 
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string ServiceSiteTargetGroupId { get; set; }

		/// <summary>
		/// The value from the reference list of the Target Group for the actual Service
		/// </summary>
		/// <cts2code scope='ServD.SSTG'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		[Required]
		public string Code { get; set; }

		/// <summary/>
		public ServiceSiteTargetGroup()
		{
		}

		/// <summary/>
		public ServiceSiteTargetGroup(ServiceSiteTargetGroup theServiceSiteTargetGroup)
		{

		}
	}
}