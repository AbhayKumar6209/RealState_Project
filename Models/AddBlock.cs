using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace RealEstate.Models
{
    public class AddBlock : CommonBase
    {
        public int? Id { get; set; }

        [Display(Name = "Block Name")]
        [Required(ErrorMessage = "Block name required")]
        public string Block { get; set; }

        [Display(Name = "Site Name")]
        [Required(ErrorMessage = "Please select site name")]
        public int ProjectId { get; set; }

        public DataTable dt { get; set; }
        
      

    }
}