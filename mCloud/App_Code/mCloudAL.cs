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

        #region Function for Generate OTP
        public string GenOTP()
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

        #region Function for Generate Email Verification Code
        public string GenEmailVerificationCode()
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";
            string characters = numbers;
            characters += alphabets + small_alphabets + numbers;

            int length = 32;
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

        #region Function for Userfolder
        public int CreateUserFolder(string mobile)
        {
            try
            {
                string map = System.Web.HttpContext.Current.Server.MapPath("~\\Users\\" + mobile);
                if (!System.IO.Directory.Exists(map))
                {
                    System.IO.Directory.CreateDirectory(map);
                    System.Web.HttpContext.Current.Session["id"] = mobile;
                    string contactmap = System.Web.HttpContext.Current.Server.MapPath("~\\Users\\" + mobile + "\\Contact");
                    string Imagesmap = System.Web.HttpContext.Current.Server.MapPath("~\\Users\\" + mobile + "\\Images");
                    string Filesmap = System.Web.HttpContext.Current.Server.MapPath("~\\Users\\" + mobile + "\\Files");

                    if (!System.IO.Directory.Exists(contactmap))
                    {
                        System.IO.Directory.CreateDirectory(contactmap);
                    }
                    if (!System.IO.Directory.Exists(Imagesmap))
                    {
                        System.IO.Directory.CreateDirectory(Imagesmap);
                    }
                    if (!System.IO.Directory.Exists(Filesmap))
                    {
                        System.IO.Directory.CreateDirectory(Filesmap);
                    }
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #region Function for Generate IDs
        public int GenId()
        {
            System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
            int random = (rand.Next(1, 100000000));
            return random;
        }
        #endregion

        #region Function for Generate Reference Code
        public string GenRefCode()
        {
            string alphabets = "ABCDEFGHIJKLMNPRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnprstuvwxyz";
            string numbers = "123456789";
            string characters = numbers;
            characters += alphabets + small_alphabets + numbers;

            int length = 5;
            string refid = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (refid.IndexOf(character) != -1);
                refid += character;
            }
            return refid;
        }
        #endregion

        #region File Encryption
        public void Encrypt(string inputFilePath, string outputfilePath)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
                {
                    using (CryptoStream cs = new CryptoStream(fsOutput, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
                        {
                            int data;
                            while ((data = fsInput.ReadByte()) != -1)
                            {
                                cs.WriteByte((byte)data);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region File Decryption
        public void Decrypt(string inputFilePath, string outputfilePath)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
                {
                    using (CryptoStream cs = new CryptoStream(fsInput, encryptor.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
                        {
                            int data;
                            while ((data = cs.ReadByte()) != -1)
                            {
                                fsOutput.WriteByte((byte)data);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Function for Document Type Check
        public string DocType(System.Web.UI.WebControls.FileUpload updoc)
        {
            string filePath = updoc.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
            string contenttype = String.Empty;

            //Word(DOC, DOCX), Excel(XLS, XLSX), PDF, Text(TXT) documents or JPG, PNG or GIF

            switch (ext)
            {
                case ".doc":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".docx":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".xls":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".xlsx":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".pdf":
                    contenttype = "application/pdf";
                    break;
                case ".txt":
                    contenttype = "text/plain";
                    break;
                case ".jpg":
                    contenttype = "image/jpeg";
                    break;
                case ".png":
                    contenttype = "image/png";
                    break;
                case ".gif":
                    contenttype = "image/gif";
                    break;
            }
            return contenttype;
        }
        #endregion

        #region Bytes To GigaBytes
        public  double ConvertBytesToGigabytes(long bytes)
        {
            return ((bytes / 1024f) / 1024f) / 1024f;
        }
        #endregion

        #region Bytes To MegaBytes
        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f ;
        }
        #endregion

        #region  GigaBytes To Bytes
       public  double ConvertGigabytesToBytes(long bytes)
        {
            return ((bytes * 1024f) * 1024f) * 1024f;
        }
        #endregion

        #region MegaBytes To Bytes
        static double ConvertMegabytesToBytes(long bytes)
        {
            return (bytes * 1024f) * 1024f;
        }
        #endregion

        #region
        public long GetDirectorySize(string folderPath)
        {
            DirectoryInfo di = new DirectoryInfo(folderPath);
            return di.EnumerateFiles("*", SearchOption.AllDirectories).Sum(fi => fi.Length);
        }
        #endregion
    }
}

