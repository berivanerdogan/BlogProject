
using BlogProject.DAL.ORM.Entity;
using BlogProject.UI.Areas.Admin.Models.DTO;
using BlogProject.UI.Areas.Author.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.UI.Areas.Author.Controllers
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
                AppUsers = service.AppUserService.GetActive(),
                
            };           
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(Article article)
        {            
            service.ArticleService.Add(article);
            return Redirect("/Author/Article/ArticleList");
        }

        public ActionResult UpdateArticle(Guid id)
        {
            Article article = service.ArticleService.GetById(id);
            ArticleVM model = new ArticleVM();
            model.Articles.ID = article.ID;
            model.Articles.Header = article.Header;
            model.Articles.Subtitle = article.SubTitle;
            model.Articles.Content = article.Content;
            model.Articles.PublishDate = DateTime.Now;

            List<AppUser> AppUsers = service.AppUserService.GetActive();
            model.AppUsers = AppUsers;

            List<Category> Categories = service.CategoryService.GetActive();
            model.Categories = Categories;
            return View(model);


        }

        [HttpPost]
        public ActionResult UpdateArticle(ArticleDTO model)
        {
            if (ModelState.IsValid)
            {
                //service.ArticleService.Update(model);
                Article article = service.ArticleService.GetById(model.ID);
                article.Header = model.Header;
                article.Content = model.Content;
                article.SubTitle = model.SubTitle;
                article.PublishDate = DateTime.Now;
                article.CategoryID = model.CategoryID;
                article.UpdateDate = DateTime.Now;
                article.Status = BlogProject.DAL.ORM.Enum.Status.Modified;
                service.ArticleService.Save(); 
                return Redirect("/Author/Article/ArticleList");
            }
            else
            {
                return Redirect("/Author/Article/ArticleList");
            }
        }

        public ActionResult Delete(Guid id)
        {
            
              
                    service.ArticleService.Remove(id);
                    return Redirect("/Author/Article/ArticleList");
     
        }
    }
}