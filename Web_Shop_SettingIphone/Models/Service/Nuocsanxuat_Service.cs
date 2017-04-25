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
    public class Nuocsanxuat_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Nuocsanxuat_Model> GetAll()
        {
            IList<Nuocsanxuat_Model> result = new List<Nuocsanxuat_Model>();

            result = Connect_Enttity.Nuocsanxuats.Select(x => new Nuocsanxuat_Model
            {
                IDNuocsanxuat = x.IDNuocsanxuat,
                TenNuocsanxuat = x.TenNuocsanxuat,
                Logo = x.Logo,
                Active = (bool)(x.Active),
                Vitri = (int)(x.Vitri),
                TenNuocsanxuat_En = x.TenNuocsanxuat_En

            }).ToList();

            return result;
        }

        public IList<Nuocsanxuat_Model> GetId(Nuocsanxuat_Model model)
        {
            IList<Nuocsanxuat_Model> result = new List<Nuocsanxuat_Model>();

            result = Connect_Enttity.Nuocsanxuats.Where(x => x.IDNuocsanxuat == model.IDNuocsanxuat).Select(x => new Nuocsanxuat_Model
            {
                IDNuocsanxuat = x.IDNuocsanxuat,
                TenNuocsanxuat = x.TenNuocsanxuat,
                Logo = x.Logo,
                Active = (bool)(x.Active),
                Vitri = (int)(x.Vitri),
                TenNuocsanxuat_En = x.TenNuocsanxuat_En

            }).ToList();

            return result;
        }

        public IEnumerable<Nuocsanxuat_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Nuocsanxuat_Model> ReadID(Nuocsanxuat_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Nuocsanxuats where c.IDNuocsanxuat == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Nuocsanxuats.Remove(data);
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
                    var data = Connect_Enttity.Nuocsanxuats.FirstOrDefault(x => x.IDNuocsanxuat.Equals(i));
                    Connect_Enttity.Nuocsanxuats.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(Nuocsanxuat_Model model)
        {
            var data = Connect_Enttity.Nuocsanxuats.FirstOrDefault(x => x.IDNuocsanxuat == model.IDNuocsanxuat);
            if (data == null)
            {
                var entity = new Nuocsanxuat();
                entity.TenNuocsanxuat = model.TenNuocsanxuat;
                entity.Logo = model.Logo;
                entity.Active = (bool)(model.Active);
                entity.Vitri = (int)(model.Vitri);
                entity.TenNuocsanxuat_En = model.TenNuocsanxuat_En;

                Connect_Enttity.Nuocsanxuats.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Nuocsanxuat_Model model)
        {
            var data = Connect_Enttity.Nuocsanxuats.FirstOrDefault(x => x.IDNuocsanxuat == model.IDNuocsanxuat);
            if (data != null)
            {
                data.TenNuocsanxuat = model.TenNuocsanxuat;
                data.Logo = model.Logo;
                data.Active = (bool)(model.Active);
                data.Vitri = (int)(model.Vitri);
                data.TenNuocsanxuat_En = model.TenNuocsanxuat_En;

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