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
    public class Chitiethinh_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Chitiethinh_Model> GetAll()
        {
            IList<Chitiethinh_Model> result = new List<Chitiethinh_Model>();

            result = Connect_Enttity.Chitiethinhs.Select(x => new Chitiethinh_Model
            {
               id=x.id,
               IDsanpham=x.IDsanpham,
               Images=x.Images,
               Thumimg=x.Thumimg,
               Thumsimg=x.Thumsimg,
               ord= (int)(x.ord)
            }).ToList();

            return result;
        }

        public IList<Chitiethinh_Model> GetId(Chitiethinh_Model model)
        {
            IList<Chitiethinh_Model> result = new List<Chitiethinh_Model>();

            result = Connect_Enttity.Chitiethinhs.Where(x => x.id == model.id).Select(x => new Chitiethinh_Model
            {
                id = x.id,
                IDsanpham = x.IDsanpham,
                Images = x.Images,
                Thumimg = x.Thumimg,
                Thumsimg = x.Thumsimg,
                ord = (int)(x.ord)
            }).ToList();

            return result;
        }
       
        public IEnumerable<Chitiethinh_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Chitiethinh_Model> ReadID(Chitiethinh_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Chitiethinhs where c.id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Chitiethinhs.Remove(data);
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
                    var data = Connect_Enttity.Chitiethinhs.FirstOrDefault(x => x.id.Equals(i));
                    Connect_Enttity.Chitiethinhs.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(Chitiethinh_Model model)
        {
            var data = Connect_Enttity.Chitiethinhs.FirstOrDefault(x => x.id == model.id);
            if (data == null)
            {
                var entity = new Chitiethinh();
                entity.IDsanpham = model.IDsanpham;
                entity.Images = model.Images;
                entity.Thumimg = model.Thumimg;
                entity.Thumsimg = model.Thumsimg;
                entity.ord = (int)(model.ord);

                Connect_Enttity.Chitiethinhs.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Chitiethinh_Model model)
        {
            var data = Connect_Enttity.Chitiethinhs.FirstOrDefault(x => x.id == model.id);
            if (data != null)
            {
                data.IDsanpham = model.IDsanpham;
                data.Images = model.Images;
                data.Thumimg = model.Thumimg;
                data.Thumsimg = model.Thumsimg;
                data.ord = (int)(model.ord);

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