using BlogProject.DAL.ORM.Entity;
using BlogProject.UI.Areas.Admin.Models.DTO;
using BlogProject.UI.Areas.Admin.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.UI.Areas.Admin.Controllers
{
    public class ArticleController : BaseController
    {
        
        public ActionResult ArticleList()
        {
            List<Article> model = service.ArticleService.GetActive();
            return View(model);
        }

        public ActionResult Add()
        {
            ArticleVM model = new ArticleVM()
            {
                Categories = service.CategoryService.GetActive(),
                AppUsers=service.AppUserService.GetActive(),

            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Article article)
        {
            service.ArticleService.Add(article);
            return Redirect("/Admin/Article/ArticleList");
        }

        public ActionResult UpdateArticle(Guid id)
        {
            Article article = service.ArticleService.GetById(id);
            ArticleUpdateVM model = new ArticleUpdateVM();

            //ArticleDTO model = new ArticleDTO();
            model.Articles.ID = article.ID;
            model.Articles.Header = article.Header;
            model.Articles.SubTitle = article.SubTitle;
            model.Articles.Content = article.Content;
            model.Articles.PublishDate = DateTime.Now;

            List<Category> Categories = service.CategoryService.GetActive();
            model.Categories = Categories;

            List<AppUser> AppUsers = service.AppUserService.GetActive();
            model.AppUsers = AppUsers;


            return View(model);

        }
        [HttpPost]
        public ActionResult UpdateArticle(ArticleDTO model)
        {
            Article article = service.ArticleService.GetById(model.ID);
            article.Header = model.Header;
            article.SubTitle = model.SubTitle;
            article.Content = model.Content;
            article.AppUserID = model.AppUserID;
            article.CategoryID = model.CategoryID;
            article.PublishDate = model.PublishDate;
            service.ArticleService.Save();
            return Redirect("/Admin/Article/ArticleList");

        }

        public ActionResult Delete(Guid id)
        {
            service.ArticleService.Remove(id);
            return Redirect("/Admin/Article/ArticleList");
        }

    }
}