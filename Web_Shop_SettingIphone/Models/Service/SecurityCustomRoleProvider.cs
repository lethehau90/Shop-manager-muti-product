using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Web_Shop_SettingIphone.Models.Entity;

namespace Web_Shop_SettingIphone.Models.Service
{
    public class SecurityCustomRoleProvider : RoleProvider
    {
        /// <summary>
        /// Ham su ly khi goi ham: FormsAuthentication.SetAuthCookie(account, true or false);
        /// </summary>
        /// <param name="username">account</param>
        /// <returns>tra ve quyen cua tai khoan</returns>
        public override string[] GetRolesForUser(string username)
        {
            ////-----------------ket noi voi database de lay quyen cua tai khoan-----------------
            Web_Shop_SettingIphoneEntities db = new Web_Shop_SettingIphoneEntities(); //tao ket noi voi database
            try
            {
                var account = db.Users.Single(x => x.Username.Equals(username)); //tuong duong voi cau lenh "Select Top 1 From Accounts Where NameAccount = username"
                if (account != null) //neu tim thay tai khoan
                {
                    return new String[] { account.Role }; //tra ve quyen cua nguoi dung
                }
                else
                    return new String[] { }; //new khong tim thay tai khoan thi gan quyen bang null
            }
            catch
            {
                return new String[] { }; //new khong tim thay tai khoan TRONG CSDL thi gan quyen bang null
            }
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            string[] roles = GetRolesForUser(username);
            return roles.Contains(roleName);
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}