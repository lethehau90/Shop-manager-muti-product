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
    public class CommentProduc_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<CommentProduc_Model> GetAll()
        {
            IList<CommentProduc_Model> result = new List<CommentProduc_Model>();

            result = Connect_Enttity.CommentProducs.Select(x => new CommentProduc_Model
            {
               Id=x.Id,
               ProId=Convert .ToInt16(x.ProId),
               Name=x.Name,
               Email=x.Email,
               Point= (int)(x.Point),
               Content= x.Content,
               Date=Convert.ToDateTime(x.Date),
               Active=(int)(x.Active),
               Level = x.Level
           
            }).ToList();

            return result;
        }

        public IList<CommentProduc_Model> GetId(CommentProduc_Model model)
        {
            IList<CommentProduc_Model> result = new List<CommentProduc_Model>();

            result = Connect_Enttity.CommentProducs.Where(x => x.Id == model.Id).Select(x => new CommentProduc_Model
            {
                Id = x.Id,
                ProId = (int)(x.ProId),
                Name = x.Name,
                Email = x.Email,
                Point = (int)(x.Point),
                Content = x.Content,
                Date = Convert.ToDateTime(x.Date),
                Active = (int)(x.Active),
                Level = x.Level
            }).ToList();

            return result;
        }

        public IEnumerable<CommentProduc_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<CommentProduc_Model> ReadID(CommentProduc_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.CommentProducs where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.CommentProducs.Remove(data);
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
                    var data = Connect_Enttity.CommentProducs.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.CommentProducs.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(CommentProduc_Model model)
        {
            var data = Connect_Enttity.CommentProducs.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new CommentProduc();
                entity.ProId=Convert .ToInt16(model.ProId);
                entity.Name=model.Name;
                entity.Email=model.Email;
                entity.Point= (int)(model.Point);
                entity.Content= model.Content;
                entity.Date=Convert.ToDateTime(model.Date);
                entity.Active = (int)(model.Active);
                entity.Level = model.Level;

                Connect_Enttity.CommentProducs.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(CommentProduc_Model model)
        {
            var data = Connect_Enttity.CommentProducs.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.ProId = (int)(model.ProId);
                data.Name = model.Name;
                data.Email = model.Email;
                data.Point = (int)(model.Point);
                data.Content = model.Content;
                data.Date = Convert.ToDateTime(model.Date);
                data.Active = (int)(model.Active);
                data.Level = model.Level;

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