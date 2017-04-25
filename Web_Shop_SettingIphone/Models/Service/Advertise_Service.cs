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
    public class Advertise_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Advertise_Model> GetAll()
        {
            IList<Advertise_Model> result = new List<Advertise_Model>();

            result = Connect_Enttity.Advertises.Select(x => new Advertise_Model
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                Width = (int)(x.Width),
                Height = (int)(x.Height),
                Link = x.Link,
                Target = x.Target,
                Content = x.Content,
                Position = (short)(x.Position), 
                PageId = (int)(x.PageId),
                Click = (int)(x.Click),
                Ord = (int)(x.Ord),
                Active = (bool)(x.Active),
                Lang = x.Lang,
                NameEn = x.NameEn,
                ContentEn = x.ContentEn,
                Ngaytao = (DateTime)(x.Ngaytao),  
                Ngayhethan = (DateTime)(x.Ngayhethan),
                LuotClick = (int)(x.LuotClick)
               
            }).ToList();

            return result;
        }

        public IList<Advertise_Model> GetId(Advertise_Model model)
        {
            IList<Advertise_Model> result = new List<Advertise_Model>();

            result = Connect_Enttity.Advertises.Where(x => x.Id == model.Id).Select(x => new Advertise_Model
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                Width = (int)(x.Width),
                Height = (int)(x.Height),
                Link = x.Link,
                Target = x.Target,
                Content = x.Content,
                Position = (short)(x.Position),
                PageId = (int)(x.PageId),
                Click = (int)(x.Click),
                Ord = (int)(x.Ord),
                Active = (bool)(x.Active),
                Lang = x.Lang,
                NameEn = x.NameEn,
                ContentEn = x.ContentEn,
                Ngaytao = Convert.ToDateTime(x.Ngaytao),
                Ngayhethan = Convert.ToDateTime(x.Ngayhethan),
                LuotClick = (int)(x.LuotClick)

            }).ToList();

            return result;
        }

        public IEnumerable<Advertise_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Advertise_Model> ReadID(Advertise_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Advertises where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Advertises.Remove(data);
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
                    var data = Connect_Enttity.Advertises.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.Advertises.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(Advertise_Model model)
        {
            var data = Connect_Enttity.Advertises.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new Advertise();
                entity.Name = model.Name;
                entity.Image = model.Image;
                entity.Width = (int)(model.Width);
                entity.Height = (int)(model.Height);
                entity.Link = model.Link;
                entity.Target = model.Target;
                entity.Content = model.Content;
                entity.Position = (short)(model.Position);
                entity.PageId = (int)(model.PageId);
                entity.Click = (int)(model.Click);
                entity.Ord = (int)(model.Ord);
                entity.Active = (bool)(model.Active);
                entity.Lang = model.Lang;
                entity.NameEn = model.NameEn;
                entity.ContentEn = model.ContentEn;
                entity.Ngaytao = Convert.ToDateTime(model.Ngaytao);
               
                if (model.Ngayhethan==null)
                {
                   entity.Ngayhethan = null;
                }
                else
                {
                    entity.Ngayhethan = Convert.ToDateTime(model.Ngayhethan);
                }
               
                entity.LuotClick = (int)(model.LuotClick);
                Connect_Enttity.Advertises.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Advertise_Model model)
        {
            var data = Connect_Enttity.Advertises.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
                data.Image = model.Image;
                data.Width = (int)(model.Width);
                data.Height = (int)(model.Height);
                data.Link = model.Link;
                data.Target = model.Target;
                data.Content = model.Content;
                data.Position = (short)(model.Position);
                data.PageId = (int)(model.PageId);
                data.Click = (int)(model.Click);
                data.Ord = (int)(model.Ord);
                data.Active = (bool)(model.Active);
                data.Lang = model.Lang;
                data.NameEn = model.NameEn;
                data.ContentEn = model.ContentEn;
                data.Ngaytao = Convert.ToDateTime(model.Ngaytao);
                if (model.Ngayhethan == null)
                {
                    data.Ngayhethan = null;
                }
                else
                {
                    data.Ngayhethan = Convert.ToDateTime(model.Ngayhethan);
                }
                data.LuotClick = (int)(model.LuotClick);
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