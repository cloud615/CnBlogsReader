using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CnBlogsReader.DataModel.ContentModel
{
    [XmlRoot("feed", Namespace = "http://www.w3.org/2005/Atom")]
    public class Feed<T> where T : class
    {
        [XmlElement("id")]
        public string ID { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("entry")]
        public List<T> Entries { get; set; }
    }
}
