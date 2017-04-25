using System;
using System.Net.Mail;
using System.Text;
namespace Web_Shop_SettingIphone.Models.Command
{
   public class SendMails
    {
       public void sendmail(string to, string from, string bcc, string objects, string body, string user, string pass)
       {
           MailMessage mail = new MailMessage(from,to,objects,body);
           mail.BodyEncoding = mail.SubjectEncoding = System.Text.Encoding.UTF8;
           mail.Bcc.Add(bcc);
           mail.IsBodyHtml = true;
           SmtpClient smtps = new SmtpClient("smtp.gmail.com");
           smtps.Port = 587;
           smtps.Credentials = new System.Net.NetworkCredential(user, pass);
           smtps.EnableSsl = true;
           smtps.Send(mail);
       }
    }
}
