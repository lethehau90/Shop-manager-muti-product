using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class DientuChitiethinh_Model
    {
        public int Id { get; set; }
        public string IdProduct { get; set; }
        public string Images { get; set; }
        public string ThumImg { get; set; }
        public string Idmau { get; set; }
        public string IdSize { get; set; }
        public Nullable<double> Giaban { get; set; }
        public Nullable<double> Giacu { get; set; }
        public Nullable<int> Soluong { get; set; }
        public Nullable<int> Phantramkm { get; set; }
        public Nullable<int> Tinhtrang { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> Ord { get; set; }
        public string IdTag { get; set; }
        public string Iddungluong { get; set; }
        public string Images1 { get; set; }
        public string Images2 { get; set; }
        public string Images3 { get; set; }
        public string Images4 { get; set; }
    }
}