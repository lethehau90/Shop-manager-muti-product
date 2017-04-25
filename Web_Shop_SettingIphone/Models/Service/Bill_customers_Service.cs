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
    public class Bill_customers_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Bill_customers_Model> GetAll()
        {
            IList<Bill_customers_Model> result = new List<Bill_customers_Model>();

            result = Connect_Enttity.Bill_customers.Select(x => new Bill_customers_Model
            {
                billid =x.billid,
                userid=(int)(x.userid),
                totalmoney=x.totalmoney,
                idate = Convert.ToDateTime(x.idate),
                xdate=Convert.ToDateTime(x.xdate),
                request=x.request,
                typepay=x.typepay ,
                state = (int)(x.state),
                lang=x.lang,
                show = (int)(x.show)

            }).ToList();

            return result;
        }

        public IList<Bill_customers_Model> GetId(Bill_customers_Model model)
        {
            IList<Bill_customers_Model> result = new List<Bill_customers_Model>();

            result = Connect_Enttity.Bill_customers.Where(x => x.billid == model.billid).Select(x => new Bill_customers_Model
            {
                billid = x.billid,
                userid = (int)(x.userid),
                totalmoney = x.totalmoney,
                idate = Convert.ToDateTime(x.idate),
                xdate = Convert.ToDateTime(x.xdate),
                request = x.request,
                typepay = x.typepay,
                state = (int)(x.state),
                lang = x.lang,
                show = (int)(x.show)

            }).ToList();

            return result;
        }

        public IEnumerable<Bill_customers_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Bill_customers_Model> ReadID(Bill_customers_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Bill_customers where c.billid == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Bill_customers.Remove(data);
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
                    var data = Connect_Enttity.Bill_customers.FirstOrDefault(x => x.billid.Equals(i));
                    Connect_Enttity.Bill_customers.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(Bill_customers_Model model)
        {
            var data = Connect_Enttity.Bill_customers.FirstOrDefault(x => x.billid == model.billid);
            if (data == null)
            {
                var entity = new Bill_customers();
                entity.userid = (int)(model.userid);
                entity.totalmoney = model.totalmoney;
                entity.idate = Convert.ToDateTime(model.idate);
                entity.xdate = Convert.ToDateTime(model.xdate);
                entity.request = model.request;
                entity.typepay = model.typepay;
                entity.state = (int)(model.state);
                entity.lang = model.lang;
                entity.show = (int)(model.show);

                Connect_Enttity.Bill_customers.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Bill_customers_Model model)
        {
            var data = Connect_Enttity.Bill_customers.FirstOrDefault(x => x.billid == model.billid);
            if (data != null)
            {
                data.userid = (int)(model.userid);
                data.totalmoney = model.totalmoney;
                data.idate = Convert.ToDateTime(model.idate);
                data.xdate = Convert.ToDateTime(model.xdate);
                data.request = model.request;
                data.typepay = model.typepay;
                data.state = (int)(model.state);
                data.lang = model.lang;
                data.show = (int)(model.show);

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