using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using mCloud.App_Code;

namespace mCloud
{
    
    public partial class ForgotPassword : System.Web.UI.Page
    {
        mCloudDAL MDal = new mCloudDAL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            string chkUser = "select * from UserDetails where UserId='"+ txtcode.Value + "'";
            DataTable dtchk = new DataTable();
            dtchk = MDal.FunDataTable(chkUser);
            if (dtchk.Rows.Count > 0)
            {
                divchoose.Visible = true;
                divverify.Visible = false;
               
                if (dtchk.Rows[0]["IsEmailVerified"].ToString() == "False"|| dtchk.Rows[0]["Email"].ToString()=="")
                {
                    divemail.Visible = false;
                }
                
            }
            else
            {
                p_warn.Visible = true;
            }
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            if(rbtmail.Checked==true)
            {

            }
            else if(rbtmobile.Checked==true)
            {

            }
            divchoose.Visible = false;
            divOTP.Visible = true;
        }

        protected void btnverify_Click(object sender, EventArgs e)
        {
            divOTP.Visible = false;
            divChnage.Visible = true;
        }

        protected void btnResend_Click(object sender, EventArgs e)
        {

        }
    }
}