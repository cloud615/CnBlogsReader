using CnBlogsReader.DataModel;
using CnBlogsReader.DataModel.ContentModel;
using CnBlogsReader.HttpHelper;
using CnBlogsReader.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace CnBlogsReader
{
    /// <summary>
    /// 可独立使用或用于导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            Initialize();   
        }


        public void Initialize()
        {
            this.ViewModel = new MainPageViewModel();
        }

        public MainPageViewModel ViewModel
        {
            get { return this.DataContext as MainPageViewModel; }
            set { this.DataContext = value; }
        }

       


        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。
        /// 此参数通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: 准备此处显示的页面。

            // TODO: 如果您的应用程序包含多个页面，请确保
            // 通过注册以下事件来处理硬件“后退”按钮:
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed 事件。
            // 如果使用由某些模板提供的 NavigationHelper，
            // 则系统会为您处理该事件。
        }
        private void InitHomeList()
        {
            HomePageViewModel homePageDao = new HomePageViewModel();

            RequestHelper httpHelper = new RequestHelper();
            // var responseString = await httpHelper.HttpGet("http://www.cnblogs.com");          
            // var firstMenuList = homePageDao.GetFirstMenuList(responseString);

            // var responseString = await httpHelper.HttpGet("http://wcf.open.cnblogs.com/blog/sitehome/paged/1/10");
            // var siteHomeFeed = homePageDao.GetFeed(responseString);

            //.......................

            SiteHomeFeedViewModel siteHomeFeedViewModel = new SiteHomeFeedViewModel();

            DataContext = siteHomeFeedViewModel;


        }

        /// <summary>
        /// Hub切换触发该事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeHub_SectionsInViewChanged(object sender, SectionsInViewChangedEventArgs e)
        {

        }

    }
}
