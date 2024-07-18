using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace RealEstate.Models
{
    public class SiteMaster: CommonBase
    {
        public int? Id { get; set; }

        [Display(Name = "Site Name")]
        [Required(ErrorMessage = "Site name required")]
        public string SiteName { get; set; }

        [Display(Name = "Farmer Name")]
        [Required(ErrorMessage = "Formar name required")]
        public string FormarName { get; set; }

        [Display(Name = "Site Address")]
        [Required(ErrorMessage = "Site address required")]
        public string SiteAddress { get; set; }

        [Display(Name = "Map Link")]
        public string MapLink { get; set; }

        [Display(Name = "Area/Size")]
        public string Size { get; set; }

        [Display(Name = "No. of Plot")]
        public string NoofPlot { get; set; }

        [Display(Name = "Actual Amount")]
        public string PlotAmt { get; set; }

        [Display(Name = "Paid Amount")]
        public string PaidAmt { get; set; }

        [Display(Name = "Due Amount")]
        public string DueAmt { get; set; }

        [Display(Name = "Project Image")]
        [RegularExpression(@"^([A-za-z0-9\s_\\.\-:])+(.jpg|.jpeg|.png)$", ErrorMessage = "Upload a valid file. It may be .jpg, .jpeg or .png type")]
        public HttpPostedFileBase _projectImagesUrl { get; set; }
        public string ProjectImagesUrl { get; set; }
        public DataTable dt { get; set; }

    }
}