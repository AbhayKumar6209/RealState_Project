using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace RealEstate.Models
{
    public class CommonBase
    {
        #region _qe

        public string EntryBy { get; set; }
        public int Action { get; set; }
        public DataTable _dt { get; set; }
        public DataSet _ds { get; set; }
        public string IP { get; set; }
        public string msg { get; set; }

        public string SaveFile(HttpPostedFileBase _file, string _location)
        {
            string _path = null;
            if (_file != null)
            {
                string _fileName = DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss_tt_") + Path.GetFileName(_file.FileName);
                _path = _location.Replace("~", "") + _fileName;
                string _fileServerPath = Path.Combine(HostingEnvironment.MapPath(_location), _fileName);
                _file.SaveAs(_fileServerPath);
            }
            return _path;
        }

        public string SaveFiles(HttpPostedFileBase[] _files, string _location)
        {
            string _path = null;
            if (_files != null)
            {
                foreach (HttpPostedFileBase _file in _files)
                {
                    string _fileName = DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss_tt_") + Path.GetFileName(_file.FileName);
                    string _fileServerPath = Path.Combine(HostingEnvironment.MapPath(_location), _fileName);
                    _file.SaveAs(_fileServerPath);
                    _path += _location.Replace("~", "") + _fileName + ",";
                }
                
            }
            return _path;
        }

        public static List<SelectListItem> BindDDl(DataTable dt, string value = null)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (dt != null && dt.Rows.Count > 0)
            {
                list.Add(new SelectListItem() { Text = "--Select--", Value = "" });
                foreach (DataRow item in dt.Rows)
                {
                    if (Convert.ToString(item[0]) == value)
                        list.Add(new SelectListItem() { Text = Convert.ToString(item[1]), Value = Convert.ToString(item[0]), Selected = true });
                    else
                        list.Add(new SelectListItem() { Text = Convert.ToString(item[1]), Value = Convert.ToString(item[0]) });
                }
            }
            else
            {
                list.Add(new SelectListItem() { Text = "--none--", Value = "" });
            }
            return list;
        }

        public string apicall(string url)
        {
            HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);

            try
            {
                HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();

                StreamReader sr = new StreamReader(httpres.GetResponseStream());

                string results = sr.ReadToEnd();

                sr.Close();
                return results;

            }
            catch
            {
                return "0";
            }
        }

        public static string ConvertTableToList(DataTable dt)
        {


            JavaScriptSerializer js = new JavaScriptSerializer();
            if (dt != null && dt.Rows.Count > 0)
            {


                Hashtable[] pr = new Hashtable[dt.Rows.Count];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Hashtable ch = new Hashtable();
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string columnName = Convert.ToString(dt.Columns[j]).Replace("'", "").Replace('"', ' ');
                        string columnValue = Convert.ToString(dt.Rows[i][columnName]).Replace("'", "").Replace('"', ' '); ;
                        ch.Add(columnName, columnValue);
                    }
                    pr[i] = ch;
                }
                js.MaxJsonLength = 999999999;
                return js.Serialize(pr);
            }


            return "False";
        }

        public string CreateTransactPassword(int PasswordLength)
        {
            string _allowedChars = "0123456789";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }

        public string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "0123456789";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }

        public string ConvertDataTabletoString(DataTable dt)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);
        }

        public string GetIP()
        {
            string IP = "";
            string ipAdd = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ipAdd))
            {
                ipAdd = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                IP = ipAdd;
            }
            else
            {
                IP = ipAdd;
            }
            return IP;
        }



        #endregion _qe
    }
}