using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CnBlogsReader.HttpHelper
{
    public static class XmlHelper
    {
        /// <summary>
        /// 获取首页文章列表实体集合
        /// </summary>
        /// <param name="responseString"></param>
        /// <returns></returns>
        public static T GetFeed<T>(string responseString)
        {
            XmlSerializer xmlSeriailzer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(responseString))
            {
                var result = (T)xmlSeriailzer.Deserialize(reader);
                return result;
            }
        }
    }
}
