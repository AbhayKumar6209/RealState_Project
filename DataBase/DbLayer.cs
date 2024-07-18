using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

namespace RealEstate.DataBase
{
	public class DbLayer
	{
		#region _qe
		SqlConnection con = new SqlConnection("Data Source=DESKTOP-4PUO57K;Initial Catalog=realstate1db;Integrated Security=True;");

        public DataTable ExecProcPara_dt(string Procedure, SqlParameter[] sp)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(Procedure, con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter p in sp) 
                {
                    cmd.Parameters.Add(p);
                }
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return dt;
        }

        public DataTable ExecuteQuery_dt(string Query)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return dt;
        }

        public DataSet ExecProcPara_ds(string Procedure, SqlParameter[] sp)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(Procedure, con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter p in sp)
                {
                    cmd.Parameters.Add(p);
                }
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return ds;
        }

        public DataSet ExecuteQuery_ds(string Query)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return ds;
        }

        #endregion _qe

    }
}