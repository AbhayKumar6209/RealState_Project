using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstate.Models
{
    public class PlotTypeMaster: CommonBase
    {
        public int? Id { get; set; }
        [Display(Name = "Plot Type")]
        [Required(ErrorMessage = "Plot Type required")]
        public string PlotType{ get; set; }
    }
}