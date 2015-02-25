using CnBlogsReader.DataModel.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CnBlogsReader.DataModel.ContentModel
{
    [XmlRoot("entry")]
    public class Blogger
    {
        [XmlElement("id")]
        public string ID { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("updated")]
        public string UpdateTimeString { get; set; }

        [XmlElement("link", typeof(Link))]
        public Link Link { get; set; }

        [XmlElement("blogapp")]
        public string BlogApp { get; set; }

        [XmlElement("avatar")]
        public string Avatar { get; set; }

        [XmlElement("postcount")]
        public string PostCount { get; set; }

        [XmlIgnore]
        public DateTime UpdateTime
        {
            get { return Functions.ParseDateTime(this.UpdateTimeString); }
        }
    }



    //[XmlRoot("entry")]
    //public class Blogger : INotifyPropertyChanged
    //{
    //    private string id;

    //    [XmlElement("id")]
    //    public string Id
    //    {
    //        get { return id; }
    //        set { id = value; OnPropertyChanged("Id"); }
    //    }
    //    private string title;

    //    [XmlElement("title")]
    //    public string Title
    //    {
    //        get { return title; }
    //        set { title = value; OnPropertyChanged("title"); }
    //    }

    //    private string updateTimeString;
    //    [XmlElement("updated")]
    //    public string UpdateTimeString
    //    {
    //        get { return updateTimeString; }
    //        set { updateTimeString = value; OnPropertyChanged("UpdateTimeString"); }
    //    }

    //    private Link link;
    //    [XmlElement("link", typeof(Link))]
    //    public Link Link
    //    {
    //        get { return link; }
    //        set { link = value; OnPropertyChanged("Link"); }
    //    }

    //    private string blogApp;
    //    [XmlElement("blogapp")]
    //    public string BlogApp
    //    {
    //        get { return blogApp; }
    //        set { blogApp = value; OnPropertyChanged("BlogApp"); }
    //    }

    //    private string avatar;
    //    [XmlElement("avatar")]
    //    public string Avatar
    //    {
    //        get { return avatar; }
    //        set { avatar = value; OnPropertyChanged("Avatar"); }
    //    }

    //    private string postCount;
    //    [XmlElement("postcount")]
    //    public string PostCount
    //    {
    //        get { return postCount; }
    //        set { postCount = value; OnPropertyChanged("PostCount"); }
    //    }

    //    [XmlIgnore]
    //    public DateTime UpdateTime
    //    {
    //        get { return Functions.ParseDateTime(this.UpdateTimeString); }
    //    }

    //    #region INotifyPropertyChanged Members（实现INotifyPropertyChanged接口 的方法）

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    private void OnPropertyChanged(string propertyName)
    //    {
    //        PropertyChangedEventHandler handler = this.PropertyChanged;
    //        if (handler != null)
    //        {
    //            handler(this, new PropertyChangedEventArgs(propertyName));
    //        }
    //    }

    //    #endregion
  //  }


}
