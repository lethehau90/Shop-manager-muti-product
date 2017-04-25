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
    public class Billdetail_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Billdetail_Model> GetAll()
        {
            IList<Billdetail_Model> result = new List<Billdetail_Model>();

            result = Connect_Enttity.Billdetails.Select(x => new Billdetail_Model
            {
                id = x.id,
                bilid = (int)(x.bilid), //khoa ngoai  Bill_customers_Model
                proid = (int)(x.proid),
                sizeid = (int)(x.sizeid),
                colorid = (int)(x.colorid),
                quantity = (int)(x.quantity),
                bilprice=x.bilprice,
                bilpricevnd = x.bilpricevnd,
                bilmoney = x.bilmoney,
                billlocation = (int)(x.billlocation),
                Date = Convert.ToDateTime(x.Date),
                status = (int)(x.status)
            }).ToList();

            return result;
        }

        public IList<Billdetail_Model> GetId(Billdetail_Model model)
        {
            IList<Billdetail_Model> result = new List<Billdetail_Model>();

            result = Connect_Enttity.Billdetails.Where(x => x.id == model.id).Select(x => new Billdetail_Model
            {
                id = x.id,
                bilid = (int)(x.bilid), //khoa ngoai  Bill_customers_Model
                proid = (int)(x.proid),
                sizeid = (int)(x.sizeid),
                colorid = (int)(x.colorid),
                quantity = (int)(x.quantity),
                bilprice = x.bilprice,
                bilpricevnd = x.bilpricevnd,
                bilmoney = x.bilmoney,
                billlocation = (int)(x.billlocation),
                Date = Convert.ToDateTime(x.Date),
                status = (int)(x.status)

            }).ToList();

            return result;
        }

        public IEnumerable<Billdetail_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Billdetail_Model> ReadID(Billdetail_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Billdetails where c.id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Billdetails.Remove(data);
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
                    var data = Connect_Enttity.Billdetails.FirstOrDefault(x => x.id.Equals(i));
                    Connect_Enttity.Billdetails.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(Billdetail_Model model)
        {
            var data = Connect_Enttity.Billdetails.FirstOrDefault(x => x.id == model.id);
            if (data == null)
            {
                var entity = new Billdetail();
                entity.bilid = (int)(model.bilid);
                entity.proid = (int)(model.proid);
                entity.sizeid = (int)(model.sizeid);
                entity.colorid = (int)(model.colorid);
                entity.quantity = (int)(model.quantity);
                entity.bilprice = model.bilprice;
                entity.bilpricevnd = model.bilpricevnd;
                entity.bilmoney = model.bilmoney;
                entity.billlocation = (int)(model.billlocation);
                entity.Date = Convert.ToDateTime(model.Date);
                entity.status = (int)(model.status);

                Connect_Enttity.Billdetails.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Billdetail_Model model)
        {
            var data = Connect_Enttity.Billdetails.FirstOrDefault(x => x.id == model.id);
            if (data != null)
            {
                data.bilid = (int)(model.bilid);
                data.proid = (int)(model.proid);
                data.sizeid = (int)(model.sizeid);
                data.colorid = (int)(model.colorid);
                data.quantity = (int)(model.quantity);
                data.bilprice = model.bilprice;
                data.bilpricevnd = model.bilpricevnd;
                data.bilmoney = model.bilmoney;
                data.billlocation = (int)(model.billlocation);
                data.Date = Convert.ToDateTime(model.Date);
                data.status = (int)(model.status);

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