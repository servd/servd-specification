///////////////////////////////////////////////////////////
//  ProviderLanguage.cs
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
	/// A Provider is able to deliver services in one or more languages. This
	/// entity records the capabilities of the Provider within the identified languages,
	/// and is useful for the referral processes.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class ProviderLanguage : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		public override string InternalId { get { return ProviderLanguageId; } set { ProviderLanguageId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.ProviderLanguage; } }

		/// <summary>
		/// The unique Identifier assigned by the ServD Directory
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string ProviderLanguageId { get; set; }

		/// <summary>
		/// A code from a predefined language list.
		/// </summary>
		/// <cts2code scope='ServD.LAN'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		[Required]
		public string LanguageSpokenCode { get; set; }

		/// <summary/>
		public ProviderLanguage()
		{

		}

		/// <summary/>
		public ProviderLanguage(ProviderLanguage theProviderLanguage)
		{

		}
	}
}
