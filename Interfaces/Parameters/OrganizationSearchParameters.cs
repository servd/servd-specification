///////////////////////////////////////////////////////////
//  OrganizationSearchParameters.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServD.Parameters
{
	/// <summary>
	/// Search for Organizations that have the following properties
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class OrganizationSearchParameters
	{
		/// <summary>
		/// A specific Organization ID to locate
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string OrganizationId { get; set; }

		/// <summary>
		/// The Name of the Organization to Search for (when filtering for this field, ensure that the 
		/// SearchControlParameter StringMatchType is utilized)
		/// </summary>
		[DataMember]
		public String Name { get; set; }

		/// <summary>
		/// A list of Attributes to filter the Organization by
		/// </summary>
		/// <remarks>
		/// If the Value specified in the attribute is empty, the request is intended to locate
		/// Organizations that have this attribute type, and its value is not important.
		/// </remarks>
		[DataMember]
		public HasAttribute[] Attributes { get; set; }

		/// <summary>
		/// Specify that we are searching for an Organization that has an Affiliation
		/// with a specific Affiliation.
		/// </summary>
		/// <cts2code scope='ServD.OAFT'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string AffiliationType { get; set; }

		/// <summary>
		/// Indicates that we are looking for an Organization that has a specific 
		/// identifier included (not its actual value).<br/>
		/// </summary>
		/// <remarks>Specifying this does not make the IdentiferValue field mandatory.</remarks>
		/// <example>HPI-O</example>
		[DataMember]
		[StringLength(64)]
		public string IdentifierType { get; set; }

		/// <summary>
		/// The value of the Identifier that an Organization must have.<br/>
		/// If specified, the IdentifierType field must also be populated.
		/// </summary>
		[DataMember]
		[StringLength(64)]
		public string IdentifierValue { get; set; }

		/// <summary>
		/// The code of a specialty to filter Organizations by
		/// </summary>
		/// <cts2code scope='ServD.SPCLTY.Org'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string SpecialtyCode { get; set; }

		/// <summary>
		/// Specify the Name type to be returned on the Search Items in the returned collection.<br/>
		/// If the specific type is not available, the ServD Core can choose which Record to include.
		/// </summary>
		/// <example>Trading Name</example>
		/// <cts2code scope='ServD.ONT'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string NameType { get; set; }

		/// <summary>
		/// Specify the Name Purpose to be returned on the Search Items in the returned collection.<br/>
		/// If the specific purpose is not available, the ServD Core can choose which Record to include.
		/// </summary>
		/// <example>Search Results</example>
		/// <cts2code scope='ServD.ONP'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string NamePupose { get; set; }

		/// <summary>
		/// Specify the Address type to be returned on the Search Items in the returned collection.<br/>
		/// If the specific type is not available, the ServD Core can choose which Record to include.
		/// </summary>
		/// <example>Administration</example>
		/// <cts2code scope='ServD.ADRT'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string AddressType { get; set; }

		/// <summary>
		/// Specify the Address Purpose to be returned on the Search Items in the returned collection.<br/>
		/// If the specific purpose is not available, the ServD Core can choose which Record to include.
		/// </summary>
		/// <example>Search Results</example>
		/// <cts2code scope='ServD.AP'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string AddressPupose { get; set; }

		/// <summary>
		/// Specify the Contact Purpose to be returned on the Search Items in the returned collection.<br/>
		/// If the specific purpose is not available, the ServD Core can choose which Record to include.
		/// </summary>
		/// <remarks>The Contact Point type that will be used is defined in the ServD Federation's Profile</remarks>
		/// <cts2code scope='ServD.CPT'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string WebAddressContactPointPupose { get; set; }


		/// <summary/>
		public OrganizationSearchParameters()
		{
		}

		/// <summary/>
		public OrganizationSearchParameters(OrganizationSearchParameters theOrganizationSearchParameters)
		{
			Name = theOrganizationSearchParameters.Name;
			OrganizationId = theOrganizationSearchParameters.OrganizationId;
		}
	}
}