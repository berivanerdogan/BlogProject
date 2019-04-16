using BlogProject.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.Repository
{
   public class AppUserRepository:BaseRepository<AppUser>
    {
        public bool CheckCredential(string username,string password)
        {
            return table.Any(x => x.UserName == username && x.Password == password && x.Status == BlogProject.DAL.ORM.Enum.Status.Active || x.Status == BlogProject.DAL.ORM.Enum.Status.Modified);
        }

        public AppUser FindByUserName(string username)
        {
            return table.FirstOrDefault(x => x.UserName == username);
        }

    }
}
