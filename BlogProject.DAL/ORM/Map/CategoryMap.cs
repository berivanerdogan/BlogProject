﻿using BlogProject.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.ORM.Map
{
   public  class CategoryMap:BaseMap<Category>
    {
        public CategoryMap()
        {
            ToTable("dbo.Categories");
            Property(x => x.CategoryName).IsRequired();
            Property(x => x.Description).IsOptional();

            //HasMany(x => x.Articles).WithRequired(x => x.Category)
            //    .HasForeignKey(x => x.CategoryID)
            //    .WillCascadeOnDelete(false);
        }
    }
}
