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
    public class Library_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Library_Model> GetAll()
        {
            IList<Library_Model> result = new List<Library_Model>();

            result = Connect_Enttity.Libraries.Select(x => new Library_Model
            {
                Id = x.Id,
                Name = x.Name,
                Tag = x.Tag,
                Image = x.Image,
                File = x.File,
                Info = x.Info,
                Priority = (int)(x.Priority),
                Active = (int)(x.Active),
                GroupLibraryId = (int)(x.GroupLibraryId),
                MemberId = (int)(x.MemberId),
                Lang = x.Lang,
                LibraryCatTag = x.LibraryCatTag,
                NameEn = x.NameEn,
                infoEn = x.infoEn,
                Content = x.Content,
                ContetnEn = x.ContetnEn

            }).ToList();

            return result;
        }

        public IList<Library_Model> GetId(Library_Model model)
        {
            IList<Library_Model> result = new List<Library_Model>();

            result = Connect_Enttity.Libraries.Where(x => x.Id == model.Id).Select(x => new Library_Model
            {
                Id = x.Id,
                Name = x.Name,
                Tag = x.Tag,
                Image = x.Image,
                File = x.File,
                Info = x.Info,
                Priority = (int)(x.Priority),
                Active = (int)(x.Active),
                GroupLibraryId = (int)(x.GroupLibraryId),
                MemberId = (int)(x.MemberId),
                Lang = x.Lang,
                LibraryCatTag = x.LibraryCatTag,
                NameEn = x.NameEn,
                infoEn = x.infoEn,
                Content = x.Content,
                ContetnEn = x.ContetnEn

            }).ToList();

            return result;
        }

        public IEnumerable<Library_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Library_Model> ReadID(Library_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Libraries where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Libraries.Remove(data);
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
                    var data = Connect_Enttity.Libraries.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.Libraries.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(Library_Model model)
        {
            var data = Connect_Enttity.Libraries.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new Library();

                entity.Name = model.Name;
                entity.Tag = model.Tag;
                entity.Image = model.Image;
                entity.File = model.File;
                entity.Info = model.Info;
                entity.Priority = (int)(model.Priority);
                entity.Active = (int)(model.Active);
                entity.GroupLibraryId = (int)(model.GroupLibraryId);
                entity.MemberId = (int)(model.MemberId);
                entity.Lang = model.Lang;
                entity.LibraryCatTag = model.LibraryCatTag;
                entity.NameEn = model.NameEn;
                entity.infoEn = model.infoEn;
                entity.Content = model.Content;
                entity.ContetnEn = model.ContetnEn;

                Connect_Enttity.Libraries.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Library_Model model)
        {
            var data = Connect_Enttity.Libraries.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
                data.Tag = model.Tag;
                data.Image = model.Image;
                data.File = model.File;
                data.Info = model.Info;
                data.Priority = (int)(model.Priority);
                data.Active = (int)(model.Active);
                data.GroupLibraryId = (int)(model.GroupLibraryId);
                data.MemberId = (int)(model.MemberId);
                data.Lang = model.Lang;
                data.LibraryCatTag = model.LibraryCatTag;
                data.NameEn = model.NameEn;
                data.infoEn = model.infoEn;
                data.Content = model.Content;
                data.ContetnEn = model.ContetnEn;

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