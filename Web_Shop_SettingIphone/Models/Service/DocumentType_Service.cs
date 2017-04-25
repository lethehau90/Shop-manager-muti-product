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
    public class DocumentType_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<DocumentType_Model> GetAll()
        {
            IList<DocumentType_Model> result = new List<DocumentType_Model>();

            result = Connect_Enttity.DocumentTypes.Select(x => new DocumentType_Model
            {
                Id = x.Id,
                Name = x.Name,
                Ord = (int)(x.Ord),
                Active = (int)(x.Active),
                Lang = x.Lang,
                NameEn = x.NameEn

            }).ToList();

            return result;
        }

        public IList<DocumentType_Model> GetId(DocumentType_Model model)
        {
            IList<DocumentType_Model> result = new List<DocumentType_Model>();

            result = Connect_Enttity.DocumentTypes.Where(x => x.Id == model.Id).Select(x => new DocumentType_Model
            {
                Id = x.Id,
                Name=x.Name,
                Ord=(int)(x.Ord),
                Active=(int)(x.Active),
                Lang=x.Lang,
                NameEn=x.NameEn
            }).ToList();

            return result;
        }

        public IEnumerable<DocumentType_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<DocumentType_Model> ReadID(DocumentType_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.DocumentTypes where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.DocumentTypes.Remove(data);
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
                    var data = Connect_Enttity.DocumentTypes.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.DocumentTypes.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(DocumentType_Model model)
        {
            var data = Connect_Enttity.DocumentTypes.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new DocumentType();
                entity.Name=model.Name;
                entity.Ord=(int)(model.Ord);
                entity.Active=(int)(model.Active);
                entity.Lang=model.Lang;
                entity.NameEn = model.NameEn;

                Connect_Enttity.DocumentTypes.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(DocumentType_Model model)
        {
            var data = Connect_Enttity.DocumentTypes.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
                data.Ord = (int)(model.Ord);
                data.Active = (int)(model.Active);
                data.Lang = model.Lang;
                data.NameEn = model.NameEn;

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