///////////////////////////////////////////////////////////
//  StringMatchTypeEnum.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Runtime.Serialization;

namespace ServD.Common
{
	/// <value>REVIEW: MF</value>
	/// <summary>
	/// If Fuzzy (4) is selected, the implementation of the search may decide how best to implement this
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace, Name = "StringMatchType")]
	public enum StringMatchTypeEnum
	{
		/// <summary>
		/// Any string match should be an exact match
		/// </summary>
		[EnumMember]
		Exact = 0,
		/// <summary>
		/// And string match should be considered a wildcard match that contains the entered text
		/// </summary>
		[EnumMember]
		Contains = 1,
		/// <summary>
		/// The provided text should be checked to see if it is the start of any entries.<br/>
		/// <example>"And" would match to "Anderson", "And" but not "Grand"</example>
		/// </summary>
		[EnumMember]
		StartsWith = 2,
		/// <summary>
		/// Fuzzy Search
		/// </summary>
		[EnumMember]
		Fuzzy = 3
	};
}