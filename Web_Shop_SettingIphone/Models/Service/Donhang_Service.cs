using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Web_Shop_SettingIphone.Models.Entity;
using Web_Shop_SettingIphone.Models.Command;
using Web_Shop_SettingIphone.Models.Data;

namespace Web_Shop_SettingIphone.Models.Service
{
    public class Donhang_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();
        public IList<Donhang_Model> GetAll()
        {
            IList<Donhang_Model> result = new List<Donhang_Model>();

            result = Connect_Enttity.Donhangs.Select(x => new Donhang_Model
            {
                IDhd= x.IDhd,
                IDuser=(int)(x.IDuser),
                SDT=x.SDT,
                Hoten=x.Hoten,
                Mail=x.Mail,
                Diachi=x.Diachi,
                Tinh=x.Tinh,
                Huyen=x.Huyen,
                Xungho=x.Xungho,
                Hinhthucgiaohang=x.Hinhthucthanhtoan,
                Goidichvu=x.Goidichvu,
                Tongtienhang = Convert.ToDouble(x.Tongtienhang),
                Thanhtoan=Convert.ToDouble(x.Thanhtoan),
                ngaydathang=Convert.ToDateTime(x.ngaydathang),
                KH=x.KH,
                Duyet=x.Duyet,
                Khuyenmai=x.Khuyenmai,
                Hinhthucthanhtoan= x.Hinhthucgiaohang,
                GhiChuKhac=x.GhiChuKhac,
                Tiengiamgia = (int)(x.Tiengiamgia)
                
            }).ToList();

            return result;
        }
        public IList<Donhang_Model> GetId(Donhang_Model model)
        {
            IList<Donhang_Model> result = new List<Donhang_Model>();

            result = Connect_Enttity.Donhangs.Where(x => x.IDhd == model.IDhd).Select(x => new Donhang_Model
            {
                IDhd = x.IDhd,
                IDuser = (int)(x.IDuser),
                SDT = x.SDT,
                Hoten = x.Hoten,
                Mail = x.Mail,
                Diachi = x.Diachi,
                Tinh = x.Tinh,
                Huyen = x.Huyen,
                Xungho = x.Xungho,
                Hinhthucgiaohang = x.Hinhthucthanhtoan,
                Goidichvu = x.Goidichvu,
                Tongtienhang = Convert.ToDouble(x.Tongtienhang),
                Thanhtoan = Convert.ToDouble(x.Thanhtoan),
                ngaydathang = Convert.ToDateTime(x.ngaydathang),
                KH = x.KH,
                Duyet = x.Duyet,
                Khuyenmai = x.Khuyenmai,
                Hinhthucthanhtoan = x.Hinhthucgiaohang,
                GhiChuKhac = x.GhiChuKhac,
                Tiengiamgia = (int)(x.Tiengiamgia)
            }).ToList();

            return result;
        }
        public IEnumerable<Donhang_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Donhang_Model> ReadID(Donhang_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Donhangs where c.IDhd == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Donhangs.Remove(data);
                Connect_Enttity.SaveChanges();
                Dispose();
            }

        }

        public void DeleteAll(int[] Id)
        {
            if (Id != null)
            {
                foreach (var i in Id)
                {
                    var data = Connect_Enttity.Donhangs.FirstOrDefault(x => x.IDhd.Equals(i));
                    Connect_Enttity.Donhangs.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }
        }

        public void Create(Donhang_Model model)
        {
            var entity = new Donhang();
            entity.IDuser = (int)(model.IDuser);
            entity.SDT = model.SDT;
            entity.Hoten = model.Hoten;
            entity.Mail = model.Mail;
            entity.Diachi = model.Diachi;
            entity.Tinh = model.Tinh;
            entity.Huyen = model.Huyen;
            entity.Xungho = model.Xungho;
            entity.Hinhthucgiaohang = model.Hinhthucthanhtoan;
            entity.Goidichvu = model.Goidichvu;
            entity.Tongtienhang = Convert.ToDouble(model.Tongtienhang);
            entity.Thanhtoan = Convert.ToDouble(model.Thanhtoan);
            entity.ngaydathang = Convert.ToDateTime(model.ngaydathang);
            entity.KH = model.KH;
            entity.Duyet = model.Duyet;
            entity.Khuyenmai = model.Khuyenmai;
            entity.Hinhthucthanhtoan = model.Hinhthucgiaohang;
            entity.GhiChuKhac = model.GhiChuKhac;
            entity.Tiengiamgia = (int)(model.Tiengiamgia);

            Connect_Enttity.Donhangs.Add(entity);
            Connect_Enttity.SaveChanges();
            //Dispose();
        }
        public void Update(Donhang_Model model)
        {
            var data = Connect_Enttity.Donhangs.FirstOrDefault(x => x.IDhd == model.IDhd);
            if (data != null)
            {
                data.IDuser = (int)(model.IDuser);
                data.SDT = model.SDT;
                data.Hoten = model.Hoten;
                data.Mail = model.Mail;
                data.Diachi = model.Diachi;
                data.Tinh = model.Tinh;
                data.Huyen = model.Huyen;
                data.Xungho = model.Xungho;
                data.Hinhthucgiaohang = model.Hinhthucthanhtoan;
                data.Goidichvu = model.Goidichvu;
                data.Tongtienhang = Convert.ToDouble(model.Tongtienhang);
                data.Thanhtoan = Convert.ToDouble(model.Thanhtoan);
                data.ngaydathang = Convert.ToDateTime(model.ngaydathang);
                data.KH = model.KH;
                data.Duyet = model.Duyet;
                data.Khuyenmai = model.Khuyenmai;
                data.Hinhthucthanhtoan = model.Hinhthucgiaohang;
                data.GhiChuKhac = model.GhiChuKhac;
                data.Tiengiamgia = (int)(model.Tiengiamgia);

                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }
        public void Dispose()
        {
            Connect_Enttity.Dispose();
        }
    }
}