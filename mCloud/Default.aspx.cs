using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace mCloud
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GenerateOTP()
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = numbers;

            characters += alphabets + small_alphabets + numbers;

            int length = 5;
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
        public void sendmail()
        {
            string companyname, prodkey, prodid, from, to;
            string otp = GenerateOTP();
            Session["otp"] = otp;
            try
            {
                string toadd = Session["Email"].ToString();
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("moilcloud222@gmail.com");
                message.To.Add(new MailAddress(toadd));
                message.Subject = "Moil Cloud Verfication";
                message.Body = "Please Click The Link Below To Verify Your Email Address By Entering This Code:  " + otp + "";

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("moilcloud222@gmail.com", "techizas1234");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);


            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void btncreate_ServerClick(object sender, EventArgs e)
        {
            Session["Email"] = txtEmail.Value;
            Session["isdCode"] = IsdCode.Value;
            Session["Mob"] = txtMob.Value;
            sendmail();
            Response.Redirect("FrontPage/Activity.aspx");
        }


    }
}