using BlogProject.DAL.ORM.Enum;
using BlogProject.DAL.ORM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.ORM.Entity
{
    public class BaseEntity : IBaseEntity
    {
        public Guid ID { get; set; }
        private DateTime _adddate=DateTime.Now;
        public DateTime AddDate { get { return _adddate; } set { _adddate=value; } }
        private DateTime _updatedate = DateTime.Now;
        public DateTime UpdateDate { get { return _updatedate; } set { _updatedate = value; } }
        private DateTime _deletedate = DateTime.Now;
        public DateTime DeleteDate { get { return _deletedate; } set { _deletedate = value; } }
        private Status _status = DAL.ORM.Enum.Status.Active;
        public Status Status { get { return _status; } set { _status = value; } }
    }
}
