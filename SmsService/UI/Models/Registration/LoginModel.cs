using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class LoginModel
    {
        [Required]
        public String Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}