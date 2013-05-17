///////////////////////////////////////////////////////////
//  RecordStatusEnum.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServD.Parameters;

namespace ServD.Common
{
	/// <value>REVIEW: MF</value>
	/// <summary>
	/// The Record Status Enumeration indicates the state/completeness of the associated record.<br/>
	/// When an Author updates a record the <b>Maintainable ServD Core</b> will automatically set this
	/// value (provided the Author is not also an Approver).
	/// When an Approver updates a record then he is able to set this value to Complete or CompleteAndRequiresModeration.
	/// If a record has the Partial Record Status, then this record cannot be updated.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace, Name = "RecordStatus")]
	public enum RecordStatusEnum
	{
		/// <summary>
		/// The record is complete and is the current approved content
		/// </summary>
		[EnumMember]
		Complete = 0,

		/// <summary>
		/// Only some data was able to be loaded (security or privacy)
		/// </summary>
		[EnumMember]
		Partial = 1,

		/// <summary>
		/// This record is complete, however the data requires moderation
		/// and is not available to users apart from the Author/Approver of
		/// this specific record
		/// </summary>
		[EnumMember]
		CompleteAndRequiresModeration = 2,

		/// <summary>
		/// This record is complete, however the data was rejected by the moderator.
		/// </summary>
		/// <remarks>
		/// Records with this status are only returned to the Author/Approver of 
		/// this specific record
		/// </remarks>
		[EnumMember]
		CompleteAndModerationRejected = 3,

		/// <summary>
		/// The Record Has been deleted
		/// </summary>
		/// <remarks>
		/// Records with this attribute will only be returned to owners of the data (Author/Approver)
		/// where the implementation performs a logical deletion.
		/// Data with this property value must not be returned via the Search interfaces
		/// to un-authenticated users.
		/// </remarks>
		[EnumMember]
		Deleted = -1,

		/// <summary>
		/// The Record Has been deleted, however the delete requires moderation
		/// </summary>
		/// <remarks>
		/// Records with this attribute will only be returned to owners of the data (Author/Approver)
		/// where the implementation performs a logical deletion.
		/// Data with this property value must not be returned via the Search interfaces
		/// to un-authenticated users.
		/// </remarks>
		[EnumMember]
		DeletedAndRequiresModeration = -2,

		/// <summary>
		/// The Record Has been deleted, however the delete requires moderation
		/// </summary>
		/// <remarks>
		/// Records with this attribute will only be returned to owners of the data (Author/Approver)
		/// where the implementation performs a logical deletion.
		/// Data with this property value must not be returned via the Search interfaces
		/// to un-authenticated users.
		/// </remarks>
		[EnumMember]
		DeletedAndModerationRejected = -3,

		/// <summary>
		/// This is a special status that is used to indicate to the Maintenance's Update Operations
		/// that it should not make any changes to this object. It is used so that during an update
		/// changes can be made to child objects without updating parent records.<br/>
		/// This will not be returned by any operations, only used as input values.
		/// </summary>
		[EnumMember]
		DoNotUpdate = -4
	}
}
