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
    public class GroupMember_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<GroupMember_Model> GetAll()
        {
            IList<GroupMember_Model> result = new List<GroupMember_Model>();

            result = Connect_Enttity.GroupMembers.Select(x => new GroupMember_Model
            {
                Id = x.Id,
                Name = x.Name,
                Active = (int)(x.Active),
                NameEn = x.NameEn

            }).ToList();

            return result;
        }

        public IList<GroupMember_Model> GetId(GroupMember_Model model)
        {
            IList<GroupMember_Model> result = new List<GroupMember_Model>();

            result = Connect_Enttity.GroupMembers.Where(x => x.Id == model.Id).Select(x => new GroupMember_Model
            {
                Id = x.Id,
                Name = x.Name,
                Active = (int)(x.Active),
                NameEn = x.NameEn

            }).ToList();

            return result;
        }

        public IEnumerable<GroupMember_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<GroupMember_Model> ReadID(GroupMember_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.GroupMembers where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.GroupMembers.Remove(data);
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
                    var data = Connect_Enttity.GroupMembers.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.GroupMembers.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(GroupMember_Model model)
        {
            var data = Connect_Enttity.GroupMembers.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new GroupMember();
                entity.Name = model.Name;
                entity.Active = (int)(model.Active);
                entity.NameEn = model.NameEn;

                Connect_Enttity.GroupMembers.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(GroupMember_Model model)
        {
            var data = Connect_Enttity.GroupMembers.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
                data.Active = (int)(model.Active);
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