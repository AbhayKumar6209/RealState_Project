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
    public class AgentController : Controller
    {
        BusinessLayer bl = new BusinessLayer();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddAgent(AgentMaster obj)
        {
            try
            {
                obj.AgentLst = CommonBase.BindDDl(bl.GetMasterData("1"));
                obj.Action = 2;
                obj.dt = bl.AgentMaster(obj);
                if (obj.Member_Id != null && obj.dt != null & obj.dt.Rows.Count > 0)
                {
                    obj.Member_Id = obj.Member_Id;
                    obj.SID = Convert.ToInt32(obj.dt.Rows[0]["SID"]);
                    obj.Name = obj.dt.Rows[0]["Name"].ToString();
                    obj.FatherName = obj.dt.Rows[0]["FatherName"].ToString();
                    obj.Gender = obj.dt.Rows[0]["Gender"].ToString();
                    obj.Mobile = obj.dt.Rows[0]["Mobile"].ToString();
                    obj.Password = obj.dt.Rows[0]["Psw"].ToString();
                    obj.Email = obj.dt.Rows[0]["Email"].ToString();
                    obj.AdharNo = obj.dt.Rows[0]["AdharNo"].ToString();
                    obj.PanNo = obj.dt.Rows[0]["PanNo"].ToString();
                    obj.DOB = obj.dt.Rows[0]["DOB1"].ToString();
                    obj.BankName = obj.dt.Rows[0]["BankName"].ToString();
                    obj.Branch = obj.dt.Rows[0]["Branch"].ToString();
                    obj.IFSCCode = obj.dt.Rows[0]["IFSCCode"].ToString();
                    obj.AccountNo = obj.dt.Rows[0]["AccountNo"].ToString();
                    obj.Address = obj.dt.Rows[0]["Address"].ToString();
                }
            }
            catch (Exception exc)
            {
                Response.Write("<script>alert('" + exc.Message + "');</script>");
            }
            
            return View(obj);
        }

        public void _addAgent(AgentMaster obj)
        {
            try
            {
                obj.Action = obj.Member_Id == null ? 1 : 3;

                obj.Password = obj.Member_Id == null ? obj.CreateRandomPassword(6) : obj.Password;

                #region file saving

                obj.ProfilePic = obj.SaveFile(obj._profilePic, "~/Media/AgentProfile/");
                obj.AdharBackCopy = obj.SaveFile(obj._adharBackCopy, "~/Media/AgentAadhar/");
                obj.AdharFrontCopy = obj.SaveFile(obj._adharFrontCopy, "~/Media/AgentAadhar/");
                obj.BankCopy = obj.SaveFile(obj._bankCopy, "~/Media/AgentBank/");
                obj.PanCopy = obj.SaveFile(obj._panCopy, "~/Media/AgentPAN/");

                #endregion file saving

                obj.dt = bl.AgentMaster(obj);

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

        public string deleteAgent(string Member_Id)
        {
            string data = "0";
            AgentMaster obj = new AgentMaster();
            try
            {
                obj.Member_Id = Member_Id;
                obj.Action = 4;
                obj.dt = bl.AgentMaster(obj);

                if (obj.dt != null & obj.dt.Rows.Count > 0)
                    data = obj.dt.Rows[0]["msg"].ToString();
            }
            catch (Exception exc)
            {
                data = exc.Message;
            }
            return data;
        }

        public ActionResult AgentList()
        {
            AgentMaster obj = new AgentMaster();
            try
            {
                obj.Action = 2;
                obj.dt = bl.AgentMaster(obj);
            }
            catch (Exception exc)
            {
                Response.Write("<script>alert('" + exc.Message + "');</script>");
            }
            return View(obj);
        }

        public ActionResult AgentDownline()
        {
            return View();
        }

        public ActionResult AgentDirect()
        {
            return View();
        }

        public ActionResult TreeView()
        {
            return View();
        }

    }
}