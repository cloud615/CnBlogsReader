using CnBlogsReader.Commom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CnBlogsReader.DataModel.ContentModel
{
    [XmlRoot("feed", Namespace = "http://www.w3.org/2005/Atom")]
    public class Feed<T> where T : class
    {
        private string id;

        [XmlElement("id")]
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        private string title;

        [XmlElement("title")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private ObservableCollection<T> entries;

        [XmlElement("entry")]
        public ObservableCollection<T> Entries
        {
            get
            {
                if (entries == null)
                {
                    entries = new ObservableCollection<T>();
                }
                return entries;
            }
            set
            {
                if (entries == null)
                {
                    entries = new ObservableCollection<T>();
                }
                entries = value;
            }
        }


        //private List<T> entries;

        //[XmlElement("entry")]
        //public List<T> Entries
        //{
        //    get { return entries; }
        //    set
        //    {
        //        entries = value;
        //        OnPropertyChanged("Entries");
        //    }
        //}



    }
}
