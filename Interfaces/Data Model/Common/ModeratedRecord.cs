///////////////////////////////////////////////////////////
//  ModeratedRecord.cs
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
	/// <value>REVIEW: MF</value>
	/// <summary>
	/// The Moderated Record is the abstract base class that includes the properties 
	/// common to all entities that require moderation and part of the persistent ServD Object Model.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public abstract class ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		public abstract string InternalId { get; set; }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		public abstract RecordTypeEnum RecordType { get; }

		/// <summary>
		/// This External Identifier is provided by applications using the Maintenance Interface 
		/// to identify their own records when adding new records.
		/// It is not required to be stored by the <b>Maintainable ServD Core</b> but 
		/// it must be returned in the Add operations on the Maintenance interface.
		/// </summary>
		[DataMember]
		[StringLength(50)]
		[Required]
		public string ExternalId { get; set; }

		/// <summary>
		/// What is the moderation Status of this record (Complete, Partial, RequiresModeration, Deleted)
		/// </summary>
		[DataMember]
		public RecordStatusEnum RecordStatus { get; set; }

		/// <summary>
		/// What is the sensitivity of this data and who should
		/// be able to see the record based on policy.<br/>
		/// This can be a multi-part policy that could include roles and levels of privacy.
		/// </summary>
		/// <example>
		/// In the Victorian (Australia) Implementation of this there is a very simple
		/// policy that has a single component with 3 possible values.<br/>
		/// Public, Secure or OwnerOnly
		/// </example>
		/// <remarks>
		/// The Privacy Policy will be based on an agreed structure that is to be used by the 
		/// integrated ServD Applications.
		/// </remarks>
		[DataMember]
		[StringLength(250)]
		public String RecordPrivacyPolicy { get; set; }

		/// <summary>
		/// The date and time this record was last modified. The server will set this to the 
		/// local server time at the point of an add or update, any values entered by a user will
		/// be ignored.<br/>
		/// Note that the approval of a record is not considered to be a modification and should not update this field.
		/// </summary>
		[DataMember]
		public DateTime? LastModificationDate 
		{
			get { return _lastModDate; }
			set
			{
				_lastModDate = value;
				if (_lastModDate.HasValue)
				{
					// If the date set was a local time, then convert it to the UTC format
					if (_lastModDate.Value.Kind == DateTimeKind.Local)
						_lastModDate = _lastModDate.Value.ToUniversalTime();
					if (_lastModDate.Value.Kind == DateTimeKind.Unspecified)
						_lastModDate = DateTime.SpecifyKind(_lastModDate.Value, DateTimeKind.Utc);
				}
			}
		}

		private DateTime? _lastModDate;

		/// <summary>
		/// The user that last modified this record (description)
		/// </summary>
		/// <remarks>This is not exposed on the Web service interface, it is here purely for the data store</remarks>
		[StringLength(50)]
		public String LastModifiedByUser { get; set; }

		/// <summary>
		/// The effective start date for this record
		/// </summary>
		[DataMember]
		public DateTime? StartDate
		{
			get { return _startDate; }
			set
			{
				_startDate = value;
				if (_startDate.HasValue)
				{
					// If the date set was a local time, then convert it to the UTC format
					if (_startDate.Value.Kind == DateTimeKind.Local)
						_startDate = _startDate.Value.ToUniversalTime();
					if (_startDate.Value.Kind == DateTimeKind.Unspecified)
						_startDate = DateTime.SpecifyKind(_startDate.Value, DateTimeKind.Utc);
				}
			}
		}

		private DateTime? _startDate;

		/// <summary>
		/// The effective end date of this record
		/// </summary>
		[DataMember]
		public DateTime? EndDate
		{
			get { return _endDate; }
			set
			{
				_endDate = value;
				if (_endDate.HasValue)
				{
					// If the date set was a local time, then convert it to the UTC format
					if (_endDate.Value.Kind == DateTimeKind.Local)
						_endDate = _endDate.Value.ToUniversalTime();
					if (_endDate.Value.Kind == DateTimeKind.Unspecified)
						_endDate = DateTime.SpecifyKind(_endDate.Value, DateTimeKind.Utc);
				}
			}
		}

		private DateTime? _endDate;
	}
}
