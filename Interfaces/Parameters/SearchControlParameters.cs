///////////////////////////////////////////////////////////
//  SearchControlParameters.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.Runtime.Serialization;
using ServD.Common;

namespace ServD.Parameters
{
	/// <value>REVIEW: MF</value>
	/// <summary>
	/// The Search Control Parameters are used to specify what level of data is to be retrieved
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class SearchControlParameters
	{
		/// <summary>
		/// Where there is data that is being moderated and you are either the author or approver,
		/// explicitly request to see the un-moderated data elements.
		/// When this value is false, all searches will return the same fully moderated data, regardless of
		/// the user type (Author, Approver or Searcher)
		/// </summary>
		[DataMember]
		public bool GetUnmoderatedDataWhereAvailable { get; set; }

		/// <summary>
		/// The Number of items to be included in a page request
		/// </summary>
		[DataMember]
		public int PageSize { get; set; }

		/// <summary>
		/// The type of search to perform
		/// </summary>
		[DataMember]
		public StringMatchTypeEnum StringMatchType { get; set; }

		/// <summary/>
		public SearchControlParameters()
		{
		}
	}
}