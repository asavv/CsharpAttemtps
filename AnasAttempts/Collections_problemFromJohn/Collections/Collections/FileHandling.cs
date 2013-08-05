using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Collections
{
    class FileHandling
    {
        /// <summary>
        /// Reads Xml File from disk and parse it to XML data
        /// </summary>
        /// <param name="pathToFile"> Path to file on disk </param>
        /// <returns></returns>
        public static XElement ReadXmlFile(string pathToFile)
        {
            string fileContent = OpenFile(pathToFile);
            XElement xml = ParseStringToXmlData(fileContent);

            return (xml);
        }

        /// <summary>
        /// Parse a string data into xml data and return the XElement content
        /// </summary>
        /// <param name="fileContent"></param>
        /// <returns></returns>
        private static XElement ParseStringToXmlData(string dataContent)
        {
            // Convert the text into xml code

            //use that string to parse to a XML stream (convert data to xml data)
            XmlReader xmlreader = XmlReader.Create(new StringReader(dataContent));

            /* ****** A way to do it, where you have  more control but also lower level (less human-friendly) ****
            
            xmlreader.MoveToContent();
            string xmlNodeType = null;
            string xmlNodeValue = null;

            while (xmlreader.Read())
            {
                if (xmlreader.NodeType == XmlNodeType.Element)
                {
                    xmlNodeType = xmlreader.Name.ToString();
                }
                else if (xmlreader.NodeType == XmlNodeType.Text)
                {
                    xmlNodeValue = xmlreader.Value.ToString();
                }
                if (xmlNodeType != null && xmlNodeValue != null)
                {
                    Console.WriteLine("{0} \t\t {1}",xmlNodeType, xmlNodeValue);
                    xmlNodeType = null;
                    xmlNodeValue = null;
                }
            /**/

            // Have access to the xml data
            XElement xml = XElement.Load(xmlreader, LoadOptions.PreserveWhitespace);

            return xml;
        }

        /// <summary>
        /// Read file from disk with FileStram, convert it into text.
        /// </summary>
        /// <param name="pathToFile"> Path to file on disk </param>
        private static String OpenFile(string pathToFile)
        {
            //read xml file with FileStram
            // make sure the file exists first.
            if (!File.Exists(pathToFile))
            {
                throw new FileNotFoundException("file " + pathToFile + " does not exist.");
            }

            //Read the file as a stream of bites/bytes
            FileStream fs = new FileStream(pathToFile, FileMode.Open);

            // Convert the binary stream into text
            //////////// ?????????????????? what to do if you don't know the encoding?!?!?!?!?! IS IT AN RECTORICAL QUESTION??? 
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.UTF8);
                // uses the automatic detection of the encoding through the BOM.
            string fileStringLines;

            // store the file text content into a string
            fileStringLines = sr.ReadToEnd();

            //Console.WriteLine(fileStringLines);

            /*  //*** debugging block***
            string line;
            while ((line = sr.ReadLine()) != null)
            {
               Console.WriteLine(line);
            } /**/

            //close FileStream and StreamReader
            fs.Close();
            sr.Close();

            return fileStringLines;
        }

    }
}
