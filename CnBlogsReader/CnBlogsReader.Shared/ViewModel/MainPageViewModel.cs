using CnBlogsReader.Commom;
using CnBlogsReader.DataModel.Common;
using CnBlogsReader.DataModel.ContentModel;
using CnBlogsReader.HttpHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnBlogsReader.ViewModel
{
    public class MainPageViewModel 
    {
        public MainPageViewModel()
        {
            // 取出首页数据
            Initializer();
        }

        private async void Initializer()
        {
            RequestHelper requestHelper = new RequestHelper();
            var requestURL = ConfigurationArgument.RequestURLMainPage.Replace("{pageIndex}", "1").Replace("{pageSize}", "10");

            if (MainPageDataContent == null)
            {
                MainPageDataContent = new ObservableCollection<Blogger>();
            }
            var responseString = await requestHelper.HttpGet(requestURL);

            var entries = XmlHelper.GetFeed<Feed<Blogger>>(responseString).Entries;

            foreach (var entry in entries)
            {
                this.MainPageDataContent.Add(entry);
            }
        }
        public ObservableCollection<Blogger> MainPageDataContent { get; set; }

        //private ObservableCollection<Blogger> _mainPageDataContent;
        //public ObservableCollection<Blogger> MainPageDataContent
        //{
        //    get
        //    {
        //        if (_mainPageDataContent == null)
        //        {
        //            _mainPageDataContent = new ObservableCollection<Blogger>();                   
        //        }
        //        return _mainPageDataContent;
        //    }
        //    set
        //    {
        //        if (_mainPageDataContent == null)
        //        {
        //            _mainPageDataContent = new ObservableCollection<Blogger>();                    
        //        }
        //        _mainPageDataContent = value;
        //       // OnPropertyChanged("MainPageDataContent");
        //        //if (_mainPageDataContent.Entries.Count > 30)
        //        //{
        //        //    _mainPageDataContent = value;
        //        //}
        //        //else
        //        //{
        //        //    foreach (var item in value.Entries)
        //        //    {
        //        //        _mainPageDataContent.Entries.Add(item);
        //        //    }
        //        //}
        //    }
        //}


    }
}
