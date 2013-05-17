///////////////////////////////////////////////////////////
//  DaysOfWeek.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ServD.Common
{
	/// <value>REVIEW: MF</value>
	/// <summary>
	/// The Day Of Week Enumeration is used in conjunction with the available time information
	/// to mark which days of the week are available.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace, Name = "DaysOfWeek")]
	public class DaysOfWeek
	{
		/// <summary>
		/// Monday
		/// </summary>
		[DataMember]
		public bool Monday { get; set; }

		/// <summary>
		/// Tuesday
		/// </summary>
		[DataMember]
		public bool Tuesday { get; set; }

		/// <summary>
		/// Wednesday
		/// </summary>
		[DataMember]
		public bool Wednesday { get; set; }

		/// <summary>
		/// Thursday
		/// </summary>
		[DataMember]
		public bool Thursday { get; set; }

		/// <summary>
		/// Friday
		/// </summary>
		[DataMember]
		public bool Friday { get; set; }

		/// <summary>
		/// Saturday
		/// </summary>
		[DataMember]
		public bool Saturday { get; set; }

		/// <summary>
		/// Sunday
		/// </summary>
		[DataMember]
		public bool Sunday { get; set; }
	}
}
