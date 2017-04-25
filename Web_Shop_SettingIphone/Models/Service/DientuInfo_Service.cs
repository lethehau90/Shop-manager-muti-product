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
    public class DientuInfo_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<DientuInfo_Model> GetAll()
        {
            IList<DientuInfo_Model> result = new List<DientuInfo_Model>();

            result = Connect_Enttity.DientuInfoes.Select(x => new DientuInfo_Model
            {
                Id = x.Id,
                Thuonghieu = x.Thuonghieu,
                Dongmay = (x.Dongmay),
                Soseri = (x.Soseri),
                Hovaten = x.Hovaten,
                Sodienthoai = x.Sodienthoai,
                Noidungsuachua = (x.Noidungsuachua),
                Images1 = x.Images1,
                Images2 = x.Images2,
                Giaban = (x.Giaban),
                Index = (x.Index),
                Ngaygoi = (x.Ngaygoi),
                Active = (x.Active)
            }).ToList();

            return result;
        }

        public IList<DientuInfo_Model> GetId(DientuInfo_Model model)
        {
            IList<DientuInfo_Model> result = new List<DientuInfo_Model>();

            result = Connect_Enttity.DientuInfoes.Where(x => x.Id == model.Id).Select(x => new DientuInfo_Model
            {
                Id = x.Id,
                Thuonghieu = x.Thuonghieu,
                Dongmay = (x.Dongmay),
                Soseri = (x.Soseri),
                Hovaten = x.Hovaten,
                Sodienthoai = x.Sodienthoai,
                Noidungsuachua = (x.Noidungsuachua),
                Images1 = x.Images1,
                Images2 = x.Images2,
                Giaban = (x.Giaban),
                Index = (x.Index),
                Ngaygoi = (x.Ngaygoi),
                Active = (x.Active)
            }).ToList();

            return result;
        }
        public IEnumerable<DientuInfo_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<DientuInfo_Model> ReadID(DientuInfo_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.DientuInfoes where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.DientuInfoes.Remove(data);
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
                    var data = Connect_Enttity.DientuInfoes.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.DientuInfoes.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(DientuInfo_Model model)
        {
            var data = Connect_Enttity.DientuInfoes.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new DientuInfo();
                entity.Thuonghieu = model.Thuonghieu;
                entity.Dongmay = (model.Dongmay);
                entity.Soseri = model.Soseri;
                entity.Hovaten = (model.Hovaten);
                entity.Sodienthoai = (model.Sodienthoai);
                entity.Noidungsuachua = model.Noidungsuachua;
                entity.Images1 = (model.Images1);
                entity.Images2 = (model.Images2);
                entity.Giaban = (model.Giaban);
                entity.Index = model.Index;
                entity.Ngaygoi = (model.Ngaygoi);
                entity.Active = (bool)(model.Active);

                Connect_Enttity.DientuInfoes.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(DientuInfo_Model model)
        {
            var data = Connect_Enttity.DientuInfoes.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Id = model.Id;
                data.Thuonghieu = model.Thuonghieu;
                data.Dongmay = (model.Dongmay);
                data.Soseri = model.Soseri;
                data.Hovaten = (model.Hovaten);
                data.Sodienthoai = (model.Sodienthoai);
                data.Noidungsuachua = model.Noidungsuachua;
                data.Images1 = (model.Images1);
                data.Images2 = (model.Images2);
                data.Giaban = (model.Giaban);
                data.Index = model.Index;
                data.Ngaygoi = (model.Ngaygoi);
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