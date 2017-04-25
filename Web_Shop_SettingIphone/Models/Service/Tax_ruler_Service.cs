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
    public class Tax_ruler_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<Tax_ruler_Model> GetAll()
        {
            IList<Tax_ruler_Model> result = new List<Tax_ruler_Model>();

            result = Connect_Enttity.Tax_ruler.Select(x => new Tax_ruler_Model
            {
                Id = x.Id,
                Name = x.Name,
                Province = x.Province,
                Tax_pri = (int)(x.Tax_pri),
                Description = x.Description,
                File_tax = x.File_tax,
                Ord = (int)(x.Ord),
                NameEn = x.NameEn,
                DescriptionEn = x.DescriptionEn,
                Active = (bool)x.Active
            }).ToList();

            return result;
        }

        public IList<Tax_ruler_Model> GetId(Tax_ruler_Model model)
        {
            IList<Tax_ruler_Model> result = new List<Tax_ruler_Model>();

            result = Connect_Enttity.Tax_ruler.Where(x => x.Id == model.Id).Select(x => new Tax_ruler_Model
            {
                Id = x.Id,
                Name = x.Name,
                Province = x.Province,
                Tax_pri = (int)(x.Tax_pri),
                Description = x.Description,
                File_tax = x.File_tax,
                Ord = (int)(x.Ord),
                NameEn = x.NameEn,
                DescriptionEn = x.DescriptionEn,
                Active = (bool)x.Active

            }).ToList();

            return result;
        }

        public IEnumerable<Tax_ruler_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<Tax_ruler_Model> ReadID(Tax_ruler_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Tax_ruler where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Tax_ruler.Remove(data);
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
                    var data = Connect_Enttity.Tax_ruler.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.Tax_ruler.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(Tax_ruler_Model model)
        {
            var data = Connect_Enttity.Tax_ruler.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new Tax_ruler();
                entity.Name = model.Name;
                entity.Province = model.Province;
                entity.Tax_pri = (int)(model.Tax_pri);
                entity.Description = model.Description;
                entity.File_tax = model.File_tax;
                entity.Ord = (int)(model.Ord);
                entity.NameEn = model.NameEn;
                entity.DescriptionEn = model.DescriptionEn;
                entity.Active = (bool)model.Active;

                Connect_Enttity.Tax_ruler.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(Tax_ruler_Model model)
        {
            var data = Connect_Enttity.Tax_ruler.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
                data.Province = model.Province;
                data.Tax_pri = (int)(model.Tax_pri);
                data.Description = model.Description;
                data.File_tax = model.File_tax;
                data.Ord = (int)(model.Ord);
                data.NameEn = model.NameEn;
                data.DescriptionEn = model.DescriptionEn;
                data.Active = (bool)model.Active;

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