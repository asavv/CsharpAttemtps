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
                DoWork(pathToFile);
            }
            catch (Exception doh)
            {
                // Still don't know how to deal with this exception...
                Console.WriteLine("EXCEPTION: {0}", doh.Message);
                Console.WriteLine("{0}", doh.StackTrace);
            }

        }

        private static void DoWork(string pathToFile)
        {
            // Extract the relevant data 
            XElement xml = FileHandling.ReadXmlFile(pathToFile);

            Collection collection = new Collection(xml);

            IEnumerable<XElement> cdXmlData;
            cdXmlData = collection.GetCDcollectionXmlData();

            CD cd1 = new CD();
            CD cd2 = new CD();
            CD cd3 = new CD();
            int countCDs = 0;
            foreach (XElement el in cdXmlData)
            {
                string name = el.Name.ToString();
                string value = el.Value;

                if (name == "cd")
                {
                    countCDs++;
                    continue;
                }
                if (countCDs == 1)
                {
                    switch (name)
                    {
                        case ("album"):
                            cd1.album = value;
                            //Console.WriteLine("Album: {0}", value);
                            break;
                        case ("year"):
                            cd1.year = Convert.ToInt32(value);
                            //Console.WriteLine("Year: {0}", value);
                            break;
                        case ("artist"):
                            cd1.artist = value;
                            //Console.WriteLine("Artist: {0}", value);
                            break;
                        case ("genre"):
                            cd1.genre = value;
                            //Console.WriteLine("Genre: {0}", value);
                            break;
                        default:
                            throw new ArgumentException("ERROR: XElement {0} not expected", name);
                            break;
                    }
                }
                else if (countCDs == 2)
                {
                    switch (name)
                    {
                        case ("album"):
                            cd2.album = value;
                            //Console.WriteLine("Album: {0}", value);
                            break;
                        case ("year"):
                            cd2.year = Convert.ToInt32(value);
                            //Console.WriteLine("Year: {0}", value);
                            break;
                        case ("artist"):
                            cd2.artist = value;
                            //Console.WriteLine("Artist: {0}", value);
                            break;
                        case ("genre"):
                            cd2.genre = value;
                            //Console.WriteLine("Genre: {0}", value);
                            break;
                        default:
                            throw new ArgumentException("ERROR: XElement {0} not expected", name);
                            break;
                    }
                }
                else if (countCDs == 3)
                {
                    switch (name)
                    {
                        case ("album"):
                            cd3.album = value;
                            Console.WriteLine("Album: {0}", cd3.album);
                            Console.WriteLine("Album: {0}", value);
                            break;
                        case ("year"):
                            cd3.year = Convert.ToInt32(value);
                            Console.WriteLine("Year: {0}", cd3.year.ToString());
                            Console.WriteLine("Year: {0}", value);
                            break;
                        case ("artist"):
                            cd3.artist = value;
                            Console.WriteLine("Artist: {0}", cd3.artist);
                            Console.WriteLine("Artist: {0}", value);
                            break;
                        case ("genre"):
                            cd3.genre = value;
                            Console.WriteLine("Genre: {0}", cd3.genre);
                            Console.WriteLine("Genre: {0}", value);
                            break;
                        default:
                            throw new ArgumentException("ERROR: XElement {0} not expected", name);
                            break;
                    }
                }
            }

            ArrayList CDobjects = new ArrayList();
            CDobjects.Add(cd1);
            CDobjects.Add(cd2);
            CDobjects.Add(cd3);

            CD.PrintCDsContent(CDobjects);


            ///////////// STRANGE ATTEMPTS!!!!!!!
            //IEnumerable<XElement> oneCDXmlData = cdXmlData.Element("cd").Descendants();
            IEnumerable<XElement> oneCDXmlData = cdXmlData.Elements("cd");

            Console.WriteLine(cdXmlData.Elements("cd"));

            foreach (XElement el in oneCDXmlData)
            {
                Console.WriteLine("{0}: {1}", el.Name.ToString(), el.Value);
            }

            cd1.GetCDInfo(oneCDXmlData);

            Console.WriteLine(cd1.artist);


            // Print data into the console
            //collection.PrintWholeCollectionToConsole();


        }




    }
}
