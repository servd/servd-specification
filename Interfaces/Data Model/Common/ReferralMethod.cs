///////////////////////////////////////////////////////////
//  ReferralMethod.cs
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
	/// A Service Site may identify the referral methods that are appropriate to its
	/// circumstances.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class ReferralMethod : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		public override string InternalId { get { return ReferralMethodId; } set { ReferralMethodId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.ReferralMethod; } }

		/// <summary>
		/// The unique Identifier assigned by the ServD Directory
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string ReferralMethodId { get; set; }

		/// <summary>
		/// A code that identifies a referral method that is acceptable to this Site
		/// </summary>
		/// <cts2code scope='ServD.RMC'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		[Required]
		public string Code { get; set; }

		/// <summary/>
		public ReferralMethod()
		{
		}

		/// <summary/>
		public ReferralMethod(ReferralMethod theReferralMethod)
		{

		}
	}
}