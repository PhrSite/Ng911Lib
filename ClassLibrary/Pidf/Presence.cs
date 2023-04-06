/////////////////////////////////////////////////////////////////////////////////////
//	File:	Presence.cs												19 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6. Added documentation
//                comments.
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

using AdditionalData;

namespace Pidf
{
    /// <summary>
    /// Class for handling the root element of a PIDF-LO presence XML document.
    /// See RFC 4119.
    /// </summary>
	[Serializable()]
	[XmlType(Namespace = "urn:ietf:params:xml:ns:pidf")]
	[XmlRoot("presence", Namespace = "urn:ietf:params:xml:ns:pidf", IsNullable = false)]
	public class Presence
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
		public Presence() { }

        /// <summary>
        /// Creates a new tuple style Presence object with empty sub-elements up to and including the 
        /// location-info element.
        /// </summary>
        /// <param name="id">Specifies the id attribute of the tuple element. May be null.</param>
        /// <returns>Returns a new tuple style Presence object.</returns>
        public static Presence CreateTuplePresence(string id)
        {
            Presence pres = new Presence();
            pres.tuple = new Tuple();
            pres.tuple.id = id;
            pres.tuple.status = new Status();
            pres.tuple.status.geopriv = new GeoPriv();
            pres.tuple.status.geopriv.LocationInfo = new locInfoType();
            return pres;
        }

        /// <summary>
        /// Creates a new device style Presence object with empty sub-elements up to and including the
        /// location-info element.
        /// </summary>
        /// <param name="id">Specifies the id attribute of the device element. May be null.</param>
        /// <returns>Returns a new device style Presence object.</returns>
        public static Presence CreateDevicePresence(string id)
        {
            Presence pres = new Presence();
            pres.device = new Device();
            pres.device.id = id;
            pres.device.geopriv = new GeoPriv();
            pres.device.geopriv.LocationInfo = new locInfoType();
            return pres;
        }

        /// <summary>
        /// Creates a new person style Presence object with empty sub-elements up to and including the
        /// location-info element.
        /// </summary>
        /// <param name="id">Specifies the id attribute of the person element. May be null.</param>
        /// <returns>Returns a new person style Presence object.</returns>
        public static Presence CreatePersonPresence(string id)
        {
            Presence pres = new Presence();
            pres.person = new Person();
            pres.person.id = id;
            pres.person.geopriv = new GeoPriv();
            pres.person.geopriv.LocationInfo = new locInfoType();
            return pres;
        }

        /// <summary>
        /// The URI of the entity whose presence the XML document describes.
        /// </summary>
		[XmlAttribute("entity")]
		public string entity = null;

        /// <summary>
        /// Umbrella element that has id, status and contact elements.
        /// </summary>
		[XmlElement("tuple")]
		public Tuple tuple = null;

        /// <summary>
        /// Contains human readable comments text. Optional.
        /// </summary>
		[XmlElement("note")]
		public string note = null;

        /// <summary>
        /// Contains location information about a person.
        /// </summary>
		[XmlElement("person", Namespace = "urn:ietf:params:xml:ns:pidf:data-model")]
		public Person person = null;

        /// <summary>
        /// Contains location information about a device.
        /// </summary>
		[XmlElement("device", Namespace = "urn:ietf:params:xml:ns:pidf:data-model")]
		public Device device = null;

        /// <summary>
        /// Gets the first instance of a CivicAddress by searching through all
        /// possible locations stored in this Presence object.
        /// </summary>
        /// <returns>Returns the first CivicAddress that is found. Returns null
        /// if there are no civic addresses.</returns>
        public CivicAddress GetFirstCivicAddress()
        {
            return GetFirstCivicAddressLocation()?.civicAddress;
        }

        /// <summary>
        /// Gets the first location-info object that has a CivicAddress in it.
        /// </summary>
        /// <returns>Returns a locInfoType object if there is civic address
        /// data in this Presence object. Returns null if no civic address
        /// data is available.</returns>
        public locInfoType GetFirstCivicAddressLocation()
        {
            locInfoType Lit = null;
            if (tuple?.status?.geopriv?.LocationInfo?.civicAddress != null)
                Lit = tuple.status.geopriv.LocationInfo;
            else if (device?.geopriv?.LocationInfo?.civicAddress != null)
                Lit = device.geopriv.LocationInfo;
            else if (person?.geopriv?.LocationInfo?.civicAddress != null)
                Lit = person.geopriv.LocationInfo;

            return Lit;
        }

        /// <summary>
        /// Builds a list of all GeoPriv objects in this Presence object.
        /// </summary>
        /// <returns>Returns a list of objects. The return value will always be
        /// non-null but may be empty.</returns>
        public List<GeoPriv> GetAllGeoPrivObjects()
        {
            List<GeoPriv> GeoPrivs = new List<GeoPriv>();

            if (tuple?.status?.geopriv != null)
                GeoPrivs.Add(tuple.status.geopriv);

            if (device?.geopriv != null)
                GeoPrivs.Add(device.geopriv);

            if (person?.geopriv != null)
                GeoPrivs.Add(person.geopriv);

            return GeoPrivs;
        }

        /// <summary>
        /// Gets the first location-info object that has at least one geolocation
        /// in it.
        /// </summary>
        /// <returns>Returns the first location-info object that contains some
        /// geolocation data. Returns null if there is no geolocation data 
        /// available.</returns>
        public locInfoType GetFirstGeolocation()
        {
            locInfoType Lit = null;
            List<locInfoType> Locs = new List<locInfoType>();
            Locs.Add(tuple?.status?.geopriv?.LocationInfo);
            Locs.Add(device?.geopriv?.LocationInfo);
            Locs.Add(person?.geopriv?.LocationInfo);

            foreach (locInfoType loc in Locs)
            {
                if (loc != null)
                {
                    if (loc.Point != null || loc.Circle != null || loc.Ellipse != 
                        null || loc.Polygon != null || loc.ArcBand != null ||
                        loc.Prism != null || loc.Sphere != null || loc.Ellipsoid !=
                        null)
                    {
                        Lit = loc;
                        break;
                    }
                }
            }

            return Lit;
        }

        /// <summary>
        /// Gets the first geopriv object.
        /// </summary>
        /// <returns>Returns the first geopriv object or null if there are none
        /// available.</returns>
        public GeoPriv GetFirstGeoPriv()
        {
            List<GeoPriv> Gps = GetAllGeoPrivObjects();
            if (Gps != null && Gps.Count > 0)
                return Gps[0];
            else
                return null;
        }

        /// <summary>
        /// Gets the first GeoPriv object that has a geodetic shape in it.
        /// </summary>
        /// <returns>Returns a GeoPriv object that contains a geodetic shape or
        /// null if one is not found.</returns>
        public GeoPriv GetFirstGeoGeoPriv()
        {
            List<GeoPriv> Gps = GetAllGeoPrivObjects();
            foreach (GeoPriv Gp in Gps)
            {
                if (Gp.LocationInfo != null)
                {
                    if (Gp.LocationInfo.Point != null || 
                        Gp.LocationInfo.Circle != null||
                        Gp.LocationInfo.ArcBand != null ||
                        Gp.LocationInfo.Ellipse != null ||
                        Gp.LocationInfo.Ellipsoid != null ||
                        Gp.LocationInfo.Polygon != null ||
                        Gp.LocationInfo.Prism != null ||
                        Gp.LocationInfo.Sphere != null)

                        return Gp;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the first GeoPriv object that contains a civic location.
        /// </summary>
        /// <returns>Returns a GeoPriv object that contains a CivicAddress or
        /// null if one is not found.</returns>
        public GeoPriv GetFirstCivicGeoPriv()
        {
            List<GeoPriv> Gps = GetAllGeoPrivObjects();
            foreach (GeoPriv Gp in Gps)
            {
                if (Gp.LocationInfo != null && Gp.LocationInfo.civicAddress != null)
                    return Gp;
            }

            return null;
        }

        /// <summary>
        /// Gets the first SubscriberInfoType object by-value from the provided-by element.
        /// </summary>
        /// <returns>Returns the first SubscriberInfoType object or null if one is not available.</returns>
        public SubscriberInfoType GetFirstSubscriberInfo()
        {
            SubscriberInfoType Sit = GetFirstGeoPriv()?.ProvidedBy?.
                EmergencyCallDataValue?.EmergencyCallDataSubscriberInfo?[0];
            return Sit;
        }

        /// <summary>
        /// Gets the first ServiceInfoType object by-value from the provided-by element.
        /// </summary>
        /// <returns>Returns the first ServiceInfoType object or null if one is not available.</returns>
        public ServiceInfoType GetFirstServiceInfo()
        {
            ServiceInfoType Sit = GetFirstGeoPriv()?.ProvidedBy?.
                EmergencyCallDataValue?.EmergencyCallDataServiceInfo?[0];
            return Sit;
        }


    }
}
