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
    public partial class PaymentWebHookPremium : System.Web.UI.Page
    {
        mCloudDAL DAL = new mCloudDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] keys = Request.Form.AllKeys;
            for (int i = 0; i < keys.Length; i++)
            {
                //Response.Write(keys[i] + ": " + Request.Form[keys[i]] + "<br>");
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath("WebHookErrorP.txt"), append: true))
                {
                    sw.WriteLine(keys[i] + ": " + Request.Form[keys[i]] + "<br>");
                    sw.Close();
                }

            }
        }
    }
}