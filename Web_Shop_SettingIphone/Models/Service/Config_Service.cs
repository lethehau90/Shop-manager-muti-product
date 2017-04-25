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
    public class Config_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Config_Model> GetAll()
        {
            IList<Config_Model> result = new List<Config_Model>();

            result = Connect_Enttity.Configs.Select(x => new Config_Model
            {
                Id= x.Id,
                Mail_Smtp=x.Mail_Smtp,
                Mail_Port = (short)(x.Mail_Port),
                Mail_Info=x.Mail_Info,
                Mail_Noreply=x.Mail_Noreply,
                Mail_Password=x.Mail_Password,
                PlaceHead=x.PlaceHead,
                PlaceBody=x.PlaceBody,
                GoogleId = x.GoogleId,
                Contact=x.Contact,
                DeliveryTerms = x.DeliveryTerms,
                PaymentTerms = x.PaymentTerms,
                FreeShipping =Convert.ToDouble(x.FreeShipping),
                Copyright = x.Copyright,
                Title=x.Title,
                Description=x.Description,
                Keyword=x.Keyword,
                Lang=x.Lang,
                Helpsize=x.Helpsize,
                Location=(int)(x.Location),
                ToolScrip=x.ToolScrip,
                Icon= x.Icon,
                pageging1 =x.pageging1,
                pageging2 = x.pageging2,
                pageging3 = x.pageging3,
                pageging4 = x.pageging4,
                pageging5 = x.pageging5

            }).ToList();

            return result;
        }

        public IList<Config_Model> GetId(Config_Model model)
        {
            IList<Config_Model> result = new List<Config_Model>();

            result = Connect_Enttity.Configs.Where(x => x.Id == model.Id).Select(x => new Config_Model
            {
                Id = x.Id,
                Mail_Smtp = x.Mail_Smtp,
                Mail_Port = (short)(x.Mail_Port),
                Mail_Info = x.Mail_Info,
                Mail_Noreply = x.Mail_Noreply,
                Mail_Password = x.Mail_Password,
                PlaceHead = x.PlaceHead,
                PlaceBody = x.PlaceBody,
                GoogleId = x.GoogleId,
                Contact = x.Contact,
                DeliveryTerms = x.DeliveryTerms,
                PaymentTerms = x.PaymentTerms,
                FreeShipping = Convert.ToDouble(x.FreeShipping),
                Copyright = x.Copyright,
                Title = x.Title,
                Description = x.Description,
                Keyword = x.Keyword,
                Lang = x.Lang,
                Helpsize = x.Helpsize,
                Location = (int)(x.Location),
                ToolScrip = x.ToolScrip,
                Icon = x.Icon,
                pageging1 = x.pageging1,
                pageging2 = x.pageging2,
                pageging3 = x.pageging3,
                pageging4 = x.pageging4,
                pageging5 = x.pageging5
            }).ToList();

            return result;
        }

        public IEnumerable<Config_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Config_Model> ReadID(Config_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Configs where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Configs.Remove(data);
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
                    var data = Connect_Enttity.Configs.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.Configs.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(Config_Model model)
        {
            var data = Connect_Enttity.Configs.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new Config();
                entity.Mail_Smtp=model.Mail_Smtp;
                entity.Mail_Port = (short)(model.Mail_Port);
                entity.Mail_Info=model.Mail_Info;
                entity.Mail_Noreply=model.Mail_Noreply;
                entity.Mail_Password=model.Mail_Password;
                entity.PlaceHead=model.PlaceHead;
                entity.PlaceBody=model.PlaceBody;
                entity.GoogleId = model.GoogleId;
                entity.Contact=model.Contact;
                entity.DeliveryTerms = model.DeliveryTerms;
                entity.PaymentTerms = model.PaymentTerms;
                entity.FreeShipping =Convert.ToDouble(model.FreeShipping);
                entity.Copyright = model.Copyright;
                entity.Title=model.Title;
                entity.Description=model.Description;
                entity.Keyword=model.Keyword;
                entity.Lang=model.Lang;
                entity.Helpsize=model.Helpsize;
                entity.Location=(int)(model.Location);
                entity.ToolScrip=model.ToolScrip;
                entity.Icon = model.Icon;
                entity.pageging1 = model.pageging1;
                entity.pageging2 = model.pageging2;
                entity.pageging3 = model.pageging3;
                entity.pageging4 = model.pageging4;
                entity.pageging5 = model.pageging5;

                Connect_Enttity.Configs.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Config_Model model)
        {
            var data = Connect_Enttity.Configs.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Mail_Smtp = model.Mail_Smtp;
                data.Mail_Port = (short)(model.Mail_Port);
                data.Mail_Info = model.Mail_Info;
                data.Mail_Noreply = model.Mail_Noreply;
                data.Mail_Password = model.Mail_Password;
                data.PlaceHead = model.PlaceHead;
                data.PlaceBody = model.PlaceBody;
                data.GoogleId = model.GoogleId;
                data.Contact = model.Contact;
                data.DeliveryTerms = model.DeliveryTerms;
                data.PaymentTerms = model.PaymentTerms;
                data.FreeShipping = Convert.ToDouble(model.FreeShipping);
                data.Copyright = model.Copyright;
                data.Title = model.Title;
                data.Description = model.Description;
                data.Keyword = model.Keyword;
                data.Lang = model.Lang;
                data.Helpsize = model.Helpsize;
                data.Location = (int)(model.Location);
                data.ToolScrip = model.ToolScrip;
                data.Icon = model.Icon;
                data.pageging1 = model.pageging1;
                data.pageging2 = model.pageging2;
                data.pageging3 = model.pageging3;
                data.pageging4 = model.pageging4;
                data.pageging5 = model.pageging5;

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