///////////////////////////////////////////////////////////
//  OrganizationName.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System.Runtime.Serialization;
using System;
using ServD.Common;
using System.ComponentModel.DataAnnotations;

namespace ServD.DataModel
{
	/// <value>REVIEW: MF</value>
	/// <summary>
	/// An agency may be known by different names distinguished by name type and name
	/// purpose.
	/// </summary>
	/// <example>the legal name might be HollCroft Health Trust, but the
	/// trade name might be The HollCroft Centre</example>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class OrganizationName : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		public override string InternalId { get { return OrganizationNameId; } set { OrganizationNameId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.OrganizationName; } }

		/// <summary>
		/// Unique identifier for row
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string OrganizationNameId { get; set; }

		/// <summary>
		/// The type of name that the Organization is known as.
		/// </summary>
		/// <example>Trading Name, Legal Name</example>
		/// <cts2code scope='ServD.ONT'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		[Required]
		public string NameType { get; set; }
		
		/// <summary>
		/// The purpose or usage of this Organization name.
		/// </summary>
		/// <example>Mailing Labels, Cheques, Correspondence, Search Results</example>
		/// <cts2code scope='ServD.ONP'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string NamePurpose { get; set; }

		/// <summary>
		/// The name referenced.
		/// </summary>
		[DataMember]
		[StringLength(250)]
		[Required]
		public string Name { get; set; }

		/// <summary>
		/// Set to true for the legal name, false for a non-legal name
		/// </summary>
		[DataMember]
		public bool IsLegalIndicator { get; set; }

		/// <summary/>
		public OrganizationName()
		{
		}

		/// <summary/>
		public OrganizationName(OrganizationName theorgName)
		{

		}
	}
}
