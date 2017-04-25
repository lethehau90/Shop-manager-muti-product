using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Web_Shop_SettingIphone.Models.Entity;
using Web_Shop_SettingIphone.Models.Command;
using Web_Shop_SettingIphone.Models.Data;
using System.Web.Security;

namespace Web_Shop_SettingIphone.Models.Service
{
    public class User_Service //quản trị login người dùng
    {
        private Web_Shop_SettingIphoneEntities Connect_Enttity = new Web_Shop_SettingIphoneEntities();

        public IList<User_Model> GetAll()
        {
            IList<User_Model> result = new List<User_Model>();

            result = Connect_Enttity.Users.Select(x => new User_Model
            {
                Id =  x.Id ,
                Name = x.Name,
                Username = x.Username,
                Password = x.Password,
                Level = x.Level,
                Admin= x.Admin,
                Ord= x.Ord,
                Active = x.Active,
                Role=x.Role
             
            }).ToList();

            return result;
        }

        public IList<User_Model> GetId(User_Model model)
        {
            IList<User_Model> result = new List<User_Model>();

            result = Connect_Enttity.Users.Where(x=>x.Id== model.Id).Select(x => new User_Model
            {
                Id = x.Id,
                Name = x.Name,
                Username = x.Username,
                Password = x.Password,
                Level = x.Level,
                Admin = x.Admin,
                Ord = x.Ord,
                Active = x.Active,
                Role = x.Role

            }).ToList();

            return result;
        }

        public IEnumerable<User_Model> Read()
        {
            return GetAll();
        }
        public IEnumerable<User_Model> ReadID(User_Model model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Users where c.Id == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Users.Remove(data);
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
                    var data = Connect_Enttity.Users.FirstOrDefault(x => x.Id.Equals(i));
                    Connect_Enttity.Users.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();
            }
         
        }

        public void Create(User_Model model)
        {
            var data = Connect_Enttity.Users.FirstOrDefault(x=>x.Id==model.Id);
            if(data==null)
            {
                var entity = new User();
                entity.Name = model.Name;
                entity.Username = model.Username;
                entity.Password = StringClass.Encrypt(model.Password);
                entity.Level = model.Level;
                entity.Admin = model.Admin;
                entity.Ord = model.Ord;
                entity.Active = model.Active;
                entity.Role = model.Role;

                Connect_Enttity.Users.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(User_Model model)
        {
            var data = Connect_Enttity.Users.FirstOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                
                    data.Name = model.Name;
                    data.Username = model.Username;
                    data.Password = StringClass.Encrypt(model.Password);
                    data.Level = model.Level;
                    data.Admin = model.Admin;
                    data.Ord = model.Ord;
                    data.Active = model.Active;
                    data.Role = model.Role;
                    //  Connect_Enttity.Users.Attach(data);
                    // Connect_Enttity.Entry(data).State = EntityState.Modified;
                    Connect_Enttity.SaveChanges();
                    Dispose();
            }
        }

        public bool Login(User_Model model)
        {
            string Name = model.Username;
            string password = StringClass.Encrypt(model.Password);
            var data =
                Connect_Enttity.Users.FirstOrDefault(x => x.Username.Equals(Name) && x.Password.Equals(password) && x.Active == 1);
            if (data != null)
            {
                return true;
            }
            else
                return false;
        }
        public void Dispose()
        {
            Connect_Enttity.Dispose();
        }

    }
}