using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ServD.Common;

namespace ServD.Results
{
	/// <value>REVIEW: MF</value>
	/// <summary>
	/// The Record Requiring Approval is used to summarize a change to a record in the 
	/// <b>Maintainable ServD Core</b> that requires approval by an Approver.<br/>
	/// It should be able to be used to present to a user a simple representation of the item to be approved
	/// so that it could be performed without having to actually load the complete record.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class RecordRequiringApproval
	{
		/// <summary>
		/// The record type that requires approval
		/// </summary>
		[DataMember]
		public RecordTypeEnum RecordType { get; set; }

		/// <summary>
		/// The Primary Identifier of the Record that requires approval
		/// </summary>
		[DataMember]
		public String Identifier { get; set; }

		/// <summary>
		/// The user that has requested the change to be made
		/// </summary>
		[DataMember]
		public String LastChangeByUser { get; set; }

		/// <summary>
		/// The date that the change was requested
		/// </summary>
		[DataMember]
		public DateTime LastChangeDate { get; set; }

		/// <summary>
		/// The Summary includes the basic description of the entity that is being changed.
		/// It is not to contain any mark-up of data
		/// </summary>
		/// <example>For an Organization Address this could be the Organization's Name</example>
		[DataMember]
		public String Summary { get; set; }

		/// <summary>
		/// (Optional) The Description of the Record or it's requested changes.<br/>
		/// (Recommended) Where this record is externally verified using the VerifyDetails attributes
		/// a note as to the current status would be could to be displayed here also.<br/>
		/// This would permit an approver to wait until the external service has verified the
		/// data before approving the update to be visible externally.
		/// </summary>
		/// <example>The Address has Changed to 355 Spencer St</example>
		[DataMember]
		public String Description { get; set; }
	}
}
