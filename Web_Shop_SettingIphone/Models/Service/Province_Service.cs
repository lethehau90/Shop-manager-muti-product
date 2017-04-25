using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Web_Shop_SettingIphone.Models.Entity;
using Web_Shop_SettingIphone.Models.Command;
using Web_Shop_SettingIphone.Models.Data;

namespace Web_Shop_SettingIphone.Models.Data
{
    public class Province_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Province_Model> GetAll()
        {
            IList<Province_Model> result = new List<Province_Model>();

            result = Connect_Enttity.Provinces.Select(x => new Province_Model
            {
                Id = x.Id,
                Name = x.Name,
                NameEn = x.NameEn

            }).ToList();

            return result;
        }

        public IList<Province_Model> GetId(Province_Model model)
        {
            IList<Province_Model> result = new List<Province_Model>();

            result = Connect_Enttity.Provinces.Where(x => x.Id == model.Id).Select(x => new Province_Model
            {
                Id = x.Id,
                Name = x.Name,
                NameEn = x.NameEn
            }).ToList();

            return result;
        }

        public IEnumerable<Province_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Province_Model> ReadID(Province_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Provinces where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Provinces.Remove(data);
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
                    var data = Connect_Enttity.Provinces.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.Provinces.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(Province_Model model)
        {
            var data = Connect_Enttity.Provinces.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new Province();
                entity.Name = model.Name;
                entity.NameEn = model.NameEn;

                Connect_Enttity.Provinces.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Province_Model model)
        {
            var data = Connect_Enttity.Provinces.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
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