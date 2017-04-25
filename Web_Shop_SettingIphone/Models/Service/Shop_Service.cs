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
    public class Shop_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Shop_Model> GetAll()
        {
            IList<Shop_Model> result = new List<Shop_Model>();

            result = Connect_Enttity.Shops.Select(x => new Shop_Model
            {
                id = x.id,
                Name = x.Name,
                CompanyId = (int)(x.CompanyId),
                Address = x.Address,
                PhoneNumber = x.PhoneNumber

            }).ToList();

            return result;
        }

        public IList<Shop_Model> GetId(Shop_Model model)
        {
            IList<Shop_Model> result = new List<Shop_Model>();

            result = Connect_Enttity.Shops.Where(x => x.id == model.id).Select(x => new Shop_Model
            {
                id = x.id,
                Name = x.Name,
                CompanyId = (int)(x.CompanyId),
                Address = x.Address,
                PhoneNumber = x.PhoneNumber
            }).ToList();

            return result;
        }

        public IEnumerable<Shop_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Shop_Model> ReadID(Shop_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Shops where c.id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Shops.Remove(data);
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
                    var data = Connect_Enttity.Shops.FirstOrDefault(x => x.id.Equals(i));
                    Connect_Enttity.Shops.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(Shop_Model model)
        {
            var data = Connect_Enttity.Shops.FirstOrDefault(x => x.id == model.id);
            if (data == null)
            {
                var entity = new Shop();

                entity.Name = model.Name;
                entity.CompanyId = (int)(model.CompanyId);
                entity.Address = model.Address;
                entity.PhoneNumber = model.PhoneNumber;

                Connect_Enttity.Shops.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Shop_Model model)
        {
            var data = Connect_Enttity.Shops.FirstOrDefault(x => x.id == model.id);
            if (data != null)
            {
                data.Name = model.Name;
                data.CompanyId = (int)(model.CompanyId);
                data.Address = model.Address;
                data.PhoneNumber = model.PhoneNumber;

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