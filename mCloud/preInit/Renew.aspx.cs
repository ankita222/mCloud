using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mCloud.App_Code;
using System.Data;

namespace mCloud.preInit
{
    public partial class Renew : System.Web.UI.Page
    {
        mCloudDAL dal = new mCloudDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            Loaduser();
            loadplan();

        }

        public void Loaduser()
        {
            string getuser = "select * from UserDetails ud join PlanMaster pm on ud.PlanId=pm.PlanId where ud.UserId='"+ txtcode.Value.Trim()+ "'";
            DataTable dt = new DataTable();
            dt = dal.FunDataTable(getuser);
            
        }

        public void loadplan()
        {
            string getuser = "select * from PlanMaster";
            DataTable dt = new DataTable();
            dt = dal.FunDataTable(getuser);
            ddlupgrade.DataSource = dt;
            ddlupgrade.DataTextField = "Name";
            ddlupgrade.DataValueField = "PlanId";
            ddlupgrade.DataBind();
        }
        protected void btnverify_Click(object sender, EventArgs e)
        {
            divselectplan.Visible = true;
            divverify.Visible = false;
        }

        protected void btnupgrade_Click(object sender, EventArgs e)
        {
            ddlupgrade.Visible = true;
            btnpaynow.Visible = true;
            btnupgrade.Visible = false;
       
        }
    }
}