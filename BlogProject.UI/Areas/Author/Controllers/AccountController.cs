﻿using BlogProject.DAL.ORM.Entity;
using BlogProject.UI.Areas.Admin.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogProject.UI.Areas.Author.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Author/Account
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser user = service.AppUserService.FindByUserName(HttpContext.User.Identity.Name);
                if (user.Role==BlogProject.DAL.ORM.Enum.Role.Author)
                {
                    TempData["class"] = "custom-hide";
                    return RedirectToAction("AuthorHomeIndex", "Home");
                }
                else if (user.Role==BlogProject.DAL.ORM.Enum.Role.Admin)
                {
                    return Redirect("/Admin/Home/AdminHomeIndex");
                }
                else if (user.Role==BlogProject.DAL.ORM.Enum.Role.Editör)
                {
                    return Redirect("/Editör/Home/EditörHomeIndex");
                }
                else
                {
                    return Redirect("/Member/Home/MemberHomeIndex");
                }
                
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM credential)
        {
            if (ModelState.IsValid)
            {
                if (service.AppUserService.CheckCredential(credential.UserName,credential.Password))
                {
                    AppUser user = service.AppUserService.FindByUserName(credential.UserName);
                    string cookie = user.UserName;
                    FormsAuthentication.SetAuthCookie(cookie, true);
                    if (user.Role==BlogProject.DAL.ORM.Enum.Role.Author)
                    {
                        return RedirectToAction("AuthorHomeIndex", "Home");
                    }
                    else if (user.Role==BlogProject.DAL.ORM.Enum.Role.Admin)
                    {
                       
                        return Redirect("/Admin/Home/AdminHomeIndex");
                    }
                    else if (user.Role==BlogProject.DAL.ORM.Enum.Role.Editör)
                    {
                        return Redirect("/Editör/Home/EditörHomeIndex");
                    }
                    else
                    {
                        return Redirect("/Member/Home/MemberHomeIndex");
                    }
                  

                }
                else
                {
                    ViewData["error"] = "Username or Password is wrong";
                    return View();
                }


            }
            TempData["class"] = "custom-show";
            return View();
        }
        public ActionResult LoginOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("AuthorHomeIndex", "Home");
        }

    }
}