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
    public class DientuChitiethinh_Service
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<DientuChitiethinh_Model> GetAll()
        {
            IList<DientuChitiethinh_Model> result = new List<DientuChitiethinh_Model>();

            result = Connect_Enttity.DientuChitiethinhs.Select(x => new DientuChitiethinh_Model
            {
                Id = x.Id,
                IdProduct = x.IdProduct,
                Images = x.Images,
                ThumImg = x.ThumImg,
                Idmau = x.Idmau,
                IdSize = x.IdSize,
                Giaban = x.Giaban,
                Giacu = x.Giacu,
                Soluong = x.Soluong,
                Phantramkm = x.Phantramkm,
                Tinhtrang = x.Tinhtrang,
                Active = x.Active,
                Ord = (int)(x.Ord),
                IdTag = x.IdTag,
                Iddungluong=x.Iddungluong,
                Images1=x.Images1,
                Images2 = x.Images2,
                Images3 = x.Images3,
                Images4 = x.Images4
            }).ToList();

            return result;
        }

        public IList<DientuChitiethinh_Model> GetId(DientuChitiethinh_Model model)
        {
            IList<DientuChitiethinh_Model> result = new List<DientuChitiethinh_Model>();

            result = Connect_Enttity.DientuChitiethinhs.Where(x => x.Id == model.Id).Select(x => new DientuChitiethinh_Model
            {
                Id = x.Id,
                IdProduct = x.IdProduct,
                Images = x.Images,
                ThumImg = x.ThumImg,
                Idmau = x.Idmau,
                IdSize = x.IdSize,
                Giaban = x.Giaban,
                Giacu = x.Giacu,
                Soluong = x.Soluong,
                Phantramkm = x.Phantramkm,
                Tinhtrang = x.Tinhtrang,
                Active = x.Active,
                Ord = (int)(x.Ord),
                IdTag = x.IdTag,
                Iddungluong = x.Iddungluong,
                Images1 = x.Images1,
                Images2 = x.Images2,
                Images3 = x.Images3,
                Images4 = x.Images4
            }).ToList();

            return result;
        }

        public IEnumerable<DientuChitiethinh_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<DientuChitiethinh_Model> ReadID(DientuChitiethinh_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(string IdTag)
        {

            var data = (from c in Connect_Enttity.DientuChitiethinhs where c.IdTag == IdTag select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.DientuChitiethinhs.Remove(data);
                Connect_Enttity.SaveChanges();
                Dispose();
            }

        }

        public void DeleteoneProduct(int IdProduct)
        {
            string Id = IdProduct.ToString();
            var data = (from c in Connect_Enttity.DientuChitiethinhs where c.IdProduct == Id select c).ToList();

            if (data != null)
            {
                foreach(var item in data)
                {
                    Connect_Enttity.DientuChitiethinhs.Remove(item);
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
                    string Id = i.ToString();
                    var data = Connect_Enttity.DientuChitiethinhs.Where(x => x.IdProduct == Id).ToList();
                    if(data != null)
                    {
                        foreach(var item in data)
                        {
                            Connect_Enttity.DientuChitiethinhs.Remove(item);
                            Connect_Enttity.SaveChanges();
                        }
                    }
                }
                Dispose();

            }

        }

        public void DeleteAll(int[] Id)
        {
            if (Id != null)
            {
                foreach (var i in Id)
                {
                    var data = Connect_Enttity.DientuChitiethinhs.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.DientuChitiethinhs.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(DientuChitiethinh_Model model)
        {
            var data = Connect_Enttity.DientuChitiethinhs.FirstOrDefault(x => x.Id == model.Id);
            if (data == null)
            {
                var entity = new DientuChitiethinh();
                entity.IdProduct = model.IdProduct;
                entity.Images = model.Images;
                entity.ThumImg = model.ThumImg;
                entity.Idmau = model.Idmau;
                entity.IdSize = model.IdSize;
                entity.Giaban = model.Giaban;
                entity.Giacu = model.Giacu;
                entity.Soluong = model.Soluong;
                entity.Phantramkm = model.Phantramkm;
                entity.Tinhtrang = model.Tinhtrang;
                entity.Active = model.Active;
                entity.Ord = (int)(model.Ord);
                entity.IdTag = (model.IdTag);
                entity.Iddungluong = model.Iddungluong;
                entity.Images1 = model.Images1;
                entity.Images2 = model.Images2;
                entity.Images3 = model.Images3;
                entity.Images4 = model.Images4;

                Connect_Enttity.DientuChitiethinhs.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(DientuChitiethinh_Model model)
        {
            var data = Connect_Enttity.DientuChitiethinhs.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.IdProduct = model.IdProduct;
                data.Images = model.Images;
                data.ThumImg = model.ThumImg;
                data.Idmau = model.Idmau;
                data.IdSize = model.IdSize;
                data.Giaban = model.Giaban;
                data.Giacu = model.Giacu;
                data.Soluong = model.Soluong;
                data.Phantramkm = model.Phantramkm;
                data.Tinhtrang = model.Tinhtrang;
                data.Active = model.Active;
                data.Ord = (int)(model.Ord);
                data.IdTag = (model.IdTag);
                data.Iddungluong = model.Iddungluong;
                data.Images1 = model.Images1;
                data.Images2 = model.Images2;
                data.Images3 = model.Images3;
                data.Images4 = model.Images4;

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