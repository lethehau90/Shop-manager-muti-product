using Cb.DBUtility;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Command
{
    public class GetProSql
    {
        public static Database CreateDB()
        {
            return new SqlDatabase(ConfigurationManager.ConnectionStrings["Web_Shop_SettingIphoneEntities"].ConnectionString);// DatabaseFactory.CreateDatabase(ConfigurationManager.ConnectionStrings["SQLConnString1"].ConnectionString);
        }
        public DataSet sp_tblSanPham_PagingBySearch(int page, int recordPage, int pagesize, string Search)
        {
            try
            {
                DGCParameter[] parammeters = new DGCParameter[4];
                parammeters[0] = new DGCParameter("@currPage", DbType.Int32, page);
                parammeters[1] = new DGCParameter("@recodperpage", DbType.Int32, recordPage);
                parammeters[2] = new DGCParameter("@Pagesize", DbType.Int32, pagesize);
                parammeters[3] = new DGCParameter("@Search", DbType.String, @Search);

                return DBHelper.ExcuteDataSetFromStore("sp_tblSanPham_PagingBySearch", parammeters);

            }
            catch (Exception)
            {
                return null;
                //throw;@
            }
        }

        public static DataTable ExcuteFromCmd(string query, DGCParameter[] parameters)
        {
            DataTable dt = null;
            Database db = CreateDB();
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(query);
                GenerateQuery.PrepareParametersList(cmd, parameters);
                cmd.CommandTimeout = 200;
                DataSet ds = db.ExecuteDataSet(cmd);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                Write2Log.WriteLogs("Generic<T>", "ExcuteFromCmd(string query, DGCParameter[] parameters)", ex.Message);
            }
            return dt;
        }
    }
}