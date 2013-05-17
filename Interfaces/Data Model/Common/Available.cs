///////////////////////////////////////////////////////////
//  Available.cs
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
	/// Defines a block of time that is available
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class Available : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		public override string InternalId { get { return AvailableId; } set { AvailableId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.Available; } }

		/// <summary>
		/// A unique Identifier allocated by the saving system
		/// When creating a new record, this is blank and will be allocated by the system
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string AvailableId { get; set; }

		/// <summary>
		/// Indicates which Days of the week are available between the Start and End Times.<br/>
		/// </summary>
		[DataMember]
		public DaysOfWeek DaysOfWeek { get; set; }

		/// <summary>
		/// Is this always available? (hence times are irrelevant)
		/// </summary>
		[DataMember]
		public bool AllDay { get; set; }

		/// <summary>
		/// The opening time of day (the date is not included)
		/// </summary>
		/// <remarks>If the AllDay flag is set, then this time is ignored.</remarks>
		/// <remarks>Ensure that the time zone information is included</remarks>
		[System.Xml.Serialization.XmlElement(DataType = "time")]
		[DataMember]
		public DateTime? AvailabileStartTime { get; set; }

		/// <summary>
		/// The closing time of day (the date is not included)
		/// </summary>
		/// <remarks>If the AllDay flag is set, then this time is ignored.</remarks>
		/// <remarks>Ensure that the time zone information is included</remarks>
		[System.Xml.Serialization.XmlElement(DataType = "time")]
		[DataMember]
		public DateTime? AvailabileEndTime { get; set; }

		/// <summary/>
		public Available()
		{
		}

		/// <summary/>
		public Available(Available theOther)
		{
		}
	}
}
