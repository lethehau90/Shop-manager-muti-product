using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Document_Model //tài liệu
    {
        public int Id { get; set; }
        public string Code { get; set; } //Mã
        public string Name { get; set; }
        public string Images { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime EffectiveDate { get; set; } //Ngày có hiệu lực
        public string Info { get; set; } //thông tin

        [AllowHtml]
        public string File { get; set; }
        public int Ord { get; set; }
        public int Priority { get; set; } //Sự ưu tiên
        public int Active { get; set; }
        public int TypeId { get; set; } //id loại
        public int MemberId { get; set; } //id thành viên
        public string Lang { get; set; }
        public string NameEn { get; set; }

        [AllowHtml]
        public string infoEn { get; set; }
    }
}