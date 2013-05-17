///////////////////////////////////////////////////////////
//  Endpoint.cs
//  Implementation of the Class Endpoint
//  Generated by Enterprise Architect
//  Created on:      16-May-2012 12:28:06 AM
//  Original author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Runtime.Serialization;

namespace ServD.Parameters
{
	/// <summary>
	/// 
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class Endpoint
	{
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public String address { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public String CTS2domain { get; set; }

		/// <summary/>
		public Endpoint()
		{
		}

		/// <summary/>
		public Endpoint(Endpoint theEndpoint)
		{
			address = theEndpoint.address;
			CTS2domain = theEndpoint.CTS2domain;
		}

	}//end Endpoint

}//end namespace Parameters