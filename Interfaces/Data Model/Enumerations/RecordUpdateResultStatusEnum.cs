///////////////////////////////////////////////////////////
//  RecordUpdateResultStatusEnum.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.ServiceModel;
using ServD.Parameters;
using ServD.DataModel;
using System.Runtime.Serialization;

namespace ServD.Common
{
	/// <summary>
	/// When data is modified by the Operations on the Maintenance Interface this enumeration
	/// is used to report the status of the update.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace, Name = "RecordUpdateResultStatus")]
	public enum RecordUpdateResultStatusEnum
	{
		/// <summary>
		/// The Update was successful and does not require moderation
		/// </summary>
		[EnumMember]
		Success,

		/// <summary>
		/// The Update was successful, but will require moderation before it will be shown in searches from other Organizations
		/// </summary>
		/// <remarks>
		/// If a record was rejected from moderation, then this status will be returned
		/// </remarks>
		[EnumMember]
		SuccessRequiresModeration,

		/// <summary>
		/// The update failed as the user does not have permission to update this record
		/// </summary>
		[EnumMember]
		ErrorPermission,

		/// <summary>
		/// The record that was submitted for update was not in an updatable state (RecordStatus = Partial).
		/// </summary>
		[EnumMember]
		PartialRecordNotUpdatable,

		/// <summary>
		/// The Record could not be updated or added as it would cause a duplicate record.
		/// </summary>
		[EnumMember]
		ErrorDuplicateRecord,

		/// <summary>
		/// A Validation error has occurred saving this record
		/// </summary>
		[EnumMember]
		ErrorValidation,

		/// <summary>
		/// Other type of error has occurred, refer to the error code and description
		/// </summary>
		[EnumMember]
		ErrorOther
	}
}