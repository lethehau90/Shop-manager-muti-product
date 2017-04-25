using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Custumer_Model //đăng ký 
    {
        public int iusid { get; set; }
        public string vusername { get; set; } //tên
        public string vpassword { get; set; }
        public string vcusname { get; set; }  //tên khác
        public string dbirthday { get; set; } //sinh nhật
        public string vprovince { get; set; } //tỉnh thành
        public string vaddress { get; set; }
        public string vphone { get; set; } //số phone
        public string vmobile { get; set; } //số di động
        public string vemail { get; set; }
        public System.DateTime dcreatedate { get; set; } //ngày tạo
        public short istatus { get; set; } //trạng thái
    }
}