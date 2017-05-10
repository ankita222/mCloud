using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Net;
using System.IO.Compression;

namespace mCloud.UserPage
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataTable dt_temp = new DataTable();
        DataTable dtfolder = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {
            CreateTable();
            if (Page.IsPostBack != true)
            {
            loadDirectory();
            loadFiles();
        }


        }

        public void CreateTable()
        {
            dt_temp.Columns.Add("Image", typeof(string));
            dt_temp.Columns.Add("icon", typeof(string));
         
            // dt_temp.Columns.Add("Folder", typeof(string));  
        }

        public void loadDirectory()
        {
            try
            {
                string name = Session["id"].ToString();
                DirectoryInfo d = new DirectoryInfo(Server.MapPath(@"~/Users/" + name));
                DirectoryInfo[] Files = d.GetDirectories(); 
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
                //site

            }
            catch (Exception)
            {

            }
        }
        public void loadFiles()
        {
            try
            {
                string name = Session["id"].ToString();
                DirectoryInfo d = new DirectoryInfo(Server.MapPath(@"~/Users/" + name));//Assuming Test is your Folder
                FileInfo[] Files = d.GetFiles(); //Getting Text files
                string str = "", image = "";
                dt_temp.Rows.Clear();
                foreach (FileInfo file in Files)
                {
                    str = file.Name;
                    string ext = file.Extension;
                    if (ext == ".ico" || ext == ".gif" || ext == ".jpg" || ext == ".png")
                    {
                        image = "~/UserPage/images/imags.png";
                    }
                    else if (ext == ".pdf")
                    {
                        image = "~/UserPage/images/ODF.png";
                    }
                    else if (ext == ".exe" || ext == ".msi")
                    {
                        image = "~/UserPage/images/modernxp-74-software-install-i.png";
                    }
                    else if (ext == ".doc" || ext == ".docx")
                    {
                        image = "~/UserPage/images/document-626142_640 (1).png";
                    }
                    else if (ext == ".xls" || ext == ".xlsx")
                    {
                        image = "~/UserPage/images/20151205_566242be95048-210x274 (1).png";
                    }
                    else if (ext == ".txt")
                    {
                        image = "~/UserPage/images/file-txt.png";
                    }
                    else if (ext == ".zip")
                    {
                        image = "~/UserPage/images/file-zip-alt.png";
                    }
                    else
                    {
                        image = "~/UserPage/images/file-512.png";
                    }
                    object[] o = { str, image };
                    dt_temp.Rows.Add(o);
                }
                Repeater2.DataSource = dt_temp;
                Repeater2.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void btnfolder_Click(object sender, EventArgs e)
        {
            string folder = txtfolder.Value;
            string name = Session["id"].ToString();
            string map = MapPath("~\\Users\\" + name + "\\" + folder);
            if (!System.IO.Directory.Exists(map))
            {
                //string mobile = txtmobile.Value;
                //string map=MapPath("~\\Users\\"+mobile);
                System.IO.Directory.CreateDirectory(map);
                loadDirectory();
            }
        }
        protected void btnupload_Click(object sender, EventArgs e)
        {
            // img1.Style.Add("display", "block")

            //  System.Threading.Thread.Sleep(5000);
            //img2.Visible = true;

            try
            {
                string filePath = string.Empty;
                string contenttype = string.Empty;
                string filename = string.Empty;
                string filesize = string.Empty;
                string name = Session["id"].ToString();
                if (FileUpload1.HasFile)
                {
                    filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    filePath = name + "/" + filename;
                    filesize = FileUpload1.FileBytes.Length.ToString();
                    FileUpload1.SaveAs(Server.MapPath("~/Users/" + name + "/" + filename));
                }
                //img1.Style.Add("display", "none");
                loadFiles();
            }
            catch (Exception ex)
            { }
        }
        protected void btndownload_ServerClick(object sender, EventArgs e)
        {
            string username = Session["id"].ToString();
            foreach (RepeaterItem ri in Repeater2.Items)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)ri.FindControl("CheckBox1");
                System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label)ri.FindControl("mylable");
                if (chk.Checked)
                {
                    string name = lbl.Text;
                    // string map = MapPath(@"~/Users/" + username + "/" + name);
                    //  lblresume.Text = "~/Student_Resume/" + fuResume.FileName.ToString();
                    if (name != string.Empty)
                    {
                        WebClient req = new WebClient();
                        HttpResponse response = HttpContext.Current.Response;
                        string filePath = "~/Users/" + username + "/" + name;// map;
                        response.Clear();
                        response.ClearContent();
                        response.ClearHeaders();
                        response.Buffer = true;
                        response.AddHeader("Content-Disposition", "attachment;filename=" + name);
                        byte[] data = req.DownloadData(Server.MapPath(filePath));
                        response.BinaryWrite(data);
                        response.End();
                    }
                }
            }
        }
        protected void btnrename_Click(object sender, EventArgs e)
        {
            string rename = txtrename.Value;
            string username = Session["id"].ToString();
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)ri.FindControl("CheckBox1");
                System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label)ri.FindControl("mylable");
                if (chk.Checked)
                {
                    string name = lbl.Text;

                    DirectoryInfo d = new DirectoryInfo(Server.MapPath(@"~/Users/" + username));//Assuming Test is your Folder
                    DirectoryInfo[] Files = d.GetDirectories();
                    foreach (DirectoryInfo file in Files)
                    {
                        if (file.Name == name)
                        {
                            string startPath = file.FullName;

                            string frompath = Path.GetDirectoryName(startPath);
                            string topath = frompath + "\\" + rename;
                            Directory.Move(@startPath, @topath);

                            //  Directory.Delete(startPath);

                        }

                    }
                }

            }
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)ri.FindControl("CheckBox1");
                System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label)ri.FindControl("mylable");
                if (chk.Checked)
                {
                    string name = lbl.Text;

                    DirectoryInfo d = new DirectoryInfo(Server.MapPath(@"~/Users/" + username));//Assuming Test is your Folder
                    FileInfo[] Files = d.GetFiles();
                    foreach (FileInfo file in Files)
                    {
                        if (file.Name == name)
                        {
                            string startPath = file.FullName;
                            string frompath = Path.GetDirectoryName(startPath);
                            string topath = frompath + "\\" + rename;
                            File.Move(startPath, @topath);

                        }

                    }
                }
            }
            Response.Redirect(Request.RawUrl);
        }
        protected void btndel_ServerClick(object sender, EventArgs e)
        {
            string username = Session["id"].ToString();
            foreach (RepeaterItem ri in Repeater2.Items)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)ri.FindControl("CheckBox1");
                System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label)ri.FindControl("mylable");
                if (chk.Checked)
                {
                    string name = lbl.Text;
                    string map = MapPath(@"~/Users/" + username + "/" + name);
                    FileInfo fi = new FileInfo(map);
                    Int64 ln = fi.Length;// (MapPath(@"~/Users/" + username + "/" + name)).Length;
               //     IncreaseSize(ln, username);
                    System.IO.File.Delete(map);
                    //File.Delete(@"~/Users/6354/" + name);
                }
            }
            loadFiles();
        }
        ///// ///////////////////////     Update the size after deleting.///////////////////////
       /* public void IncreaseSize(Int64 size, string userid)
        {
            try
            {
                string gettotalsize = "select SizeOnDisk from UserPlanDetail where UserId='" + userid + "'";
                DataTable dtuserplan = new DataTable();
                dtuserplan = c.fetchInfo(gettotalsize);
                string sizedb = dtuserplan.Rows[0][0].ToString();
                if (double.Parse(sizedb) < double.Parse(size.ToString()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Sorry You Dont Have Enough Space')", true);
                }
                else
                {
                    double newsize = double.Parse(sizedb) + double.Parse(size.ToString());
                    string updatesize = "update UserPlanDetail set SizeOnDisk='" + newsize + "' where UserId='" + userid + "'";
                    int j = c.InsertUpdateDel(updatesize);

                }
            }
            catch (Exception)
            {
            }
        }*/
    }
}