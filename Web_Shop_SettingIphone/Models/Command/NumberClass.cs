using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace Web_Shop_SettingIphone.Models.Command
{
    public class NumberClass : System.Web.UI.Page
    {
        /// <summary>
        /// Get script validator number
        /// </summary>
        /// <returns>Client javascript function check number</returns>
        protected static string GetScriptValidatorNumber() 
        {
            string str;
            str = "<script> ";
            str += @" function OnlyInputNumber(Characters){";
            str += @" var re; ";
            str += @"var ch=String.fromCharCode(event.keyCode);";
            str += @"if (event.keyCode<32)";
            str += @"{";
            str += @"return;";
            str += @"};";
            str += @"if( (event.keyCode<=57)&&(event.keyCode>=48))";
            str += @"{";
            str += @"if (!event.shiftKey)";
            str += @"{";
            str += @"return;";
            str += @"}";
            str += @"}";
            str += @"if (Characters.length >0 && ch==Characters)";
            str += @"{";
            str += @"return;";
            str += @"}";
            str += @"event.returnValue=false;";
            str += "}</script>";
            return str;
        }
        /// <summary>
        /// Set onkeypress event for textbox,
        /// Call this funtion on load update page
        /// </summary>
        /// <param name="textBox">Textbox only input number</param>
        public static void OnlyInputNumber(TextBox textBox)
        {
            OnlyInputNumber(textBox,"");
        }
        /// <summary>
        /// Set onkeypress event for textbox,
        /// Call this funtion on load update page
        /// </summary>
        /// <param name="textBox">Textbox only input number</param>
        /// <param name="Characters">Skip Characters input</param>
        public static void OnlyInputNumber(TextBox textBox, string Characters)
        {
            StringClass.CreateClientScriptAttributes(textBox, "onkeypress", "OnlyInputNumber('" + Characters + "')", GetScriptValidatorNumber());
        }
        /// <summary>
        /// Convert string number to vi-VN number
        /// </summary>
        /// <param name="strNumber">Number to conver</param>
        /// <returns></returns>
        public static string ConvertNumber(string strNumber)
        {
            //return ConvertNumber(strNumber, "vi-VN");
            return strNumber.Replace(".", ",");

        }
        /// <summary>
        /// Convert string number to culture number
        /// </summary>
        /// <param name="strNumber">Number to conver</param>
        /// <param name="CultureInfo">vi-VN or en-US or more</param>
        /// <returns></returns>
        public static string ConvertNumber(string strNumber, string cultureInfo)
        {
            //float strReturn = 0;
            //NumberStyles style = NumberStyles.AllowDecimalPoint;
            //CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureInfo);
            //float.TryParse(strNumber, style, culture, out strReturn);
            //return strReturn.ToString();
            //Double strReturn = Convert.ToDouble(strNumber);
            //return strReturn.ToString("00.00");
            return strNumber.Replace(",", ".");
        }
        //dinh dang tien te
        public static string FormatNumber(string _strInput)
        {
            string strInput = _strInput;
            int Length = 0;
            if (strInput.IndexOf('.') > 0)
                Length = strInput.Length - (strInput.Length - strInput.IndexOf('.'));
            else
                Length = strInput.Length;
            string afterFormat = "";
            if (Length <= 3)
                afterFormat = strInput;
            else if (Length > 3)
            {
                afterFormat = strInput.Insert(Length - 3, ",");
                Length = afterFormat.IndexOf(",");
                while (Length > 3)
                {
                    afterFormat = afterFormat.Insert(Length - 3, ",");
                    Length = Length - 3;
                }
            }
            return afterFormat;
        }
    }
}
