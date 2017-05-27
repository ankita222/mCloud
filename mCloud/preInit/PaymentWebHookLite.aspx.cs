using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mCloud.App_Code;
using System.IO;

namespace mCloud.preInit
{
    public partial class PaymentWebHookLite : System.Web.UI.Page
    {
        mCloudDAL DAL = new mCloudDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] keys = Request.Form.AllKeys;
            for (int i = 0; i < keys.Length; i++)
            {
                //Response.Write(keys[i] + ": " + Request.Form[keys[i]] + "<br>");
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath("WebHookError.txt"), append: true))
                {
                    sw.WriteLine(keys[i] + ": " + Request.Form[keys[i]] + "<br>");
                    sw.Close();
                }

            }
        }
    }
}
            ////string TransactionId = Request.Form[keys[0]];
            //string Status = Request.Form[keys[2]];
            //string UserId = Request.Form[keys[7]].Substring(3, Request.Form[keys[7]].Length - 3);
            //string Amount = Request.Form[keys[10]];

            //string TransactionId = Request.Form[keys[0]];
            //string Status = Request.Form[keys[1]];
            //string UserId = Request.Form[keys[2]];
            //string Amount = Request.Form[keys[3]];

            //object exist = DAL.FunExecuteScalar("SELECT COUNT(*) FROM Payment WHERE UserId='" + UserId + "'");
            //        if (int.Parse(exist.ToString()) > 0)
            //        {
            //            DAL.FunExecuteNonQuery("UPDATE Payment SET PaymentStatus='" + Status + "',TransactionId='" + TransactionId + "',PaidAmount='" + Amount + "',PaymentMode='WebSite' WHERE UserId='" + UserId + "'");
            //        }
            //    }
            //  }
            // catch (Exception ex)
            //{
            //    using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath("WebHookError.txt"), append: true))
            //    {
            //        sw.WriteLine(ex);
            //        sw.WriteLine("-----PaymentWebHookLite-----" + DateTime.Now + "-----PaymentWebHookLite-----");
            //        sw.Close();
            //    }
            //}
            //}
 