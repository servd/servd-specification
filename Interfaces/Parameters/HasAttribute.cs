///////////////////////////////////////////////////////////
//  HasAttribute.cs
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
	/// The Has Attribute Parameter is used to specify that Provider, Site or Service Site has
	/// the defined value.
	/// </summary>
	/// <remarks>
	/// This code type that is applicable to the Value in this object can 
	/// either be associated with one of the following types depending on the parent of this record;
	/// ServD.ATTT.Org, ServD.ATTT.Site, ServD.ATTT.SS, 
	/// ServD.ATTT.Prov, ServD.ATTT.Prov.Cred, ServD.ATTT.Prov.Qual or ServD.ATTT.Prov.Reg
	/// </remarks>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class HasAttribute
	{
		/// <summary>
		/// The Attribute Type Associated
		/// </summary>
		[DataMember]
		[StringLength(64)]
		[Required]
		public String AttributeType { get; set; }

		/// <summary>
		/// The Value to search for given the specified Attribute Type
		/// </summary>
		[DataMember]
		[StringLength(250)]
		public String Value { get; set; }

		/// <summary>
		/// Include attributes that have an Expired Verification Status
		/// </summary>
		[DataMember]
		public bool IncludeExpired { get; set; }

		/// <summary>
		/// Include attributes that have a Pending Verification Status
		/// </summary>
		[DataMember]
		public bool IncludePending { get; set; }

		/// <summary>
		/// Include attributes that have a NotValid Verification Status
		/// </summary>
		/// <remarks>Those that failed verification with a ServD Verifier</remarks>
		[DataMember]
		public bool IncludeNotValid { get; set; }

		/// <summary>
		/// </summary>
		public HasAttribute()
		{
		}

		/// <summary>
		/// </summary>
		/// <param name="theAttribute"></param>
		public HasAttribute(HasAttribute theAttribute)
		{
			AttributeType = theAttribute.AttributeType;
			Value = theAttribute.Value;
		}
	}
}
