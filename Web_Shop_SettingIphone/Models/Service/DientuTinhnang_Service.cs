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
    public class DientuTinhnang_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<DientuTinhnang_Model> GetAll()
        {
            IList<DientuTinhnang_Model> result = new List<DientuTinhnang_Model>();

            result = Connect_Enttity.DientuTinhnangs.Select(x => new DientuTinhnang_Model
            {
                Idthuoctinh = x.Idthuoctinh,
                Thuoctinh = x.Thuoctinh,
                Idtinhang = (x.Idtinhang),
                Active = (bool)(x.Active),
                Ord = (int)(x.Ord),
                Title = x.Title,
                Content = x.Content,
                Idthuoctinhselect = x.Idthuoctinhselect
            }).ToList();

            return result;
        }

        public IList<DientuTinhnang_Model> GetId(DientuTinhnang_Model model)
        {
            IList<DientuTinhnang_Model> result = new List<DientuTinhnang_Model>();

            result = Connect_Enttity.DientuTinhnangs.Where(x => x.Idthuoctinh == model.Idthuoctinh).Select(x => new DientuTinhnang_Model
            {
                Idthuoctinh = x.Idthuoctinh,
                Thuoctinh = x.Thuoctinh,
                Idtinhang = (x.Idtinhang),
                Active = (bool)(x.Active),
                Ord = (int)(x.Ord),
                Title = x.Title,
                Content = x.Content,
                Idthuoctinhselect = x.Idthuoctinhselect
            }).ToList();

            return result;
        }
        public IEnumerable<DientuTinhnang_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<DientuTinhnang_Model> ReadID(DientuTinhnang_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.DientuTinhnangs where c.Idthuoctinh == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.DientuTinhnangs.Remove(data);
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
                    var data = Connect_Enttity.DientuTinhnangs.FirstOrDefault(x => x.Idthuoctinh.Equals(i));
                    Connect_Enttity.DientuTinhnangs.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(DientuTinhnang_Model model)
        {
            var data = Connect_Enttity.DientuTinhnangs.FirstOrDefault(x => x.Idthuoctinh == model.Idthuoctinh);
            if (data == null)
            {
                var entity = new DientuTinhnang();
                entity.Thuoctinh = model.Thuoctinh;
                entity.Idtinhang = (model.Idtinhang);
                entity.Active = (bool)(model.Active);
                entity.Ord = (int)(model.Ord);
                entity.Title = model.Title;
                entity.Content = model.Content;
                model.Idthuoctinhselect = model.Idthuoctinhselect;

                Connect_Enttity.DientuTinhnangs.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(DientuTinhnang_Model model)
        {
            var data = Connect_Enttity.DientuTinhnangs.FirstOrDefault(x => x.Idthuoctinh == model.Idthuoctinh);
            if (data != null)
            {
                data.Idthuoctinh = model.Idthuoctinh;
                data.Thuoctinh = model.Thuoctinh;
                data.Idtinhang = (model.Idtinhang);
                data.Active = (bool)(model.Active);
                data.Ord = (int)(model.Ord);
                data.Title = model.Title;
                data.Content = model.Content;
                data.Idthuoctinhselect = model.Idthuoctinhselect;

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