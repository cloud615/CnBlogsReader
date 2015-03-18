using CnBlogsReader.DataModel.Common;
using CnBlogsReader.DataModel.ContentModel;
using CnBlogsReader.HttpHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CnBlogsReader.ViewModel
{
    public class BlogDetailViewModel : INotifyPropertyChanged
    {
        public BlogDetailViewModel(string blogID)
        {
            //取出博客详细信息
            Initializer(blogID);
        }

        private async void Initializer(string blogID)
        {
            RequestHelper requestHelper = new RequestHelper();
            var requestURL = ConfigurationArgument.RequestURLBlogDetail.Replace("{POSTID}", blogID);

            var responseString = await requestHelper.HttpGet(requestURL);

            //if (BlogDetailModel == null)
            //{
            //    BlogDetailModel = new BlogDetailModel();
            //}
            //BlogDetailModel.Detail = XmlHelper.GetFeed<BlogDetailModel>(responseString).Detail;
            Detail = XmlHelper.GetFeed<BlogDetailModel>(responseString).Detail;
        }
        //public BlogDetailModel BlogDetailModel { get; set; }

        private string detail;

        public string Detail
        {
            get { return detail; }
            set { detail = value;
            OnPropertyChanged("Detail");
            }
        }



        #region INotifyPropertyChanged Members（实现INotifyPropertyChanged接口 的方法）

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion



    }
}
