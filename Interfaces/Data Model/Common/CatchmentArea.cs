///////////////////////////////////////////////////////////
//  CatchmentArea.cs
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
	/// This entity provides for grouping service sites into geographical areas
	/// appropriate for specific agencies, each with their own catchment area. This is
	/// to assist in the selection of sites for referral management.
	/// </summary>
	/// <remarks>This often used as a Local Government Area</remarks>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class CatchmentArea : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		public override string InternalId { get { return CatchmentAreaId; } set { CatchmentAreaId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.CatchmentArea; } }

		/// <summary>
		/// Directory assigned unique identifier
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string CatchmentAreaId { get; set; }

		/// <summary>
		/// From the Catchment Area reference table
		/// </summary>
		/// <cts2code scope='ServD.CAC'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		[Required]
		public string Code { get; set; }

		/// <summary/>
		public CatchmentArea()
		{
		}

		/// <summary/>
		public CatchmentArea(CatchmentArea theCatchmentArea)
		{

		}
	}
}