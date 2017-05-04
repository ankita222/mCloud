using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using mCloud.App_Code;



namespace mCloud.preInit
{

    public partial class Login : System.Web.UI.Page
    {
        mCloudAL m = new mCloudAL();
        mCloudDAL mDal = new mCloudDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnsign_ServerClick(object sender, EventArgs e)
        {

        }
    }
}