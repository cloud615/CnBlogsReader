using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CnBlogsReader.DataModel.ContentModel
{
    [XmlRoot("author")]
    public class Author
    {
        /// <summary>
        /// 作者姓名
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }
        /// <summary>
        /// 作者主页链接
        /// </summary>
        [XmlElement("uri")]
        public string Uri { get; set; }
        /// <summary>
        /// 作者头像链接
        /// </summary>
        [XmlElement("avatar")]
        public string Avatar { get; set; }
    }
}
