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
    public class GroupNewMenuSanPhamDetail_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<GroupNewMenuSanPhamDetail_Model> GetAll()
        {
            IList<GroupNewMenuSanPhamDetail_Model> result = new List<GroupNewMenuSanPhamDetail_Model>();

            result = Connect_Enttity.GroupNewMenuSanPhamDetails.Select(x => new GroupNewMenuSanPhamDetail_Model
            {
                Id = x.Id,
                Name = x.Name,
                NameEn = x.NameEn,

                Tag = x.Tag,
                IDthuonghieu= x.IDthuonghieu,
                NguonSanPham=x.NguonSanPham,
                Mausac=x.Mausac,
                Kichthuoc=x.Kichthuoc,
                SanphamCungloai=x.SanphamCungloai,
                Donvi=x.Donvi,
                Luotdanhgia= x.Luotdanhgia,
                Video=x.Video,

                Title = x.Title,
                Description = x.Description,
                Keyword = x.Keyword,

                Priority = (int)(x.Priority),
                Index = (int)(x.Index),
                Order = (int)(x.Order),
                Active = (int)(x.Active),

                GroupNewsCatTag = x.GroupNewsCatTag,
                Cateprolevel1 = x.Cateprolevel1,
                Cateprolevel2 = x.Cateprolevel2,
                Cateprolevel3 = x.Cateprolevel3,

                Image = x.Image,
                Image1 = x.Image1,
                Image2 = x.Image2,
                Image3 = x.Image3,
                Image4 = x.Image4,
                Image5 = x.Image5,

                Content = x.Content,
                ContentEn = x.ContentEn,

                Detail = x.Detail,
                DetailEn = x.DetailEn,

                Khuyenmai=x.Khuyenmai,
                KhuyenmaiEn = x.KhuyenmaiEn,

                Baohanh=x.Baohanh,
                BaohanhEn = x.BaohanhEn,

                DacDiemNoiBat = x.DacDiemNoiBat,
                DacDiemNoiBatEn = x.DacDiemNoiBatEn,

                Thongdiep = x.Thongdiep,
                ThongdiepEn = x.ThongdiepEn,
                
                Seri = x.Seri,
                Luotxem = (int)(x.Luotxem),
                Soluongmua = (int)(x.Soluongmua),
                DateCreate = (DateTime)(x.DateCreate),
                DateView = (DateTime)(x.DateView),

                //giá trị
                Stock = (int)(x.Stock),
                Number_Stock = (int)(x.Number_Stock),
                Vat = (bool)(x.Vat),

                Gianhaphang = (double)(x.Gianhaphang),
                Giaban = (double)(x.Giaban),
                Phantramkhuyenmai = (int)(x.Phantramkhuyenmai),
                Giabankhuyenmai = (double)(x.Giabankhuyenmai),

                DateStart_Event = (DateTime)(x.DateStart_Event),
                DateEnd_Event = (DateTime)(x.DateEnd_Event),
                Giaban_Event = (double)(x.Giaban_Event),

                Content_Event = x.Content_Event,
                Content_EventEn = x.Content_EventEn

            }).ToList();

            return result;
        }

        public IList<GroupNewMenuSanPhamDetail_Model> GetId(GroupNewMenuSanPhamDetail_Model model)
        {
            IList<GroupNewMenuSanPhamDetail_Model> result = new List<GroupNewMenuSanPhamDetail_Model>();

            result = Connect_Enttity.GroupNewMenuSanPhamDetails.Where(x => x.Id == model.Id).Select(x => new GroupNewMenuSanPhamDetail_Model
            {
                Id = x.Id,
                Name = x.Name,
                NameEn = x.NameEn,

                Tag = x.Tag,
                IDthuonghieu = x.IDthuonghieu,
                NguonSanPham = x.NguonSanPham,
                Mausac = x.Mausac,
                Kichthuoc = x.Kichthuoc,
                SanphamCungloai = x.SanphamCungloai,
                Donvi = x.Donvi,
                Luotdanhgia = x.Luotdanhgia,
                Video = x.Video,

                Title = x.Title,
                Description = x.Description,
                Keyword = x.Keyword,

                Priority = (int)(x.Priority),
                Index = (int)(x.Index),
                Order = (int)(x.Order),
                Active = (int)(x.Active),

                GroupNewsCatTag = x.GroupNewsCatTag,
                Cateprolevel1 = x.Cateprolevel1,
                Cateprolevel2 = x.Cateprolevel2,
                Cateprolevel3 = x.Cateprolevel3,

                Image = x.Image,
                Image1 = x.Image1,
                Image2 = x.Image2,
                Image3 = x.Image3,
                Image4 = x.Image4,
                Image5 = x.Image5,

                Content = x.Content,
                ContentEn = x.ContentEn,

                Detail = x.Detail,
                DetailEn = x.DetailEn,

                Khuyenmai = x.Khuyenmai,
                KhuyenmaiEn = x.KhuyenmaiEn,

                Baohanh = x.Baohanh,
                BaohanhEn = x.BaohanhEn,

                DacDiemNoiBat = x.DacDiemNoiBat,
                DacDiemNoiBatEn = x.DacDiemNoiBatEn,

                Thongdiep = x.Thongdiep,
                ThongdiepEn = x.ThongdiepEn,

                Seri = x.Seri,
                Luotxem = (int)(x.Luotxem),
                Soluongmua = (int)(x.Soluongmua),
                DateCreate = Convert.ToDateTime(x.DateCreate),
                DateView = Convert.ToDateTime(x.DateView),

                //giá trị
                Stock = (int)(x.Stock),
                Number_Stock = (int)(x.Number_Stock),
                Vat = (bool)(x.Vat),

                Gianhaphang = (double)(x.Gianhaphang),
                Giaban = (double)(x.Giaban),
                Phantramkhuyenmai = (int)(x.Phantramkhuyenmai),
                Giabankhuyenmai = (double)(x.Giabankhuyenmai),

                DateStart_Event = Convert.ToDateTime(x.DateStart_Event),
                DateEnd_Event = Convert.ToDateTime(x.DateEnd_Event),
                Giaban_Event = (double)(x.Giaban_Event),

                Content_Event = x.Content_Event,
                Content_EventEn = x.Content_EventEn

            }).ToList();

            return result;
        }

        public IEnumerable<GroupNewMenuSanPhamDetail_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<GroupNewMenuSanPhamDetail_Model> ReadID(GroupNewMenuSanPhamDetail_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.GroupNewMenuSanPhamDetails where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.GroupNewMenuSanPhamDetails.Remove(data);
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
                    var data = Connect_Enttity.GroupNewMenuSanPhamDetails.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.GroupNewMenuSanPhamDetails.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(GroupNewMenuSanPhamDetail_Model model)
        {
            var data = Connect_Enttity.GroupNewMenuSanPhamDetails.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new GroupNewMenuSanPhamDetail();

                entity.Name = model.Name;
                entity.NameEn = model.NameEn;

                entity.Tag = model.Tag;
                entity.IDthuonghieu = model.IDthuonghieu;
                entity.NguonSanPham = model.NguonSanPham;
                entity.Mausac = model.Mausac;
                entity.Kichthuoc = model.Kichthuoc;
                entity.SanphamCungloai = model.SanphamCungloai;
                entity.Donvi = model.Donvi;
                entity.Luotdanhgia = model.Luotdanhgia;
                entity.Video = model.Video;

                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Keyword = model.Keyword;

                entity.Priority = (int)(model.Priority);
                entity.Index = (int)(model.Index);
                entity.Order = (int)(model.Order);
                entity.Active = (int)(model.Active);

                entity.GroupNewsCatTag = model.GroupNewsCatTag;
                entity.Cateprolevel1 = model.Cateprolevel1;
                entity.Cateprolevel2 = model.Cateprolevel2;
                entity.Cateprolevel3 = model.Cateprolevel3;

                entity.Image = model.Image;
                entity.Image1 = model.Image1;
                entity.Image2 = model.Image2;
                entity.Image3 = model.Image3;
                entity.Image4 = model.Image4;
                entity.Image5 = model.Image5;

                entity.Content = model.Content;
                entity.ContentEn = model.ContentEn;

                entity.Detail = model.Detail;
                entity.DetailEn = model.DetailEn;

                entity.Khuyenmai = model.Khuyenmai;
                entity.KhuyenmaiEn = model.KhuyenmaiEn;

                entity.Baohanh = model.Baohanh;
                entity.BaohanhEn = model.BaohanhEn;

                entity.DacDiemNoiBat = model.DacDiemNoiBat;
                entity.DacDiemNoiBatEn = model.DacDiemNoiBatEn;

                entity.Thongdiep = model.Thongdiep;
                entity.ThongdiepEn = model.ThongdiepEn;

                entity.Seri = model.Seri;
                entity.Luotxem = (int)(model.Luotxem);
                entity.Soluongmua = (int)(model.Soluongmua);
                entity.DateCreate = Convert.ToDateTime(model.DateCreate);

                if (model.DateView != null)
                {
                    entity.DateView = Convert.ToDateTime(model.DateView);
                }
                else
                {
                    entity.DateView = null;
                }
                  

                //giá trị
                entity.Stock = (int)(model.Stock);
                entity.Number_Stock = (int)(model.Number_Stock);
                entity.Vat = (bool)(model.Vat);

                entity.Gianhaphang = (double)(model.Gianhaphang);
                entity.Giaban = (double)(model.Giaban);
                entity.Phantramkhuyenmai = (int)(model.Phantramkhuyenmai);
                entity.Giabankhuyenmai = (double)(model.Giabankhuyenmai);

                //start event
                if (model.DateStart_Event != null )
                {
                    entity.DateStart_Event = Convert.ToDateTime(model.DateStart_Event);
                }
                else
                {
                    entity.DateStart_Event = null;
                }

                //end event
                if (model.DateEnd_Event != null)
                {
                    entity.DateEnd_Event = Convert.ToDateTime(model.DateEnd_Event);
                }
                else
                {
                    entity.DateEnd_Event = null;
                }
                
                entity.Giaban_Event = (double)(model.Giaban_Event);

                entity.Content_Event = model.Content_Event;
                entity.Content_EventEn = model.Content_EventEn;

                Connect_Enttity.GroupNewMenuSanPhamDetails.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(GroupNewMenuSanPhamDetail_Model model)
        {
            var data = Connect_Enttity.GroupNewMenuSanPhamDetails.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
                data.NameEn = model.NameEn;

                data.Tag = model.Tag;
                data.IDthuonghieu = model.IDthuonghieu;
                data.NguonSanPham = model.NguonSanPham;
                data.Mausac = model.Mausac;
                data.Kichthuoc = model.Kichthuoc;
                data.SanphamCungloai = model.SanphamCungloai;
                data.Donvi = model.Donvi;
                data.Luotdanhgia = model.Luotdanhgia;
                data.Video = model.Video;

                data.Title = model.Title;
                data.Description = model.Description;
                data.Keyword = model.Keyword;

                data.Priority = (int)(model.Priority);
                data.Index = (int)(model.Index);
                data.Order = (int)(model.Order);
                data.Active = (int)(model.Active);

                data.GroupNewsCatTag = model.GroupNewsCatTag;
                data.Cateprolevel1 = model.Cateprolevel1;
                data.Cateprolevel2 = model.Cateprolevel2;
                data.Cateprolevel3 = model.Cateprolevel3;

                data.Image = model.Image;
                data.Image1 = model.Image1;
                data.Image2 = model.Image2;
                data.Image3 = model.Image3;
                data.Image4 = model.Image4;
                data.Image5 = model.Image5;

                data.Content = model.Content;
                data.ContentEn = model.ContentEn;

                data.Detail = model.Detail;
                data.DetailEn = model.DetailEn;

                data.Khuyenmai = model.Khuyenmai;
                data.KhuyenmaiEn = model.KhuyenmaiEn;

                data.Baohanh = model.Baohanh;
                data.BaohanhEn = model.BaohanhEn;

                data.DacDiemNoiBat = model.DacDiemNoiBat;
                data.DacDiemNoiBatEn = model.DacDiemNoiBatEn;

                data.Thongdiep = model.Thongdiep;
                data.ThongdiepEn = model.ThongdiepEn;

                data.Seri = model.Seri;
                data.Luotxem = (int)(model.Luotxem);
                data.Soluongmua = (int)(model.Soluongmua);
                data.DateCreate = Convert.ToDateTime(model.DateCreate);

                if (model.DateView != null)
                {
                    data.DateView = Convert.ToDateTime(model.DateView);
                }
                else
                {
                    data.DateView = null;
                }

                //giá trị
                data.Stock = (int)(model.Stock);
                data.Number_Stock = (int)(model.Number_Stock);
                data.Vat = (bool)(model.Vat);

                data.Gianhaphang = (double)(model.Gianhaphang);
                data.Giaban = (double)(model.Giaban);
                data.Phantramkhuyenmai = (int)(model.Phantramkhuyenmai);
                data.Giabankhuyenmai = (double)(model.Giabankhuyenmai);

                //start event
                if (model.DateStart_Event != null)
                {
                    data.DateStart_Event = Convert.ToDateTime(model.DateStart_Event);
                }
                else
                {
                    data.DateStart_Event = null;
                }

                //end event
                if (model.DateEnd_Event != null)
                {
                    data.DateEnd_Event = Convert.ToDateTime(model.DateEnd_Event);
                }
                else
                {
                    data.DateEnd_Event = null;
                }

                data.Giaban_Event = (double)(model.Giaban_Event);

                data.Content_Event = model.Content_Event;
                data.Content_EventEn = model.Content_EventEn;

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