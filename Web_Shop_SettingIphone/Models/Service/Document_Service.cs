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
    public class Document_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Document_Model> GetAll()
        {
            IList<Document_Model> result = new List<Document_Model>();

            result = Connect_Enttity.Documents.Select(x => new Document_Model
            {
                Id = x.Id,
                

            }).ToList();

            return result;
        }

        public IList<Document_Model> GetId(Document_Model model)
        {
            IList<Document_Model> result = new List<Document_Model>();

            result = Connect_Enttity.Documents.Where(x => x.Id == model.Id).Select(x => new Document_Model
            {
                Id = x.Id,
                Code=x.Code,
                Name=x.Name,
                Images=x.Images,
                CreateDate=Convert.ToDateTime(x.CreateDate),
                EffectiveDate=Convert.ToDateTime(x.EffectiveDate),
                Info = x.Info,
                File=x.File,
                Ord= (int)(x.Ord),
                Priority=(int)(x.Priority),
                Active=(int)(x.Active),
                TypeId=(int)(x.TypeId),
                MemberId = (int)(x.MemberId),
                Lang = x.Lang,
                NameEn = x.NameEn,
                infoEn = x.infoEn
            }).ToList();

            return result;
        }

        public IEnumerable<Document_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Document_Model> ReadID(Document_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Documents where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Documents.Remove(data);
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
                    var data = Connect_Enttity.Documents.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.Documents.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(Document_Model model)
        {
            var data = Connect_Enttity.Documents.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new Document();
                entity.Code=model.Code;
                entity.Name=model.Name;
                entity.Images=model.Images;
                entity.CreateDate=Convert.ToDateTime(model.CreateDate);
                entity.EffectiveDate=Convert.ToDateTime(model.EffectiveDate);
                entity.Info = model.Info;
                entity.File=model.File;
                entity.Ord= (int)(model.Ord);
                entity.Priority=(int)(model.Priority);
                entity.Active=(int)(model.Active);
                entity.TypeId=(int)(model.TypeId);
                entity.MemberId = (int)(model.MemberId);
                entity.Lang = model.Lang;
                entity.NameEn = model.NameEn;
                entity.infoEn = model.infoEn;

                Connect_Enttity.Documents.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Document_Model model)
        {
            var data = Connect_Enttity.Documents.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Code = model.Code;
                data.Name = model.Name;
                data.Images = model.Images;
                data.CreateDate = Convert.ToDateTime(model.CreateDate);
                data.EffectiveDate = Convert.ToDateTime(model.EffectiveDate);
                data.Info = model.Info;
                data.File = model.File;
                data.Ord = (int)(model.Ord);
                data.Priority = (int)(model.Priority);
                data.Active = (int)(model.Active);
                data.TypeId = (int)(model.TypeId);
                data.MemberId = (int)(model.MemberId);
                data.Lang = model.Lang;
                data.NameEn = model.NameEn;
                data.infoEn = model.infoEn;

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