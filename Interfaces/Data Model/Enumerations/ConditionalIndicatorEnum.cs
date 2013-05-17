///////////////////////////////////////////////////////////
//  ConditionalIndicatorEnum.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServD.Common;

namespace ServD.Common
{
	/// <value>REVIEW: MF</value>
	/// <summary>
	/// The Conditional Indicator is used by the Service Site to indicate the Service Sites Eligibility, 
	/// or if an Appointment is required
	/// </summary>
	/// <remarks>When storing this into a database, it may be stored as a string/char data type so that 
	/// the textual representation is easier to identify.
	/// </remarks>
	[DataContract(Namespace = Constants.ServDNamespace, Name = "ConditionalIndicator")]
	public enum ConditionalIndicatorEnum
	{
		/// <summary>
		/// The condition state is not defined 
		/// </summary>
		[EnumMember]
		NotDefined = 0,
		/// <summary>
		/// 'Y' The condition is required
		/// </summary>
		[EnumMember]
		Yes = 'Y',
		/// <summary>
		/// 'N' The condition is not required
		/// </summary>
		[EnumMember]
		No ='N',
		/// <summary>
		/// 'U' The condition state is unknown
		/// </summary>
		[EnumMember]
		Unknown = 'U',
		/// <summary>
		/// 'C' The condition depends on other factors. Refer to other associated fields
		/// </summary>
		[EnumMember]
		Conditional = 'C'
	}

}
