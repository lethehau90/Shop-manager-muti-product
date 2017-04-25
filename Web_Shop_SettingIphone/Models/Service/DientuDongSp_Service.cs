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
    public class DientuDongSp_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<DientuDongSp_Model> GetAll()
        {
            IList<DientuDongSp_Model> result = new List<DientuDongSp_Model>();

            result = Connect_Enttity.DientuDongSps.Select(x => new DientuDongSp_Model
            {
                Id = x.Id,
                Idnsx = x.Idnsx,
                Name = (x.Name),
                Active = (bool)(x.Active),
                Ord= (int)(x.Ord)
            }).ToList();

            return result;
        }

        public IList<DientuDongSp_Model> GetId(DientuDongSp_Model model)
        {
            IList<DientuDongSp_Model> result = new List<DientuDongSp_Model>();

            result = Connect_Enttity.DientuDongSps.Where(x => x.Id == model.Id).Select(x => new DientuDongSp_Model
            {
                Id = x.Id,
                Idnsx = x.Idnsx,
                Name = (x.Name),
                Active = (bool)(x.Active),
                Ord = (int)(x.Ord)
            }).ToList();

            return result;
        }
        public IEnumerable<DientuDongSp_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<DientuDongSp_Model> ReadID(DientuDongSp_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.DientuDongSps where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.DientuDongSps.Remove(data);
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
                    var data = Connect_Enttity.DientuDongSps.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.DientuDongSps.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(DientuDongSp_Model model)
        {
            var data = Connect_Enttity.DientuDongSps.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new DientuDongSp();
                entity.Idnsx = model.Idnsx;
                entity.Name = (model.Name);
                entity.Active = (bool)(model.Active);
                entity.Ord = (int)(model.Ord);

                Connect_Enttity.DientuDongSps.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(DientuDongSp_Model model)
        {
            var data = Connect_Enttity.DientuDongSps.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Id = model.Id;
                data.Idnsx = model.Idnsx;
                data.Name = (model.Name);
                data.Active = (bool)(model.Active);
                data.Ord = (int)(model.Ord);

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