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
    public class quantity_purchased_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<quantity_purchased_Model> GetAll()
        {
            IList<quantity_purchased_Model> result = new List<quantity_purchased_Model>();

            result = Connect_Enttity.quantity_purchased.Select(x => new quantity_purchased_Model
            {
                Id_quantity = x.Id_quantity,
                Sl_mua = (int)(x.Sl_mua),
                Phan_tram_tang = (int)(x.Phan_tram_tang),
                Active = (bool)(x.Active)

            }).ToList();

            return result;
        }

        public IList<quantity_purchased_Model> GetId(quantity_purchased_Model model)
        {
            IList<quantity_purchased_Model> result = new List<quantity_purchased_Model>();

            result = Connect_Enttity.quantity_purchased.Where(x => x.Id_quantity == model.Id_quantity).Select(x => new quantity_purchased_Model
            {
                Id_quantity = x.Id_quantity,
                Sl_mua = (int)(x.Sl_mua),
                Phan_tram_tang = (int)(x.Phan_tram_tang),
                Active = (bool)(x.Active)
            }).ToList();

            return result;
        }

        public IEnumerable<quantity_purchased_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<quantity_purchased_Model> ReadID(quantity_purchased_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.quantity_purchased where c.Id_quantity == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.quantity_purchased.Remove(data);
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
                    var data = Connect_Enttity.quantity_purchased.FirstOrDefault(x => x.Id_quantity.Equals(i));
                    Connect_Enttity.quantity_purchased.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(quantity_purchased_Model model)
        {
            var data = Connect_Enttity.quantity_purchased.FirstOrDefault(x => x.Id_quantity == model.Id_quantity);
            if (data == null)
            {
                var entity = new quantity_purchased();

                entity.Sl_mua = (int)(model.Sl_mua);
                entity.Phan_tram_tang = (int)(model.Phan_tram_tang);
                entity.Active = (bool)(model.Active);

                Connect_Enttity.quantity_purchased.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(quantity_purchased_Model model)
        {
            var data = Connect_Enttity.quantity_purchased.FirstOrDefault(x => x.Id_quantity == model.Id_quantity);
            if (data != null)
            {
                data.Sl_mua = (int)(model.Sl_mua);
                data.Phan_tram_tang = (int)(model.Phan_tram_tang);
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