///////////////////////////////////////////////////////////
//  OrganizationAffiliation.cs
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
	/// An Organization might be associated with other organizations due to a number of
	/// different business needs or relevance, such as participation in integrated
	/// programs, geographic relevance to an area, or to identify insurance agreements.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class OrganizationAffiliation : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		public override string InternalId { get { return OrganizationAffiliationId; } set { OrganizationAffiliationId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.OrganizationAffiliation; } }

		/// <summary>
		/// Unique identifier for row
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string OrganizationAffiliationId { get; set; }

		/// <summary>
		/// A code value representing another entity that the Organization is
		/// affiliated with.
		/// </summary>
		/// <cts2code scope='ServD.OAFT'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		[Required]
		public string AffiliationType { get; set; }

		/// <summary>
		/// A description for the user to see that describes the details of the 
		/// Organizations Affiliation.
		/// </summary>
		[DataMember]
		[StringLength(2048)]
		public string Note { get; set; }

		/// <summary/>
		public OrganizationAffiliation()
		{

		}

		/// <summary/>
		public OrganizationAffiliation(OrganizationAffiliation theorgAffiliation)
		{

		}
	}
}