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
    public class Custumer_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Custumer_Model> GetAll()
        {
            IList<Custumer_Model> result = new List<Custumer_Model>();

            result = Connect_Enttity.Custumers.Select(x => new Custumer_Model
            {
                iusid =x.iusid,
                vusername=x.vusername,
                vpassword = x.vpassword,
                vcusname = x.vcusname,
                dbirthday = x.dbirthday,
                vprovince = x.vprovince,
                vaddress = x.vaddress,
                vphone = x.vphone,
                vmobile = x.vmobile,
                vemail = x.vemail,
                dcreatedate = Convert.ToDateTime(x.dcreatedate),
                istatus = (short)(x.istatus)

            }).ToList();

            return result;
        }

        public IList<Custumer_Model> GetId(Custumer_Model model)
        {
            IList<Custumer_Model> result = new List<Custumer_Model>();

            result = Connect_Enttity.Custumers.Where(x => x.iusid == model.iusid).Select(x => new Custumer_Model
            {
                iusid = x.iusid,
                vusername = x.vusername,
                vpassword = x.vpassword,
                vcusname = x.vcusname,
                dbirthday = x.dbirthday,
                vprovince = x.vprovince,
                vaddress = x.vaddress,
                vphone = x.vphone,
                vmobile = x.vmobile,
                vemail = x.vemail,
                dcreatedate = Convert.ToDateTime(x.dcreatedate),
                istatus = (short)(x.istatus)
            }).ToList();

            return result;
        }

        public IEnumerable<Custumer_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Custumer_Model> ReadID(Custumer_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Custumers where c.iusid == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Custumers.Remove(data);
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
                    var data = Connect_Enttity.Custumers.FirstOrDefault(x => x.iusid.Equals(i));
                    Connect_Enttity.Custumers.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(Custumer_Model model)
        {
            var data = Connect_Enttity.Custumers.FirstOrDefault(x => x.iusid == model.iusid);
            if (data == null)
            {
                var entity = new Custumer();
                entity.iusid =model.iusid;
                entity.vusername=model.vusername;
                entity.vpassword = model.vpassword;
                entity.vcusname = model.vcusname;
                entity.dbirthday = model.dbirthday;
                entity.vprovince = model.vprovince;
                entity.vaddress = model.vaddress;
                entity.vphone = model.vphone;
                entity.vmobile = model.vmobile;
                entity.vemail = model.vemail;
                entity.dcreatedate = Convert.ToDateTime(model.dcreatedate);
                entity.istatus = (short)(model.istatus);

                Connect_Enttity.Custumers.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Custumer_Model model)
        {
            var data = Connect_Enttity.Custumers.FirstOrDefault(x => x.iusid == model.iusid);
            if (data != null)
            {
                data.iusid = model.iusid;
                data.vusername = model.vusername;
                data.vpassword = model.vpassword;
                data.vcusname = model.vcusname;
                data.dbirthday = model.dbirthday;
                data.vprovince = model.vprovince;
                data.vaddress = model.vaddress;
                data.vphone = model.vphone;
                data.vmobile = model.vmobile;
                data.vemail = model.vemail;
                data.dcreatedate = Convert.ToDateTime(model.dcreatedate);
                data.istatus = (short)(model.istatus);

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