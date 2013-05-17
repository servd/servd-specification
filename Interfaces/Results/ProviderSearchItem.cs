///////////////////////////////////////////////////////////
//  ProviderSearchItem.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ServD.Common;
using ServD.DataModel;
using System.Collections.Generic;

namespace ServD.Results
{
	/// <summary>
	/// The Provider Search Item contains a subset of the Provider information that has been restricted down 
	/// into an atomized form that can be displayed. Generic information can be populated into the base class SearchItem's Summary properties
	/// as desired by a ServD Core instance or component.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class ProviderSearchItem : SearchItem
	{
		/// <summary>
		/// ID of the Provider
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public String ProviderId { get; set; }

		/// <summary>
		/// Primary Site Id
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public String PrimarySiteId { get; set; }

		/// <summary>
		/// Collection of all Site Ids that this Provider is associated with
		/// </summary>
		[DataMember]
		public String[] SiteIds { get; set; }

		/// <summary>
		/// Collection of all Organization Ids (that also associate with the Site Ids above) that this Provider is associated with
		/// </summary>
		[DataMember]
		public String[] OrganizationIds { get; set; }

		/// <summary>
		/// Collection of all ServiceSite Ids (that also associate with the Site Ids above) that this Provider is associated with
		/// </summary>
		[DataMember]
		public String[] ServiceSiteIds { get; set; }

		/// <summary>
		/// The Title of the Provider.
		/// </summary>
		/// <example>Mr, Mrs, Dr</example>
		/// <cts2code scope='ServD.TITLE'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string TitleCode { get; set; }

		/// <summary>
		/// The Gender (sex) of the Provider.
		/// </summary>
		/// <cts2code scope='ServD.GEN'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string GenderCode { get; set; }

		/// <summary>
		/// Details the Provider’s family name.
		/// </summary>
		[DataMember]
		public string FamilyName { get; set; }

		/// <summary>
		/// Details the Provider’s given name(s).
		/// </summary>
		[DataMember]
		public string GivenNames { get; set; }

		/// <summary>
		/// Brief description of any special professional interests a Provider may wish to list.
		/// </summary>
		[DataMember]
		public string SpecialInterest { get; set; }

		/// <summary>
		/// Brief description of what is offered by a Provider, as a link to further
		/// information.
		/// </summary>
		[DataMember]
		public string Comment { get; set; }

		/// <summary>
		/// The Cultural Ethnicity code provides a link to the Cultural Ethnicity reference
		/// entity to enable the selection of one Cultural Ethnicity type.
		/// It is the self-identified cultural allegiance or background or ethnicity of the Provider.
		/// </summary>
		/// <cts2code scope='ServD.ETH'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string CulturalEthnicityCode { get; set; }

		/// <summary>
		/// Collection of Contact points for this Site
		/// </summary>
		[DataMember]
		public ContactPoint[] ContactPoints { get; set; }

		/// <summary>
		/// The language(s) spoken by the Provider
		/// </summary>
		[DataMember]
		public ProviderLanguage[] Languages { get; set; }

		/// <summary/>
		public ProviderSearchItem()
		{
		}

		/// <summary/>
		public ProviderSearchItem(ProviderSearchItem theProviderSearchItem)
		{

		}

		/// <summary/>
		public ProviderSearchItem(Provider theProvider)
		{
			this.Comment = theProvider.Comment;
			this.ContactPoints = (new List<ContactPoint>(theProvider.ContactPoints)).ToArray();
			if (theProvider.PreferredName != null)
			{
				this.FamilyName = theProvider.PreferredName.FamilyName;
				this.GivenNames = theProvider.PreferredName.GivenNames;
				this.TitleCode = theProvider.PreferredName.TitleCode;
			}
			this.ProviderId = theProvider.ProviderId;
			this.CulturalEthnicityCode = theProvider.CulturalEthnicityCode;
			this.GenderCode = theProvider.GenderCode;
			this.Heading = this.FamilyName + ", " + this.GivenNames;
			this.ImageURI = theProvider.ImageURI;
			this.Languages = (new List<ProviderLanguage>(theProvider.Languages)).ToArray();
			this.SpecialInterest = theProvider.SpecialInterest;
		}
	}
}