///////////////////////////////////////////////////////////
//  PublicKey.cs
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
	/// <summary>
	/// The PublicKey object is used as a return value for the GetPublicKeys method
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class PublicKey
	{
		/// <summary>
		/// Which record type was modified
		/// </summary>
		[DataMember]
		public RecordTypeEnum RecordType { get; set; }

		/// <summary>
		/// The Primary Identifier of the Record that was modified
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public String Identifier { get; set; }

		/// <summary>
		/// The public part of the ‘keys’ allocated to an Organization by an accredited
		/// body to support secure exchange of data over the internet.
		/// To be provided by the Organization, where available.<br/>
		/// The length of this string is undefined and should be of an un-restricted type.
		/// </summary>
		/// <remarks>This is a base64 encoded digital certificate. The ServD Federation's Profile will
		/// specify the type of certificate to be used and its purpose.</remarks>
		[DataMember]
		public string Value { get; set; }
	}
}
