///////////////////////////////////////////////////////////
//  SearchItem.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////

// don't need the code comments for this base interface as it is
// just here to force the discipline on the collection classes
#pragma warning disable 1591

using System;
using System.Runtime.Serialization;
using ServD.Common;

namespace ServD.Common
{
	/// <summary>
	/// The abstract Search Item class provides the common properties that are required
	/// for all Search Items.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public abstract class SearchItem
	{
		/// <summary>
		/// The network location of the Retrieve Details Interface to request for the
		/// detailed information.
		/// </summary>
		[DataMember]
		public String RetrieveDetailsURI { get; set; }

		/// <summary>
		/// A Generalized heading that can present any information for this search item.<br/>
		/// This is unformatted text.
		/// </summary>
		[DataMember]
		public String Heading { get; set; }

		/// <summary>
		/// A Generalized sub-heading that can present any information for this search item.<br/>
		/// This prides flexibility for a <b>ServD Core</b> implementation to adapt what information is included.<br/>
		/// This is unformatted text.
		/// </summary>
		[DataMember]
		public String SubHeading { get; set; }

		/// <summary>
		/// A Generalized summary description of the search Item.<br/>
		/// This prides flexibility for a <b>ServD Core</b> implementation to adapt what information is included.<br/>
		/// This is unformatted text.
		/// </summary>
		[DataMember]
		public String Summary { get; set; }

		/// <summary>
		/// If there is an image associated with this Search Result Item, its URI can be included here.
		/// </summary>
		[DataMember]
		public String ImageURI { get; set; }

		/// <summary>
		/// The date and time this record (or one of its child records) was last modified.<br/>
		/// Note that the approval of a record is not considered to be a modification and should not update this field.
		/// </summary>
		[DataMember]
		public DateTime LastModificationDate
		{
			get { return _lastModDate; }
			set
			{
				_lastModDate = value;
				// If the date set was a local time, then convert it to the UTC format
				if (_lastModDate.Kind == DateTimeKind.Local)
					_lastModDate = _lastModDate.ToUniversalTime();
				if (_lastModDate.Kind == DateTimeKind.Unspecified)
					_lastModDate = DateTime.SpecifyKind(_lastModDate, DateTimeKind.Utc);
			}
		}

		private DateTime _lastModDate;

		/// <summary>
		/// What is the moderation Status of this record (Complete, Partial, RequiresModeration, Deleted)
		/// </summary>
		[DataMember]
		public RecordStatusEnum RecordStatus { get; set; }
	}
}
