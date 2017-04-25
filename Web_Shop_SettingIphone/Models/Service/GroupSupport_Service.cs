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
    public class GroupSupport_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<GroupSupport_Model> GetAll()
        {
            IList<GroupSupport_Model> result = new List<GroupSupport_Model>();

            result = Connect_Enttity.GroupSupports.Select(x => new GroupSupport_Model
            {
                Id = x.Id,
                Name = x.Name,
                Ord = (int)(x.Ord),
                Active = (int)(x.Active),
                Lang = x.Lang,
                NameEn = x.NameEn

            }).ToList();

            return result;
        }

        public IList<GroupSupport_Model> GetId(GroupSupport_Model model)
        {
            IList<GroupSupport_Model> result = new List<GroupSupport_Model>();

            result = Connect_Enttity.GroupSupports.Where(x => x.Id == model.Id).Select(x => new GroupSupport_Model
            {
                Id = x.Id,
                Name = x.Name,
                Ord = (int)(x.Ord),
                Active = (int)(x.Active),
                Lang = x.Lang,
                NameEn = x.NameEn

            }).ToList();

            return result;
        }

        public IEnumerable<GroupSupport_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<GroupSupport_Model> ReadID(GroupSupport_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.GroupSupports where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.GroupSupports.Remove(data);
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
                    var data = Connect_Enttity.GroupSupports.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.GroupSupports.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(GroupSupport_Model model)
        {
            var data = Connect_Enttity.GroupSupports.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new GroupSupport();
                entity.Name = model.Name;
                entity.Ord = (int)(model.Ord);
                entity.Active = (int)(model.Active);
                entity.Lang = model.Lang;
                entity.NameEn = model.NameEn;

                Connect_Enttity.GroupSupports.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(GroupSupport_Model model)
        {
            var data = Connect_Enttity.GroupSupports.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
                data.Ord = (int)(model.Ord);
                data.Active = (int)(model.Active);
                data.Lang = model.Lang;
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