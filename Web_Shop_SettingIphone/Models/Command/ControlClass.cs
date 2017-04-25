using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using FredCK.FCKeditorV2;

namespace Web_Shop_SettingIphone.Models.Command
{
    public class ControlClass : System.Web.UI.UserControl
    {
        public static void SetPostBackUrlLinkControl(Control parent) 
        {
            foreach (Control c in parent.Controls)
            {
                string abc = c.ID;
                if (c.Controls.Count > 0)
                {
                    SetPostBackUrlLinkControl(c);
                }
                else
                {
                    switch (c.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.LinkButton":
                            ((LinkButton)c).PostBackUrl = c.ID.Replace("lbt", "/Admin/") + ".aspx";
                            break;
                    }
                }
            }
        }
        public static string RandomString(int len)
        {
            string allowedChars = "";
            allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "1,2,3,4,5,6,7,8,9,0,!,@,#,$,%,&,?";

            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);
            string randomString = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < len; i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                randomString += temp;
            }
            return randomString;
        }

        public static void ResetControlValues(Control parent)// reset lại các giá trị của các textbox, checkbox , FCKeditor
        {
            foreach (Control c in parent.Controls)
            {
                string abc = c.ID;
                /*if (c.Controls.Count > 0)
                {
                    if (c.GetType().ToString() == "FredCK.FCKeditorV2.FCKeditor") {
                        ((FCKeditor)c).Value = "";
                        break;
                    }
                    else {
                        ResetControlValues(c);
                    }
                }
                else
                {*/
                    switch (c.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.TextBox":
                            ((TextBox)c).Text = "";
                            break;
                        case "System.Web.UI.WebControls.CheckBox":
                            ((CheckBox)c).Checked = true;
                            break;
                        case "System.Web.UI.WebControls.RadioButton":
                            ((RadioButton)c).Checked = false;
                            break;
                        case "System.Web.UI.WebControls.Image":
                            ((Image)c).ImageUrl = null;
                            ((Image)c).Width = 0;
                            break;
                        //case "FredCK.FCKeditorV2.FCKeditor":
                        //    ((FCKeditor)c).Value = "";
                         //   break;
                   // }
                }
            }
        }
    }
}
