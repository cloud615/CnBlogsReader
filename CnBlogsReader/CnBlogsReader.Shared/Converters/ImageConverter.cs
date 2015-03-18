using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace CnBlogsReader.Converters
{

    public class ImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string href = System.Convert.ToString(value);
            try
            {
                Uri uri = null;
                if (!string.IsNullOrWhiteSpace(href))
                {
                    //保存到文件: client.SaveAsFile(fileName);
                    uri = new Uri(href);
                }
                else
                {
                    uri = new Uri("ms-appx:///Assets/Logo.100.Blue.png");
                }
                BitmapImage bitmapImage = new BitmapImage(uri);
                return bitmapImage;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
