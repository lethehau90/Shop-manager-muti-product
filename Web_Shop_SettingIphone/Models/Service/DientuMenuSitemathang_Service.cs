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
    public class DientuMenuSitemathang_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<DientuMenuSitemathang_Model> GetAll()
        {
            IList<DientuMenuSitemathang_Model> result = new List<DientuMenuSitemathang_Model>();

            result = Connect_Enttity.DientuMenuSitemathangs.Select(x => new DientuMenuSitemathang_Model
            {
                Id = x.Id,
                MenuName = x.MenuName,
                Tag = (x.Tag),
                Level = x.Level,
                Logogroup = (x.Logogroup),
                Mota = x.Mota,
                Url = (x.Url),
                idThuoctinh = x.idThuoctinh,
                Priority = (x.Priority),
                Index = (x.Index),
                Title = x.Title,
                Keyword = x.Keyword,
                Description = x.Description,
                Active = (bool)(x.Active),
                Ord = (int)(x.Ord),

            }).ToList();

            return result;
        }

        public IList<DientuMenuSitemathang_Model> GetId(DientuMenuSitemathang_Model model)
        {
            IList<DientuMenuSitemathang_Model> result = new List<DientuMenuSitemathang_Model>();

            result = Connect_Enttity.DientuMenuSitemathangs.Where(x => x.Id == model.Id).Select(x => new DientuMenuSitemathang_Model
            {
                Id = x.Id,
                MenuName = x.MenuName,
                Tag = (x.Tag),
                Level = x.Level,
                Logogroup = (x.Logogroup),
                Mota = x.Mota,
                Url = (x.Url),
                idThuoctinh = x.idThuoctinh,
                Priority = (x.Priority),
                Title = x.Title,
                Keyword = x.Keyword,
                Description = x.Description,
                Index = (x.Index),
                Active = (bool)(x.Active),
                Ord = (int)(x.Ord)
            }).ToList();

            return result;
        }
        public IEnumerable<DientuMenuSitemathang_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<DientuMenuSitemathang_Model> ReadID(DientuMenuSitemathang_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.DientuMenuSitemathangs where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.DientuMenuSitemathangs.Remove(data);
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
                    var data = Connect_Enttity.DientuMenuSitemathangs.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.DientuMenuSitemathangs.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(DientuMenuSitemathang_Model model)
        {
            var data = Connect_Enttity.DientuMenuSitemathangs.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new DientuMenuSitemathang();
                entity.MenuName = model.MenuName;
                entity.Tag = (model.Tag);
                entity.Level = model.Level;
                entity.Logogroup = (model.Logogroup);
                entity.Mota = model.Mota;
                entity.Url = (model.Url);
                entity.idThuoctinh = model.idThuoctinh;
                entity.Priority = (model.Priority);
                entity.Index = (model.Index);
                entity.Active = (bool)(model.Active);
                entity.Ord = (int)(model.Ord);
                entity.Title = model.Title;
                entity.Keyword = model.Keyword;
                entity.Description = model.Description;

                Connect_Enttity.DientuMenuSitemathangs.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(DientuMenuSitemathang_Model model)
        {
            var data = Connect_Enttity.DientuMenuSitemathangs.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Id = model.Id;
                data.MenuName = model.MenuName;
                data.Tag = (model.Tag);
                data.Level = model.Level;
                data.Logogroup = (model.Logogroup);
                data.Mota = model.Mota;
                data.Url = (model.Url);
                data.idThuoctinh = model.idThuoctinh;
                data.Priority = (model.Priority);
                data.Index = (model.Index);
                data.Active = (bool)(model.Active);
                data.Ord = (int)(model.Ord);
                data.Title = model.Title;
                data.Keyword = model.Keyword;
                data.Description = model.Description;

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