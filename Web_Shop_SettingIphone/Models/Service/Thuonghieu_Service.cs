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
    public class Thuonghieu_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Thuonghieu_Model> GetAll()
        {
            IList<Thuonghieu_Model> result = new List<Thuonghieu_Model>();

            result = Connect_Enttity.Thuonghieux.Select(x => new Thuonghieu_Model
            {
                IDthuonghieu = x.IDthuonghieu,
                Tenthuonghieu = x.Tenthuonghieu,
                Logo = x.Logo,
                Url=x.Url,
                Active = (bool)(x.Active),
                Vitri = (int)(x.Vitri),
                Lienkettinh = x.Lienkettinh,
                mota = x.mota,
                Lang = x.Lang,
                Tenthuonghieu_En = x.Tenthuonghieu_En,
                mota_En = x.mota_En

            }).ToList();

            return result;
        }

        public IList<Thuonghieu_Model> GetId(Thuonghieu_Model model)
        {
            IList<Thuonghieu_Model> result = new List<Thuonghieu_Model>();

            result = Connect_Enttity.Thuonghieux.Where(x => x.IDthuonghieu == model.IDthuonghieu).Select(x => new Thuonghieu_Model
            {
                IDthuonghieu = x.IDthuonghieu,
                Tenthuonghieu = x.Tenthuonghieu,
                Logo = x.Logo,
                Url = x.Url,
                Active = (bool)(x.Active),
                Vitri = (int)(x.Vitri),
                Lienkettinh = x.Lienkettinh,
                mota = x.mota,
                Lang = x.Lang,
                Tenthuonghieu_En = x.Tenthuonghieu_En,
                mota_En = x.mota_En

            }).ToList();

            return result;
        }

        public IEnumerable<Thuonghieu_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Thuonghieu_Model> ReadID(Thuonghieu_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Thuonghieux where c.IDthuonghieu == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Thuonghieux.Remove(data);
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
                    var data = Connect_Enttity.Thuonghieux.FirstOrDefault(x => x.IDthuonghieu.Equals(i));
                    Connect_Enttity.Thuonghieux.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(Thuonghieu_Model model)
        {
            var data = Connect_Enttity.Thuonghieux.FirstOrDefault(x => x.IDthuonghieu == model.IDthuonghieu);
            if (data == null)
            {
                var entity = new  Thuonghieu();
                entity.Tenthuonghieu = model.Tenthuonghieu;
                entity.Logo = model.Logo;
                entity.Url=model.Url;
                entity.Active = (bool)(model.Active);
                entity.Vitri = (int)(model.Vitri);
                entity.Lienkettinh = model.Lienkettinh;
                entity.mota = model.mota;
                entity.Lang = model.Lang;
                entity.Tenthuonghieu_En = model.Tenthuonghieu_En;
                entity.mota_En = model.mota_En;

                Connect_Enttity.Thuonghieux.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Thuonghieu_Model model)
        {
            var data = Connect_Enttity.Thuonghieux.FirstOrDefault(x => x.IDthuonghieu == model.IDthuonghieu);
            if (data != null)
            {
                data.Tenthuonghieu = model.Tenthuonghieu;
                data.Logo = model.Logo;
                data.Url = model.Url;
                data.Active = (bool)(model.Active);
                data.Vitri = (int)(model.Vitri);
                data.Lienkettinh = model.Lienkettinh;
                data.mota = model.mota;
                data.Lang = model.Lang;
                data.Tenthuonghieu_En = model.Tenthuonghieu_En;
                data.mota_En = model.mota_En;

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