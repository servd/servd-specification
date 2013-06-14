///////////////////////////////////////////////////////////
//  Identifier.cs
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
	/// An Organization may be known by any number of external identifiers. Each
	/// identifier is specified by a type, an issuing authority, and a controlling
	/// authority.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class Identifier : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		public override string InternalId { get { return IdentifierId; } set { IdentifierId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.Identifier; } }

		/// <summary>
		/// An internal unique Identifier that is allocated by the saving system
		/// When adding a new Site, this is blank and will be allocated
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string IdentifierId { get; set; }

		/// <summary>
		/// Medical Record Number, Driver’s License, Provincial Health Number, National
		/// Health Number, etc.
		/// </summary>
		/// <example>HPI-I or HPI-O</example>
		[DataMember]
		[StringLength(64)]
		[Required]
		public string IdentifierType { get; set; }

		/// <summary>
		/// Provincial Department of Health, St. Michael’s Hospital (for example)
		/// </summary>
		[DataMember]
		[StringLength(256)]
		public string IdentifierIssuingAuthority { get; set; }

		/// <summary>
		/// Public Works and Government Services, Health Region (for example)
		/// </summary>
		[DataMember]
		[StringLength(256)]
		public string IdentifierControllingAuthority { get; set; }

		/// <summary>
		/// The value of the Identifier
		/// </summary>
		[DataMember]
		[StringLength(64)]
		[Required]
		public string Value { get; set; }

		/// <summary/>
		public Identifier()
		{
		}

		/// <summary/>
		public Identifier(Identifier theorgIdentifier)
		{

		}
	}
}
