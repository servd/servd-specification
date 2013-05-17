///////////////////////////////////////////////////////////
//  SiteSearchParameters.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServD.Parameters
{
	/// <value>REVIEW: MF</value>
	/// <summary>
	/// Search for Sites that have the following properties
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class SiteSearchParameters
	{
		/// <summary>
		/// A specific Site ID to locate
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string SiteId { get; set; }

		/// <summary>
		/// The Name of the Site to Search for (when filtering for this field, ensure that the 
		/// SearchControlParameter StringMatchType is utilized)
		/// </summary>
		[DataMember]
		public String Name { get; set; }

		/// <summary>
		/// A list of Attributes to filter the Site by
		/// </summary>
		/// <remarks>
		/// If the Value specified in the attribute is empty, the request is intended to locate
		/// Sites that have this attribute type, and its value is not important.
		/// </remarks>
		[DataMember]
		public HasAttribute[] Attributes { get; set; }

		/// <summary/>
		public SiteSearchParameters()
		{
		}

		/// <summary/>
		public SiteSearchParameters(SiteSearchParameters theSiteSearchParameters)
		{
			Name = theSiteSearchParameters.Name;
			SiteId = theSiteSearchParameters.SiteId;
			if (theSiteSearchParameters.Attributes != null)
			{
				List<HasAttribute> attribs = new List<HasAttribute>();
				foreach (HasAttribute other in theSiteSearchParameters.Attributes)
				{
					attribs.Add(new HasAttribute(other));
				}
				Attributes = attribs.ToArray();
			}
			else
			{
				Attributes = null;
			}
		}
	}
}