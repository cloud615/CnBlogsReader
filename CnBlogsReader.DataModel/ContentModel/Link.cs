using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CnBlogsReader.DataModel.ContentModel
{
    [XmlRoot("root")]
    public class Link
    {
        [XmlAttribute("href")]
        public string Href { get; set; }
    }
}
