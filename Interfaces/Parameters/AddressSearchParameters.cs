///////////////////////////////////////////////////////////
//  AddressSearchParameters.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServD.Parameters
{
	/// <value>REVIEW: MF</value>
	/// <summary>
	/// Filter options for the searching for records that have the specified address/catchment area values
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class AddressSearchParameters
	{
		/// <summary>
		/// Defines the primary type of activity at a location (Optional)
		/// </summary>
		/// <example>Residential, Business, Temporary</example>
		/// <cts2code scope='ServD.ADRT'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string AddressType { get; set; }

		/// <summary>
		/// Defines the usage of this address in relation to a specific action (Optional)
		/// </summary>
		/// <example>Mailing, Delivery, Shipping, Search Results</example>
		/// <cts2code scope='ServD.AP'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string AddressPurpose { get; set; }

		/// <summary>
		/// (City, Town, Village, Area) points within a hierarchy that travels from Country
		/// down to the lowest level of jurisdiction within the specified country.
		/// </summary>
		/// <example>West Melbourne</example>
		[DataMember]
		[StringLength(256)]
		public string Jurisdiction { get; set; }

		/// <summary>
		/// Include the surrounding Suburbs/Jurisdictions
		/// </summary>
		[DataMember]
		public Boolean IncludeSurrounding { get; set; }

		/// <summary>
		/// The region or state of this address.
		/// </summary>
		/// <example>Victoria</example>
		[DataMember]
		[StringLength(256)]
		public string Region { get; set; }

		/// <summary>
		/// The postal Identification Code contains the Zip Code or Postcode<br/>
		/// Usually this is defined by the national postal service.
		/// </summary>
		/// <example>3003</example>
		[DataMember]
		[StringLength(50)]
		public string PostalIdentificationCode { get; set; }

		/// <summary>
		/// The country
		/// </summary>
		/// <example>Australia</example>
		[DataMember]
		[StringLength(256)]
		public string Country { get; set; }

		/// <summary>
		/// The Catchment Area Code
		/// </summary>
		/// <remarks>This often used as a Local Government Area</remarks>
		/// <cts2code scope='ServD.CAC'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public String CatchmentAreaCode { get; set; }
		
		/// <summary/>
		public AddressSearchParameters()
		{
		}
	}
}