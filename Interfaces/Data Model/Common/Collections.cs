using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServD.Enumerations;
using ServD.Parameters;

namespace ServD.Results
{
	/// <summary>
	/// 
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class AggregatedSearchResults
	{
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public OrganizationList Organizations { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public String[] Errors { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public SearchResultsStatusEnum Status { get; set; }

		/// <summary/>
		public AggregatedSearchResults()
		{
		}
	}

	/// <summary>
	/// 
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class CoverageAreas
	{
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		virtual public ICollection<CoverageArea> Results { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class OrganizationList : PagedSearchResults
	{
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public OrganizationSearchItem[] Results { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int CurrentPage { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int EstimatedTotalPages { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int EstimatedTotalItems { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string SearchCookie { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public String[] Errors { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public SearchResultsStatusEnum Status { get; set; }

		/// <summary/>
		public OrganizationList()
		{
		}

		/// <summary/>
		public OrganizationList(OrganizationList theOrganizationList)
		{
		}
	}

	/// <summary>
	/// 
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class SiteList : PagedSearchResults
	{
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public SiteSearchItem[] Results { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int CurrentPage { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int EstimatedTotalPages { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int EstimatedTotalItems { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string SearchCookie { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public String[] Errors { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public SearchResultsStatusEnum Status { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class ServiceSiteList : PagedSearchResults
	{
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public ServiceSiteSearchItem[] Results { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int CurrentPage { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int EstimatedTotalPages { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int EstimatedTotalItems { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string SearchCookie { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public String[] Errors { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public SearchResultsStatusEnum Status { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class ProviderList : PagedSearchResults
	{
		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public ProviderSearchItem[] Results { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int CurrentPage { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int EstimatedTotalPages { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int EstimatedTotalItems { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string SearchCookie { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public String[] Errors { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public SearchResultsStatusEnum Status { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class ReferenceList : PagedSearchResults
	{
		//[DataMember]
		//public OrganizationSearchItem[] Results { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int CurrentPage { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int EstimatedTotalPages { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int EstimatedTotalItems { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string SearchCookie { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public String[] Errors { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public SearchResultsStatusEnum Status { get; set; }
	}
}
