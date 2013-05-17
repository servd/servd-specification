///////////////////////////////////////////////////////////
//  CoverageArea.cs
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
	/// This entity provides the scope within the <b>ServD Locator</b> for the purpose of selecting
	/// which ServD Directories are to be searched for a specific area.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class CoverageArea : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		public override string InternalId { get { return CoverageAreaId; } set { CoverageAreaId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.CoverageArea; } }

		/// <summary>
		/// Directory assigned unique identifier
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string CoverageAreaId { get; set; }

		/// <summary>
		/// The Coverage Area that facilitates the federation by the <b>ServD Locator</b>.
		/// </summary>
		/// <cts2code scope='ServD.CA'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		[Required]
		public string Code { get; set; }

		/// <summary/>
		public CoverageArea()
		{
		}
	}
}
