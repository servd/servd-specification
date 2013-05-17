///////////////////////////////////////////////////////////
//  LocatorUpdateResult.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ServD.Results
{
	/// <value>REVIEW: MF</value>
	/// <summary>
	/// The result just provides a simple summary of the changes that were made (if any)
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class LocatorUpdateResult
	{
		/// <summary>
		/// The number of new Coverage Areas that have been added to the database
		/// </summary>
		[DataMember]
		public int NumberOfAreasAdded { get; set; }

		/// <summary>
		/// The number of areas that were already registered in the <b>ServD Locator</b>
		/// </summary>
		[DataMember]
		public int NumberOfAreasAlreadyExisting { get; set; }

		/// <summary>
		/// Number of Coverage Areas that were removed from the <b>ServD Locator</b>
		/// </summary>
		[DataMember]
		public int NumberOfAreasRemoved { get; set; }

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


	}
}
