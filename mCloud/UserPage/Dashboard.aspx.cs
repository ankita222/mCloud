using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace mCloud.UserPage
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataTable dt_temp = new DataTable();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateTable();
        }

        public void CreateTable()
        {
            dt_temp.Columns.Add("Image", typeof(string));
            dt_temp.Columns.Add("icon", typeof(string));
          
        }

        public void loadDirectory()
        {
            try
            {
                string name = Session["id"].ToString();
                DirectoryInfo d = new DirectoryInfo(Server.MapPath(@"~/Users/" + name));//Assuming Test is your Folder
                DirectoryInfo[] Files = d.GetDirectories(); //Getting Text files
                string str = "", image = "";
                foreach (DirectoryInfo file in Files)
                {
                    str = file.Name;
                    image = "~/UserPage/images/folder_PNG8771.png";
                    object[] o = { str, image };
                    dt_temp.Rows.Add(o);
                }
                Repeater1.DataSource = dt_temp;
                Repeater1.DataBind();

            }
            catch (Exception)
            {

            }
        }
    }
}