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
    public class DientuLoaithuoctinh_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<DientuLoaithuoctinh_Model> GetAll()
        {
            IList<DientuLoaithuoctinh_Model> result = new List<DientuLoaithuoctinh_Model>();

            result = Connect_Enttity.DientuLoaithuoctinhs.Select(x => new DientuLoaithuoctinh_Model
            {
                Id = x.Id,
                Name = x.Name,
                Ord = (int)(x.Ord),
                Active = (bool)(x.Active),
                Content = x.Content

            }).ToList();

            return result;
        }

        public IList<DientuLoaithuoctinh_Model> GetId(DientuLoaithuoctinh_Model model)
        {
            IList<DientuLoaithuoctinh_Model> result = new List<DientuLoaithuoctinh_Model>();

            result = Connect_Enttity.DientuLoaithuoctinhs.Where(x => x.Id == model.Id).Select(x => new DientuLoaithuoctinh_Model
            {
                Id = x.Id,
                Name = x.Name,
                Ord = (int)(x.Ord),
                Active = (bool)(x.Active),
                Content = x.Content

            }).ToList();

            return result;
        }

        public IEnumerable<DientuLoaithuoctinh_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<DientuLoaithuoctinh_Model> ReadID(DientuLoaithuoctinh_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.DientuLoaithuoctinhs where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.DientuLoaithuoctinhs.Remove(data);
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
                    var data = Connect_Enttity.DientuLoaithuoctinhs.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.DientuLoaithuoctinhs.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(DientuLoaithuoctinh_Model model)
        {
            var data = Connect_Enttity.DientuLoaithuoctinhs.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new DientuLoaithuoctinh();
                entity.Name = model.Name;
                entity.Ord = (int)(model.Ord);
                entity.Active = (bool)(model.Active);
                entity.Content = model.Content;

                Connect_Enttity.DientuLoaithuoctinhs.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(DientuLoaithuoctinh_Model model)
        {
            var data = Connect_Enttity.DientuLoaithuoctinhs.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
                data.Ord = (int)(model.Ord);
                data.Active = (bool)(model.Active);
                data.Content = model.Content;

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