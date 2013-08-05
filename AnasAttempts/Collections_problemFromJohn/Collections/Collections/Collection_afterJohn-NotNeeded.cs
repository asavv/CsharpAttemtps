using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Collections
{
    class Collection
    {
        private XDocument mXml;

        public Collection(XDocument xmlData)
        {
            mXml = xmlData;
        }
        /// <summary>
        /// Obtain the data of the CD collection only from the general data file
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> GetCDcollectionXmlData()
        {
            IEnumerable<XElement> mEnumXml;

            mEnumXml = mXml.Elements("cds").Descendants();

            //// debug: testing content of mEnumXmml


            /*
            foreach (XElement el in mEnumXml)
            {
                Console.WriteLine("{0}: {1}", el.Name.ToString(), el.Value);
            }/**/

            Console.WriteLine("INFO: Finished getting XML CD collection from XML Data Collection - at GetCDcollectionXmlData function");
            /*
            foreach (XElement el in mEnumXml)
            {
                if (el.HasAttributes)
                {
                    Console.WriteLine("{0} {1}", el.Name.ToString(), el.Attribute("cd").Value);
                }
                else
                    Console.WriteLine("{0}: {1}", el.Name.ToString(), el.Value); 
                 
            }/**/

            return mEnumXml;
        }


        public void PrintWholeCollectionToConsole()
        {
            foreach (XElement element in mXml.Elements())
            {
                Console.WriteLine("{0} \t\t {1}", element.Name, element.Value);
            }
        }
    }
}
