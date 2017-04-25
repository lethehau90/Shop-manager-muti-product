using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Thanhvien_Model
    {
        public int id { get; set; }
        public string Taikhoan { get; set; }
        public string Matkhau { get; set; }
        public string Hoten { get; set; }
        public Nullable<DateTime> Ngaysinh { get; set; }
        public string Gioitinh { get; set; }
        public string Diachi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public bool Actice { get; set; }
        public int thutu { get; set; }
        public Nullable<DateTime> CreateDate { get; set; }
    }
}