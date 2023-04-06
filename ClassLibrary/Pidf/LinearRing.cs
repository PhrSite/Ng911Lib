/////////////////////////////////////////////////////////////////////////////////////
//	File:	LinearRing.cs											24 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6. Added documentation
//                comments.
//				2 Dec 22 PHR -- Added ConvertCompactFormToStandardForm()
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace Pidf
{
	/// <summary>
	/// Class that implements the LinearRing element XML schemas for a Polygon 
	/// element.
	/// </summary>
	[SerializableAttribute()]
	[XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/gml")]
	[XmlRoot(Namespace = "http://www.opengis.net/gml", IsNullable = false)]
	public class LinearRing
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public LinearRing()
		{
		}

		/// <summary>
		/// Gets or sets the array of Position elements.
		/// </summary>
		[XmlElement("pos")]
		public List<Position> pos = null;

		/// <summary>
		/// Gets or sets a string containing the coordinates for the compact
		/// form of the LinearRing element.
		/// </summary>
		[XmlElement("posList")]
		public string posList = null;

		/// <summary>
		/// Converts the compact form of a LinearRing to the standard form.
		/// </summary>
		/// <returns>Returns a List of Position elements. Returns null if an error is detected.</returns>
		public List<Position> ConvertCompactFormToStandardForm()
		{
			if (string.IsNullOrEmpty(posList) == true)
				return null;

			List<Position> list = new List<Position>();
			string str = posList.Trim().Replace("\n", " ").Replace("\r", " ");
			string[] strPts = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			if (strPts == null || strPts.Length == 0)
				return null;

			if (strPts.Length < 4)
				return null;    // Two coordinates are not enough points to make a polygon

			bool HasAltitude = false;
			int Increment = 2;

			if (strPts.Length % 2 == 0)
				HasAltitude = false;
			else if (strPts.Length % 3 == 0)
			{
				HasAltitude = true;
				Increment = 3;
			}
			else
				return null;

			double Lat, Long, Alt;
            for (int i=0; i < strPts.Length; i += Increment)
			{
				if (double.TryParse(strPts[i], out Lat) == false)
					return null;
				if (double.TryParse(strPts[i + 1], out Long) == false)
					return null;

				if (HasAltitude == true)
				{
					if (double.TryParse(strPts[i + 2], out Alt) == false)
						return null;
					list.Add(new Position(Lat, Long, Alt));
				}
				else
					list.Add(new Position(Lat, Long));
			}

			return list;
		}
	}
}
