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
    public class MacodeKhuyenMai_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<MacodeKhuyenMai_Model> GetAll()
        {
            IList<MacodeKhuyenMai_Model> result = new List<MacodeKhuyenMai_Model>();

            result = Connect_Enttity.MacodeKhuyenMais.Select(x => new MacodeKhuyenMai_Model
            {
                ID = x.ID,
                Macode = x.Macode,
                Valueprice = (int)x.Valueprice,
                Active = (bool)x.Active
            }).ToList();

            return result;
        }

        public IList<MacodeKhuyenMai_Model> GetId(MacodeKhuyenMai_Model model)
        {
            IList<MacodeKhuyenMai_Model> result = new List<MacodeKhuyenMai_Model>();

            result = Connect_Enttity.MacodeKhuyenMais.Where(x => x.ID == model.ID).Select(x => new MacodeKhuyenMai_Model
            {
                ID = x.ID,
                Macode = x.Macode,
                Valueprice = (int)x.Valueprice,
                Active = (bool)x.Active
            }).ToList();

            return result;
        }

        public IEnumerable<MacodeKhuyenMai_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<MacodeKhuyenMai_Model> ReadID(MacodeKhuyenMai_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.MacodeKhuyenMais where c.ID == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.MacodeKhuyenMais.Remove(data);
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
                    var data = Connect_Enttity.MacodeKhuyenMais.FirstOrDefault(x => x.ID.Equals(i));
                    Connect_Enttity.MacodeKhuyenMais.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void Create(MacodeKhuyenMai_Model model)
        {
            var data = Connect_Enttity.MacodeKhuyenMais.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                var entity = new MacodeKhuyenMai();
                entity.Macode = model.Macode;
                entity.Valueprice = model.Valueprice;
                entity.Active = model.Active;

                Connect_Enttity.MacodeKhuyenMais.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(MacodeKhuyenMai_Model model)
        {
            var data = Connect_Enttity.MacodeKhuyenMais.FirstOrDefault(x => x.ID == model.ID);
            if (data != null)
            {
                data.Macode = model.Macode;
                data.Valueprice = model.Valueprice;
                data.Active = model.Active;

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