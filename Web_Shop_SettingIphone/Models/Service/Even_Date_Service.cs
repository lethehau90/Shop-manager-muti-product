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
    public class Even_Date_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Even_Date_Model> GetAll()
        {
            IList<Even_Date_Model> result = new List<Even_Date_Model>();

            result = Connect_Enttity.Even_Date.Select(x => new Even_Date_Model
            {
                Id = x.Id,
                Name = x.Name,
                NameEn = x.NameEn,
                content = x.content,
                contentEn = x.contentEn,
                Date_event_start = (DateTime)(x.Date_event_start),
                Date_event_end = (DateTime)(x.Date_event_end),
                Price_event = (int)(x.Price_event),
                Ord = (int)(x.Ord),
                Active = (bool)(x.Active)
            }).ToList();

            return result;
        }

        public IList<Even_Date_Model> GetId(Even_Date_Model model)
        {
            IList<Even_Date_Model> result = new List<Even_Date_Model>();

            result = Connect_Enttity.Even_Date.Where(x => x.Id == model.Id).Select(x => new Even_Date_Model
            {
                Id = x.Id,
                Name = x.Name,
                NameEn = x.NameEn,
                content = x.content,
                contentEn = x.contentEn,
                Date_event_start = (DateTime)(x.Date_event_start),
                Date_event_end = (DateTime)(x.Date_event_end),
                Price_event = (int)(x.Price_event),
                Ord = (int)(x.Ord),
                Active = (bool)(x.Active)

            }).ToList();

            return result;
        }

        public IEnumerable<Even_Date_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Even_Date_Model> ReadID(Even_Date_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Even_Date where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Even_Date.Remove(data);
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
                    var data = Connect_Enttity.Even_Date.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.Even_Date.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(Even_Date_Model model)
        {
            var data = Connect_Enttity.Even_Date.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new Even_Date();
                entity.Name = model.Name;
                entity.NameEn = model.NameEn;
                entity.content = model.content;
                entity.contentEn = model.contentEn;
               
                entity.Price_event = model.Price_event;

                if (model.Date_event_start == null)
                {
                    entity.Date_event_start = null;
                }
                else
                {
                    entity.Date_event_start = Convert.ToDateTime(model.Date_event_start);
                }

                if (model.Date_event_end == null)
                {
                    entity.Date_event_end = null;
                }
                else
                {
                    entity.Date_event_end = Convert.ToDateTime(model.Date_event_end);
                }

                entity.Ord = (int)(model.Ord);
                entity.Active = (bool)(model.Active);

                Connect_Enttity.Even_Date.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Even_Date_Model model)
        {
            var data = Connect_Enttity.Even_Date.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
                data.NameEn = model.NameEn;
                data.content = model.content;
                data.contentEn = model.contentEn;

                data.Price_event = model.Price_event;

                if (model.Date_event_start == null)
                {
                    data.Date_event_start = null;
                }
                else
                {
                    data.Date_event_start = Convert.ToDateTime(model.Date_event_start);
                }

                if (model.Date_event_end == null)
                {
                    data.Date_event_end = null;
                }
                else
                {
                    data.Date_event_end = Convert.ToDateTime(model.Date_event_end);
                }

                data.Ord = (int)(model.Ord);
                data.Active = (bool)(model.Active);

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