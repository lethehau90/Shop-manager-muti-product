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
    public class Url_thanhtoan_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Url_thanhtoan_Model> GetAll()
        {
            IList<Url_thanhtoan_Model> result = new List<Url_thanhtoan_Model>();

            result = Connect_Enttity.Url_thanhtoan.Select(x => new Url_thanhtoan_Model
            {
                id = x.id,
                Name = x.Name,
                Address = x.Address,
                PhoneNumber =x.PhoneNumber,
                Fax = x.Fax,
                vitri = (int)(x.vitri)

            }).ToList();

            return result;
        }

        public IList<Url_thanhtoan_Model> GetId(Url_thanhtoan_Model model)
        {
            IList<Url_thanhtoan_Model> result = new List<Url_thanhtoan_Model>();

            result = Connect_Enttity.Url_thanhtoan.Where(x => x.id == model.id).Select(x => new Url_thanhtoan_Model
            {
                id = x.id,
                Name = x.Name,
                Address = x.Address,
                PhoneNumber = x.PhoneNumber,
                Fax = x.Fax,
                vitri = (int)(x.vitri)

            }).ToList();

            return result;
        }

        public IEnumerable<Url_thanhtoan_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Url_thanhtoan_Model> ReadID(Url_thanhtoan_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Url_thanhtoan where c.id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Url_thanhtoan.Remove(data);
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
                    var data = Connect_Enttity.Url_thanhtoan.FirstOrDefault(x => x.id.Equals(i));
                    Connect_Enttity.Url_thanhtoan.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(Url_thanhtoan_Model model)
        {
            var data = Connect_Enttity.Url_thanhtoan.FirstOrDefault(x => x.id == model.id);
            if (data == null)
            {
                var entity = new Url_thanhtoan();
                entity.Name = model.Name;
                entity.Address = model.Address;
                entity.PhoneNumber =model.PhoneNumber;
                entity.Fax = model.Fax;
                entity.vitri = (int)(model.vitri);

                Connect_Enttity.Url_thanhtoan.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Url_thanhtoan_Model model)
        {
            var data = Connect_Enttity.Url_thanhtoan.FirstOrDefault(x => x.id == model.id);
            if (data != null)
            {
                data.Name = model.Name;
                data.Address = model.Address;
                data.PhoneNumber = model.PhoneNumber;
                data.Fax = model.Fax;
                data.vitri = (int)(model.vitri);

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