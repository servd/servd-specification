///////////////////////////////////////////////////////////
//  ProviderSearchParameters.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServD.Parameters
{
	/// <summary>
	/// Search for Providers that have the following properties.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class ProviderSearchParameters
	{
		/// <summary>
		/// The ID of the Provider to search for.
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string ProviderId { get; set; }

		/// <summary>
		/// The Surname of the Organization to Search for (when filtering for this field, ensure that the 
		/// SearchControlParameter StringMatchType is utilized)
		/// </summary>
		[DataMember]
		public String Surname { get; set; }

		/// <summary>
		/// The Given Name(s) of the Provider to Search for (when filtering for this field, ensure that the 
		/// SearchControlParameter StringMatchType is utilized)
		/// </summary>
		[DataMember]
		public String GivenNames { get; set; }

		/// <summary>
		/// The ethnic background of the Provider
		/// </summary>
		/// <cts2code scope='ServD.ETH'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public String CulturalEthnicityCode { get; set; }

		/// <summary>
		/// The language spoken by the Provider
		/// </summary>
		/// <cts2code scope='ServD.LAN'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public String LanguageSpokenCode { get; set; }

		/// <summary>
		/// The gender of the Provider to filter to
		/// </summary>
		/// <cts2code scope='ServD.GEN'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public String GenderCode { get; set; }

		/// <summary>
		/// The special interests of the Provider 
		/// </summary>
		[DataMember]
		public String SpecialInterests { get; set; }


		/// <summary>
		/// Filter Providers that have the specified Attributes
		/// </summary>
		/// <remarks>
		/// If the Value specified in the attribute is empty, the request is intended to locate
		/// Providers that have this attribute type, and its value is not important.
		/// </remarks>
		[DataMember]
		public HasAttribute[] Attributes { get; set; }

		/// <summary/>
		public ProviderSearchParameters()
		{
		}

		/// <summary/>
		public ProviderSearchParameters(ProviderSearchParameters theProviderSearchParameters)
		{
			CulturalEthnicityCode = theProviderSearchParameters.CulturalEthnicityCode;
			GivenNames = theProviderSearchParameters.GivenNames;
			LanguageSpokenCode = theProviderSearchParameters.LanguageSpokenCode;
			Surname = theProviderSearchParameters.Surname;

			if (theProviderSearchParameters.Attributes != null)
			{
				List<HasAttribute> attribs = new List<HasAttribute>();
				foreach (HasAttribute other in theProviderSearchParameters.Attributes)
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