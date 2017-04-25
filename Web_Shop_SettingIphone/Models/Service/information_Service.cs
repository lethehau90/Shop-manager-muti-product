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
    public class information_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<information_Model> GetAll()
        {
            IList<information_Model> result = new List<information_Model>();

            result = Connect_Enttity.information.Select(x => new information_Model
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                Target=x.Target,
                Content = x.Content,
                Detail = x.Detail,
                Position = (short)(x.Position),
                Click = (int)(x.Click),
                Ord = (int)(x.Ord),
                Active = (bool)(x.Active),
                Lang = x.Lang,
                Title = x.Title,
                Description = x.Description,
                Keyword = x.Keyword,
                Image1 = x.Image1,
                Image2 = x.Image2,
                Image3 = x.Image3,
                Image4 = x.Image4,
                Image5 = x.Image5,
                Index = (int)(x.Index),
                Priority = (int)(x.Priority),
                Tag = x.Tag,
                NameEn = x.NameEn,
                ContentEn = x.ContentEn,
                DetailEn = x.DetailEn

            }).ToList();

            return result;
        }

        public IList<information_Model> GetId(information_Model model)
        {
            IList<information_Model> result = new List<information_Model>();

            result = Connect_Enttity.information.Where(x => x.Id == model.Id).Select(x => new information_Model
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                Target = x.Target,
                Content = x.Content,
                Detail = x.Detail,
                Position = (short)(x.Position),
                Click = (int)(x.Click),
                Ord = (int)(x.Ord),
                Active = (bool)(x.Active),
                Lang = x.Lang,
                Title = x.Title,
                Description = x.Description,
                Keyword = x.Keyword,
                Image1 = x.Image1,
                Image2 = x.Image2,
                Image3 = x.Image3,
                Image4 = x.Image4,
                Image5 = x.Image5,
                Index = (int)(x.Index),
                Priority = (int)(x.Priority),
                Tag = x.Tag,
                NameEn = x.NameEn,
                ContentEn = x.ContentEn,
                DetailEn = x.DetailEn

            }).ToList();

            return result;
        }

        public IEnumerable<information_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<information_Model> ReadID(information_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.information where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.information.Remove(data);
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
                    var data = Connect_Enttity.information.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.information.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(information_Model model)
        {
            var data = Connect_Enttity.information.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new information();

                entity.Name = model.Name;
                entity.Image = model.Image;
                entity.Target = model.Target;
                entity.Content = model.Content;
                entity.Detail = model.Detail;
                entity.Position = (short)(model.Position);
                entity.Click = (int)(model.Click);
                entity.Ord = (int)(model.Ord);
                entity.Active = (bool)(model.Active);
                entity.Lang = model.Lang;
                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Keyword = model.Keyword;
                entity.Image1 = model.Image1;
                entity.Image2 = model.Image2;
                entity.Image3 = model.Image3;
                entity.Image4 = model.Image4;
                entity.Image5 = model.Image5;
                entity.Index = (int)(model.Index);
                entity.Priority = (int)(model.Priority);
                entity.Tag = model.Tag;
                entity.NameEn = model.NameEn;
                entity.ContentEn = model.ContentEn;
                entity.DetailEn = model.DetailEn;

                Connect_Enttity.information.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(information_Model model)
        {
            var data = Connect_Enttity.information.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
                data.Image = model.Image;
                data.Target = model.Target;
                data.Content = model.Content;
                data.Detail = model.Detail;
                data.Position = (short)(model.Position);
                data.Click = (int)(model.Click);
                data.Ord = (int)(model.Ord);
                data.Active = (bool)(model.Active);
                data.Lang = model.Lang;
                data.Title = model.Title;
                data.Description = model.Description;
                data.Keyword = model.Keyword;
                data.Image1 = model.Image1;
                data.Image2 = model.Image2;
                data.Image3 = model.Image3;
                data.Image4 = model.Image4;
                data.Image5 = model.Image5;
                data.Index = (int)(model.Index);
                data.Priority = (int)(model.Priority);
                data.Tag = model.Tag;
                data.NameEn = model.NameEn;
                data.ContentEn = model.ContentEn;
                data.DetailEn = model.DetailEn;

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