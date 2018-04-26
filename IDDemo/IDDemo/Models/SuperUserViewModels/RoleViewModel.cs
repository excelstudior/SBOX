using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IDDemo.Models.SuperUserViewModels
{
    public class RoleViewModel
    {
        
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
