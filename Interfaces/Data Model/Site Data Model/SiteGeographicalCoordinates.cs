///////////////////////////////////////////////////////////
//  SiteGeographicalCoordinates.cs
//  Created on:      10-August-2012 2:00:00 PM
//  Original Author: BPostlethwaite
///////////////////////////////////////////////////////////
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ServD.Common;

namespace ServD.DataModel
{
	///<value>REVIEW: MF</value>
	/// <summary>
	/// A Site may be described in many different ways in order to place the
	/// Site into a geographical context. For example: one method is to assign to each
	/// Site a longitude, latitude and altitude. Another method is to assign each Site
	/// within some larger context such as a bounded area which could be defined by
	/// postal codes, electoral districts, or some other means of dividing areas. Each
	/// method of description is represented by a different instance within this entity,
	/// allowing a Service Site to have zero, one or more geographical definitions.
	/// </summary>
	[DataContract(Namespace = Constants.ServDNamespace)]
	public class SiteGeographicalCoordinate : ModeratedRecord
	{
		/// <summary>
		/// The Id is just used to provide a central value that permits the extraction
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[StringLength(50)]
		[IgnoreDataMember]
		public override string InternalId { get { return SiteGeographicalCoordinateId; } set { SiteGeographicalCoordinateId = value; } }

		/// <summary>
		/// The type of record this is
		/// </summary>
		/// <remarks>Not a part of the data contract or the entity framework</remarks>
		[IgnoreDataMember]
		public override RecordTypeEnum RecordType { get { return RecordTypeEnum.SiteGeographicalCoordinate; } }

		/// <summary>
		/// A unique Identifier that is allocated by the saving system
		/// When adding a new Site geographical co-ordinate, this is blank and will be allocated
		/// </summary>
		[DataMember]
		[StringLength(50)]
		public string SiteGeographicalCoordinateId { get; set; }

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
		/// The Latitude of the Site (Optional)
		/// </summary>
		[DataMember]
		public decimal Latitude { get; set; }

		/// <summary>
		/// The Longitude of the Site (Optional)
		/// </summary>
		[DataMember]
		public decimal Longitude { get; set; }

		/// <summary>
		/// The Altitude of the Site (Optional)
		/// </summary>
		[DataMember]
		public decimal Altitude { get; set; }

		/// <summary>
		/// The accuracy of the Latitude, Longitude and Altitude fields.
		/// Measures in meters.
		/// </summary>
		[DataMember]
		public int Granularity { get; set; }

		/// <summary>
		/// This format of the Boundary Shape field.<br/>
		/// (see http://en.wikipedia.org/wiki/GIS_file_formats)
		/// </summary>
		/// <example>WKT</example>
		/// <example>WKB</example>
		/// <cts2code scope='ServD.GBSHF'>ServD.CTS2.References</cts2code>
		[DataMember]
		[StringLength(64)]
		public string ShapeFormat { get; set; }

		/// <summary>
		/// This is the shape definition of the boundary for this Site.
		/// </summary>
		[DataMember]
		public string SiteShape { get; set; }

		/// <summary>
		/// This is the shape definition of the "coverage area" for the Site.
		/// </summary>
		[DataMember]
		public string CatchmentShape { get; set; }

		/// <summary>
		/// If true, this coordinate may be used in searches to find a Site.
		/// If false, then the value cannot be used in searches
		/// </summary>
		/// <remarks>
		/// This has been added to strengthen the privacy implications of location
		/// </remarks>
		[DataMember]
		public bool IsSearchableCoordinate { get; set; }

		/// <summary/>
		public SiteGeographicalCoordinate()
		{
		}

		/// <summary/>
		public SiteGeographicalCoordinate(SiteGeographicalCoordinate theSiteGeographicalCoordinates)
		{

		}
	}
}