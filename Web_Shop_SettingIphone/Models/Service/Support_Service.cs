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
    public class Support_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Support_Model> GetAll()
        {
            IList<Support_Model> result = new List<Support_Model>();

            result = Connect_Enttity.Supports.Select(x => new Support_Model
            {
                Id = x.Id,
                Name = x.Name,
                Tel = x.Tel,
                Type = (int)(x.Type),
                Nick = x.Nick,
                Ord = (int)(x.Ord),
                Active = (int)(x.Active),
                Lang = x.Lang,
                GroupSupportId = (int)(x.GroupSupportId),
                Location = (int)(x.Location)

            }).ToList();

            return result;
        }

        public IList<Support_Model> GetId(Support_Model model)
        {
            IList<Support_Model> result = new List<Support_Model>();

            result = Connect_Enttity.Supports.Where(x => x.Id == model.Id).Select(x => new Support_Model
            {
                Id = x.Id,
                Name = x.Name,
                Tel = x.Tel,
                Type = (int)(x.Type),
                Nick = x.Nick,
                Ord = (int)(x.Ord),
                Active = (int)(x.Active),
                Lang = x.Lang,
                GroupSupportId = (int)(x.GroupSupportId),
                Location = (int)(x.Location)

            }).ToList();

            return result;
        }

        public IEnumerable<Support_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Support_Model> ReadID(Support_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Supports where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Supports.Remove(data);
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
                    var data = Connect_Enttity.Supports.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.Supports.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(Support_Model model)
        {
            var data = Connect_Enttity.Supports.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new Support();

                entity.Name = model.Name;
                entity.Tel = model.Tel;
                entity.Type = (int)(model.Type);
                entity.Nick = model.Nick;
                entity.Ord = (int)(model.Ord);
                entity.Active = (int)(model.Active);
                entity.Lang = model.Lang;
                entity.GroupSupportId = (int)(model.GroupSupportId);
                entity.Location = (int)(model.Location);

                Connect_Enttity.Supports.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Support_Model model)
        {
            var data = Connect_Enttity.Supports.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
                data.Tel = model.Tel;
                data.Type = (int)(model.Type);
                data.Nick = model.Nick;
                data.Ord = (int)(model.Ord);
                data.Active = (int)(model.Active);
                data.Lang = model.Lang;
                data.GroupSupportId = (int)(model.GroupSupportId);
                data.Location = (int)(model.Location);

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