using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Shop_SettingIphone.Models.Entity;
using Web_Shop_SettingIphone.Models.Service;
using Web_Shop_SettingIphone.Models.Command;
using Web_Shop_SettingIphone.Models.Data;
using Web_Shop_SettingIphone.Models.Cart;

namespace Web_Shop_SettingIphone.Controllers
{
    public class ThanhtoanController : Controller
    {
        //
        // GET: /thanhtoan/
        private Web_Shop_SettingIphoneEntities connect_entity = new Web_Shop_SettingIphoneEntities();
        Donhang_Service ConnectDonhang = new Donhang_Service();
        CTdonhang_Service ConnectCTDonhang = new CTdonhang_Service();
        int resurt;
        public JsonResult CreateDonhang(string Hoten, string Mail ,string Diachi ,string GhiChuKhac,
                                          string SDT,string ngaydathang,string Duyet,string Xungho,
                                            string Tongtienhang, string Hinhthucgiaohang, string Tiengiamgia)
        {

            try
            {
                if (MySession.TongTien != 0)
                {
                    CTdonhang_Model modelCTDonhang = new CTdonhang_Model();
                    Donhang_Model modelDonhang = new Donhang_Model();//gọi model data
                    //xử lý Đơn hàng
                    modelDonhang.IDuser = 0;
                    modelDonhang.SDT = SDT;
                    modelDonhang.Hoten = Hoten;
                    modelDonhang.Mail = Mail;
                    modelDonhang.Diachi = Diachi;
                    modelDonhang.Tinh = "";
                    modelDonhang.Huyen = "";
                    modelDonhang.Xungho = Xungho;
                    modelDonhang.Hinhthucthanhtoan = "";
                    modelDonhang.Goidichvu = "";
                    modelDonhang.Tongtienhang = Convert.ToDouble(MySession.TongTien);
                    modelDonhang.Thanhtoan = 0;
                    modelDonhang.ngaydathang = DateTime.Now;
                    modelDonhang.KH = "";
                    modelDonhang.Duyet = "0";
                    modelDonhang.Khuyenmai = "";
                    modelDonhang.Hinhthucgiaohang = "";
                    modelDonhang.GhiChuKhac = GhiChuKhac;
                    modelDonhang.Tiengiamgia = 0;

                    ///Xử lý chi tiết đơn hàng
                    /////////////////////////////
                    ConnectDonhang.Create(modelDonhang);
                    var donhangmax = connect_entity.Donhang_Max().FirstOrDefault();
                    int id = Convert.ToInt32(donhangmax);
                    foreach (var s in MySession.GioHang)
                    {
                        modelCTDonhang.IDhd = id;
                        modelCTDonhang.IDsanpham = Convert.ToString(s.IDsanpham);
                        modelCTDonhang.Tensanpham = s.TenSanPham;
                        modelCTDonhang.Soluong = Convert.ToInt32(s.SoLuong);
                        modelCTDonhang.Giacu = Convert.ToDouble(s.Giacu);
                        modelCTDonhang.Giaban = Convert.ToDouble(s.Giaban);
                        modelCTDonhang.Size = s.Size;
                        modelCTDonhang.Mausac = _resurtTenmau(Convert.ToInt32(s.Mausac));
                        modelCTDonhang.Dungluong = s.Dungluong;
                        modelCTDonhang.Hinhanh = s.Hinhanh;
                        modelCTDonhang.Giamthem = s.Giamthem;
                        modelCTDonhang.danhmucsanpham = s.danhmucsanpham;
                        modelCTDonhang.chitietsanpham = s.chitietsanpham;
                        modelCTDonhang.Giamthem = s.Giamthem;
                        modelCTDonhang.phantramkm = s.phantramkm;
                        modelCTDonhang.Baohanh = Convert.ToInt32(s.Baohanh);
                        modelCTDonhang.tinhtrang = s.tinhtrang;
                        ConnectCTDonhang.Create(modelCTDonhang);
                    }
                    //sendmail(modelDonhang.Mail, modelDonhang.Hoten, modelDonhang.Xungho, modelDonhang.SDT, Convert.ToInt32(modelDonhang.Hinhthucgiaohang), modelDonhang.Diachi, 0 );
                    MySession.GioHang.Clear();
                    MySession.TongTien = 0;
                    
                }

                resurt = 1;
                
                return Json(resurt, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        public string _resurtTenmau(int Idmau)
        {
            var data = connect_entity.Mausacs.FirstOrDefault(x => x.IDmau == Idmau);
            return data.Tenmau;
        }

        public ActionResult Succsess()
        {
            return View();
        }

        [HttpPost]
        public void sendmail(string mailkhach, string hoten, string xungho, string sdt, int phidichvu, string diachigiaohang, int tiengiam)
        {

            if (ModelState.IsValid)
            {
                double bien = Convert.ToDouble(MySession.TongTien);

                string tien_vnd = VNCurrency.ToString(bien);
                var db_config = connect_entity.Configs.FirstOrDefault();
                string html = "";
                html += "<h3>Xác nhận Đơn Hàng Của Quý Khách Hàng </h3><br/><br/>";
                html += "Xin chào <b>" + xungho + " " + hoten + " </b><br/><br/>";
                html += "<b> Địa Chỉ Giao Hàng Quý Khách: </b>" + diachigiaohang + " <br/><br/>";
                html += "Cảm ơn quý khách đã mua hàng . Mã số xác nhận đơn hàng của quý khách là " + sdt + " <br/><br/>";
                html += "<table  cellpadding='1' cellspacing='1' padding='5' width='100%'   style='text-align:left; margin-bottom: 25px;border:1px solid #ccc;'>";
                html += "<tr height='30' style='background:#f0f0f0; height:30px;border-bottom:1px solid #ccc; '><th> Sản phẩm</th> <th>Mã sản phẩm</th><th> Đơn giá</th><th>Số lượng</th><th>Màu sắc</th><th> Thành tiền</th> </tr>";
                if (MySession.GioHang != null)
                {


                    foreach (var item in MySession.GioHang)
                    {
                        html += "<tr style='border-bottom:1px solid #ccc; text-align:left; height:30px; padding:5px;'>";
                        html += "<td>" + item.TenSanPham + "</td>";
                        html += "<td> Thoitrangdepxinh.vn-" + item.IDsanpham + "</td>";
                        html += "<td>" + item.Giaban + "</td>";
                        html += "<td>" + item.SoLuong + "</td>";
                        html += "<td>" + item.Mausac + "</td>";
                        html += "<td>" + string.Format("{0:#,##0}", item.TongTien) + " VND</td>";
                        html += "</tr>";

                    }

                    html += " <tr>  <th> Tổng tiền" + MySession.TongTien+ " VND<td>";
                    html += "  </td></tr>    </table><br/>";
                    html += "Xin quý khách vui lòng thanh toán <b>" + string.Format("{0:0,00}", MySession.TongTien) + " VND</b>, <b>Đọc thành chữ:</b> " + tien_vnd + "<br/><br/>";
                    html += "Bạn có thể thanh toán qua ATM với số tài khoản vào một trong các tài khoản ngân hàng sau (" + db_config.PaymentTerms + ") Thuộc Chi Nhánh Ngân Hàng (" + db_config.GoogleId + ") Chủ Tài Khoản (" + db_config.PlaceBody + ") <br/><br/>";
                    html += " Chân thành cám ơn quý khách đã mua sắm, và chúng tôi hi vọng quý khách sẽ hài lòng với sản phẩm mình đã chọn.<br/>";
                }









                string smtpUserName = db_config.Mail_Noreply;
                string smtpPassword = db_config.Mail_Password;
                string smtpHost = db_config.Mail_Smtp;  //smtp.gmail.com
                int smtpPort = Convert.ToInt32(db_config.Mail_Port); //25

                string emailTo = mailkhach; // Khi có liên hệ sẽ gửi về thư của mình
                string subject = db_config.PlaceHead;
                string body = html;



                EmailService service = new EmailService();

                bool kq = service.Send(smtpUserName, smtpPassword, smtpHost, smtpPort,
                    emailTo, subject, body);

                if (kq) ModelState.AddModelError("", "Cảm ơn bạn đã liên hệ với chúng tôi.");
                else ModelState.AddModelError("", "Gửi tin nhắn thất bại, vui lòng thử lại.");
            }


        }

    }
}
