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


        /// <summary>
        /// Constructor that requires the initialization of every field that characterizes a CD.
        /// </summary>
        /// <param name="pArtist">Artist must not be null. </param>
        /// <param name="pAlbum">Ablum must not be null. </param>
        /// <param name="pGenre">Genre must not be null. </param>
        /// <param name="pYear">Year must be between year 1000 and current year. </param>
        public CD(string pArtist, string pAlbum, string pGenre, int pYear)
        {
            mArtist = pArtist;
            mAlbum = pAlbum;
            mGenre = pGenre;

            if (pYear < 1000 || pYear > DateTime.Now.Year)
            {
                throw new ArgumentOutOfRangeException("WARNING: year parameter is not within expected limits.");
            }
            mYear = pYear;
        }


        public string artist
        {
            get { return this.mArtist; }
            set { this.mArtist = value; }
        }

        public string album
        {
            get { return this.mAlbum; }
            set { this.mAlbum = value; }
        }

        public string genre
        {
            get { return this.mGenre; }
            set { this.mGenre = value; }
        }
        public int year
        {
            get { return this.mYear; }
            set { this.mYear = value; }
        }
        

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

        /// <summary>
        /// Prints a list of all the CD present in the list
        /// </summary>
        /// <param name="cds">List of CDs. Must not be empty.</param>
        public static void PrintCDsContent(List<CD> cds)
        {
            if (cds.Count < 0) throw new ArgumentException("CD list is empty.");

            //Is it enough to read each element entry in order and print it to screen with the Name and Value?! 
            // With the same approach as what I did in the collections function?!
            Console.WriteLine("\tThe CD collection in database is:");
            Console.WriteLine("===========================================================");
            Console.WriteLine(" Artist \t Album \t year \t Genre ");
            Console.WriteLine("===========================================================");
            foreach (CD cd in cds)
            {
                Console.WriteLine(" {0} \t {1} \t {2} \t {3} ", cd.artist, cd.album, cd.year, cd.genre);
            }
        }

    }
}
