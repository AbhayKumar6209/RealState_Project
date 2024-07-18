using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Controllers
{
    public class PinManagementController : Controller
    {
        // GET: PinManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GeneratePin()
        {
            return View();
        }

        public ActionResult PinList()
        {
            return View();
        }

        public ActionResult TransferPin()
        {
            return View();
        }
    }
}