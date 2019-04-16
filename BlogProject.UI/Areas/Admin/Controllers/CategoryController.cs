using BlogProject.DAL.ORM.Entity;
using BlogProject.UI.Areas.Admin.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.UI.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        public ActionResult CategoryList()
        {
            List<Category> model = service.CategoryService.GetActive();
            return View(model);
        }
        
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category model)
        {
            service.CategoryService.Add(model);
            return Redirect("/Admin/Category/CategoryList");
        }

        public ActionResult CategoryUpdate(Guid id)
        {
            //Category category = service.CategoryService.GetById(id);
            Category category = service.CategoryService.GetById(id);
            CategoryDTO model = new CategoryDTO();
            model.ID = category.ID;
            model.CategoryName = category.CategoryName;
            model.Description = category.Description;
            return View(model);
        }

        [HttpPost]
        public ActionResult CategoryUpdate(CategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                Category category = service.CategoryService.GetById(model.ID);
                category.CategoryName = model.CategoryName;
                category.Description = model.Description;
                category.UpdateDate = DateTime.Now;
                service.CategoryService.Update(category);

                return Redirect("/Admin/Category/CategoryList");
            }
            else
            {
                return Redirect("/Admin/Category/CategoryList");
            }
        }

        public ActionResult Delete(Guid id)
        {
            service.CategoryService.Remove(id);
            return Redirect("/Admin/Category/CategoryList");
        }
    }
}