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
    public class DientuCapLoaithuoctinh_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<DientuCapLoaithuoctinh_Model> GetAll()
        {
            IList<DientuCapLoaithuoctinh_Model> result = new List<DientuCapLoaithuoctinh_Model>();

            result = Connect_Enttity.DientuCapLoaithuoctinhs.Select(x => new DientuCapLoaithuoctinh_Model
            {
                Id = x.Id,
                Name = x.Name,
                Ord = (int)(x.Ord),
                Active = (bool)(x.Active),
                Content = x.Content

            }).ToList();

            return result;
        }

        public IList<DientuCapLoaithuoctinh_Model> GetId(DientuCapLoaithuoctinh_Model model)
        {
            IList<DientuCapLoaithuoctinh_Model> result = new List<DientuCapLoaithuoctinh_Model>();

            result = Connect_Enttity.DientuCapLoaithuoctinhs.Where(x => x.Id == model.Id).Select(x => new DientuCapLoaithuoctinh_Model
            {
                Id = x.Id,
                Name = x.Name,
                Ord = (int)(x.Ord),
                Active = (bool)(x.Active),
                Content = x.Content

            }).ToList();

            return result;
        }

        public IEnumerable<DientuCapLoaithuoctinh_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<DientuCapLoaithuoctinh_Model> ReadID(DientuCapLoaithuoctinh_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.DientuCapLoaithuoctinhs where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.DientuCapLoaithuoctinhs.Remove(data);
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
                    var data = Connect_Enttity.DientuCapLoaithuoctinhs.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.DientuCapLoaithuoctinhs.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(DientuCapLoaithuoctinh_Model model)
        {
            var data = Connect_Enttity.DientuCapLoaithuoctinhs.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new DientuCapLoaithuoctinh();
                entity.Name = model.Name;
                entity.Ord = (int)(model.Ord);
                entity.Active = (bool)(model.Active);
                entity.Content = model.Content;

                Connect_Enttity.DientuCapLoaithuoctinhs.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(DientuCapLoaithuoctinh_Model model)
        {
            var data = Connect_Enttity.DientuCapLoaithuoctinhs.FirstOrDefault(x => x.Id == model.Id);
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