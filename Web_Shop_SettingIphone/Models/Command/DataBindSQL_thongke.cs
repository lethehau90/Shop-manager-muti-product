using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
public class DataBindSQL
{
    public static string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["RemoingayEntities"].ConnectionString;
    public static SqlConnection connection;
    public static SqlConnection Getconnection()
    {
        if (connection == null)
        {
            connection = new SqlConnection(connectionstring);
        }
        if (connection.State == ConnectionState.Closed)
        {
            connection.Open();
            return connection;
        }
        else
        {

            return connection;
        }
    }

   
  
    public DataTable TableThongKe()
    {
        DataTable dtb = new DataTable();
        // Khai báo chuỗi kết nối
      // string ConnectionString =@"Server =.\SQL2005;Initial Catalog=QuanLyThuVien;User ID=sa;Password=sa";
        SqlConnection Conn = new SqlConnection(connectionstring);
        try
        {
            // Mở kết nối
            Conn.Open();
            DataSet ds = new DataSet();
            SqlCommand cmdUpd = new SqlCommand("spThongKe_Edit", Conn);
            cmdUpd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmdUpd);
            
            // Đổ dữ liệu vào DataSet
            da.Fill(ds);
            dtb = ds.Tables[0];
          //  var datamodel = Connnect.spThongKe_Edit().ToList();
           // dtb = datamodel[0];

        }
        catch { }
        finally
        {
            if (Conn.State == ConnectionState.Open)
                Conn.Close();
            Conn.Dispose();
        }
        return dtb;
    }
}
