///////////////////////////////////////////////////////////
//  PagedSearchResults.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////

// don't need the code comments for this base interface as it is
// just here to force the discipline on the collection classes
#pragma warning disable 1591

using System;
using System.Runtime.Serialization;
using ServD.Common;

namespace ServD.Common
{
	/// <value>REVIEW: MF</value>
	/// <summary>
	/// The Paged Search Results provides a common paging foundation under all search list results to
	/// permit the loading of longer lists of data.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public abstract class PagedSearchResults
	{
		/// <summary>
		/// The result status of the Search
		/// </summary>
		/// <example>Success, Error, Partial</example>
		[DataMember]
		public SearchResultsStatusEnum Status { get; set; }

		/// <summary>
		/// Collection of errors
		/// </summary>
		[DataMember]
		public Result[] Errors { get; set; }

		/// <summary>
		/// The Number of items included in a page of results
		/// </summary>
		[DataMember]
		public int PageSize { get; set; }

		/// <summary>
		/// The Current page of data that is in this results collection
		/// </summary>
		[DataMember]
		public int CurrentPage { get; set; }
	
		/// <summary>
		/// The Estimated Total number of Pages of data available in the collection
		/// </summary>
		[DataMember]
		public int EstimatedTotalPages { get; set; }

		/// <summary>
		/// The Estimated Total number of items in the collection
		/// </summary>
		[DataMember]
		public int EstimatedTotalItems { get; set; }
	}
}
