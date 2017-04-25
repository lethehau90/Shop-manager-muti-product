using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Bill_customers_Model //Hóa đơn khách hàng
    {
        // Các thuộc tính của lớp 
        public int billid { get; set; }
        public int userid { get; set; }
        public string totalmoney { get; set; }
        public DateTime idate { get; set; }
        public DateTime xdate { get; set; }
        public string request { get; set; } //yêu cầu
        public string typepay { get; set; } //kieu thanh toan
        public int state { get; set; } //trạng thái
        public string lang { get; set; }
        public int show { get; set; } 

    }
}