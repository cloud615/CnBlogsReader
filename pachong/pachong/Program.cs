using HttpHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pachong
{
    class Program
    {
        static void Main(string[] args)
        {
            RequestDao request = new RequestDao();
            var param = "CategoryId:808&CategoryType:'SiteHome'&ItemListActionName:'PostList'&PageIndex:2&ParentCategoryId:0";
           // string httpResponse = request.HttpPost("http://www.cnblogs.com", param);
            string httpResponse = request.HttpGet("http://www.cnblogs.com/sitehome/p/2", "");
            //Console.WriteLine(httpResult);

            CatchDao catchDao = new CatchDao();
            //var result=catchDao.CatchHomePage_MenuList(httpResponse);

            //var result = catchDao.CatchHomePage_ConcentList(httpResponse);
            //if (result != null && result.Count > 0)
            //{
            //    var author0 = result[0];
            //    var secondResponse = request.HttpGet(author0.ContentLink, "");
            //    Console.WriteLine(secondResponse);
            //}
            //else
            //{
            //    Console.WriteLine("爬取异常");
            //}

            //var result = catchDao.CatchHomePage_FirstMenuList(httpResponse);

            var result = catchDao.CatchHomePage_SecondMenuList(httpResponse);

            Console.ReadKey();
        }


        private void PostReq()
        {
            
            //CategoryId: 808
            //CategoryType: "SiteHome"
            //ItemListActionName: "PostList"
            //PageIndex: 2
            //ParentCategoryId: 0
            //Response Headersview source

        }
    }
}
