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
    public class Contact_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Contact_Model> GetAll()
        {
            IList<Contact_Model> result = new List<Contact_Model>();

            result = Connect_Enttity.Contacts.Select(x => new Contact_Model
            {
                Id = x.Id,
                Name=x.Name,
                Company=x.Company,
                Address=x.Address,
                Tel=x.Tel,
                Mail=x.Mail,
                Detail=x.Detail,
                Date=Convert.ToDateTime(x.Date),
                Active= (int)(x.Active),
                Lang=x.Lang,
                NameEn=x.NameEn,
                CompanyEn=x.CompanyEn,
                AddressEn=x.AddressEn,
                DetailEn=x.DetailEn

            }).ToList();

            return result;
        }

        public IList<Contact_Model> GetId(Contact_Model model)
        {
            IList<Contact_Model> result = new List<Contact_Model>();

            result = Connect_Enttity.Contacts.Where(x => x.Id == model.Id).Select(x => new Contact_Model
            {
                Id = x.Id,
                Name = x.Name,
                Company = x.Company,
                Address = x.Address,
                Tel = x.Tel,
                Mail = x.Mail,
                Detail = x.Detail,
                Date = Convert.ToDateTime(x.Date),
                Active = (int)(x.Active),
                Lang = x.Lang,
                NameEn = x.NameEn,
                CompanyEn = x.CompanyEn,
                AddressEn = x.AddressEn,
                DetailEn = x.DetailEn
            }).ToList();

            return result;
        }

        public IEnumerable<Contact_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Contact_Model> ReadID(Contact_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Contacts where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Contacts.Remove(data);
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
                    var data = Connect_Enttity.Contacts.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.Contacts.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(Contact_Model model)
        {
            var data = Connect_Enttity.Contacts.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new Contact();
                entity.Name = model.Name;
                entity.Company = model.Company;
                entity.Address = model.Address;
                entity.Tel = model.Tel;
                entity.Mail = model.Mail;
                entity.Detail = model.Detail;
                entity.Date = Convert.ToDateTime(model.Date);
                entity.Active = (int)(model.Active);
                entity.Lang = model.Lang;
                entity.NameEn = model.NameEn;
                entity.CompanyEn = model.CompanyEn;
                entity.AddressEn = model.AddressEn;
                entity.DetailEn = model.DetailEn;

                Connect_Enttity.Contacts.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Contact_Model model)
        {
            var data = Connect_Enttity.Contacts.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
                data.Company = model.Company;
                data.Address = model.Address;
                data.Tel = model.Tel;
                data.Mail = model.Mail;
                data.Detail = model.Detail;
                data.Date = Convert.ToDateTime(model.Date);
                data.Active = (int)(model.Active);
                data.Lang = model.Lang;
                data.NameEn = model.NameEn;
                data.CompanyEn = model.CompanyEn;
                data.AddressEn = model.AddressEn;
                data.DetailEn = model.DetailEn;

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