///////////////////////////////////////////////////////////
//  RecordIndex.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ServD.Common;

namespace ServD.Parameters
{
	/// <value>REVIEW: MF</value>
	/// <summary>
	/// An index to a Record by its primary identifier
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class RecordIndex
	{
		/// <summary>
		/// Which record type this index relates to
		/// </summary>
		[DataMember]
		public RecordTypeEnum RecordType { get; set; }

		/// <summary>
		/// The Primary Identifier of the Record this index relates to
		/// </summary>
		[DataMember]
		public String Identifier { get; set; }
	}
}
