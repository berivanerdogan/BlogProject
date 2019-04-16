using BlogProject.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.UI.Areas.Author.Controllers
{
    public class HomeController : BaseController
    {
        
        public ActionResult AuthorHomeIndex()
        {
            TempData["class"] = "custom-hide";
            var model = service.ArticleService.GetActive().OrderBy(x => x.AddDate).Take(5);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return View(model);
            }
            AppUser user = service.AppUserService.FindByUserName(HttpContext.User.Identity.Name);
            if (user.Role==BlogProject.DAL.ORM.Enum.Role.Author)
            {
                TempData["class"] = "custom-show";
            }
            return View(model);
        
        }
    }
}