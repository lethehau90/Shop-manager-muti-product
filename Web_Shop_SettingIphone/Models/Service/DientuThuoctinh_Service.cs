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
    public class DientuThuoctinh_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<DientuThuoctinh_Model> GetAll()
        {
            IList<DientuThuoctinh_Model> result = new List<DientuThuoctinh_Model>();

            result = Connect_Enttity.DientuThuoctinhs.Select(x => new DientuThuoctinh_Model
            {
                Id = x.Id,
                IdTag = x.IdTag,
                Text = x.Text,
                Value=x.Value,
                Ord = (int)(x.Ord),
                Active = (bool)(x.Active),
                Idcapthuoctinh = (int)(x.Idcapthuoctinh),
                Idthuoctinh = (int)(x.Idthuoctinh),
                Idproduct = (int)(x.Idproduct),
                Content = x.Content,
                TagProduct = x.TagProduct
            }).ToList();

            return result;
        }

        public IList<DientuThuoctinh_Model> GetId(DientuThuoctinh_Model model)
        {
            IList<DientuThuoctinh_Model> result = new List<DientuThuoctinh_Model>();

            result = Connect_Enttity.DientuThuoctinhs.Where(x => x.Id == model.Id).Select(x => new DientuThuoctinh_Model
            {
                Id = x.Id,
                IdTag = x.IdTag,
                Text = x.Text,
                Value = x.Value,
                Ord = (int)(x.Ord),
                Active = (bool)(x.Active),
                Idcapthuoctinh = (int)(x.Idcapthuoctinh),
                Idthuoctinh = (int)(x.Idthuoctinh),
                Idproduct = (int)(x.Idproduct),
                Content = x.Content,
                TagProduct = x.TagProduct

            }).ToList();

            return result;
        }

        public IEnumerable<DientuThuoctinh_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<DientuThuoctinh_Model> ReadID(DientuThuoctinh_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(string IdTag)
        {
            var data = (from c in Connect_Enttity.DientuThuoctinhs where c.IdTag == IdTag select c).FirstOrDefault();
            if (data != null)
            {
                Connect_Enttity.DientuThuoctinhs.Remove(data);
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
                    var data = Connect_Enttity.DientuThuoctinhs.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.DientuThuoctinhs.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }


        public void DeleteoneProduct(int IdProduct)
        {

            var data = (from c in Connect_Enttity.DientuThuoctinhs where c.Idproduct == IdProduct select c).ToList();

            if (data != null)
            {
                foreach(var item in data)
                {
                    Connect_Enttity.DientuThuoctinhs.Remove(item);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }

        }

        public void DeletemutiProduct(int[] IdProduct)
        {

            if (IdProduct != null)
            {
                foreach (var i in IdProduct)
                {
                    var data = Connect_Enttity.DientuThuoctinhs.Where(x => x.Idproduct == i).ToList();
                    foreach(var item in data)
                    {
                        Connect_Enttity.DientuThuoctinhs.Remove(item);
                        Connect_Enttity.SaveChanges();
                    }
                }
                Dispose();

            }

        }

        public void Create(DientuThuoctinh_Model model)
        {
            var data = Connect_Enttity.DientuThuoctinhs.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new DientuThuoctinh();
                entity.Text = model.Text;
                entity.IdTag = model.IdTag;
                entity.Value = model.Value;
                entity.Ord = (int)(model.Ord);
                entity.Idthuoctinh = (int)(model.Idthuoctinh);
                entity.Idproduct = (int)(model.Idproduct);
                entity.Idcapthuoctinh = (int)(model.Idcapthuoctinh);
                entity.Active = (bool)(model.Active);
                entity.Content = model.Content;
                entity.TagProduct = model.TagProduct;


                Connect_Enttity.DientuThuoctinhs.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(DientuThuoctinh_Model model)
        {
            var data = Connect_Enttity.DientuThuoctinhs.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Text = model.Text;
                data.Value = model.Value;
                data.IdTag = model.IdTag;
                data.Ord = (int)(model.Ord);
                data.Active = (bool)(model.Active);
                data.Idthuoctinh = (int)(model.Idthuoctinh);
                data.Idproduct = (int)(model.Idproduct);
                data.Idcapthuoctinh = (int)(model.Idcapthuoctinh);
                data.Content = model.Content;
                data.TagProduct = model.TagProduct;

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