///////////////////////////////////////////////////////////
//  AttributeVerificationStatusEnum.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Runtime.Serialization;
using ServD.Common;

namespace ServD.Common
{
	/// <value>REVIEW: MF</value>
	/// <summary>
	/// The AttributeVerificationStatus provides a Status for the an attribute
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace, Name = "AttributeVerificationStatus")]
	public enum AttributeVerificationStatusEnum
	{
		/// <summary>
		/// There is no <b>ServD Verifier</b> configured by the <b>ServD Core</b> for the specified Attribute Type.
		/// </summary>
		[EnumMember]
		NotApplicable = 0,

		/// <summary>
		/// The <b>ServD Verifier</b> allocated to this type by the <b>ServD Core</b> does not support the specified
		/// Attribute Type.
		/// </summary>
		[EnumMember]
		NotVerifiable = 1,

		/// <summary>
		/// This attribute has not yet been verified.<br/>
		/// (not returned by the <b>ServD Verifier</b>, but used in search results
		/// for rows that have not been verified yet)
		/// </summary>
		[EnumMember]
		Pending = 2,

		/// <summary>
		/// This attribute has been verified for the specified Organization, Site or Provider.
		/// </summary>
		[EnumMember]
		Verified = 3,

		/// <summary>
		/// This attribute was Verified but has expired 
		/// (refer to the expiry date for information as to when)
		/// </summary>
		[EnumMember]
		Expired = 4,

		/// <summary>
		/// This attribute has been checked with the <b>ServD Verifier</b> and the 
		/// specified Organization, Site or Provider is not certified.
		/// </summary>
		[EnumMember]
		NotValid = 5
	}
}