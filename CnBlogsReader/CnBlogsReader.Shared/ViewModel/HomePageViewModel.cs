using CnBlogsReader.DataModel;
using CnBlogsReader.DataModel.ContentModel;
using CnBlogsReader.DataModel.MenuModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace CnBlogsReader.ViewModel
{
    /// <summary>
    /// 获取首页需要的数据
    /// </summary>
    public class HomePageViewModel
    {
        public List<FirstMenu> GetFirstMenuList(string responseString)
        {
            Regex regex = new Regex("<div id=\"nav_menu\">(.*?)</div>", RegexOptions.IgnoreCase);
            if (regex.IsMatch(responseString))
            {
                Match match = regex.Match(responseString);
                regex = new Regex("<a href=\"([^\"]*?)\">(.*?)</a>", RegexOptions.IgnoreCase);
                if (regex.IsMatch(match.Groups[1].Value))
                {
                    MatchCollection matchAlinkColl = regex.Matches(match.Groups[1].Value);
                    List<FirstMenu> list = new List<FirstMenu>();
                    foreach (Match item in matchAlinkColl)
                    {
                        FirstMenu model = new FirstMenu();
                        model.Link = item.Groups[1].Value;
                        model.Name = item.Groups[2].Value;
                        list.Add(model);
                    }
                    return list;
                }
            }
            return null;
        }
        /// <summary>
        /// 获取首页文章列表实体集合
        /// </summary>
        /// <param name="responseString"></param>
        /// <returns></returns>
        public Feed<Blogger> GetFeed(string responseString)
        {
            Feed<Blogger>  result=new Feed<Blogger>();
            XmlSerializer xmlSeriailzer = new XmlSerializer(typeof(Feed<Blogger>));
            using (var reader = new StringReader(responseString))
            {
                result = (Feed<Blogger>)xmlSeriailzer.Deserialize(reader);
            }
            return result;

            //List<HomePageArticle> list = new List<HomePageArticle>();
            //try
            //{
            //    XDocument xdoc = XDocument.Parse(responseString);
            //    var root = xdoc.Root;

            //    //List<HomePageArticle> sss = (from el in root.Elements()
            //    //                             where el.Name.LocalName == "entry"
            //    //                             select new HomePageArticle()
            //    //                             {
            //    //                                 ID = el.Element("id").Value,
            //    //                                 Title = el.Element("title").Value,
            //    //                                 Summary = el.Element("summary").Value,
            //    //                                 Published = el.Element("published").Value,
            //    //                                 Updated = el.Element("updated").Value,
            //    //                                 AuthorName = el.Element("name").Value
            //    //                             }).ToList();


            //    var entrys = root.Elements("entry");


            //    foreach (var entry in entrys)
            //    {
            //        HomePageArticle model = new HomePageArticle();
            //        model.ID = entry.Element("id").Value;
            //        model.Title = entry.Element("title").Value;
            //        model.Summary = entry.Element("summary").Value;
            //        model.Published = entry.Element("published").Value;
            //        model.Updated = entry.Element("updated").Value;
            //        model.AuthorName = entry.Element("name").Value;
            //        model.AuthorHomePageLink = entry.Element("uri").Value;
            //        model.AuthorAvatar = entry.Element("avatar").Value;
            //        model.ArticleLink = entry.Element("link ").Value;
            //        model.BlogApp = entry.Element("blogapp ").Value;
            //        model.Diggs = entry.Element("diggs ").Value;
            //        model.Views = entry.Element("views ").Value;
            //        model.Comments = entry.Element("comments ").Value;

            //        list.Add(model);
            //    }
            //}
            //catch (Exception)
            //{
            //}
           // return list;
        }

    }
}
