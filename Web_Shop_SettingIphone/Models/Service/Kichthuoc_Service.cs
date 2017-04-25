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
    public class Kichthuoc_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Kichthuoc_Model> GetAll()
        {
            IList<Kichthuoc_Model> result = new List<Kichthuoc_Model>();

            result = Connect_Enttity.Kichthuocs.Select(x => new Kichthuoc_Model
            {
                ID = x.ID,
                Kichthuoc1 = x.Kichthuoc1,
                Vitri = (int)(x.Vitri),
                Active = (bool)(x.Active)
            }).ToList();

            return result;
        }

        public IList<Kichthuoc_Model> GetId(Kichthuoc_Model model)
        {
            IList<Kichthuoc_Model> result = new List<Kichthuoc_Model>();

            result = Connect_Enttity.Kichthuocs.Where(x => x.ID == model.ID).Select(x => new Kichthuoc_Model
            {
                ID = x.ID,
                Kichthuoc1 = x.Kichthuoc1,
                Vitri = (int)(x.Vitri),
                Active = (bool)(x.Active)
            }).ToList();

            return result;
        }
        public IEnumerable<Kichthuoc_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Kichthuoc_Model> ReadID(Kichthuoc_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Kichthuocs where c.ID == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Kichthuocs.Remove(data);
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
                    var data = Connect_Enttity.Kichthuocs.FirstOrDefault(x => x.ID.Equals(i));
                    Connect_Enttity.Kichthuocs.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(Kichthuoc_Model model)
        {
            var data = Connect_Enttity.Kichthuocs.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                var entity = new Kichthuoc();
                entity.Kichthuoc1 = model.Kichthuoc1;
                entity.Vitri = (int)(model.Vitri);
                entity.Active = (bool)(model.Active);

                Connect_Enttity.Kichthuocs.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Kichthuoc_Model model)
        {
            var data = Connect_Enttity.Kichthuocs.FirstOrDefault(x => x.ID == model.ID);
            if (data != null)
            {
                data.Kichthuoc1 = model.Kichthuoc1;
                data.Vitri = (int)(model.Vitri);
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