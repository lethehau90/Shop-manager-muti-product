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
    public class Company_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Company_Model> GetAll()
        {
            IList<Company_Model> result = new List<Company_Model>();

            result = Connect_Enttity.Companies.Select(x => new Company_Model
            {
                id=x.id,
                Name=x.Name,
                Address=x.Address,
                PhoneNumber=x.PhoneNumber,
                Fax=x.Fax,
                ProvinceId=(int)(x.ProvinceId),
                NameEn= x.NameEn,
                AddressEn=x.AddressEn
            }).ToList();

            return result;
        }

        public IList<Company_Model> GetId(Company_Model model)
        {
            IList<Company_Model> result = new List<Company_Model>();

            result = Connect_Enttity.Companies.Where(x => x.id == model.id).Select(x => new Company_Model
            {
                id = x.id,
                Name = x.Name,
                Address = x.Address,
                PhoneNumber = x.PhoneNumber,
                Fax = x.Fax,
                ProvinceId = (int)(x.ProvinceId),
                NameEn = x.NameEn,
                AddressEn = x.AddressEn
            }).ToList();

            return result;
        }
        public IEnumerable<Company_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Company_Model> ReadID(Company_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Companies where c.id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Companies.Remove(data);
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
                    var data = Connect_Enttity.Companies.FirstOrDefault(x => x.id.Equals(i));
                    Connect_Enttity.Companies.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(Company_Model model)
        {
            var data = Connect_Enttity.Companies.FirstOrDefault(x => x.id == model.id);
            if (data == null)
            {
                var entity = new Company();
                entity.Name=model.Name;
                entity.Address=model.Address;
                entity.PhoneNumber=model.PhoneNumber;
                entity.Fax=model.Fax;
                entity.ProvinceId=(int)(model.ProvinceId);
                entity.NameEn= model.NameEn;
                entity.AddressEn=model.AddressEn;

                Connect_Enttity.Companies.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Company_Model model)
        {
            var data = Connect_Enttity.Companies.FirstOrDefault(x => x.id == model.id);
            if (data != null)
            {
                data.Name = model.Name;
                data.Address = model.Address;
                data.PhoneNumber = model.PhoneNumber;
                data.Fax = model.Fax;
                data.ProvinceId = (int)(model.ProvinceId);
                data.NameEn = model.NameEn;
                data.AddressEn = model.AddressEn;

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