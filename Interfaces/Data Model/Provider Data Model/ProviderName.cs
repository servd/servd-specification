///////////////////////////////////////////////////////////
//  ProviderName.cs
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
	/// A Provider may be known by one or more names distinguished by type and
	/// purpose. For example: married name, professional name, birth name, and so on.
	/// Also, any one of those names may be identified as the preferred name or the
	/// legal name.
	/// </summary>
	/// <remarks>The preferred name is an instance of this class on the Provider object, not a flag on this item</remarks>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class ProviderName : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		public override string InternalId { get { return ProviderNameId; } set { ProviderNameId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.ProviderName; } }

		/// <summary>
		/// The unique reference identifying an attribute. This is the primary
		/// key for the attribute entity.
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string ProviderNameId { get; set; }

		/// <summary>
		/// The Name type covers ways in which the person can be known.
		/// </summary>
		/// <example>
		/// Professional, Married, Birth, Name by Repute, Alias
		/// </example>
		/// <cts2code scope='ServD.PNT'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string NameType { get; set; }

		/// <summary>
		/// The way in which this name record is intended to be used.
		/// </summary>
		/// <example>
		/// Mailing, Cheques, Correspondence
		/// </example>
		/// <cts2code scope='ServD.PNP'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string NamePurpose { get; set; }

		/// <summary>
		/// Details the Providers’s family name.
		/// </summary>
		[DataMember]
		[StringLength(50)]
		[Required]
		public string FamilyName { get; set; }

		/// <summary>
		/// Details the Provider’s given name(s).
		/// </summary>
		[DataMember]
		[StringLength(250)]
		public string GivenNames { get; set; }

		/// <summary>
		/// The Title of the Provider.
		/// </summary>
		/// <example>Mr, Mrs, Dr</example>
		/// <cts2code scope='ServD.TITLE'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string TitleCode { get; set; }

		/// <summary>
		/// Set to true for the legal name, false for a non-legal name
		/// </summary>
		[DataMember]
		public bool IsLegalIndicator { get; set; }

		/// <summary/>
		public ProviderName()
		{
		}

		/// <summary/>
		public ProviderName(ProviderName theProviderName)
		{

		}
	}
}
