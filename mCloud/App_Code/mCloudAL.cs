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
        public int SendMail(string Email, string Subject, string BodyText)
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
                return 1;
            }
            catch (Exception ex)
            {
               // throw ex;
                return 0;
            }
            return 0;
        }
        #endregion

        #region
        public string GenerateOTP()
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";


            string characters = numbers;

            characters += alphabets + small_alphabets + numbers;

            int length = 6;
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            return otp;
        }
        #endregion

    }
}