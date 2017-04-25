using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Billdetail_Model //chi tiết Hóa đơn khách hàng
    {
        // Các thuộc tính của lớp 
        public int id { get; set; }
        public int bilid { get; set; }  // khoa ngoai Hóa đơn khách hàng
        public int proid { get; set; } //id san pham
        public int sizeid { get; set; }
        public int colorid { get; set; }
        public int quantity { get; set; }
        public string bilprice { get; set; }
        public string bilpricevnd { get; set; }
        public string bilmoney { get; set; }
        public int billlocation { get; set; }
        public DateTime Date { get; set; }
        public int status { get; set; }  //trạng thái

    }
}