using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
//using System.Web.UI.HtmlControls;

namespace HttpHelper
{
    public class CatchDao
    {
        /// <summary>
        /// 获取首页 一级菜单 【园子-新闻-博问-等】
        /// </summary>
        /// <param name="httpResponse"></param>
        /// <returns></returns>
        public List<FirstMenu> CatchHomePage_FirstMenuList(string httpResponse)
        {
            //<div id="nav_menu">(.*?)</div>

            Regex regex = new Regex("<div id=\"nav_menu\">(.*?)</div>", RegexOptions.IgnoreCase);
            if (regex.IsMatch(httpResponse))
            {
                Match match = regex.Match(httpResponse);
                regex = new Regex("<a href=\"([^\"]*?)\">(.*?)</a>", RegexOptions.IgnoreCase);
                if (regex.IsMatch(match.Groups[1].Value))
                {
                    MatchCollection matchAlinkColl = regex.Matches(match.Groups[1].Value);
                    List<FirstMenu> list = new List<FirstMenu>();
                    foreach (Match item in matchAlinkColl)
                    {
                        FirstMenu model = new FirstMenu();
                        model.MenuLink = item.Groups[1].Value;
                        model.MenuName = item.Groups[2].Value;
                        list.Add(model);
                    }
                    return list;
                }
            }
            return null;
        }
        
        /// <summary>
        /// 获取首页 二级菜单 【首页-精华-候选-新闻-关注-我平-我赞】
        /// </summary>
        /// <param name="httpResponse"></param>
        /// <returns></returns>
        public List<SecondMenu> CatchHomePage_SecondMenuList(string httpResponse)
        {
            //<ul class="post_nav_block">(.*?)</ul>
            httpResponse = httpResponse.Replace("\r\n", "");
            Regex regex = new Regex("<ul class=\"post_nav_block\">(.*?)</ul>", RegexOptions.IgnoreCase);
            if (regex.IsMatch(httpResponse))
            {
                Match match = regex.Match(httpResponse);
                regex = new Regex("<a href=\"([^\"]*?)\" [^>]*?>(.*?)</a>", RegexOptions.IgnoreCase);
                if (regex.IsMatch(match.Groups[1].Value))
                {
                    MatchCollection matchAlinkColl = regex.Matches(match.Groups[1].Value);
                    List<SecondMenu> list = new List<SecondMenu>();
                    foreach (Match item in matchAlinkColl)
                    {
                        SecondMenu model = new SecondMenu();
                        model.MenuLink = item.Groups[1].Value;
                        model.MenuName = item.Groups[2].Value;
                        list.Add(model);
                    }
                    return list;
                }
            }
            return null;

        }
        /// <summary>
        /// 获取首页分类菜单列表
        /// </summary>
        /// <param name="httpResponse"></param>
        /// <returns></returns>
        public List<HomePageClassifyMenu> CatchHomePage_ClassifyMenuList(string httpResponse)
        {
            // argHtml = argHtml.Replace("\r\n", "");
            //Regex regex = new Regex("<ul id=\"cate_item\">(.*)</ul>", RegexOptions.IgnoreCase);

            Regex regex = new Regex("<a href=\"([0-9a-z\\-/]+)\">([\\w\\d\\(\\)]+?)</a>", RegexOptions.IgnoreCase);
            if (regex.IsMatch(httpResponse))
            {
                MatchCollection matchs = regex.Matches(httpResponse);
                List<HomePageClassifyMenu> list = new List<HomePageClassifyMenu>();
                foreach (Match item in matchs)
                {
                    HomePageClassifyMenu model = new HomePageClassifyMenu();
                    model.Link = item.Groups[1].Value;
                    model.Name = item.Groups[2].Value;
                    list.Add(model);
                }
                return list;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取首页文章信息列表
        /// </summary>
        /// <param name="httpResponse"></param>
        /// <returns></returns>
        public List<HomePageContent> CatchHomePage_ConcentList(string httpResponse)
        {
            httpResponse = httpResponse.Replace("\r\n", "");
            //Regex regex = new Regex("<div class=\"post_item_body\">\\s*<h3>\\s*<a class=\"titlelnk\" [^>]*>(.*?)</a>\\s*</h3>\\s*<p class=\"post_item_summary\">\\s*<a [^>]*>\\s*<img [^>]*>\\s*</a>(.*?)</p>\\s*<div class=\"post_item_foot\">\\s*<a [^>]*>(.*?)</a>\\s*(.*?)\\s*<span [^>]*>\\s*<a [^>]*>\\s*(.*?)</a>\\s*</span>\\s*<span [^>]*>\\s*<a [^>]*>(.*?)</a>\\s*</span>\\s*</div>\\s*</div>", RegexOptions.IgnoreCase);

            //Regex regex = new Regex("<div class=\"post_item_body\">\\s*<h3>\\s*<a class=\"titlelnk\" [^>]*>(.*?)</a>\\s*</h3>\\s*<p class=\"post_item_summary\">(.*?)\\s*<a [^>]*>(.*?)</a>(.*?)\\s*<span [^>]*>\\s*<a [^>]*>(.*?)</a>\\s*</span>\\s*<span [^>]*>\\s*<a [^>]*>(.*?)</a>\\s*</span>\\s*</div>\\s*</div>", RegexOptions.IgnoreCase);

            Regex regex = new Regex("<div class=\"post_item_body\">\\s*<h3>\\s*<a [^>]* href=\"([^\"]*?)\" [^>]*>(.*?)</a>\\s*</h3>\\s*<p [^>]*>(\\s*.*?)\\s*</p>\\s*<div [^>]*>\\s*<a [^>]*>(.*?)</a>\\s*(.*?)\\s*<span [^>]*><a [^>]*>\\s*(.*?)</a></span><span [^>]*><a [^>]*>(.*?)</a></span></div>", RegexOptions.IgnoreCase);

            if (regex.IsMatch(httpResponse))
            {
                MatchCollection matchs = regex.Matches(httpResponse);
                List<HomePageContent> list = new List<HomePageContent>();
                foreach (Match item in matchs)
                {
                    HomePageContent model = new HomePageContent();
                    model.ContentLink = item.Groups[1].Value;
                    model.Title = item.Groups[2].Value;
                    if (item.Groups[3].Value.Contains("<a"))
                    {
                        // 带有图片
                        //model.AuthorSummary = ;
                        regex = new Regex("<a href=\"([^\"]*)\" [^>]*?><img [^>]*? src=\"([^\"]*)\" [^>]*?></a>(.*)");
                        if (regex.IsMatch(item.Groups[3].Value))
                        {
                            Match matchSummary = regex.Match(item.Groups[3].Value);

                            model.AuthorHomePageLink = matchSummary.Groups[1].Value;
                            model.AuthorPhoto = matchSummary.Groups[2].Value;
                            model.Summary = matchSummary.Groups[3].Value;
                        }
                    }
                    else
                    {
                        model.Summary = item.Groups[3].Value;
                    }
                    //model.ClickCount = item.Groups[4].Value;
                    model.Author = item.Groups[4].Value;
                    model.CreateTime = item.Groups[5].Value;
                    model.ReviewCount = item.Groups[6].Value;
                    model.ReadCounts = item.Groups[7].Value;

                    list.Add(model);
                }
                return list;
            }
            else
            {
                return null;
            }
        }
    }
    /// <summary>
    /// 首页分类列表
    /// </summary>
    public class HomePageClassifyMenu
    {
        public string Name { get; set; }
        public string Link { get; set; }
    }
    /// <summary>
    /// 首页列表  
    /// </summary>
    public class HomePageContent
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 文章链接
        /// </summary>
        public string ContentLink { get; set; }
        /// <summary>
        /// 作者姓名
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 评论次数
        /// </summary>
        public string ReviewCount { get; set; }
        /// <summary>
        /// 阅读次数
        /// </summary>
        public string ReadCounts { get; set; }
        //public string ClickCount { get; set; }
        /// <summary>
        /// 文章摘要
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string AuthorPhoto { get; set; }
        /// <summary>
        /// 作者主页链接
        /// </summary>
        public string AuthorHomePageLink { get; set; }
    }

    public class FirstMenu
    {
        public string MenuName { get; set; }
        public string MenuLink { get; set; }
    }
    public class SecondMenu
    {
        public string MenuName { get; set; }
        public string MenuLink { get; set; }
    }
}
