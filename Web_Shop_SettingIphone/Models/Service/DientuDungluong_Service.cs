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
    public class DientuDungluong_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<DientuDungluong_Model> GetAll()
        {
            IList<DientuDungluong_Model> result = new List<DientuDungluong_Model>();

            result = Connect_Enttity.DientuDungluongs.Select(x => new DientuDungluong_Model
            {
                Id = x.Id,
                Name = x.Name,
                Ord = (int)(x.Ord),
                Active = (bool)(x.Active)
            }).ToList();

            return result;
        }

        public IList<DientuDungluong_Model> GetId(DientuDungluong_Model model)
        {
            IList<DientuDungluong_Model> result = new List<DientuDungluong_Model>();

            result = Connect_Enttity.DientuDungluongs.Where(x => x.Id == model.Id).Select(x => new DientuDungluong_Model
            {
                Id = x.Id,
                Name = x.Name,
                Ord = (int)(x.Ord),
                Active = (bool)(x.Active)

            }).ToList();

            return result;
        }

        public IEnumerable<DientuDungluong_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<DientuDungluong_Model> ReadID(DientuDungluong_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.DientuDungluongs where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.DientuDungluongs.Remove(data);
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
                    var data = Connect_Enttity.DientuDungluongs.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.DientuDungluongs.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(DientuDungluong_Model model)
        {
            var data = Connect_Enttity.DientuDungluongs.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new DientuDungluong();
                entity.Name = model.Name;
                entity.Ord = (int)(model.Ord);
                entity.Active = (bool)(model.Active);
                Connect_Enttity.DientuDungluongs.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(DientuDungluong_Model model)
        {
            var data = Connect_Enttity.DientuDungluongs.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
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