using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Models
{
    public class SalePlot
    {
        public List<SelectListItem> AgentLst =new List<SelectListItem>();
        public List<SelectListItem> SiteLst = new List<SelectListItem>();
        public string AgentId { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string PermanentAddress { get; set; }
        public string PinCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string C_Address { get; set; }
        public string C_PinCode { get; set; }
        public string C_City { get; set; }
        public string C_State { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string PanNo { get; set; }
        public string Occupation { get; set; }
        public string Nationality { get; set; }
        public string AadharFront_url { get; set; }
        public string AadharBack_url { get; set; }
        public string DL_url { get; set; }
        public string PAN_url { get; set; }
        public string NomineeName { get; set; }
        public string Relation { get; set; }
        public int PropertyId { get; set; }
        public string Block { get; set; }
        public string PlotNo { get; set; }
        public decimal? DevelopmentCharge { get; set; }
        public decimal? DevelopmentRate { get; set; }
        public decimal? PlotRate { get; set; }
        public decimal? PlotArea { get; set; }
        public decimal? PlotCost { get; set; }
        public decimal? PLCAmount { get; set; }
        
        public decimal? OtherCharges { get; set; }
        public decimal? FinalPayable { get; set; }
        public decimal? Discount { get; set; }
        
        public decimal? TotalPlotCost { get; set; }
        public string Date { get; set; }
        public string Remark { get; set; }



        public string PaymentType { get; set; }
        public decimal? BookingAmount { get; set; }
        public decimal? DueAmount { get; set; }
        public string PaymentMode { get; set; }
        public string AC_Number { get; set; }
        public string IFSC { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string ChequeDate { get; set; }
        public string TransactionID { get; set; }
        public int? EMI_Month { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public bool Is_Reminder { get; set; }
        public string Payment_Remark { get; set; }
        public string EntryBy { get;  set; }






    }
}