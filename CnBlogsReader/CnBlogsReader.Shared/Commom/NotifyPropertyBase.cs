using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CnBlogsReader.Commom
{
    public class NotifyPropertyBase : INotifyPropertyChanged
    {
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
