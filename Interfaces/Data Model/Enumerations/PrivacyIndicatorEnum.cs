using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServD.Parameters;

namespace ServD.Enumerations
{
	/// <summary>
	/// The Privacy Indicator is used to describe the conditions under which this data is permitted to be viewed.<br/>
	/// This property is only able to be changed by Authors and Approvers of data.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace, Name = "PrivacyIndicator")]
	public enum PrivacyIndicatorEnum
	{
		/// <summary>
		/// Data with this value can be accessed by anyone
		/// And may be over an insecure connection
		/// </summary>
		[EnumMember]
		Public = 0,
		/// <summary>
		/// Data with this value can only be accessed over a secure connection
		/// by authenticated users
		/// </summary>
		[EnumMember]
		SecureAccessOnly = 1,
		/// <summary>
		/// Data with this value can only be accessed by authenticated users
		/// of the organisation that owns (authors) the data.
		/// </summary>
		[EnumMember]
		SecureAccessForOwnerOnly = 2
	}
}
