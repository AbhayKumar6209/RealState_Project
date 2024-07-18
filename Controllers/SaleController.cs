using RealEstate.DataBase;
using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Controllers
{
    public class SaleController : Controller
    {
        BusinessLayer bl = new BusinessLayer();
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PlotTransfer()
        {
            return View();
        }

        public ActionResult PlotCancel()
        {
            return View();
        }

        public ActionResult CustomersList()
        {
            return View();
        }

        public ActionResult SalePlot()
        {
            SalePlot obj = new SalePlot();

            obj.AgentLst = CommonBase.BindDDl(bl.GetMasterData("1"));
            obj.SiteLst = CommonBase.BindDDl(bl.GetMasterData("2"));

            return View(obj);
        }
        [HttpPost]
        public ActionResult SalePlot(SalePlot obj,HttpPostedFileBase FU_AdharFront, HttpPostedFileBase FU_AdharBack, HttpPostedFileBase FU_drivinglicence, HttpPostedFileBase FU_PAN)
        {
            CommonBase objcom = new CommonBase();

            ViewBag.flag = "0";
            ViewBag.msg = "Server Not Responding";


            obj.EntryBy = Convert.ToString(Session["UserName"]);

            obj.AadharFront_url = objcom.SaveFile(FU_AdharFront, "/Media/BookingFile/");
            obj.AadharBack_url = objcom.SaveFile(FU_AdharBack, "/Media/BookingFile/");
            obj.DL_url = objcom.SaveFile(FU_drivinglicence, "/Media/BookingFile/");
            obj.PAN_url = objcom.SaveFile(FU_PAN, "/Media/BookingFile/");

            DataTable dt = bl.SalePlot(obj);

            if (dt != null && dt.Rows.Count > 0)
            {
                ViewBag.flag = Convert.ToString(dt.Rows[0]["flag"]);
                ViewBag.msg = Convert.ToString(dt.Rows[0]["msg"]);
            }

            obj.AgentLst = CommonBase.BindDDl(bl.GetMasterData("1"));
            obj.SiteLst = CommonBase.BindDDl(bl.GetMasterData("2"));
            return View(obj);
        }

        public ActionResult PlotRegistry()
        {
            return View();
        }

        public ActionResult PlotAgreement()
        {
            return View();
        }

    }
}