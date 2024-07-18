using RealEstate.DataBase;
using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstate.SessionHandler;

namespace RealEstate.Controllers
{
    [SessionCheck]
    public class SupportController : Controller
    {
        BusinessLayer bl = new BusinessLayer();
        // GET: Support
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EnquiriyDetails(PropEnquiry obj)
        {
            try
            {
                obj.Action = 2;
                obj.dt = bl.PropEnquiry(obj);
            }
            catch (Exception exc)
            {
                Response.Write("<script>alert('" + exc.Message + "');</script>");
            }
            return View(obj);
        }

        public ActionResult ContactDerails(Contact obj)
        {
            obj.Action = 2;
            obj._dt = bl.Contact(obj);
            return View(obj);
        }

    }
}