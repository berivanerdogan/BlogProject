﻿using BlogProject.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.UI.Areas.Member.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult MemberHomeIndex()
        {
            TempData["class"] = "custom-hide";
            var model = service.ArticleService.GetActive().OrderBy(x => x.AddDate).Take(5);

            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return View(model);
            }

            AppUser user = new AppUser();
            user = service.AppUserService.FindByUserName(HttpContext.User.Identity.Name);
            if (user.Role == BlogProject.DAL.ORM.Enum.Role.Member)
            {
                TempData["class"] = "custom-show";
                return Redirect("/Author/Article/ArticleList");
            }
            return View(model);
        }

        public  ActionResult ArticleList()
        {
            List<Article> model = service.ArticleService.GetActive();
            return View(model);

        }
    }
}