using CnBlogsReader.DataModel.ContentModel;
using CnBlogsReader.HttpHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Windows.UI.Xaml;

namespace CnBlogsReader.ViewModel
{
    public class SiteHomeFeedViewModel : INotifyPropertyChanged
    {
        public SiteHomeFeedViewModel()
        {
            Initialize();
        }

        private async void Initialize()
        {
            HomePageViewModel homePageDao = new HomePageViewModel();
            RequestHelper requestHelper = new RequestHelper();
            var responseString = await requestHelper.HttpGet("http://wcf.open.cnblogs.com/blog/sitehome/paged/1/10");

            SiteHomeFeed = XmlHelper.GetFeed<Feed<Blogger>>(responseString);
        }

        private Feed<Blogger> _siteHomeFeed;
        public Feed<Blogger> SiteHomeFeed
        {
            get { return _siteHomeFeed; }
            private set
            {
                _siteHomeFeed = value; OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
