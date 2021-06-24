using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;
using System.Drawing;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Gym_Management_System
{
    class QRmailSender
    {
        private string subject, body,
                       gmslogopath = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10) + "\\Resources\\method-draw-image.png",
                       From = "gym.manage.System@gmail.com", epw = "Gymmanagement20.1";
        public void qrgen(string QRsubject,string qrimgpath)
        {
            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(QRsubject, QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode = new QRCode(qRCodeData);
            Bitmap qrCodeImage = new Bitmap(200, 200);
            qrCodeImage = qRCode.GetGraphic(20, Color.Black, Color.White, (Bitmap)Bitmap.FromFile(gmslogopath));
            qrCodeImage.Save(qrimgpath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        public void Emailgen(string name,string type)
        {
            DB_Connection dB_Connection = new DB_Connection();
            string qry = "Select Company_Name from Usertb";
            SqlDataReader dr = dB_Connection.getData(qry);
            dr.Read();
            subject = dr["Company_Name"].ToString();
            body = "Welcome to " + subject +" Hi " + name + "!"+" You are now "+type+" of " + subject + "Now you can mark your attendence using this QR code";
        }
        public void Emailsend(string To,string qrimgpath)
        {
            try
            {


                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                mailMessage.From = new MailAddress(From);
                mailMessage.To.Add(To);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                Attachment attachment = new Attachment(qrimgpath);
                mailMessage.Attachments.Add(attachment);

                smtpClient.EnableSsl = true;
                smtpClient.Port = 587;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential(From, epw);
                smtpClient.Send(mailMessage);
                MessageBox.Show("Mail has been successfully sent!", "Email sent", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
    
}
