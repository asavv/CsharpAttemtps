using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Collections
{
    class CDserialiser
    {
        /// <summary>
        /// Deserialise one CD from an xml entry (XElement)
        /// </summary>
        /// <param name="cdXml">The XML entry equivalent to one CD.</param>
        /// <returns></returns>
        public static CD CDdeserialise(XElement cdXml)
        {
            if(cdXml == null) throw new ArgumentNullException("cdXml","XElement entry is null.");

            string artist = cdXml.Element("artist").Value;
            if (artist == null)
            {
                throw new ArgumentNullException(artist, "Artist parameter in CDSerialise is null.");
            }

            string album = cdXml.Element("album").Value;
            if (album == null)
            {
                throw new ArgumentNullException(album, "Album parameter in CDSerialise is null.");
            }

            string genre = cdXml.Element("genre").Value;
            if (genre == null)
            {
                throw new ArgumentNullException(genre, "Genre parameter in CDSerialise is null.");
            }

            string year = cdXml.Element("year").Value;
            if(year == null)
            {
                throw new ArgumentNullException(year, "Year parameter in CDSerialise is null.");
            }
          

            CD cd = new CD(
                artist, 
                album, 
                genre, 
                Convert.ToInt32(year));

            return cd;

        }

        /// <summary>
        /// Serialise one CD to xml data
        /// </summary>
        /// <param name="cd"></param>
        /// <returns></returns>
        public static XElement CDserialise(CD cd)
        {
            if (cd == null) throw new ArgumentNullException("cd","CD object is null.");

            XElement element = new XElement("cd",
                new XElement ("artist", cd.Artist),
                new XElement ("album", cd.Album),
                new XElement ("genre", cd.Genre),
                new XElement ("year", cd.Year.ToString()) );

            return element;
        }

        /// <summary>
        /// Deserialise the list of CDs from XML data source
        /// </summary>
        /// <param name="xml">XML data source.</param>
        /// <returns></returns>
        public static List<CD> DeserialiseAllCD(XDocument xmlDoc)
        {
            if (xmlDoc == null) throw new ArgumentNullException("xmlDoc", "Xdocument is null ");

            List<CD> cds = new List<CD>();
            /// HEEEEEEEEREEEEEEEEEEEEEEE!!!!
            //var cdsAll = from cd in xmlDoc.Descendants("cds") where cd.Element().Value == "cd" select cd
            foreach (XElement cdElement in xmlDoc.Root.Elements("cds").Elements())
            {
                CD cd = CDdeserialise(cdElement);
                cds.Add(cd);
            }

            //foreach (XElement cdElement in xmlDoc.Root.Elements("cds").Elements())
            //{
            //    CD cd = CDdeserialise(cdElement);
            //    cds.Add(cd);
            //}

            return cds;
        }

        /// <summary>
        /// Serialise a list of CD objects to a XML data source
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static XElement SerialiseAllCD(List<CD> cds)
        {
            if (cds == null) throw new ArgumentNullException("cds","List of CDs is null.");

            XElement element = new XElement("cds");
            foreach (CD cd in cds)
            {
                element.Add(CDserialise(cd));
            }
            return element;
        }

    }
}
