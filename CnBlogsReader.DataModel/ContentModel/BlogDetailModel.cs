using CnBlogsReader.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CnBlogsReader.DataModel.ContentModel
{
    [XmlRoot("string")]
    public class BlogDetailModel : NotifyPropertyBase
    {
        private string detail;
        [XmlText]
        public string Detail
        {
            get { return detail; }
            set
            {
                detail = value;
                OnPropertyChanged("Detail");
            }
        }
    }

}
