///////////////////////////////////////////////////////////
//  Speciality.cs
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
	/// An Organization may provide services under zero, one or more specialties. An
	/// Organization that is a holding company may have no specialties, while those
	/// sites or services held by the holding company may have various.
	/// Note that it is not intended that Speciality is used as the basis for a
	/// service search.  The specialties pertaining to each service offered are more
	/// likely to be the ones relevant to the consumer.
	/// </summary>
	/// <remarks>
	/// This code type that is applicable to the code Value in this object can 
	/// either be associated with the ServD.SPCLTY.Org or ServD.SPCLTY.SS types,
	/// depending on the parent of this record.
	/// </remarks>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class Specialty : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		public override string InternalId { get { return SpecialtyId; } set { SpecialtyId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.Specialty; } }

		/// <summary>
		/// The repository unique reference number identifying this item
		/// (This is assigned by the Directory when the item is added)
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string SpecialtyId { get; set; }

		/// <summary>
		/// The code of the specialty.
		/// </summary>
		/// <remarks>This code set can either be associated with the ServD.ORGSPCLTY or ServD.STSPCLTY types</remarks>
		[DataMember]
		[StringLength(64)]
		[Required]
		public string Code { get; set; }

		/// <summary/>
		public Specialty()
		{
		}
	}
}