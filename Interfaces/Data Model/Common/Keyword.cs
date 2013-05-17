using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ServD.Enumerations;

namespace ServD.DataModel
{
	///<value>REVIEW: MF</value>
	/// <summary>
	/// A Keyword that is to be used by a specific Service Site.<br/>
	/// It can be either a primary, or secondary keyword
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class Keyword
	{
		/// <summary>
		/// A unique Identifier allocated by the saving system
		/// When creating a new record, this is blank and will be allocated by the system
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public String KeywordId { get; set; }

		/// <summary>
		/// This External Identifier is provided by applications using the Maintenance API 
		/// to be able to identify their own records when they adding new records.
		/// It is not required to be stored by the <b>ServD Maintenance Service</b> but 
		/// it must be returned in the Add operations on the Maintenance interface.
		/// </summary>
		[DataMember]
		[StringLength(50)]
		[Required]
		public string ExternalId { get; set; }

		/// <summary>
		/// What is the Status of this record (Complete, Partial, RequiresModeration, Deleted)
		/// </summary>
		[DataMember]
		public RecordStatusEnum RecordStatus { get; set; }

		/// <summary>
		/// What is the sensitivity of this data and who should
		/// be able to see the record.
		/// (Public, Secure, OwnerOnly)
		/// </summary>
		[DataMember]
		public PrivacyIndicatorEnum RecordPrivacyIndicator { get; set; }

		/// <summary>
		/// The actual Keyword Value
		/// </summary>
		/// <cts2code scope='ServD.KWD'>ServD.CTS2.References</cts2code>
		/// <summary>
		/// TODO: Verify the String Length here
		/// </summary>
		[DataMember]
		[StringLength(100)]
		[Required]
		public String Value { get; set; }

		/// <summary>
		/// The date and time this record was last modified. The server will set this to the 
		/// local server time at the point of an add or update, any values entered by a user will
		/// be ignored.<br/>
		/// Note that the approval of a record is not considered to be a modification and should not update this field.
		/// </summary>
		[DataMember]
		public DateTime? LastModificationDate { get; set; }

		/// <summary>
		/// The effective start date of this record
		/// </summary>
		[DataMember]
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// The effective end date of this record
		/// </summary>
		[DataMember]
		public DateTime? EndDate { get; set; }
	}
}
