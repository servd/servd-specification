///////////////////////////////////////////////////////////
//  NotAvailable.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ServD.Common;

namespace ServD.DataModel
{
	///<value>REVIEW: MF</value>
	/// <summary>
	/// The NotAvailable object defines a range of dates that are not available.<br/>
	/// Can be used for cases where the Service or Site is closed, or equipment for
	/// some services is under repair and will be unavailable for a period of time.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class NotAvailable : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		public override string InternalId { get { return NotAvailableId; } set { NotAvailableId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.NotAvailable; } }

		/// <summary>
		/// A unique Identifier allocated by the saving system
		/// When creating a new record, this is blank and will be allocated by the system
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string NotAvailableId { get; set; }

		/// <summary>
		/// The reason that can be presented to the user as to why this time is not available
		/// </summary>
		[DataMember]
		public string Description { get; set; }

		/// <summary>
		/// Service is not available (seasonally or for a public holiday) from this date
		/// </summary>
		[DataMember]
		public DateTime? NotAvailableBetweenStartDate { get; set; }
		/// <summary>
		/// Service is not available (seasonally or for a public holiday) until this date.
		/// </summary>
		[DataMember]
		public DateTime? NotAvailableBetweenEndDate { get; set; }

		/// <summary/>
		public NotAvailable()
		{
		}

		/// <summary/>
		public NotAvailable(NotAvailable theAvailability)
		{
		}
	}
}
