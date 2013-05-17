///////////////////////////////////////////////////////////
//  ServiceSiteSearchParameters.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ServD.Common;

namespace ServD.Parameters
{
	/// <summary>
	/// Search for Service Sites that have the following properties 
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class ServiceSiteSearchParameters
	{
		/// <summary>
		/// The ID of the ServiceSite to search for.
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string ServiceSiteId { get; set; }

		/// <summary>
		/// Indicates whether or not a prospective consumer will require an appointment for
		/// a particular service at a Site.
		/// To be provided by the Organization.
		/// Indicates if an appointment is required for access to this service.
		/// If this flag is 'NotDefined' then this flag is be overridden by the Site’s availability flag.
		/// </summary>
		[DataMember]
		public ConditionalIndicatorEnum NoAppointmentReqiured { get; set; }

		/// <summary>
		/// The free provision code provides a link to the Free Provision reference entity
		/// to enable the selection of one free provision type.
		/// </summary>
		/// <cts2code scope='ServD.SSFPC'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public String FreeProvisionCode { get; set; }

		/// <summary>
		/// Identifies the broad category of service being performed or delivered.
		/// Selecting a Service Category then determines the list of relevant service types
		/// that can be selected in the Primary Service Type.
		/// </summary>
		/// <cts2code scope='ServD.SC'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public String ServiceCategory { get; set; }

		/// <summary>
		/// The Code value of the Service Type
		/// </summary>
		/// <cts2code scope='ServD.ST'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(100)]
		public String ServiceType { get; set; }

		/// <summary>
		/// The code of a specialty to filter Organizations by
		/// </summary>
		/// <cts2code scope='ServD.SPCLTY.SS'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string SpecialtyCode { get; set; }

		/// <summary>
		/// The value from the reference list of the Target Group for the actual Service
		/// </summary>
		/// <cts2code scope='ServD.SSTG'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public String TargetGroup { get; set; }

		/// <summary>
		/// The Service Site Attribute can define things such as Bulk Billing, HMO
		/// attributes etc.
		/// These will be defined by specific CTS2 mappings where the ontology has not been
		/// defined.
		/// </summary>
		/// <remarks>
		/// If the Value specified in the attribute is empty, the request is intended to locate
		/// Service Site(s) that have this attribute type, and its value is not important.
		/// </remarks>
		[DataMember]
		public HasAttribute[] Attributes { get; set; }

		/// <summary>
		/// Indicates that we are looking for a Service Site that has a specific 
		/// identifier included (not its actual value).<br/>
		/// </summary>
		/// <remarks>Specifying this does not make the IdentiferValue field mandatory.</remarks>
		[DataMember]
		[StringLength(64)]
		public string IdentifierType { get; set; }

		/// <summary>
		/// The value of the Identifier that a Service Site must have.<br/>
		/// If specified, the IdentifierType field must also be populated.
		/// </summary>
		[DataMember]
		[StringLength(64)]
		public string IdentifierValue { get; set; }


		/// <summary/>
		public ServiceSiteSearchParameters()
		{
		}

		/// <summary/>
		public ServiceSiteSearchParameters(ServiceSiteSearchParameters theServiceSiteSearchParameters)
		{
			NoAppointmentReqiured = theServiceSiteSearchParameters.NoAppointmentReqiured;
			ServiceCategory = theServiceSiteSearchParameters.ServiceCategory;
			ServiceType = theServiceSiteSearchParameters.ServiceType;

			if (theServiceSiteSearchParameters.Attributes != null)
			{
				List<HasAttribute> attribs = new List<HasAttribute>();
				foreach (HasAttribute other in theServiceSiteSearchParameters.Attributes)
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
