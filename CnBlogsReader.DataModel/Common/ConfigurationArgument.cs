using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnBlogsReader.DataModel.Common
{
    public static class ConfigurationArgument
    {
        public static readonly string RequestURLMainPage = "http://wcf.open.cnblogs.com/blog/sitehome/paged/{pageIndex}/{pageSize}";
        public static readonly string RequestURLBlogDetail = "http://wcf.open.cnblogs.com/blog/post/body/{POSTID} ";
    }
}
