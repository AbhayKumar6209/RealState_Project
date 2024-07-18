using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace RealEstate.Models
{
    public class Login: CommonBase
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username required.")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password required.")]
        public string Password { get; set; }

        public DataTable dt { get; set; }
    }
}