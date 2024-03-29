﻿using BlogProject.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.ORM.Map
{
    public class CommentMap:BaseMap<Comment>
    {
        public CommentMap()
        {
            ToTable("dbo.Comments");
            Property(x => x.Content).IsOptional();
            Property(x => x.Header).IsOptional();


            //HasKey(x => new { x.AppUserID, x.ArticleID });
            HasRequired(x => x.AppUser).WithMany(x => x.Comments)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Article).WithMany(x => x.Comments)
                .HasForeignKey(x => x.ArticleID)
                .WillCascadeOnDelete(false);
        }
    }
}
