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
    public class DientuMathang_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<DientuMathang_Model> GetAll()
        {
            IList<DientuMathang_Model> result = new List<DientuMathang_Model>();

            result = Connect_Enttity.DientuMathangs.Select(x => new DientuMathang_Model
            {
                Id = x.Id,
                Seri = x.Seri,
                Tenhang = x.Tenhang,
                Img = x.Img,
                ThumImg = x.ThumImg,
                Thum_img_img = x.Thum_img_img,
                Idnsx = x.Idnsx,
                Giaban = x.Giaban,
                Giamua = x.Giamua,
                Soluong = x.Soluong,
                Tinhtrang = x.Tinhtrang,
                Donvi = x.Donvi,
                Baohanh = x.Baohanh,
                Ngaynhap = x.Ngaynhap,
                Danhgia = x.Danhgia,
                Luotxem = x.Luotxem,
                Vat = x.Vat,
                Lienhe = x.Lienhe,
                Forder = x.Forder,
                Baiviet = x.Baiviet,
                Thongso = x.Thongso,
                Mota = x.Mota,
                Giagiam = x.Giagiam,
                Phantramkm = x.Phantramkm,
                Title = x.Title,
                Keyword = x.Keyword,
                Description = x.Description,
                Khuvuc = x.Khuvuc,
                thuoctinh = x.thuoctinh,
                khuyenmai = x.khuyenmai,
                khuyenmai_html = x.khuyenmai_html,
                Ord = x.Ord,
                Active = x.Active,
                Idmenu = x.Idmenu,
                Priority = x.Priority,
                Index = x.Index,
                Idthuoctinh = x.Idthuoctinh,
                Diemdanhgia = x.Diemdanhgia,
                Ngayxemganday = x.Ngayxemganday,
                Tag = x.Tag,
                GroupNewsCatTag = x.GroupNewsCatTag,
                Cateprolevel1 = (x.Cateprolevel1),
                Cateprolevel2 = x.Cateprolevel2,
                Cateprolevel3 = (x.Cateprolevel3),
                Soluongmua= x.Soluongmua
            }).ToList();

            return result;
        }

        public IList<DientuMathang_Model> GetId(DientuMathang_Model model)
        {
            IList<DientuMathang_Model> result = new List<DientuMathang_Model>();

            result = Connect_Enttity.DientuMathangs.Where(x => x.Id == model.Id).Select(x => new DientuMathang_Model
            {
                Id = x.Id,
                Seri = x.Seri,
                Tenhang = x.Tenhang,
                Img = x.Img,
                ThumImg = x.ThumImg,
                Thum_img_img = x.Thum_img_img,
                Idnsx = x.Idnsx,
                Giaban = x.Giaban,
                Giamua = x.Giamua,
                Soluong = x.Soluong,
                Tinhtrang = x.Tinhtrang,
                Donvi = x.Donvi,
                Baohanh = x.Baohanh,
                Ngaynhap = x.Ngaynhap,
                Danhgia = x.Danhgia,
                Luotxem = x.Luotxem,
                Vat = x.Vat,
                Lienhe = x.Lienhe,
                Forder = x.Forder,
                Baiviet = x.Baiviet,
                Thongso = x.Thongso,
                Mota = x.Mota,
                Giagiam = x.Giagiam,
                Phantramkm = x.Phantramkm,
                Title = x.Title,
                Keyword = x.Keyword,
                Description = x.Description,
                Khuvuc = x.Khuvuc,
                thuoctinh = x.thuoctinh,
                khuyenmai = x.khuyenmai,
                khuyenmai_html = x.khuyenmai_html,
                Ord = x.Ord,
                Active = x.Active,
                Idmenu = x.Idmenu,
                Priority = x.Priority,
                Idthuoctinh = x.Idthuoctinh,
                Diemdanhgia = x.Diemdanhgia,
                Ngayxemganday = x.Ngayxemganday,
                Tag = x.Tag,
                GroupNewsCatTag = x.GroupNewsCatTag,
                Cateprolevel1 = (x.Cateprolevel1),
                Cateprolevel2 = x.Cateprolevel2,
                Cateprolevel3 = (x.Cateprolevel3),
                Soluongmua = x.Soluongmua
            }).ToList();

            return result;
        }
        public IEnumerable<DientuMathang_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<DientuMathang_Model> ReadID(DientuMathang_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.DientuMathangs where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.DientuMathangs.Remove(data);
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
                    var data = Connect_Enttity.DientuMathangs.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.DientuMathangs.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(DientuMathang_Model model)
        {
            var data = Connect_Enttity.DientuMathangs.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new DientuMathang();
                entity.Seri = model.Seri;
                entity.Tenhang = model.Tenhang;
                entity.Img = model.Img;
                entity.ThumImg = model.ThumImg;
                entity.Thum_img_img = model.Thum_img_img;
                entity.Idnsx = model.Idnsx;
                entity.Giaban = model.Giaban;
                entity.Giamua = model.Giamua;
                entity.Soluong = model.Soluong;
                entity.Tinhtrang = model.Tinhtrang;
                entity.Donvi = model.Donvi;
                entity.Baohanh = model.Baohanh;
                //entity.Ngaynhap = model.Ngaynhap;
                if (model.Ngaynhap != null)
                {
                    entity.Ngaynhap = Convert.ToDateTime(model.Ngaynhap);
                }
                else
                {
                    entity.Ngaynhap = null;
                }
                entity.Danhgia = model.Danhgia;
                entity.Luotxem = model.Luotxem;
                entity.Vat = model.Vat;
                entity.Lienhe = model.Lienhe;
                entity.Forder = model.Forder;
                entity.Baiviet = model.Baiviet;
                entity.Thongso = model.Thongso;
                entity.Mota = model.Mota;
                entity.Giagiam = model.Giagiam;
                entity.Phantramkm = model.Phantramkm;
                entity.Title = model.Title;
                entity.Keyword = model.Keyword;
                entity.Description = model.Description;
                entity.Khuvuc = model.Khuvuc;
                entity.thuoctinh = model.thuoctinh;
                entity.khuyenmai = model.khuyenmai;
                entity.khuyenmai_html = model.khuyenmai_html;
                entity.Ord = model.Ord;
                entity.Active = model.Active;
                entity.Idmenu = model.Idmenu;
                entity.Priority = model.Priority;
                entity.Index = model.Index;
                entity.Idthuoctinh = model.Idthuoctinh;
                entity.Diemdanhgia = model.Diemdanhgia;
                //entity.Ngayxemganday = model.Ngayxemganday;
                if (model.Ngayxemganday != null)
                {
                    entity.Ngayxemganday = Convert.ToDateTime(model.Ngayxemganday);
                }
                else
                {
                    entity.Ngayxemganday = null;
                }
                entity.Tag = model.Tag;
                entity.GroupNewsCatTag = model.GroupNewsCatTag;
                entity.Cateprolevel1 = (model.Cateprolevel1);
                entity.Cateprolevel2 = model.Cateprolevel2;
                entity.Cateprolevel3 = (model.Cateprolevel3);
                entity.Soluongmua = model.Soluongmua;

                Connect_Enttity.DientuMathangs.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(DientuMathang_Model model)
        {
            var data = Connect_Enttity.DientuMathangs.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Id = model.Id;
                data.Seri = model.Seri;
                data.Tenhang = model.Tenhang;
                data.Img = model.Img;
                data.ThumImg = model.ThumImg;
                data.Thum_img_img = model.Thum_img_img;
                data.Idnsx = model.Idnsx;
                data.Giaban = model.Giaban;
                data.Giamua = model.Giamua;
                data.Soluong = model.Soluong;
                data.Tinhtrang = model.Tinhtrang;
                data.Donvi = model.Donvi;
                data.Baohanh = model.Baohanh;
                //data.Ngaynhap = model.Ngaynhap;
                if (model.Ngaynhap != null)
                {
                    data.Ngaynhap = Convert.ToDateTime(model.Ngaynhap);
                }
                else
                {
                    data.Ngaynhap = null;
                }
                data.Danhgia = model.Danhgia;
                data.Luotxem = model.Luotxem;
                data.Vat = model.Vat;
                data.Lienhe = model.Lienhe;
                data.Forder = model.Forder;
                data.Baiviet = model.Baiviet;
                data.Thongso = model.Thongso;
                data.Mota = model.Mota;
                data.Giagiam = model.Giagiam;
                data.Phantramkm = model.Phantramkm;
                data.Title = model.Title;
                data.Keyword = model.Keyword;
                data.Description = model.Description;
                data.Khuvuc = model.Khuvuc;
                data.thuoctinh = model.thuoctinh;
                data.khuyenmai = model.khuyenmai;
                data.khuyenmai_html = model.khuyenmai_html;
                data.Ord = model.Ord;
                data.Active = model.Active;
                data.Idmenu = model.Idmenu;
                data.Priority = model.Priority;
                data.Index = model.Index;
                data.Idthuoctinh = model.Idthuoctinh;
                data.Diemdanhgia = model.Diemdanhgia;
                //data.Ngayxemganday = model.Ngayxemganday;
                if (model.Ngayxemganday != null)
                {
                    data.Ngayxemganday = Convert.ToDateTime(model.Ngayxemganday);
                }
                else
                {
                    data.Ngayxemganday = null;
                }
                data.Tag = model.Tag;
                data.GroupNewsCatTag = model.GroupNewsCatTag;
                data.Cateprolevel1 = (model.Cateprolevel1);
                data.Cateprolevel2 = model.Cateprolevel2;
                data.Cateprolevel3 = (model.Cateprolevel3);
                data.Soluongmua = model.Soluongmua;

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