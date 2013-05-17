///////////////////////////////////////////////////////////
//  DeleteRecordResult.cs
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

namespace ServD.Results
{
	/// <value>REVIEW: MF,ST</value>
	/// <summary>
	/// The Delete Record Result indicates that success or failure of a single delete
	/// record request. It is returned as a collection by the DeleteRecords method on the Maintenance
	/// interface.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class DeleteRecordResult : RecordResult
	{
		/// <summary>
		/// Actual result of the delete method
		/// </summary>
		[DataMember]
		public RecordUpdateResultStatusEnum Result { get; set; }
	}
}
