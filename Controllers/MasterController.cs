using Newtonsoft.Json;
using RealEstate.DataBase;
using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstate.SessionHandler;
using System.Data;

namespace RealEstate.Controllers
{
    [SessionCheck]
    public class MasterController : Controller
    {
        BusinessLayer bl = new BusinessLayer();
        public JsonResult GetDDLData(string Action, string P1, string P2, string P3, string P4, string P5)
        {
            return Json(CommonBase.BindDDl(bl.GetMasterData(Action, P1, P2, P3, P4, P5)),JsonRequestBehavior.AllowGet);
        }
        public string GetMasterData(string Action,string P1,string P2,string P3,string P4,string P5)
        {
            return CommonBase.ConvertTableToList(bl.GetMasterData(Action,P1,P2,P3,P4,P5));
        }

        // GET: Master
        public ActionResult Index()
        {
            return View();
        }

        #region _qe

        public ActionResult AddSite(SiteMaster obj)
        {
            try
            {
                obj.Action = 2;
                obj.dt = bl.SiteMaster(obj);
                if (obj.Id != null && obj.dt != null & obj.dt.Rows.Count > 0)
                {
                    obj.Id = obj.Id;
                    obj.SiteName = obj.dt.Rows[0]["SiteName"].ToString();
                    obj.FormarName = obj.dt.Rows[0]["FormarName"].ToString();
                    obj.SiteAddress = obj.dt.Rows[0]["SiteAddress"].ToString();
                    obj.MapLink = obj.dt.Rows[0]["MapLink"].ToString();
                    obj.Size = obj.dt.Rows[0]["Size"].ToString();
                    obj.NoofPlot = obj.dt.Rows[0]["NoofPlot"].ToString();
                    obj.PlotAmt = obj.dt.Rows[0]["PlotAmt"].ToString();
                    obj.PaidAmt = obj.dt.Rows[0]["PaidAmt"].ToString();
                    obj.DueAmt = (Convert.ToDecimal(obj.PlotAmt) - Convert.ToDecimal(obj.PaidAmt)).ToString("0.00"); //obj.dt.Rows[0]["DueAmt"].ToString();
                }
            }
            catch (Exception exc)
            {
                Response.Write("<script>alert('" + exc.Message + "');</script>");
            }

            return View(obj);
        }

        public void _addSite(SiteMaster obj)
        {
            try
            {
                obj.Action = obj.Id == null ? 1 : 3;
                obj.ProjectImagesUrl = obj.SaveFile(obj._projectImagesUrl, "~/Media/SiteImage/");
                obj.dt = bl.SiteMaster(obj);

                if (obj.dt != null & obj.dt.Rows.Count > 0)
                    Response.Write("<script>alert('" + obj.dt.Rows[0]["msg"].ToString() + "');Javascript:history.back();</script>");
                else
                    Response.Write("<script>alert('Server error occured!');Javascript:history.back();</script>");
            }
            catch (Exception exc)
            {
                Response.Write("<script>alert('" + exc.Message + "');Javascript:history.back();</script>");
            }

        }

        public string deleteSite(int Id)
        {
            string data = "0";
            SiteMaster obj = new SiteMaster();
            try
            {
                obj.Id = Id;
                obj.Action = 4;
                obj.dt = bl.SiteMaster(obj);

                if (obj.dt != null & obj.dt.Rows.Count > 0)
                    data = obj.dt.Rows[0]["msg"].ToString();
            }
            catch (Exception exc)
            {
                data = exc.Message;
            }
            return data;
        }

        [HttpGet]
        public ActionResult AddPlot()
        {
            PlotMaster obj = new PlotMaster();
            SiteMaster objs = new SiteMaster();
            objs.Action = 5;
            ViewBag.SiteNames = CommonBase.BindDDl(bl.SiteMaster(objs));

            PlotTypeMaster objp = new PlotTypeMaster();
            objp.Action = 5;
            ViewBag.PlotTypes = CommonBase.BindDDl(bl.MasterPlotType(objp));

            obj.Action = 2;
            obj.dt = bl.PlotMaster(obj);
            return View(obj);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddPlot(PlotMaster obj)
        {
            try
            {
                obj.Action = obj.Id == null ? 1 : 3;
                obj.PlotImage = obj.SaveFile(obj._plotImage, "~/Media/PlotImage/");
                obj.dt = bl.PlotMaster(obj);

                if (obj.dt != null & obj.dt.Rows.Count > 0)
                {
                    Response.Write("<script>alert('" + obj.dt.Rows[0]["msg"].ToString() + "');Javascript:history.back();</script>");
                    ModelState.Clear();
                }
                else
                    Response.Write("<script>alert('Server error occured!');Javascript:history.back();</script>");
            }
            catch (Exception exc)
            {
                Response.Write("<script>alert('" + exc.Message + "');Javascript:history.back();</script>");
            }

            SiteMaster objs = new SiteMaster();
            objs.Action = 5;
            ViewBag.SiteNames = CommonBase.BindDDl(bl.SiteMaster(objs));

            PlotTypeMaster objp = new PlotTypeMaster();
            objp.Action = 5;
            ViewBag.PlotTypes = CommonBase.BindDDl(bl.MasterPlotType(objp));

            obj.Action = 2;
            obj.dt = bl.PlotMaster(obj);

            return View(obj);
        }

        public string BindSiteDetails(SiteMaster obj)
        {
            string data = "0";
            try
            {
                obj.Action = 5;
                obj.dt = bl.SiteMaster(obj);
                if (obj.dt != null & obj.dt.Rows.Count > 0)
                    data = JsonConvert.SerializeObject(obj.dt);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return data;
        }

        public string BindBlock_Site(AddBlock obj)
        {
            string data = "0";
            try
            {
                obj.Action = 5;
                obj.dt = bl.MasterBlock(obj);
                if (obj.dt != null & obj.dt.Rows.Count > 0)
                    data = JsonConvert.SerializeObject(obj.dt);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return data;
        }

        public string deletePlot(PlotMaster obj)
        {
            string data = "0";
            try
            {
                obj.Action = 4;
                obj._dt = bl.PlotMaster(obj);
                if (obj._dt != null && obj._dt.Rows.Count > 0)
                    data = obj._dt.Rows[0]["msg"].ToString();
            }
            catch (Exception exc)
            {
                data = exc.Message;
            }
            return data;
        }

        public string updatePlot(PlotMaster obj)
        {
            string data = "0";
            try
            {
                obj.Action = 2;
                obj._dt = bl.PlotMaster(obj);
                if (obj._dt != null && obj._dt.Rows.Count > 0)
                    data = JsonConvert.SerializeObject(obj._dt);
            }
            catch (Exception exc)
            {
                data = exc.Message;
            }
            return data;
        }

        #endregion _qe

        public ActionResult AddPlotType()
        {
            PlotTypeMaster objA = new PlotTypeMaster();
            try
            {
                objA.Action = 2;
                objA._dt = bl.MasterPlotType(objA);

                if (objA.Id != null && objA._dt != null & objA._dt.Rows.Count > 0)
                {
                    objA.Id = objA.Id;
                    objA.PlotType = objA._dt.Rows[0]["PlotType"].ToString();
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');Javascript:history.back();</script>");
            }
            return View(objA);

        }

        [HttpPost]
        public ActionResult AddPlotType(PlotTypeMaster ObjC)
        {
            try
            {
                ObjC.Action = ObjC.Id == null ? 1 : 3;

                ObjC._dt = bl.MasterPlotType(ObjC);
                if (ObjC._dt != null && ObjC._dt.Rows.Count > 0)
                {
                    Response.Write("<script>alert('" + ObjC._dt.Rows[0]["msg"].ToString() + "');</script>");
                    ModelState.Clear();
                }
                else
                    Response.Write("<script>alert('Server error occured!');</script>");
            }
            catch (Exception exc)
            {

                Response.Write("<script>alert('" + exc.Message + "');</script>");
            }
            ObjC.Action = 2;
            ObjC._dt = bl.MasterPlotType(ObjC);
            return View(ObjC);
        }

        #region _qe

        public string deletePlotType(PlotTypeMaster obj)
        {
            string data = "0";
            try
            {
                obj.Action = 4;
                obj._dt = bl.MasterPlotType(obj);
                if (obj._dt != null && obj._dt.Rows.Count > 0)
                    data = obj._dt.Rows[0]["msg"].ToString();
            }
            catch (Exception exc)
            {
                data = exc.Message;
            }
            return data;
        }

        public string updatePlotType(PlotTypeMaster obj)
        {
            string data = "0";
            try
            {
                obj.Action = 2;
                obj._dt = bl.MasterPlotType(obj);
                if (obj._dt != null && obj._dt.Rows.Count > 0)
                    data = JsonConvert.SerializeObject(obj._dt);
            }
            catch (Exception exc)
            {
                data = exc.Message;
            }
            return data;
        }

        #endregion _qe

        public ActionResult AddBlock()
        {
            AddBlock objA = new AddBlock();
            SiteMaster objs = new SiteMaster();
            try
            {
                objs.Action = 5;
                ViewBag.ProjectList = CommonBase.BindDDl(bl.SiteMaster(objs));

                objA.Action = 2;
                objA._dt = bl.MasterBlock(objA);

                if (objA.Id != null && objA._dt != null & objA._dt.Rows.Count > 0)
                {
                    objA.Id = objA.Id;
                    objA.Block = objA._dt.Rows[0]["BlockName"].ToString();
                    objA.ProjectId = Convert.ToInt32(objA._dt.Rows[0]["SiteId"]);
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');Javascript:history.back();</script>");
            }
            return View(objA);
        }

        [HttpPost]
        public ActionResult AddBlock(AddBlock ObjC)
        {
            try
            {
                ObjC.Action = ObjC.Id == null ? 1 : 3;
                ObjC._dt = bl.MasterBlock(ObjC);

                if (ObjC._dt != null && ObjC._dt.Rows.Count > 0)
                    Response.Write("<script>alert('" + ObjC._dt.Rows[0]["msg"].ToString() + "');</script>");
                else
                    Response.Write("<script>alert('Server error occured!');</script>");
            }
            catch (Exception exc)
            {
                Response.Write("<script>alert('" + exc.Message + "');</script>");
            }

            SiteMaster objs = new SiteMaster();
            objs.Action = 5;
            ViewBag.ProjectList = CommonBase.BindDDl(bl.SiteMaster(objs));
            ObjC.Action = 2;
            ObjC._dt = bl.MasterBlock(ObjC);

            return View(ObjC);
        }

        #region _qe

        public string deleteBlock(AddBlock obj)
        {
            string data = "0";
            try
            {
                obj.Action = 4;
                obj._dt = bl.MasterBlock(obj);
                if (obj._dt != null && obj._dt.Rows.Count > 0)
                    data = obj._dt.Rows[0]["msg"].ToString();
            }
            catch (Exception exc)
            {
                data = exc.Message;
            }
            return data;
        }

        public string updateBlock(AddBlock obj)
        {
            string data = "0";
            try
            {
                obj.Action = 2;
                obj._dt = bl.MasterBlock(obj);
                if (obj._dt != null && obj._dt.Rows.Count > 0)
                    data = JsonConvert.SerializeObject(obj._dt);
            }
            catch (Exception exc)
            {
                data = exc.Message;
            }
            return data;
        }

        #endregion _qe


        //public void clear()
        //{
        //    PlotTypeMaster objA = new PlotTypeMaster();
        //    objA.PlotType == "";
        //}

    }
};