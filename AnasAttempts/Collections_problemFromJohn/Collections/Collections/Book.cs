using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Collections
{
    class Book 
    {
        private XDocument mXml;

        public Book(XDocument xmlData)
        {
            mXml = xmlData;
        }
    }
}
