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
    public class CTdonhang_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<CTdonhang_Model> GetAll()
        {
            IList<CTdonhang_Model> result = new List<CTdonhang_Model>();

            result = Connect_Enttity.CTdonhangs.Select(x => new CTdonhang_Model
            {
                IdCTHD = x.IdCTHD,
                IDhd = (int)(x.IDhd),
                IDsanpham = x.IDsanpham,
                Tensanpham = x.Tensanpham,
                Soluong = (int)(x.Soluong),
                Giaban = Convert.ToDouble(x.Giaban),
                Size = x.Size,
                Mausac = x.Mausac,
                Hinhanh = x.Hinhanh,
                danhmucsanpham = x.danhmucsanpham,
                chitietsanpham = x.chitietsanpham,
                Giamthem = Convert.ToDouble(x.Giamthem),
                phantramkm = Convert.ToInt32(x.phantramkm),
                Baohanh = Convert.ToInt32(x.Baohanh),
                Giacu = Convert.ToDouble(x.Giacu),
                tinhtrang = x.tinhtrang


            }).ToList();

            return result;
        }

        public IList<CTdonhang_Model> GetId(CTdonhang_Model model)
        {
            IList<CTdonhang_Model> result = new List<CTdonhang_Model>();

            result = Connect_Enttity.CTdonhangs.Where(x => x.IdCTHD == model.IdCTHD).Select(x => new CTdonhang_Model
            {
                IdCTHD=x.IdCTHD,
                IDhd= (int)(x.IDhd),
                IDsanpham=x.IDsanpham,
                Tensanpham=x.Tensanpham,
                Soluong= (int)(x.Soluong),
                Giaban=Convert.ToDouble(x.Giaban),
                Size= x.Size,
                Mausac=x.Mausac,
                Hinhanh=x.Hinhanh,
                danhmucsanpham=x.danhmucsanpham,
                chitietsanpham=x.chitietsanpham,
                Giamthem=Convert.ToDouble(x.Giamthem),
                phantramkm = Convert.ToInt32(x.phantramkm),
                Baohanh = Convert.ToInt32(x.Baohanh),
                Giacu = Convert.ToDouble(x.Giacu),
                tinhtrang = x.tinhtrang
            }).ToList();

            return result;
        }

        public IEnumerable<CTdonhang_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<CTdonhang_Model> ReadID(CTdonhang_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.CTdonhangs where c.IdCTHD == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.CTdonhangs.Remove(data);
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
                    var data = Connect_Enttity.CTdonhangs.FirstOrDefault(x => x.IdCTHD.Equals(i));
                    Connect_Enttity.CTdonhangs.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(CTdonhang_Model model)
        {
            var data = Connect_Enttity.CTdonhangs.FirstOrDefault(x => x.IdCTHD == model.IdCTHD);
            var entity = new CTdonhang();
            entity.IDhd = (int)(model.IDhd);
            entity.IDsanpham = model.IDsanpham;
            entity.Tensanpham = model.Tensanpham;
            entity.Soluong = (int)(model.Soluong);
            entity.Giaban = Convert.ToDouble(model.Giaban);
            entity.Size = model.Size;
            entity.Mausac = model.Mausac;
            entity.Dungluong = model.Dungluong;
            entity.Hinhanh = model.Hinhanh;
            entity.danhmucsanpham = model.danhmucsanpham;
            entity.chitietsanpham = model.chitietsanpham;
            entity.Giamthem = Convert.ToDouble(model.Giamthem);
            entity.phantramkm = model.phantramkm;
            entity.Baohanh = model.Baohanh;
            entity.Giacu = model.Giacu;
            entity.tinhtrang = model.tinhtrang;

            Connect_Enttity.CTdonhangs.Add(entity);
            Connect_Enttity.SaveChanges();
            //Dispose();
        }

        public void Update(CTdonhang_Model model)
        {
            var data = Connect_Enttity.CTdonhangs.FirstOrDefault(x => x.IdCTHD == model.IdCTHD);
            if (data != null)
            {
                data.IDhd = (int)(model.IDhd);
                data.IDsanpham = model.IDsanpham;
                data.Tensanpham = model.Tensanpham;
                data.Soluong = (int)(model.Soluong);
                data.Giaban = Convert.ToDouble(model.Giaban);
                data.Size = model.Size;
                data.Mausac = model.Mausac;
                data.Dungluong = model.Dungluong;
                data.Hinhanh = model.Hinhanh;
                data.danhmucsanpham = model.danhmucsanpham;
                data.chitietsanpham = model.chitietsanpham;
                data.Giamthem = Convert.ToDouble(model.Giamthem);
                data.phantramkm = model.phantramkm;
                data.Baohanh = model.Baohanh;
                data.Giacu = model.Giacu;
                data.tinhtrang = model.tinhtrang;

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