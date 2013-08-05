using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Collections
{
    internal class Program
    {
        /// <summary>
        /// the purpose of this program is to read from an xml file, extract the data and write it to the console 
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {

            try
            {
                string pathToFile =
                    @"C:\\Users\Ana\Projects\CsharpTryouts-ASAVV\CsharpAttemtps\AnasAttempts\Collections_problemFromJohn\DataCollection.xml";
                CDReport(pathToFile);
            }
            catch (ArgumentNullException doh)
            {
                Console.WriteLine("EXCEPTION: {0}", doh.Message);
                Console.WriteLine("Extra info: {0}", doh.StackTrace);
            }

            catch (Exception doh)
            {
                // Still don't know how to deal with this exception...
                Console.WriteLine("EXCEPTION: {0}", doh.Message);
                Console.WriteLine("Extra info: {0}", doh.StackTrace);
            }

        }

        private static void CDReport(string pathToFile)
        {
            if (pathToFile == null) throw new ArgumentNullException("Path file is null.");

            XDocument xml;
            // Extract the relevant data from file to xml data access
            try
            {
                xml = FileHandling.ReadXmlFile(pathToFile);
            }
            catch (Exception )
            {
                throw new Exception("Could not open file. Program closing...");
            }

            //// Deserialise XML data to list of CDs.
            List<CD> cds;
            try
            {
                cds = new List<CD>();
                cds = CDserialiser.DeserialiseAllCD(xml);
            }
            catch (Exception )
            {
                throw new Exception("Problems converting input data. Program closing...");
            }

            try
            {
                // Print data into the console
                CD.PrintCDsContent(cds);
            }
            catch (Exception )
            {
                throw new Exception("Problem printing the content requested. Program closing...");
            }

            //// Continue program by adding a few more CD entries to the CDList
            string fileoutputPath;
            try
            {
                CD cd = new CD("Andrew Bird", "Break it yourself", "fold rock, indie folk", 2012);
                cds.Add(cd);

                fileoutputPath = @"C:\Users\Ana\Projects\CsharpTryouts-ASAVV\CsharpAttemtps\AnasAttempts\Collections_problemFromJohn\OutputFile.xml";
                FileHandling.WriteXmlFile(cds, fileoutputPath);
            }
            catch (Exception )
            {
                throw new Exception("Problems adding data and printing the total content of the list of CDs to file. Program closing...");
            }

        }
    }
}
