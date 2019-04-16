﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogProject.UI.Areas.Author.Models.VM
{
    public class LoginVM
    {
        [Required(ErrorMessage ="UserName Error")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Password Error")]
        public string Password { get; set; }
    }
}