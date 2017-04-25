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
    public class Khoanggia_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Khoanggia_Model> GetAll()
        {
            IList<Khoanggia_Model> result = new List<Khoanggia_Model>();

            result = Connect_Enttity.Khoanggias.Select(x => new Khoanggia_Model
            {
                ID=x.ID,
                Khoangdau=x.Khoangdau,
                Khoangcuoi=x.Khoangcuoi,
                Vitri=(int)(x.Vitri),
                Active=(bool)(x.Active)
            }).ToList();

            return result;
        }

        public IList<Khoanggia_Model> GetId(Khoanggia_Model model)
        {
            IList<Khoanggia_Model> result = new List<Khoanggia_Model>();

            result = Connect_Enttity.Khoanggias.Where(x => x.ID == model.ID).Select(x => new Khoanggia_Model
            {
                ID = x.ID,
                Khoangdau = x.Khoangdau,
                Khoangcuoi = x.Khoangcuoi,
                Vitri = (int)(x.Vitri),
                Active = (bool)(x.Active)
            }).ToList();

            return result;
        }
        public IEnumerable<Khoanggia_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Khoanggia_Model> ReadID(Khoanggia_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Khoanggias where c.ID == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Khoanggias.Remove(data);
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
                    var data = Connect_Enttity.Khoanggias.FirstOrDefault(x => x.ID.Equals(i));
                    Connect_Enttity.Khoanggias.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(Khoanggia_Model model)
        {
            var data = Connect_Enttity.Khoanggias.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                var entity = new Khoanggia();
                entity.Khoangdau = model.Khoangdau;
                entity.Khoangcuoi = model.Khoangcuoi;
                entity.Vitri = (int)(model.Vitri);
                entity.Active = (bool)(model.Active);

                Connect_Enttity.Khoanggias.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Khoanggia_Model model)
        {
            var data = Connect_Enttity.Khoanggias.FirstOrDefault(x => x.ID == model.ID);
            if (data != null)
            {
                data.Khoangdau = model.Khoangdau;
                data.Khoangcuoi = model.Khoangcuoi;
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