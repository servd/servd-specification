///////////////////////////////////////////////////////////
//  ServiceType.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ServD.Common;

namespace ServD.DataModel
{
	///<value>REVIEW: MF</value>
	/// <summary>
	/// A Keyword that is to be used by a specific Service Site.<br/>
	/// It can be either a primary, or secondary keyword
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class ServiceType : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		public override string InternalId { get { return ServiceTypeId; } set { ServiceTypeId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.ServiceType; } }

		/// <summary>
		/// A unique Identifier allocated by the saving system
		/// When creating a new record, this is blank and will be allocated by the system
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public String ServiceTypeId { get; set; }

		/// <summary>
		/// The Code value of the Service Type
		/// </summary>
		/// <cts2code scope='ServD.ST'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		[Required]
		public String Value { get; set; }
	}
}
