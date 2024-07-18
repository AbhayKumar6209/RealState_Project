using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RealEstate.DataBase;
using RealEstate.Models;

namespace RealEstate.DataBase
{
    public class BusinessLayer
    {
        DbLayer dbl = new DbLayer();

        #region _qe


        internal DataTable GetMasterData(string Action, string id1 = null, string id2 = null, string id3 = null, string id4 = null, string id5 = null)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[] {
                new SqlParameter("@Action",Action),
                new SqlParameter("@P1",id1),
                new SqlParameter("@P2",id2),
                new SqlParameter("@P3",id3),
                new SqlParameter("@P4",id4),
                new SqlParameter("@P5",id5)
                };
                dt = dbl.ExecProcPara_dt("USP_GetMasterData", para);
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }


        public DataTable GetLogins(Login obj)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@UserName", obj.UserName),
                    new SqlParameter("@Password", obj.Password),
                    new SqlParameter("@Action", obj.Action)
                };
                dt = dbl.ExecProcPara_dt("Proc_GetLoginDetails", sp);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return dt;
        }

        public DataTable AgentMaster(AgentMaster obj)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@Id", obj.Id),
                    new SqlParameter("@MID", obj.MID),
                    new SqlParameter("@SID", obj.SID),
                    new SqlParameter("@Member_Id", obj.Member_Id),
                    new SqlParameter("@Psw", obj.Password),
                    new SqlParameter("@Name", obj.Name),
                    new SqlParameter("@FatherName", obj.FatherName),
                    new SqlParameter("@Gender", obj.Gender),
                    new SqlParameter("@Mobile", obj.Mobile),
                    new SqlParameter("@Email", obj.Email),
                    new SqlParameter("@AdharNo", obj.AdharNo),
                    new SqlParameter("@PanNo", obj.PanNo),
                    new SqlParameter("@DOB", obj.DOB),
                    new SqlParameter("@BankName", obj.BankName),
                    new SqlParameter("@Branch", obj.Branch),
                    new SqlParameter("@IFSCCode", obj.IFSCCode),
                    new SqlParameter("@AccountNo", obj.AccountNo),
                    new SqlParameter("@ProfilePic", obj.ProfilePic),
                    new SqlParameter("@BankCopy", obj.BankCopy),
                    new SqlParameter("@AdharFrontCopy", obj.AdharFrontCopy),
                    new SqlParameter("@AdharBackCopy", obj.AdharBackCopy),
                    new SqlParameter("@PanCopy", obj.PanCopy),
                    new SqlParameter("@KYC_Status", obj.KYC_Status),
                    new SqlParameter("@createdby", obj.EntryBy),
                    new SqlParameter("@Address", obj.Address),
                    new SqlParameter("@Rank_Id", obj.Rank_Id),
                    new SqlParameter("@Action", obj.Action)
                };
                dt = dbl.ExecProcPara_dt("Proc_AgentMaster", sp);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return dt;
        }

        public DataTable SiteMaster(SiteMaster obj)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@Id", obj.Id),
                    new SqlParameter("@SiteName", obj.SiteName),
                    new SqlParameter("@FormarName", obj.FormarName),
                    new SqlParameter("@SiteAddress", obj.SiteAddress),
                    new SqlParameter("@MapLink", obj.MapLink),
                    new SqlParameter("@Size", obj.Size),
                    new SqlParameter("@NoofPlot", obj.NoofPlot),
                    new SqlParameter("@PlotAmt", obj.PlotAmt),
                    new SqlParameter("@PaidAmt", obj.PaidAmt),
                    new SqlParameter("@DueAmt", obj.DueAmt),
                    new SqlParameter("@ProjectImagesUrl", obj.ProjectImagesUrl),
                    new SqlParameter("@Action", obj.Action)
                };
                dt = dbl.ExecProcPara_dt("Proc_SiteMaster", sp);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return dt;
        }

        public DataTable PlotMaster(PlotMaster obj)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@Id", obj.Id),
                    new SqlParameter("@SiteId", obj.SiteName),
                    new SqlParameter("@BlockId", obj.BlockName),
                    new SqlParameter("@PlotTypeId", obj.PlotType),
                    new SqlParameter("@PlotNumber", obj.PlotNumber),
                    new SqlParameter("@PlotRate", obj.PlotRate),
                    new SqlParameter("@PlotArea", obj.PlotArea),
                    new SqlParameter("@PlotCost", obj.PlotCost),
                    new SqlParameter("@PlotStatus", obj.PlotStatus),
                    new SqlParameter("@PlotImage", obj.PlotImage),
                    new SqlParameter("@Description", obj.Description),
                    new SqlParameter("@Action", obj.Action)
                };
                dt = dbl.ExecProcPara_dt("Proc_PlotMaster", sp);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return dt;
        }

        public DataTable Contact(Contact obj)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@Name", obj.Name),
                    new SqlParameter("@Email", obj.Email),
                    new SqlParameter("@Subject", obj.Subject),
                    new SqlParameter("@Mobile", obj.Mobile),
                    new SqlParameter("@Message", obj.Message),
                    new SqlParameter("@Action",obj.Action)
                };
                dt = dbl.ExecProcPara_dt("Proc_Contact", sp);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return dt;
        }

        public DataTable PropEnquiry(PropEnquiry obj)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sp = new SqlParameter[]
                    {
                        new SqlParameter("@Id", obj.Id),
                        new SqlParameter("@PlotId", obj.PlotId),
                        new SqlParameter("@Name", obj.Name),
                        new SqlParameter("@Phone", obj.Phone),
                        new SqlParameter("@Email", obj.Email),
                        new SqlParameter("@Message", obj.Message),
                        new SqlParameter("@Ip", obj.IP),
                        new SqlParameter("@Action", obj.Action),
                    };
                dt = dbl.ExecProcPara_dt("Proc_PlotEnquiry", sp);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return dt;
        }

        #endregion


        #region SalePlot

        public DataTable SalePlot(SalePlot obj)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@AgentId", obj.AgentId),
                    new SqlParameter("@Name", obj.Name),
                    new SqlParameter("@FatherName", obj.FatherName),
                    new SqlParameter("@PermanentAddress", obj.PermanentAddress),
                    new SqlParameter("@PinCode", obj.PinCode),
                    new SqlParameter("@City", obj.City),
                    new SqlParameter("@State", obj.State),
                    new SqlParameter("@C_Address", obj.C_Address),
                    new SqlParameter("@C_PinCode", obj.C_PinCode),
                    new SqlParameter("@C_City", obj.C_City),
                    new SqlParameter("@C_State", obj.C_State),
                    new SqlParameter("@PhoneNo", obj.PhoneNo),
                    new SqlParameter("@Email", obj.Email),
                    new SqlParameter("@PanNo", obj.PanNo),
                    new SqlParameter("@Occupation", obj.Occupation),
                    new SqlParameter("@Nationality", obj.Nationality),
                    new SqlParameter("@AadharFront_url", obj.AadharFront_url),
                    new SqlParameter("@AadharBack_url", obj.AadharBack_url),
                    new SqlParameter("@DL_url", obj.DL_url),
                    new SqlParameter("@PAN_url", obj.PAN_url),
                    new SqlParameter("@NomineeName", obj.NomineeName),
                    new SqlParameter("@Relation", obj.Relation),
                    new SqlParameter("@PropertyId", obj.PropertyId),
                    new SqlParameter("@Block", obj.Block),
                    new SqlParameter("@PlotNo", obj.PlotNo),
                    new SqlParameter("@DevelopmentCharge", obj.DevelopmentCharge),
                    new SqlParameter("@DevelopmentRate", obj.DevelopmentRate),
                    new SqlParameter("@PlotRate", obj.PlotRate),
                    new SqlParameter("@PlotArea", obj.PlotArea),
                    new SqlParameter("@PlotCost", obj.PlotCost),
                    new SqlParameter("@PLCAmount", obj.PLCAmount),
                    new SqlParameter("@OtherCharges", obj.OtherCharges),
                    new SqlParameter("@FinalPayable", obj.FinalPayable),
                    new SqlParameter("@Discount", obj.Discount),
                    new SqlParameter("@TotalPlotCost", obj.TotalPlotCost),
                    new SqlParameter("@BookingDate", obj.Date),
                    new SqlParameter("@Remark", obj.Remark),
                    new SqlParameter("@PaymentType", obj.PaymentType),
                    new SqlParameter("@BookingAmount", obj.BookingAmount),
                    new SqlParameter("@DueAmount", obj.DueAmount),
                    new SqlParameter("@PaymentMode", obj.PaymentMode),
                    new SqlParameter("@AC_Number", obj.AC_Number),
                    new SqlParameter("@IFSC", obj.IFSC),
                    new SqlParameter("@BankName", obj.BankName),
                    new SqlParameter("@BranchName", obj.BranchName),
                    new SqlParameter("@ChequeDate", obj.ChequeDate),
                    new SqlParameter("@TransactionID", obj.TransactionID),
                    new SqlParameter("@EMI_Month", obj.EMI_Month),
                    new SqlParameter("@InstallmentAmount", obj.InstallmentAmount),
                    new SqlParameter("@Is_Reminder", obj.Is_Reminder),
                    new SqlParameter("@Payment_Remark", obj.Payment_Remark),
                    new SqlParameter("@EntryBy", obj.EntryBy),
                };
                dt = dbl.ExecProcPara_dt("USP_SalePlot", sp);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return dt;
        }

        #endregion

        #region Anuj

        public DataTable MasterBlock(AddBlock objB)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sp = new SqlParameter[]
                {

                    new SqlParameter("@Action", objB.Action),
                    new SqlParameter("@BlockName",objB.Block),
                    new SqlParameter("@SiteId",objB.ProjectId),
                    new SqlParameter("@Id",objB.Id)
                };
                dt = dbl.ExecProcPara_dt("Sp_MasterBlock", sp);
            }
            catch (Exception exc)
            {

                throw exc;
            }
            return dt;
        }

        public DataTable MasterPlotType(PlotTypeMaster objB)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sp = new SqlParameter[]
                {

                   new SqlParameter("@Id",objB.Id),
                    new SqlParameter("@PlotType",objB.PlotType),
                    new SqlParameter("@Action", objB.Action)
                };
                dt = dbl.ExecProcPara_dt("Sp_MasterPlotType", sp);
            }
            catch (Exception exc)
            {

                throw exc;
            }
            return dt;
        }

        #endregion Anuj

    }
}