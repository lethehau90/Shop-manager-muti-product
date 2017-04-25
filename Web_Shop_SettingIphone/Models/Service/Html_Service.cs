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
    public class Html_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Html_Model> GetAll()
        {
            IList<Html_Model> result = new List<Html_Model>();

            result = Connect_Enttity.Htmls.Select(x => new Html_Model
            {
                id = x.id,
                type = (int)x.type,
                Active = (int)x.Active,
                Lang = x.Lang,
                Ten = x.Ten,
                Html_content = x.Html_content,
                TenEn = x.TenEn,
                Html_contentEn = x.Html_contentEn,
                images = x.images,
                Ord = (int)x.Ord

            }).ToList();

            return result;
        }

        public IList<Html_Model> GetId(Html_Model model)
        {
            IList<Html_Model> result = new List<Html_Model>();

            result = Connect_Enttity.Htmls.Where(x => x.id == model.id).Select(x => new Html_Model
            {
                id = x.id,
                type = (int)(x.type),
                Active = (int)(x.Active),
                Lang = x.Lang,
                Ten = x.Ten,
                Html_content = x.Html_content,
                TenEn = x.TenEn,
                Html_contentEn = x.Html_contentEn,
                images = x.images,
                Ord = (int)x.Ord

            }).ToList();

            return result;
        }

        public IEnumerable<Html_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Html_Model> ReadID(Html_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Htmls where c.id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Htmls.Remove(data);
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
                    var data = Connect_Enttity.Htmls.FirstOrDefault(x => x.id.Equals(i));
                    Connect_Enttity.Htmls.Remove(data);
                    Connect_Enttity.SaveChanges();

                }

                Dispose();

            }

        }

        public void Create(Html_Model model)
        {
            var data = Connect_Enttity.Htmls.FirstOrDefault(x => x.id == model.id);
            if (data == null)
            {
                var entity = new Html();
                entity.type = (int)(model.type);
                entity.Active = (int)(model.Active);
                entity.Lang = model.Lang;
                entity.Ten = model.Ten;
                entity.Html_content = model.Html_content;
                entity.TenEn = model.TenEn;
                entity.Html_contentEn = model.Html_contentEn;
                entity.images = model.images;
                entity.Ord = model.Ord;

                Connect_Enttity.Htmls.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Html_Model model)
        {
            var data = Connect_Enttity.Htmls.FirstOrDefault(x => x.id == model.id);
            if (data != null)
            {
                data.type = (int)(model.type);
                data.Active = (int)(model.Active);
                data.Lang = model.Lang;
                data.Ten = model.Ten;
                data.Html_content = model.Html_content;
                data.TenEn = model.TenEn;
                data.Html_contentEn = model.Html_contentEn;
                data.images = model.images;
                data.Ord = model.Ord;

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