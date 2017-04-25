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
    public class GroupLibrary_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<GroupLibrary_Model> GetAll()
        {
            IList<GroupLibrary_Model> result = new List<GroupLibrary_Model>();

            result = Connect_Enttity.GroupLibraries.Select(x => new GroupLibrary_Model
            {
                Id = x.Id,
                Name = x.Name,
                Tag = x.Tag,
                Level = x.Level,
                Image = x.Image,
                Ord = (int)(x.Ord),
                Active = (int)(x.Active),
                Lang = x.Lang,
                NameEn = x.NameEn

            }).ToList();

            return result;
        }

        public IList<GroupLibrary_Model> GetId(GroupLibrary_Model model)
        {
            IList<GroupLibrary_Model> result = new List<GroupLibrary_Model>();

            result = Connect_Enttity.GroupLibraries.Where(x => x.Id == model.Id).Select(x => new GroupLibrary_Model
            {
                Id = x.Id,
                Name = x.Name,
                Tag = x.Tag,
                Level = x.Level,
                Image = x.Image,
                Ord = (int)(x.Ord),
                Active = (int)(x.Active),
                Lang = x.Lang,
                NameEn = x.NameEn
            }).ToList();

            return result;
        }

        public IEnumerable<GroupLibrary_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<GroupLibrary_Model> ReadID(GroupLibrary_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.GroupLibraries where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.GroupLibraries.Remove(data);
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
                    var data = Connect_Enttity.GroupLibraries.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.GroupLibraries.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(GroupLibrary_Model model)
        {
            var data = Connect_Enttity.GroupLibraries.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new GroupLibrary();
                entity.Name = model.Name;
                entity.Tag = model.Tag;
                entity.Level = model.Level;
                entity.Image = model.Image;
                entity.Ord = (int)(model.Ord);
                entity.Active = (int)(model.Active);
                entity.Lang = model.Lang;
                entity.NameEn = model.NameEn;

                Connect_Enttity.GroupLibraries.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(GroupLibrary_Model model)
        {
            var data = Connect_Enttity.GroupLibraries.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
                data.Tag = model.Tag;
                data.Level = model.Level;
                data.Image = model.Image;
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