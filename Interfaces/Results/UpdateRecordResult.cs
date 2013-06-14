///////////////////////////////////////////////////////////
//  UpdateRecordResults.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ServD.Common;
using System.ComponentModel.DataAnnotations;

namespace ServD.Results
{
	/// <summary>
	/// The Update Record result is returned by the Maintenance operations while updating and adding data.
	/// It provides a simple structure by which the Maintenance Application can match its internal records
	/// that it is publishing into the <b>Maintainable ServD Core</b> to the new records.<br/>
	/// Typically this is returned as items in an array to refer to each record that was created updated
	/// and the status of the method.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class UpdateRecordResult : RecordResult
	{
		/// <summary>
		/// Actual result of the update method
		/// </summary>
		[DataMember]
		public RecordUpdateResultStatusEnum Result { get; set; }
	}
}
