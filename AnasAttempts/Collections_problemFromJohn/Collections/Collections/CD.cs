using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Collections
{
    enum CDfields {artist, genre, album, year}  ///// STILL NOT WORKING!!!

    class CD 
    {
        

        private string mArtist, mAlbum, mGenre;
        private int mYear;

        public string artist
        {
            get { return this.mArtist; }
            set { this.mArtist = artist; }
        }

        public string album
        {
            get { return this.mAlbum; }
            set { this.mAlbum = album; }
        }

        public string genre
        {
            get { return this.mGenre; }
            set { this.mGenre = genre; }
        }
        public int year
        {
            get { return this.mYear; }
            set { this.mYear = year; }
        }

        /// <summary>
        /// Extract the data of one CD from XML data. 
        /// </summary>
        /// <param name="oneCDXmlData">The XML data of ONE cd only.</Xelement></param>
        /// <returns></returns>
        public void GetCDInfo(IEnumerable<XElement> oneCDXmlData)
        {

            foreach (XElement el in oneCDXmlData)
            {
                string name = el.Name.ToString();
                string value = el.Value;


                switch (name)
                {
                    case ("album"):
                        this.mAlbum = value;
                        Console.WriteLine( "Album: {0}", value);
                        break;
                    case ("year"):
                        this.mYear = Convert.ToInt32(value);
                        Console.WriteLine("Year: {0}", value);
                        break;
                    case ("artist"):
                        this.mArtist = value;
                        Console.WriteLine("Artist: {0}", value);
                        break;
                    case ("genre"):
                        this.mGenre = value;
                        Console.WriteLine("Genre: {0}", value);
                        break;
                    default:
                        throw new ArgumentException("ERROR: XElement {0} not expected", name);
                        break;

                }
            } // end foreach XElement in oneCDXmlData

        } // end GetCDInfo

        // THINK MORE ON WHAT TO DO HERE....
        
        // should I start creating specific functions as
        public void GetAllAlbumsInCollection()
        {
            throw new NotImplementedException();
        }

        public string GetAlbumInfoInCollection(string albumTitle, bool withArtist=false, bool withYear=false)
        {
            throw new NotImplementedException();
        }

        public bool DoesAlbumExistInCollection(string albumTitle)
        {
            return checkIfItemExistsInCollection(albumTitle);
        }

        public bool DoesArtistExistInCollection(string artistName)
        {
            return checkIfItemExistsInCollection(artistName);
        }

        private bool checkIfItemExistsInCollection(string item)
        {
            throw new NotImplementedException();
        }


        public static void PrintCDsContent(ArrayList CDobjects)
        {
            //Is it enough to read each element entry in order and print it to screen with the Name and Value?! 
            // With the same approach as what I did in the collections function?!
            Console.WriteLine("The CD collection in database is:"); 
            Console.WriteLine("Artist \t Album \t year \t Genre ");
            foreach (CD cd in CDobjects)
            {
                Console.WriteLine("{0} \t {1} \t {2} \t {3} ", cd.artist, cd.album, cd.year, cd.genre);
            }

            

            //Console.WriteLine(mXml.Elements("cds").Elements("artist").Elements("genre"));   //rubbish out!!!

            /*
            XNode newNode = mXml.NextNode;

            Console.WriteLine(" ");

            //check if xml tree is not empty
            if (mXml.HasElements)
            {
                foreach (XElement element in mXml.Elements())
                {
                    string name0 = element.Name.ToString();
                    
                    if (name0 == "cds" && element.HasElements)
                    {
                        foreach (XElement subElement in element.Elements())
                        {
                            string name1 = subElement.Name.ToString();
                            string value1 = subElement.Value.ToString();
                            if (subElement.HasElements)
                            {
                                foreach (XElement subSubElement in subElement.Elements())
                                {
                                    string name2 = subSubElement.Name.ToString();
                                    string value2 = subSubElement.Value.ToString();
                                    if (subSubElement.HasElements)
                                    {
                                        foreach (XElement bottomElement in subSubElement.Elements())
                                            //assuming a 4 layer tree
                                        {
                                            string name3 = bottomElement.Name.ToString();
                                            string value3 = bottomElement.Value.ToString();

                                            if (!bottomElement.HasElements)
                                            {
                                                Console.WriteLine("{0}: {1}, {2}: {3}, {4}, {5} ", name1, value1, name2,
                                                                  value2, name3, value3);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("{0}: {1}, {2}: {3}, {4}, {5} ", name1, value1, name2,
                                                                   value2);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("{0}: {1}, {2}: {3}, {4}, {5} ", name1, value1);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0}: {1}", name0);
                    }
                    //Console.WriteLine("\t {0} \t\t {1}", element.Name, element.Value);
                }
            } /**/
        }

    }
}
