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
    public class GroupMenuSanPham_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<GroupMenuSanPham_Model> GetAll()
        {
            IList<GroupMenuSanPham_Model> result = new List<GroupMenuSanPham_Model>();

            result = Connect_Enttity.GroupMenuSanPhams.Select(x => new GroupMenuSanPham_Model
            {
                Id = x.Id,
                Name = x.Name,
                Tag = x.Tag,
                Level = x.Level,
                Title = x.Title,
                Description = x.Description,
                Keyword = x.Keyword,
                Ord = (int)(x.Ord),
                Priority = (int)(x.Priority),
                Index = (int)(x.Index),
                Active = (int)(x.Active),
                Lang = x.Lang,
                Logogroup = x.Logogroup,
                ImagesLogo = x.ImagesLogo,
                content = x.content,
                NameEn = x.NameEn,
                TitleEn = x.TitleEn,
                contentEn = x.contentEn

            }).ToList();

            return result;
        }

        public IList<GroupMenuSanPham_Model> GetId(GroupMenuSanPham_Model model)
        {
            IList<GroupMenuSanPham_Model> result = new List<GroupMenuSanPham_Model>();

            result = Connect_Enttity.GroupMenuSanPhams.Where(x => x.Id == model.Id).Select(x => new GroupMenuSanPham_Model
            {
                Id = x.Id,
                Name = x.Name,
                Tag = x.Tag,
                Level = x.Level,
                Title = x.Title,
                Description = x.Description,
                Keyword = x.Keyword,
                Ord = (int)(x.Ord),
                Priority = (int)(x.Priority),
                Index = (int)(x.Index),
                Active = (int)(x.Active),
                Lang = x.Lang,
                Logogroup = x.Logogroup,
                ImagesLogo = x.ImagesLogo,
                content = x.content,
                NameEn = x.NameEn,
                TitleEn = x.TitleEn,
                contentEn = x.contentEn

            }).ToList();

            return result;
        }

        public IEnumerable<GroupMenuSanPham_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<GroupMenuSanPham_Model> ReadID(GroupMenuSanPham_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.GroupMenuSanPhams where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.GroupMenuSanPhams.Remove(data);
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
                    var data = Connect_Enttity.GroupMenuSanPhams.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.GroupMenuSanPhams.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(GroupMenuSanPham_Model model)
        {
            var data = Connect_Enttity.GroupMenuSanPhams.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new GroupMenuSanPham();

                entity.Name = model.Name;
                entity.Tag = model.Tag;
                entity.Level = model.Level;
                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Keyword = model.Keyword;
                entity.Ord = (int)(model.Ord);
                entity.Priority = (int)(model.Priority);
                entity.Index = (int)(model.Index);
                entity.Active = (int)(model.Active);
                entity.Lang = model.Lang;
                entity.Logogroup = model.Logogroup;
                entity.ImagesLogo = model.ImagesLogo;
                entity.content = model.content;
                entity.NameEn = model.NameEn;
                entity.TitleEn = model.TitleEn;
                entity.contentEn = model.contentEn;

                Connect_Enttity.GroupMenuSanPhams.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(GroupMenuSanPham_Model model)
        {
            var data = Connect_Enttity.GroupMenuSanPhams.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
                data.Tag = model.Tag;
                data.Level = model.Level;
                data.Title = model.Title;
                data.Description = model.Description;
                data.Keyword = model.Keyword;
                data.Ord = (int)(model.Ord);
                data.Priority = (int)(model.Priority);
                data.Index = (int)(model.Index);
                data.Active = (int)(model.Active);
                data.Lang = model.Lang;
                data.Logogroup = model.Logogroup;
                data.ImagesLogo = model.ImagesLogo;
                data.content = model.content;
                data.NameEn = model.NameEn;
                data.TitleEn = model.TitleEn;
                data.contentEn = model.contentEn;

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