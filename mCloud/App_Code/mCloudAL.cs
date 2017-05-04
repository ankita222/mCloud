using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#region Other Required Namespace
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Configuration;
#endregion

namespace mCloud.App_Code
{
    public class mCloudAL
    {
        #region Function for Password Hash
        public string PassHash(string Password)
        {
            byte[] hs = new byte[50];
            string pass = Password;
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                hs[i] = hash[i];
                sb.Append(hs[i].ToString("x2"));
            }
            string hash_pass = sb.ToString();
            return hash_pass;
        }
        #endregion

        #region Function for SendMail
        public void SendMail(string Email, string Subject, string BodyText)
        {
            MailMessage message = new MailMessage();
            MailAddress Sender = new MailAddress(ConfigurationManager.AppSettings["smtpUser"], "MoilCloud");
            MailAddress receiver = new MailAddress(Email);
            SmtpClient smtp = new SmtpClient()
            {
                Host = ConfigurationManager.AppSettings["smtpServer"],
                Port = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]),
                EnableSsl = true,
                Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["smtpUser"], ConfigurationManager.AppSettings["smtpPass"])
            };
            message.From = Sender;

            message.To.Add(receiver);
            message.Body = BodyText;
            message.Subject = Subject;
            message.IsBodyHtml = true;
            try
            {
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        
    }
}