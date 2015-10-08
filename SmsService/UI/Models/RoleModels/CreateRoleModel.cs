using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models.RoleModels
{
    public class CreateRoleModel
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Description { get; set; }
    }
}