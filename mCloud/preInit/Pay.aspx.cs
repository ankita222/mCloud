using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using mCloud.App_Code;

namespace mCloud.preInit
{
    public partial class Pay : System.Web.UI.Page
    {
        mCloudDAL DAL = new mCloudDAL();
        mCloudAL AL = new mCloudAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["Name"] as string))
            {
                lblName.Text = Session["Name"].ToString();
            }

            if (!string.IsNullOrEmpty(Session["Mob"] as string))
            {
                lblMob.Text = Session["Mob"].ToString();
            }
            if (!string.IsNullOrEmpty(Session["DataSize"] as String))
            {
                string planDescription = Session["PlanName"].ToString()+" ("+ Session["DataSize"].ToString() + " GB for "+ Session["Days"].ToString() + " Days)";
                lblpalDescription.Text = planDescription;
            }
            if (!string.IsNullOrEmpty(Session["Amount"] as string))
            {
                lblAmount.Text = Session["Amount"].ToString();
            }


        }

        protected void btnPayNow_Click(object sender, EventArgs e)
        {
            if (
                !string.IsNullOrEmpty(Session["PlanId"] as string) &&
                !string.IsNullOrEmpty(Session["Amount"] as string) &&
                !string.IsNullOrEmpty(Session["DataSize"] as string) &&
                !string.IsNullOrEmpty(Session["Days"] as string) &&
                !string.IsNullOrEmpty(Session["PlanName"] as string) &&

                !string.IsNullOrEmpty(Session["Email"] as string) &&
                !string.IsNullOrEmpty(Session["Name"] as string) &&
                !string.IsNullOrEmpty(Session["Mob"] as string)
                )
            {
                
                float amount = float.Parse(Session["Amount"].ToString());
                string name = Session["Name"].ToString();
                string email = Session["Email"].ToString();
                string phone = Session["Mob"].ToString();
                
                string productinfo = Session["PlanName"].ToString() + "( " + "₹" + Session["Amount"].ToString() + " - " + Session["DataSize"].ToString() + " GB" + " - " + Session["Days"].ToString() + " Days )";
                //"₹" + Session["Amount"].ToString() + " - " + Session["DataSize"].ToString() + " GB" + " for " + Session["Days"].ToString() + " Days";

                //double validity = double.Parse()
                int PaymentId = AL.GenId();
                SqlParameter[] param =
                {
                    new SqlParameter("@UserId",phone ),
                    new SqlParameter("@Name", name),
                    new SqlParameter("@Email", email),
                    new SqlParameter("@Password", Session["Password"].ToString()),
                    new SqlParameter("@PlanId", Session["PlanId"].ToString()),
                    new SqlParameter("@PlanStatus", "NewAccount"),
                    new SqlParameter("@ExpiryDate", DateTime.Now.AddDays(Double.Parse(Session["Days"].ToString()))),
                    new SqlParameter("@PaymentId", PaymentId),
                    new SqlParameter("@UserDirectoryPath", "~/Users/"+phone),

                    new SqlParameter("@MyReferenceCode", AL.GenRefCode()),
                    new SqlParameter("@ByReferenceCode", DBNull.Value),

                    new SqlParameter("@PlanBought", Session["PlanId"].ToString()),
                    new SqlParameter("@PaymentStatus", "Pending"),
                    new SqlParameter("@PaidAmount", amount)
                };

                int x = DAL.FunExecuteNonQuerySP("ust_onreg", param);
                if (x == 0)
                {
                    //Payment Gateway
                    /// Code to Create Default Folders -> Images, Contacts, Files
                    AL.CreateUserFolder(Session["Mob"].ToString());
                    
                    
                    /// 


                    Response.Write("<script>alert('Registered Successfully.');</script>");
                   
                }
            }
            else
                Response.Write("<script>alert('Something went wrong, please try again.');</script>");


        }
    }
}