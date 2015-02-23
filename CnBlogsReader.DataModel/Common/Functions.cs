using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnBlogsReader.DataModel.Common
{
    public static class Functions
    {
        /// <summary>
        /// parse string to datetime,  if fail will return DateTime.MinValue
        /// </summary>
        public static DateTime ParseDateTime(string datetime)
        {
            var date = DateTime.MinValue;

            DateTime.TryParse(datetime, out date);

            return date;
        }
    }
}
