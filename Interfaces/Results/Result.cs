///////////////////////////////////////////////////////////
//  Result.cs
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

namespace ServD.Common
{
	/// <summary>
	/// This base class is used to provide a common set of properties for results. 
	/// Specific Error status codes can be defined in derived classes.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class Result
	{
		/// <summary>
		/// A System provided error code.  (Optional)
		/// </summary>
		[DataMember]
		public string ErrorCode { get; set; }

		/// <summary>
		/// A textual representation of the error that has occurred, intended to be displayed to 
		/// a user as to what has occurred.<br/>
		/// </summary>
		/// <remarks>If relevant the name and value of any fields in error should be included</remarks>
		[DataMember]
		public string ErrorDescription { get; set; }

		/// <summary>
		/// This Advanced Error Message description is intended for logging and diagnosis of issues,
		/// and not expected to be displayed to users. (Optional)
		/// </summary>
		[DataMember]
		public string AdvancedErrorDescription { get; set; }

		/// <summary>
		/// Which record type was modified
		/// </summary>
		[DataMember]
		public RecordTypeEnum RecordType { get; set; }
	}

	/// <summary>
	/// This base class is used to provide a common set of properties for results for record modifications. 
	/// Specific Error status codes can be defined in derived classes.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class RecordResult : Result
	{
		/// <summary>
		/// The network location of the Retrieve Details Interface to request for the
		/// detailed information.
		/// </summary>
		[DataMember]
		public String RetrieveDetailsURI { get; set; }

		/// <summary>
		/// The Primary Identifier of the Record that was modified
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public String Identifier { get; set; }

		/// <summary>
		/// The External Identifier of the record that modified (if applicable).
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string ExternalId { get; set; }
	}
}
