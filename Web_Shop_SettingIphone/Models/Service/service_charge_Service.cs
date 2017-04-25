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
    public class service_charge_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<service_charge_Model> GetAll()
        {
            IList<service_charge_Model> result = new List<service_charge_Model>();

            result = Connect_Enttity.service_charge.Select(x => new service_charge_Model
            {
                idservice = x.idservice,
                Name = x.Name,
                Ord = (int)(x.Ord),
                Gia = (int)(x.Gia),
                Active = (bool)(x.Active),
                NameEn = x.NameEn

            }).ToList();

            return result;
        }

        public IList<service_charge_Model> GetId(service_charge_Model model)
        {
            IList<service_charge_Model> result = new List<service_charge_Model>();

            result = Connect_Enttity.service_charge.Where(x => x.idservice == model.idservice).Select(x => new service_charge_Model
            {
                idservice = x.idservice,
                Name = x.Name,
                Ord = (int)(x.Ord),
                Gia = (int)(x.Gia),
                Active = (bool)(x.Active),
                NameEn = x.NameEn
            }).ToList();

            return result;
        }

        public IEnumerable<service_charge_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<service_charge_Model> ReadID(service_charge_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.service_charge where c.idservice == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.service_charge.Remove(data);
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
                    var data = Connect_Enttity.service_charge.FirstOrDefault(x => x.idservice.Equals(i));
                    Connect_Enttity.service_charge.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(service_charge_Model model)
        {
            var data = Connect_Enttity.service_charge.FirstOrDefault(x => x.idservice == model.idservice);
            if (data == null)
            {
                var entity = new service_charge();

                entity.Name = model.Name;
                entity.Ord = (int)(model.Ord);
                entity.Gia = (int)(model.Gia);
                entity.Active = (bool)(model.Active);
                entity.NameEn = model.NameEn;

                Connect_Enttity.service_charge.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(service_charge_Model model)
        {
            var data = Connect_Enttity.service_charge.FirstOrDefault(x => x.idservice == model.idservice);
            if (data != null)
            {
                data.Name = model.Name;
                data.Ord = (int)(model.Ord);
                data.Gia = (int)(model.Gia);
                data.Active = (bool)(model.Active);
                data.NameEn = model.NameEn;

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