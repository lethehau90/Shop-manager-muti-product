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
    public class Tintuc_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Tintuc_Model> GetAll()
        {
            IList<Tintuc_Model> result = new List<Tintuc_Model>();

            result = Connect_Enttity.Tintucs.Select(x => new Tintuc_Model
            {
                Id = x.Id,
                Name = x.Name,
                Tag = x.Tag,
                Ngaydang=Convert.ToDateTime(x.Ngaydang),
                Tomtat = x.Tomtat,
                Noidung = x.Noidung,
                Tacgia = x.Tacgia,
                Luotxem = (int)(x.Luotxem),
                Hinhanh = x.Hinhanh,
                Title = x.Title,
                Description = x.Description,
                Keyword = x.Keyword,
                Active = (bool)(x.Active),
                Ord = (int)(x.Ord),
                Type = (int)(x.Type),
                Ngayxemganday = Convert.ToDateTime(x.Ngayxemganday),
                lienkiettinh = x.lienkiettinh,
                NameEn = x.NameEn,
                ContentEn = x.ContentEn,
                DetailEn = x.DetailEn,
                Nguon = x.Nguon
              
            }).ToList();

            return result;
        }

        public IList<Tintuc_Model> GetId(Tintuc_Model model)
        {
            IList<Tintuc_Model> result = new List<Tintuc_Model>();

            result = Connect_Enttity.Tintucs.Where(x => x.Id == model.Id).Select(x => new Tintuc_Model
            {
                Id = x.Id,
                Name = x.Name,
                Tag = x.Tag,
                Ngaydang = Convert.ToDateTime(x.Ngaydang),
                Tomtat = x.Tomtat,
                Noidung = x.Noidung,
                Tacgia = x.Tacgia,
                Luotxem = (int)(x.Luotxem),
                Hinhanh = x.Hinhanh,
                Title = x.Title,
                Description = x.Description,
                Keyword = x.Keyword,
                Active = (bool)(x.Active),
                Ord = (int)(x.Ord),
                Type = (int)(x.Type),
                Ngayxemganday = Convert.ToDateTime(x.Ngayxemganday),
                lienkiettinh = x.lienkiettinh,
                NameEn = x.NameEn,
                ContentEn = x.ContentEn,
                DetailEn = x.DetailEn,
                Nguon = x.Nguon

            }).ToList();

            return result;
        }

        public IEnumerable<Tintuc_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Tintuc_Model> ReadID(Tintuc_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Tintucs where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Tintucs.Remove(data);
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
                    var data = Connect_Enttity.Tintucs.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.Tintucs.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(Tintuc_Model model)
        {
            var data = Connect_Enttity.Tintucs.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new Tintuc();

                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Tag = model.Tag;
                entity.Ngaydang = DateTime.Now; //lấy ngày hiện tại
                entity.Tomtat = model.Tomtat;
                entity.Noidung = model.Noidung;
                entity.Tacgia = model.Tacgia;
                entity.Luotxem = (int)(model.Luotxem);
                entity.Hinhanh = model.Hinhanh;
                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Keyword = model.Keyword;
                entity.Active = (bool)(model.Active);
                entity.Ord = (int)(model.Ord);
                entity.Type = (int)(model.Type);
                entity.Ngayxemganday = null; //ngày xem rỗng
                entity.lienkiettinh = model.lienkiettinh;
                entity.NameEn = model.NameEn;
                entity.ContentEn = model.ContentEn;
                entity.DetailEn = model.DetailEn;
                entity.Nguon = model.Nguon;

                Connect_Enttity.Tintucs.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Tintuc_Model model)
        {
            var data = Connect_Enttity.Tintucs.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Id = model.Id;
                data.Name = model.Name;
                data.Tag = model.Tag;
                data.Ngaydang = data.Ngaydang;  //lấy ngày đăng trong hệ thống
                data.Tomtat = model.Tomtat;
                data.Noidung = model.Noidung;
                data.Tacgia = model.Tacgia;
                data.Luotxem = data.Luotxem;// (int)(model.Luotxem); lấy lượt xem trong hệ thống
                data.Hinhanh = model.Hinhanh;
                data.Title = model.Title;
                data.Description = model.Description;
                data.Keyword = model.Keyword;
                data.Active = (bool)(model.Active);
                data.Ord = (int)(model.Ord);
                data.Type = (int)(model.Type);
                data.Ngayxemganday = DateTime.Now; // lấy ngày hiện tại
                data.lienkiettinh = model.lienkiettinh;
                data.NameEn = model.NameEn;
                data.ContentEn = model.ContentEn;
                data.DetailEn = model.DetailEn;
                data.Nguon = model.Nguon;

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