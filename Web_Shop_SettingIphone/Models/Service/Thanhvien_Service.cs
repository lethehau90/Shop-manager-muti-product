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
    public class Thanhvien_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Thanhvien_Model> GetAll()
        {
            IList<Thanhvien_Model> result = new List<Thanhvien_Model>();

            result = Connect_Enttity.Thanhviens.Select(x => new Thanhvien_Model
            {
                id = x.id,
                Taikhoan = x.Taikhoan,
                Matkhau = x.Matkhau,
                Hoten = x.Hoten,
                Ngaysinh = x.Ngaysinh,
                Gioitinh = x.Gioitinh,
                Diachi = x.Diachi,
                SDT = x.SDT,
                Email = x.Email,
                Actice = (bool)(x.Actice),
                thutu = (int)(x.thutu),
                CreateDate = (DateTime)(x.CreateDate)
              

            }).ToList();

            return result;
        }

        public IList<Thanhvien_Model> GetId(Thanhvien_Model model)
        {
            IList<Thanhvien_Model> result = new List<Thanhvien_Model>();

            result = Connect_Enttity.Thanhviens.Where(x => x.id == model.id).Select(x => new Thanhvien_Model
            {
                id = x.id,
                Taikhoan = x.Taikhoan,
                Matkhau = x.Matkhau,
                Hoten = x.Hoten,
                Ngaysinh = x.Ngaysinh,
                Gioitinh = x.Gioitinh,
                Diachi = x.Diachi,
                SDT = x.SDT,
                Email = x.Email,
                Actice = (bool)(x.Actice),
                thutu = (int)(x.thutu),
                CreateDate = (DateTime)(x.CreateDate)

            }).ToList();

            return result;
        }

        public IEnumerable<Thanhvien_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Thanhvien_Model> ReadID(Thanhvien_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Thanhviens where c.id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Thanhviens.Remove(data);
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
                    var data = Connect_Enttity.Thanhviens.FirstOrDefault(x => x.id.Equals(i));
                    Connect_Enttity.Thanhviens.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(Thanhvien_Model model)
        {
            var data = Connect_Enttity.Thanhviens.FirstOrDefault(x => x.id == model.id);
            if (data == null)
            {
                var entity = new Thanhvien();

                 entity.Taikhoan = model.Taikhoan;
                 entity.Matkhau = model.Matkhau;
                 entity.Hoten = model.Hoten;
                 entity.Ngaysinh = model.Ngaysinh;
                 entity.Gioitinh = model.Gioitinh;
                 entity.Diachi = model.Diachi;
                 entity.SDT = model.SDT;
                 entity.Email = model.Email;
                 entity.Actice = (bool)(model.Actice);
                 entity.thutu = (int)(model.thutu);
                 entity.CreateDate = DateTime.Now;

                Connect_Enttity.Thanhviens.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Thanhvien_Model model)
        {
            var data = Connect_Enttity.Thanhviens.FirstOrDefault(x => x.id == model.id);
            if (data != null)
            {
                data.Taikhoan = model.Taikhoan;
                data.Matkhau = model.Matkhau;
                data.Hoten = model.Hoten;
                data.Ngaysinh = model.Ngaysinh;
                data.Gioitinh = model.Gioitinh;
                data.Diachi = model.Diachi;
                data.SDT = model.SDT;
                data.Email = model.Email;
                data.Actice = (bool)(model.Actice);
                data.thutu = (int)(model.thutu);

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