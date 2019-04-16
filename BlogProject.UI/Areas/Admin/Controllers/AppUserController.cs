using BlogProject.DAL.ORM.Entity;
using BlogProject.UI.Areas.Admin.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.UI.Areas.Admin.Controllers
{
    public class AppUserController : BaseController
    {
        public ActionResult AppUserList()
        {
            List<AppUser> model = service.AppUserService.GetActive();

            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AppUser user)
        {
            service.AppUserService.Add(user);
            return Redirect("/Admin/AppUser/AppUserList");
        }

        public ActionResult UpdateAppUser(Guid id)
        {
            AppUser user = service.AppUserService.GetById(id);
            AppUserDTO model = new AppUserDTO();
            model.ID = user.ID;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;
            model.UserName = user.UserName;
            model.Password = user.Password;
            model.Role = user.Role;
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateAppUser(AppUser model)
        {
            if (ModelState.IsValid)
            {
                
                service.AppUserService.Update(model);
                return Redirect("/Admin/AppUser/AppUserList");
            }
            else
            {
                return Redirect("/Admin/AppUser/AppUserList");
            }
        }

        public ActionResult Delete(Guid id)
        {      
                service.AppUserService.Remove(id);
                return Redirect("/Admin/AppUser/AppUserList");         
        }
    }
}