using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RealEstate.Models
{
    public class PropEnquiry: CommonBase
    {
        public int? Id{ get; set; }
        public string PlotId { get; set; }
        public string Name{ get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public DataTable dt { get; set; }
    }
}