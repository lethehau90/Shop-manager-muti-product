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
    public class Language_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Language_Model> GetAll()
        {
            IList<Language_Model> result = new List<Language_Model>();

            result = Connect_Enttity.Languages.Select(x => new Language_Model
            {
                Id=x.Id,
                Name = x.Name,
                Folder = x.Folder,
                Image = x.Image,
                Default = (bool)(x.Default),
                Active = (bool)(x.Active)
            }).ToList();

            return result;
        }

        public IList<Language_Model> GetId(Language_Model model)
        {
            IList<Language_Model> result = new List<Language_Model>();

            result = Connect_Enttity.Languages.Where(x => x.Id == model.Id).Select(x => new Language_Model
            {
                Id = x.Id,
                Name = x.Name,
                Folder = x.Folder,
                Image = x.Image,
                Default = (bool)(x.Default),
                Active = (bool)(x.Active)
            }).ToList();

            return result;
        }
        public IEnumerable<Language_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Language_Model> ReadID(Language_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {
            string ID = Id.ToString();
            var data = (from c in Connect_Enttity.Languages where c.Id == ID select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Languages.Remove(data);
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
                    var data = Connect_Enttity.Languages.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.Languages.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(Language_Model model)
        {
            var data = Connect_Enttity.Languages.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new Language();
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Folder = model.Folder;
                entity.Image = model.Image;
                entity.Default = (bool)(model.Default);
                entity.Active = (bool)(model.Active);

                Connect_Enttity.Languages.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Language_Model model)
        {
            var data = Connect_Enttity.Languages.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
                data.Folder = model.Folder;
                data.Image = model.Image;
                data.Default = (bool)(model.Default);
                data.Active = (bool)(model.Active);

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