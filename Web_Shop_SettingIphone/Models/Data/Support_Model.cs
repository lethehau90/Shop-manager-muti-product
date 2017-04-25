using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Support_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public int Type { get; set; }//Kiểu
        public string Nick { get; set; }
        public int Ord { get; set; }
        public int Active { get; set; }
        public int GroupSupportId { get; set; }//nhóm hỗ trợ
        public string Lang { get; set; }
        public int Location { get; set; } //Vị trí
    }
}