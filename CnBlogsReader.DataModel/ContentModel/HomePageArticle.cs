using System;
using System.Collections.Generic;
using System.Text;

namespace CnBlogsReader.DataModel.ContentModel
{
    /// <summary>
    /// 首页文章实体 
    /// </summary>
    public class HomePageArticle
    {
        public string ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 文章链接
        /// </summary>
        public string ArticleLink { get; set; }
        /// <summary>
        /// 作者姓名
        /// </summary>
        public string AuthorName { get; set; }
        /// <summary>
        /// 文章摘要
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string AuthorAvatar { get; set; }
        /// <summary>
        /// 作者主页链接
        /// </summary>
        public string AuthorHomePageLink { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string Published { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public string Updated { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BlogApp { get; set; }
        /// <summary>
        /// 推荐次数
        /// </summary>
        public string Diggs { get; set; }
        /// <summary>
        /// 阅读次数
        /// </summary>
        public string Views { get; set; }
        /// <summary>
        /// 评论次数
        /// </summary>
        public string Comments { get; set; }
    }
}
