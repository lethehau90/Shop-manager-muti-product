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
    public class Member_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Member_Model> GetAll()
        {
            IList<Member_Model> result = new List<Member_Model>();

            result = Connect_Enttity.Members.Select(x => new Member_Model
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Username = x.Username,
                Password = x.Password,
                GroupMemberId = (int)(x.GroupMemberId),
                Active = (int)(x.Active),
                NameEn = x.NameEn,
                Isplace = x.Isplace,
                IsplaceEn = x.IsplaceEn,
                Note = x.Note,
                NoteEn = x.NoteEn

            }).ToList();

            return result;
        }

        public IList<Member_Model> GetId(Member_Model model)
        {
            IList<Member_Model> result = new List<Member_Model>();

            result = Connect_Enttity.Members.Where(x => x.Id == model.Id).Select(x => new Member_Model
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Username = x.Username,
                Password = x.Password,
                GroupMemberId = (int)(x.GroupMemberId),
                Active = (int)(x.Active),
                NameEn = x.NameEn,
                Isplace = x.Isplace,
                IsplaceEn = x.IsplaceEn,
                Note = x.Note,
                NoteEn = x.NoteEn

            }).ToList();

            return result;
        }

        public IEnumerable<Member_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Member_Model> ReadID(Member_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Members where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Members.Remove(data);
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
                    var data = Connect_Enttity.Members.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.Members.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(Member_Model model)
        {
            var data = Connect_Enttity.Members.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new Member();

                entity.Name = model.Name;
                entity.Email = model.Email;
                entity.Username = model.Username;
                entity.Password = model.Password;
                entity.GroupMemberId = (int)(model.GroupMemberId);
                entity.Active = (int)(model.Active);
                entity.NameEn = model.NameEn;
                entity.Isplace = model.Isplace;
                entity.IsplaceEn = model.IsplaceEn;
                entity.Note = model.Note;
                entity.NoteEn = model.NoteEn;

                Connect_Enttity.Members.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Member_Model model)
        {
            var data = Connect_Enttity.Members.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
                data.Email = model.Email;
                data.Username = model.Username;
                data.Password = model.Password;
                data.GroupMemberId = (int)(model.GroupMemberId);
                data.Active = (int)(model.Active);
                data.NameEn = model.NameEn;
                data.Isplace = model.Isplace;
                data.IsplaceEn = model.IsplaceEn;
                data.Note = model.Note;
                data.NoteEn = model.NoteEn;

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