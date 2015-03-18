using CnBlogsReader.DataModel.ContentModel;
using CnBlogsReader.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// “用户控件”项模板在 http://go.microsoft.com/fwlink/?LinkId=234236 上提供

namespace CnBlogsReader.WindowsPhoneControls
{
    public sealed partial class BlogsListControl : UserControl
    {
        public BlogsListControl()
        {
            this.InitializeComponent();

        }



        public System.Collections.ObjectModel.ObservableCollection<Blogger> BlogListSource
        {
            get { return (ObservableCollection<Blogger>)GetValue(BlogListSourceProperty); }
            set { SetValue(BlogListSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BlogListSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BlogListSourceProperty =
            DependencyProperty.Register("BlogListSource", typeof(System.Collections.ObjectModel.ObservableCollection<Blogger>), typeof(BlogsListControl), new PropertyMetadata(new ObservableCollection<Blogger>()));

        private void feedListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = e.AddedItems;
            if (list.Count > 0)
            {
                Blogger item = list[0] as Blogger;
                if (item != null)
                {
                    var contenHref = item.ID;
                    Frame rootFrame = Window.Current.Content as Frame;
                    rootFrame.Navigate(typeof(BlogDeatil), contenHref);
                }
            }

        }


    }
}
