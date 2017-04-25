using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.SqlClient;

namespace Web_Shop_SettingIphone.Models.Command
{
    public class ThumsbImg : System.Web.UI.UserControl
    {
        //Phương thức chỉnh kích thước ảnh khi upload
        public Size NewImageSize(int OriginalHeight, int OriginalWidth, double FormatSize)
        {
            Size NewSize;
            double tempval;

            if (OriginalHeight > FormatSize && OriginalWidth > FormatSize)
            {
                if (OriginalHeight > OriginalWidth)
                    tempval = FormatSize / Convert.ToDouble(OriginalHeight);
                else
                    tempval = FormatSize / Convert.ToDouble(OriginalWidth);
                NewSize = new Size(Convert.ToInt32(tempval * OriginalWidth), Convert.ToInt32(tempval * OriginalHeight));
            }
            else

                NewSize = new Size(OriginalWidth, OriginalHeight);
            return NewSize;
        }
        public string Url(string img, int index)
        {
            string[] image = img.ToString().Split('/');
            string url = "";
            for (int i = index; i < image.Length; i++)
            {
                url += "/" + image[i];
            }
            return url;
        }
       
    }
}
