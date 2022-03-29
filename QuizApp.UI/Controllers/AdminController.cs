using HtmlAgilityPack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Dto.article;
using System.Collections.Generic;

namespace QuizApp.UI.Controllers
{
   // [Authorize]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {

            var articles = new List<ArticleDto>();

            var html = @"https://www.wired.com";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);

            //var node = htmlDoc.DocumentNode.SelectNodes("//body/div/div/main/div/div/section/div/div/div/div/div/div/div/a/h2");

            var nodeLinks = htmlDoc.DocumentNode.SelectNodes("//body/div/div/main/div/div/section/div/div/div/div/div/div/div/a[contains(@class,'SummaryItemHedLink-cgPsOZ cnoEIb summary-item-tracking__hed-link summary-item__hed-link')]");

            foreach (var nodeLink in nodeLinks)
            {
                var webLink = $"{html}{nodeLink.GetAttributeValue("href", string.Empty)}";
                var htmlD = web.Load(webLink);
                var  titleNode = htmlD.DocumentNode.SelectSingleNode("//body/div/div/main/article/div/header/div/div/h1");
                var title = titleNode.InnerText;




                var article = new ArticleDto
                {
                    Title = title,
                    Paragraph =""
                };
                articles.Add(article);

            }

            // var aa = node2[0].GetAttributeValue("href", string.Empty);

            //var articles = new List<ArticleDto>();

            //foreach (var item in node)
            //{
            //    var article = new ArticleDto
            //    {
            //        Title = item.InnerHtml
            //    };

            //    articles.Add(article);
            //}

            return View(articles);

        }
    }

}
