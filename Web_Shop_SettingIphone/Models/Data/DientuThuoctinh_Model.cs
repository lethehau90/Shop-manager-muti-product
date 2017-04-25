using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class DientuThuoctinh_Model
    {
        public int Id { get; set; }
        public string IdTag { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public Nullable<int> Idproduct { get; set; }
        public Nullable<int> Idthuoctinh { get; set; }
        public Nullable<int> Idcapthuoctinh { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> Ord { get; set; }
        public string Content { get; set; }
        public string TagProduct { get; set; }
    }
}