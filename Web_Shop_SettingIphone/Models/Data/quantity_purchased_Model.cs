using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class quantity_purchased_Model //số lượng mua tăng giá
    {
        public int Id_quantity { get; set; }
        public int Sl_mua { get; set; }
        public int Phan_tram_tang { get; set; }
        public bool Active { get; set; }
    }
}