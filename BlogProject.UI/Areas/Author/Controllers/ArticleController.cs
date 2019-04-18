
using BlogProject.DAL.ORM.Entity;
using BlogProject.DAL.ORM.Enum;
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
            Guid userid = service.AppUserService.FindByUserName(User.Identity.Name).ID;
            List<Article> model = service.ArticleService.GetDefault(x => x.AppUserID == userid && (x.Status == Status.Active || x.Status == Status.Modified));
            return View(model);
        }
        
        public ActionResult Add()
        {
            //List<Category> model = service.CategoryService.GetActive();
            return View(service.CategoryService.GetActive());
        }
        [HttpPost]
        public ActionResult Add(Article article)
        {

            AppUser user = service.AppUserService.GetByDefault(x => x.UserName == User.Identity.Name);
            article.AppUserID = user.ID;
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

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser user = service.AppUserService.FindByUserName(HttpContext.User.Identity.Name);
                    //Article articles = service.ArticleService.GetByDefault(x => x.AppUserID == user.ID);
                    if (user.ID == model.AppUserID)
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
                    else
                    {
                        ViewData["Message"] = "You are not authorized to updated this article";
                        return Redirect("/Author/Article/ArticleList");
                    }
            }


            return View();

        }
        public ActionResult Delete(ArticleDTO model)
        {
            service.ArticleService.Remove(model.ID);
            return Redirect("/Author/Article/ArticleList");
        }

        public ActionResult Show(Article article) //Burada Diğer Yazarların da makalelerini görücek
        {
            AppUser user = service.AppUserService.GetByDefault(x => x.UserName == User.Identity.Name);
         
            List<Article> model = service.ArticleService.GetDefault(x=>x.AppUserID!=user.ID);
            return View(model);

        }


    }
}