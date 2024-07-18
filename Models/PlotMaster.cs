using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace RealEstate.Models
{
    public class PlotMaster: CommonBase
    {
        public int? Id { get; set; }

        [Display(Name = "Site Name")]
        [Required(ErrorMessage = "Please select site name.")]
        public string SiteName {get; set; }

        [Display(Name = "Site Location")]
        public string SiteLocation {get; set; }

        [Display(Name = "No. of Plot")]
        public string NoOfPlot {get; set; }

        [Display(Name = "Block Name")]
        [Required(ErrorMessage = "Please select block name.")]
        public string BlockName { get; set; }

        [Display(Name = "Plot Type")]
        [Required(ErrorMessage = "Please select plot type.")]
        public string PlotType {get; set; }

        [Display(Name = "Plot No.")]
        [Required(ErrorMessage = "Please select plot no.")]
        public string PlotNumber { get; set; }

        [Display(Name = "Plot Rate")]
        [Required(ErrorMessage = "Please select plot rate.")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{0,2})$", ErrorMessage = "Valid decimal number with maximum 2 decimal places.")]
        public string PlotRate { get; set; }

        [Display(Name = "Plot Area")]
        [Required(ErrorMessage = "Please select plot rate.")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{0,2})$", ErrorMessage = "Valid decimal number with maximum 2 decimal places.")]
        public string PlotArea { get; set; }

        [Display(Name = "Plot Cost")]
        [Required(ErrorMessage = "Please select plot cost.")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{0,2})$", ErrorMessage = "Valid decimal number with maximum 2 decimal places.")]
        public string PlotCost { get; set; }

        [Display(Name = "Plot Status")]
        [Required(ErrorMessage = "Please select plot status.")]
        public string PlotStatus { get; set; }

        [Display(Name = "Plot Image")]
        [RegularExpression(@"^([A-za-z0-9\s_\\.\-:])+(.jpg|.jpeg|.png)$", ErrorMessage = "Upload a valid file. It may be .jpg, .jpeg or .png type")]
        //[Required(ErrorMessage = "Please upload an image.")]
        public HttpPostedFileBase _plotImage { get; set; }

        public string PlotImage { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "This field is required.")]
        public string Description { get; set; }

        public DataTable dt { get; set; }
    }
}