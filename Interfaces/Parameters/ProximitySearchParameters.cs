///////////////////////////////////////////////////////////
//  ProximitySearchParameters.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServD.Parameters
{
	/// <summary>
	/// Filter options for the searching for records that are within a specified location (by co-ordinates)<br/>
	/// This will check that the latitude and longitude of a Sites SiteGeographicalCoordinate falls within the
	/// circle created by these parameters.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class ProximitySearchParameters
	{
		/// <summary>
		/// The Co-ordinate system being used (Spatial Reference ID - SRID)
		/// </summary>
		/// <remarks>
		/// The spatial reference identification system is defined by the 
		/// European Petroleum Survey Group (EPSG) standard, 
		/// which is a set of standards developed for cartography, surveying, and geodetic data storage. 
		/// This standard is owned by the Oil and Gas Producers (OGP) Surveying and Positioning Committee.
		/// </remarks>
		/// <example>WGS84</example>
		/// <summary>
		/// Other relevant information can be found at 
		/// http://sharpgis.net/post/2007/05/Spatial-references2c-coordinate-systems2c-projections2c-datums2c-ellipsoids-e28093-confusing.aspx
		/// </summary>
		[DataMember]
		[StringLength(64)]
		[Required]
		public string SpatialReferenceID { get; set; }

		/// <summary>
		/// The Latitude of the reference co-ordinate
		/// </summary>
		[DataMember]
		[Required]
		public double ProximityOfLatitude { get; set; }

		/// <summary>
		/// The Longitude of the reference co-ordinate
		/// </summary>
		[DataMember]
		[Required]
		public double ProximityOfLongitude { get; set; }

		/// <summary>
		/// Radius to search (in meters)
		/// </summary>
		[DataMember]
		[Required]
		public double ProximityRadiusToSearch { get; set; }

		/// <summary/>
		public ProximitySearchParameters()
		{
		}

		/// <summary/>
		public ProximitySearchParameters(ProximitySearchParameters theProximitySearchParameters)
		{
			ProximityOfLatitude = theProximitySearchParameters.ProximityOfLatitude;
			ProximityOfLongitude = theProximitySearchParameters.ProximityOfLongitude;
			ProximityRadiusToSearch = theProximitySearchParameters.ProximityRadiusToSearch;
		}
	}
}