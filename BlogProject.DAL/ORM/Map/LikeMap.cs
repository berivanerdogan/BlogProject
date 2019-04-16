using BlogProject.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.ORM.Map
{
   public  class LikeMap:BaseMap<Like>
    {
        public LikeMap()
        {
            ToTable("dbo.Likes");
            HasKey(x => new { x.AppUserID, x.ArticleID });
            //HasRequired(x => x.AppUser).WithMany(x => x.Likes)
            //    .HasForeignKey(x => x.AppUserID)
            //    .WillCascadeOnDelete(false);
            //HasRequired(x => x.Article).WithMany(x => x.Likes)
            //    .HasForeignKey(x => x.ArticleID)
            //    .WillCascadeOnDelete(false);
        }

    }
}

