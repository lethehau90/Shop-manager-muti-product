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
    public class GroupNewsNewsDetail_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<GroupNewsNewsDetail_Model> GetAll()
        {
            IList<GroupNewsNewsDetail_Model> result = new List<GroupNewsNewsDetail_Model>();

            result = Connect_Enttity.GroupNewsNewsDetails.Select(x => new GroupNewsNewsDetail_Model
            {
                Id = x.Id,
                Name = x.Name,
                Tag = x.Tag,
                Image = x.Image,
                Content = x.Content,
                Detail = x.Detail,
                Date = Convert.ToDateTime(x.Date),
                Title = x.Title,
                Description = x.Description,
                Keyword = x.Keyword,
                Priority = (int)(x.Priority),
                Index = (int)(x.Index),
                Active = (int)(x.Active),
                ord= (int)(x.ord),
                Nguon=x.Nguon,
                Lang = x.Lang,
                Image1 = x.Image1,
                Image2 = x.Image2,
                Image3 = x.Image3,
                Image4 = x.Image4,
                Image5 = x.Images5,
                GroupNewsCatTag = x.GroupNewsCatTag,
                Cateprolevel1 = x.Cateprolevel1,
                Cateprolevel2 = x.Cateprolevel2,
                Cateprolevel3 = x.Cateprolevel3,
                NameEn = x.NameEn,
                ContentEn = x.ContentEn,
                DetailEn = x.DetailEn,
                DateView = Convert.ToDateTime(x.DateView),
                Luotxem= (int)(x.Luotxem)

            }).ToList();

            return result;
        }

        public IList<GroupNewsNewsDetail_Model> GetId(GroupNewsNewsDetail_Model model)
        {
            IList<GroupNewsNewsDetail_Model> result = new List<GroupNewsNewsDetail_Model>();

            result = Connect_Enttity.GroupNewsNewsDetails.Where(x => x.Id == model.Id).Select(x => new GroupNewsNewsDetail_Model
            {
                Id = x.Id,
                Name = x.Name,
                Tag = x.Tag,
                Image = x.Image,
                Content = x.Content,
                Detail = x.Detail,
                Date = Convert.ToDateTime(x.Date),
                Title = x.Title,
                Description = x.Description,
                Keyword = x.Keyword,
                Priority = (int)(x.Priority),
                Index = (int)(x.Index),
                Active = (int)(x.Active),
                ord = (int)(x.ord),
                Nguon = x.Nguon,
                Lang = x.Lang,
                Image1 = x.Image1,
                Image2 = x.Image2,
                Image3 = x.Image3,
                Image4 = x.Image4,
                Image5 = x.Images5,
                GroupNewsCatTag = x.GroupNewsCatTag,
                Cateprolevel1 = x.Cateprolevel1,
                Cateprolevel2 = x.Cateprolevel2,
                Cateprolevel3 = x.Cateprolevel3,
                NameEn = x.NameEn,
                ContentEn = x.ContentEn,
                DetailEn = x.DetailEn,
                DateView=x.DateView,
                Luotxem=x.Luotxem


            }).ToList();

            return result;
        }

        public IEnumerable<GroupNewsNewsDetail_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<GroupNewsNewsDetail_Model> ReadID(GroupNewsNewsDetail_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.GroupNewsNewsDetails where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.GroupNewsNewsDetails.Remove(data);
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
                    var data = Connect_Enttity.GroupNewsNewsDetails.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.GroupNewsNewsDetails.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(GroupNewsNewsDetail_Model model)
        {
            var data = Connect_Enttity.GroupNewsNewsDetails.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new GroupNewsNewsDetail();

                entity.Name = model.Name;
                entity.Tag = model.Tag;
                entity.Image = model.Image;
                entity.Content = model.Content;
                entity.Detail = model.Detail;
                entity.Date = Convert.ToDateTime(model.Date);
                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Keyword = model.Keyword;
                entity.Priority = (int)(model.Priority);
                entity.Index = (int)(model.Index);
                entity.Active = (int)(model.Active);
                entity.ord = (int)(model.ord);
                entity.Nguon = model.Nguon;
                entity.Lang = model.Lang;
                entity.Image1 = model.Image1;
                entity.Image2 = model.Image2;
                entity.Image3 = model.Image3;
                entity.Image4 = model.Image4;
                entity.Images5 = model.Image5;
                entity.GroupNewsCatTag = model.GroupNewsCatTag;
                entity.Cateprolevel1 = model.Cateprolevel1;
                entity.Cateprolevel2 = model.Cateprolevel2;
                entity.Cateprolevel3 = model.Cateprolevel3;
                entity.NameEn = model.NameEn;
                entity.ContentEn = model.ContentEn;
                entity.DetailEn = model.DetailEn;
                entity.DateView = model.DateView;
                entity.Luotxem = model.Luotxem;

                Connect_Enttity.GroupNewsNewsDetails.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(GroupNewsNewsDetail_Model model)
        {
            var data = Connect_Enttity.GroupNewsNewsDetails.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
                data.Tag = model.Tag;
                data.Image = model.Image;
                data.Content = model.Content;
                data.Detail = model.Detail;
                data.Date = Convert.ToDateTime(model.Date);
                data.Title = model.Title;
                data.Description = model.Description;
                data.Keyword = model.Keyword;
                data.Priority = (int)(model.Priority);
                data.Index = (int)(model.Index);
                data.Active = (int)(model.Active);
                data.ord = (int)(model.ord);
                data.Nguon = model.Nguon;
                data.Lang = model.Lang;
                data.Image1 = model.Image1;
                data.Image2 = model.Image2;
                data.Image3 = model.Image3;
                data.Image4 = model.Image4;
                data.Images5 = model.Image5;
                data.GroupNewsCatTag = model.GroupNewsCatTag;
                data.Cateprolevel1 = model.Cateprolevel1;
                data.Cateprolevel2 = model.Cateprolevel2;
                data.Cateprolevel3 = model.Cateprolevel3;
                data.NameEn = model.NameEn;
                data.ContentEn = model.ContentEn;
                data.DetailEn = model.DetailEn;
                data.DateView = model.DateView;
                data.Luotxem = model.Luotxem;

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