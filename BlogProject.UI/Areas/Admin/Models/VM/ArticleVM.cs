using BlogProject.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.UI.Areas.Admin.Models.VM
{
    public class ArticleVM
    {
        public ArticleVM()
        {
            Categories = new List<Category>();
            AppUsers = new List<AppUser>();
            
        }

        public List<Category> Categories { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}