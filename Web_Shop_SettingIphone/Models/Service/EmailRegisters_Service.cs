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
    public class EmailRegisters_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<EmailRegister_Model> GetAll()
        {
            IList<EmailRegister_Model> result = new List<EmailRegister_Model>();

            result = Connect_Enttity.EmailRegisters.Select(x => new EmailRegister_Model
            {
                Id = x.Id,
                Email = x.Email,
                Createdate = Convert.ToDateTime(x.Createdate),
                Status=(int)(x.Status)

            }).ToList();

            return result;
        }

        public IList<EmailRegister_Model> GetId(EmailRegister_Model model)
        {
            IList<EmailRegister_Model> result = new List<EmailRegister_Model>();

            result = Connect_Enttity.EmailRegisters.Where(x => x.Id == model.Id).Select(x => new EmailRegister_Model
            {
                Id = x.Id,
                Email = x.Email,
                Createdate = Convert.ToDateTime(x.Createdate),
                Status = (int)(x.Status)
            }).ToList();

            return result;
        }

        public IEnumerable<EmailRegister_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<EmailRegister_Model> ReadID(EmailRegister_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.EmailRegisters where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.EmailRegisters.Remove(data);
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
                    var data = Connect_Enttity.EmailRegisters.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.EmailRegisters.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(EmailRegister_Model model)
        {
            var data = Connect_Enttity.EmailRegisters.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new EmailRegister();
                entity.Email = model.Email;
                entity.Createdate = Convert.ToDateTime(model.Createdate);
                entity.Status=(int)(model.Status);

                Connect_Enttity.EmailRegisters.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(EmailRegister_Model model)
        {
            var data = Connect_Enttity.EmailRegisters.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Email = model.Email;
                data.Createdate = Convert.ToDateTime(model.Createdate);
                data.Status = (int)(model.Status);

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