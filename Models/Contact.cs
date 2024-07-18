using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace RealEstate.Models
{
    public class Contact : CommonBase
    {

        public int? Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name required")]

        public string Name { get; set; }

        

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email required")]

        public string Email { get; set; }


        [Display(Name = "Subject")]
        [Required(ErrorMessage = "Subject required")]

        public string Subject { get; set; }


        [Display(Name = "Mobile")]
        [Required(ErrorMessage = "Mobile required")]

        public string Mobile { get; set; }


        [Display(Name = "Message")]
        [Required(ErrorMessage = "Message required")]


        public string Message { get; set; }
        
        




    }
}