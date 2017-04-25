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
    public class DientuNsx_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<DientuNsx_Model> GetAll()
        {
            IList<DientuNsx_Model> result = new List<DientuNsx_Model>();

            result = Connect_Enttity.DientuNsxes.Select(x => new DientuNsx_Model
            {
                Id = x.Id,
                Name = x.Name,
                Images = (x.Images),
                Active = (bool)(x.Active),
                Ord = (int)(x.Ord),
                Content = (x.Content)
            }).ToList();

            return result;
        }

        public IList<DientuNsx_Model> GetId(DientuNsx_Model model)
        {
            IList<DientuNsx_Model> result = new List<DientuNsx_Model>();

            result = Connect_Enttity.DientuNsxes.Where(x => x.Id == model.Id).Select(x => new DientuNsx_Model
            {
                Id = x.Id,
                Name = x.Name,
                Images = (x.Images),
                Active = (bool)(x.Active),
                Ord = (int)(x.Ord),
                Content = (x.Content)
            }).ToList();

            return result;
        }
        public IEnumerable<DientuNsx_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<DientuNsx_Model> ReadID(DientuNsx_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.DientuNsxes where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.DientuNsxes.Remove(data);
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
                    var data = Connect_Enttity.DientuNsxes.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.DientuNsxes.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(DientuNsx_Model model)
        {
            var data = Connect_Enttity.DientuNsxes.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new DientuNsx();
                entity.Name = model.Name;
                entity.Images = (model.Images);
                entity.Active = (bool)(model.Active);
                entity.Ord = (int)(model.Ord);
                entity.Content = model.Content;

                Connect_Enttity.DientuNsxes.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(DientuNsx_Model model)
        {
            var data = Connect_Enttity.DientuNsxes.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Id = model.Id;
                data.Name = model.Name;
                data.Images = (model.Images);
                data.Active = (bool)(model.Active);
                data.Ord = (int)(model.Ord);
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