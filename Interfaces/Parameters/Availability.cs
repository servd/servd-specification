///////////////////////////////////////////////////////////
//  Availability.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ServD.Common;

namespace ServD.Parameters
{
	/// <summary>
	/// The availability parameter is used to specify at what date/time that you are specifically looking for the service
	/// to be available. Alternately it can be used to specify which day(s) of the week (with optional time).<br/>
	/// This is not defined as an appointment available interface, but an office-hours available type search.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class Availability
	{
		/// <summary>
		/// The date and time that the service should be available at.
		/// If the time Available At date is not provided, then the request
		/// is assuming that the request does not have a specific date in mind
		/// </summary>
		/// <remarks>Be particularly careful of time-zone information here.<br/>
		/// The time-zone that is provided to the Current Local System Time is used as a cross reference
		/// to this field also. It can ensure that when requesting the available at the time-zone request
		/// is consistently applied.
		/// </remarks>
		[DataMember]
		public DateTime? AvailableAt { get; set; }

		/// <summary>
		/// If this option is selected the date component of the AvailableAt parameter is included in the filter
		/// </summary>
		/// <remarks>Setting this value to true will then ignore the DaysOfWeek option.</remarks>
		[DataMember]
		public bool CheckDate { get; set; }

		/// <summary>
		/// If this option is selected the time component of the AvailableAt parameter is included in the filter
		/// </summary>
		[DataMember]
		public bool CheckTime { get; set; }

		/// <summary>
		/// Which day(s) of the week should be checked.
		/// </summary>
		/// <remarks>
		/// Selecting multiple days with this field will look for records that
		/// have at least one of the specified days available.
		/// </remarks>
		/// <example>Mon or Tues</example>
		/// <remarks>This property will be ignored if the CheckDate flag (above) is set</remarks>
		[DataMember]
		public DaysOfWeek DaysOfWeek { get; set; }

		/// <summary>
		/// Include Services where the Availability information is unknown.
		/// The typical use of this would be to filter only for those
		/// where the availability is actually known. Not including this
		/// availability restriction type means that the search will not
		/// consider availability.
		/// </summary>
		[DataMember]
		public Boolean IncludeUnknown { get; set; }

		/// <summary/>
		public Availability()
		{
		}

		/// <summary/>
		public Availability(Availability theAvailability)
		{
			AvailableAt = theAvailability.AvailableAt;
			IncludeUnknown = theAvailability.IncludeUnknown;
		}
	}
}
