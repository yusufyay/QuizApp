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
            var html = @"https://www.wired.com/";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var node = htmlDoc.DocumentNode.SelectNodes("//body/div/div/main/div/div/section/div/div/div/div/div/div/div/a/h2");

            var articles = new List<ArticleDto>();
            
            foreach (var item in node)
            {
                var article = new ArticleDto
                {
                    Title = item.InnerHtml
                };

                articles.Add(article);
            }

            return View(articles);

        }
    }

}
