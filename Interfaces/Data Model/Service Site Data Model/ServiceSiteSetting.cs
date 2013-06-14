///////////////////////////////////////////////////////////
//  ServiceSiteSetting.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ServD.Common;

namespace ServD.DataModel
{
	/// <summary>
	/// This entity describes the Service Site with respect to facilities arrangement.
	/// Is this a walk-in clinic, a corporate office environment, a surgical suite, and
	/// so on?
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class ServiceSiteSetting : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		public override string InternalId { get { return ServiceSiteSettingId; } set { ServiceSiteSettingId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.ServiceSiteSetting; } }

		/// <summary>
		/// A unique Identifier that is allocated by the saving system.<br/>
		/// When adding a new record, this is blank and will be allocated 
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public String ServiceSiteSettingId { get; set; }

		/// <summary>
		/// The value from the reference list of the Setting for the actual Service
		/// </summary>
		/// <cts2code scope='ServD.SSS'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		[Required]
		public string Code { get; set; }

		/// <summary/>
		public ServiceSiteSetting()
		{
		}

		/// <summary/>
		public ServiceSiteSetting(ServiceSiteSetting theServiceSiteSetting)
		{

		}
	}
}