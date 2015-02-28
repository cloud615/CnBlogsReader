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

                //保存到文件: client.SaveAsFile(fileName);
                Uri uri = new Uri(href); 
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
