///////////////////////////////////////////////////////////
//  SearchResultsStatusEnum.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServD.Parameters;

namespace ServD.Common
{
	/// <summary>
	/// The Search Results Status is used to describe the status Search
	/// Operations of the ServD Search Interface.<br/>
	/// This is either from a <b>ServD Core</b> or a <b>ServD Locator</b>
	/// that supports the Search Interface, federating the actual search calls.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace, Name = "SearchResultsStatus")]
	public enum SearchResultsStatusEnum
	{
		/// <summary>
		/// The Search was successful.
		/// </summary>
		[EnumMember]
		Success,

		/// <summary>
		/// An error has occurred during the search.<br/>
		/// Refer to the Errors collection on the associated search result for
		/// details of the errors.
		/// </summary>
		[EnumMember]
		Error,

		/// <summary>
		/// Only some data was able to be loaded.
		/// </summary>
		/// <remarks>
		/// When searching using a federated search by a <b>ServD Locator</b>
		/// this can be the status associated if some of the searches succeeded,
		/// but others failed.<br/>
		/// In these cases refer to the Errors collection on the associated search 
		/// result for details of the errors.
		/// </remarks>
		[EnumMember]
		Partial,

		/// <summary>
		/// The search has returned no data as the search criteria was not
		/// sufficiently restricted.
		/// </summary>
		[EnumMember]
		ErrorInadequateSearchParameters,
	}
}
