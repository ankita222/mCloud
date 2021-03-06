﻿using System;
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
using mCloud.App_Code;
using System.Web.Security;
using Thought.vCards;

namespace mCloud.UserPage
{
    public partial class Dashboard : System.Web.UI.Page
    {
        DataTable dt_temp = new DataTable();
        DataTable dtfolder = new DataTable();
        mCloudAL AL = new mCloudAL();
        mCloudDAL DAL = new mCloudDAL();
        DataTable dtSiteMap = new DataTable();
        DataTable dtfav;
        DataTable dticon = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["id"] as string))
            {
                Session.Clear();
                Session.Abandon();
                FormsAuthentication.SignOut();
                Response.Redirect("~/Default.aspx");
            }
            CreateTable();
            CreateSiteMap();
            LoadDtFavList();
            divContact.Visible = false;

            string ReqFolder = Request.QueryString["type"];

            if (Page.IsPostBack != true)
            {


                LoadSiteMap(Session["id"].ToString());
                treeFolder();

                if (ReqFolder == "files")
                {
                    //CreateSiteMap("files");
                    //LoadSiteMap("Files");
                    LoadSiteMap("Files");
                }
                else if (ReqFolder == "image")
                {
                    LoadSiteMap("Images");
                }
                else if (ReqFolder == "contact")
                {
                    // LoadSiteMap("Contact");
                    LoadContactFolder("Contact");
                }
                else if (ReqFolder == "sharedby")
                {
                    LoadSharedBy();
                }
                else if (ReqFolder == "shared")
                {
                    LoadSharedWith();
                }

                if (ReqFolder != "contact" && ReqFolder != "sharedby" && ReqFolder != "shared")
                {
                    loadDirectory();
                    loadFiles();
                }

            }
        }

        protected void LoadDtFavList()
        {
            #region Code to create Session Datatable and storing the Favourite items
            dtfav = new DataTable();
            dtfav = DAL.FunDataTable("Select [UserId],[FavouriteItemName],[FavouriteItemPath],[ItemType] from [FavouriteList] where [UserId]='" + Session["id"].ToString() + "' ");
            Session["dtfav"] = dtfav;
            dticon = (DataTable)Session["dtfav"];
            #endregion

        }

        public void LoadSharedBy()
        {
            try
            {
                string name = Session["id"].ToString();
                string getshareddoc = "select * from SharedFiles where SharedBy ='" + name + "'";
                DataTable dtshare = new DataTable();

                dtshare = DAL.FunDataTable(getshareddoc);

                if (dtshare != null)
                {

                    for (int i = 0; i < dtshare.Rows.Count; i++)
                    {
                        string path = dtshare.Rows[i]["FilePath"].ToString();
                        //check for it is directory or file
                        int dir;
                        FileAttributes attr = File.GetAttributes(path);
                        if ((attr & FileAttributes.Directory) != FileAttributes.Directory)
                        {
                            //string sender = dtshare.Rows[i]["Sender"].ToString();
                            // DirectoryInfo d = new DirectoryInfo(@"E:\MoilCloud\New folder\MoilCloud\onlineStorage\Users\9708942333");
                            FileInfo Files = new FileInfo(path);
                            string ext = Files.Extension;
                            string str1 = dtshare.Rows[i]["FilleName"].ToString(), image;
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
                            object[] o = { str1, image };
                            dt_temp.Rows.Add(o);
                            Repeater2.DataSource = dt_temp;
                            Repeater2.DataBind();

                        }
                        //else
                        //{
                        //    string str = dtshare.Rows[i]["FilleName"].ToString();
                        //    string image = "~/UserPage/images/folder_PNG8771.png";
                        //    object[] o1 = { str, image };
                        //    dt_temp.Rows.Clear();
                        //    dt_temp.Rows.Add(o1);
                        //    Repeater1.DataSource = dt_temp;
                        //    Repeater1.DataBind();

                        //}


                    }
                    foreach (RepeaterItem ri in Repeater2.Items)
                    {
                        ImageButton btnfav = (ImageButton)ri.FindControl("btnfilefav");
                        btnfav.Visible = false;
                    }
                }
                // for loading 

            }

            catch (Exception ex)
            {

            }
        }

        public void LoadSharedWith()
        {


            try
            {
                string name = Session["id"].ToString();
                string getshareddoc = "select * from SharedFiles where SharedWith ='" + name + "'";
                DataTable dtshare = new DataTable();

                dtshare = DAL.FunDataTable(getshareddoc);

                if (dtshare != null && dtshare.Rows.Count > 0)
                {

                    for (int i = 0; i < dtshare.Rows.Count; i++)
                    {
                        string path = dtshare.Rows[i]["FilePath"].ToString();
                        //check for it is directory or file
                        int dir;
                        FileAttributes attr = File.GetAttributes(path);
                        if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                        {
                            string str = dtshare.Rows[i]["FilleName"].ToString();
                            string image = "~/UserPage/images/folder_PNG8771.png";
                            object[] o1 = { str, image };
                            dt_temp.Rows.Clear();
                            dt_temp.Rows.Add(o1);
                            Repeater1.DataSource = dt_temp;
                            Repeater1.DataBind();

                        }
                        else
                        {
                            //string sender = dtshare.Rows[i]["Sender"].ToString();
                            // DirectoryInfo d = new DirectoryInfo(@"E:\MoilCloud\New folder\MoilCloud\onlineStorage\Users\9708942333");
                            FileInfo Files = new FileInfo(path);
                            string ext = Files.Extension;
                            string str1 = dtshare.Rows[i]["FilleName"].ToString(), image;
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
                            object[] o = { str1, image };
                            dt_temp.Rows.Add(o);
                            Repeater2.DataSource = dt_temp;
                            Repeater2.DataBind();
                        }


                    }
                    foreach (RepeaterItem ri in Repeater2.Items)
                    {
                        ImageButton btnfav = (ImageButton)ri.FindControl("btnfilefav");
                        btnfav.Visible = false;
                    }
                }
                // for loading 

            }

            catch (Exception ex)
            {
                DAL.OnError(ex);
            }
        }

        public void treeFolder()
        {
            try
            {
                string name = Session["id"].ToString();
                // DirectoryInfo rootInfo = new DirectoryInfo(Server.MapPath(@"~/Users/" + name));

                //////      Changes-------------------////////////////////////
                SetTreeViewCopyPath();
                SetTreeViewMovePath();
                /////       End Changes ----------------------------////////

                // this.PopulateTreeViewMove(rootInfo, null);
                // this.PopulateTreeViewCopy(rootInfo,null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region treeview path set
        protected void SetTreeViewCopyPath()
        {
            string name = Session["id"].ToString();

            DirectoryInfo rootInfo = new DirectoryInfo(Server.MapPath(@"~/Users/" + name));
            TreeNode parentNode = new TreeNode("Dashboard");
            TreeViewCopy.Nodes.Add(parentNode);
            this.PopulateTreeViewCopy(rootInfo, parentNode);
        }
        protected void SetTreeViewMovePath()
        {
            string name = Session["id"].ToString();
            DirectoryInfo rootInfo = new DirectoryInfo(Server.MapPath(@"~/Users/" + name));
            TreeNode parentNode = new TreeNode("Dashboard");
            TreeViewMove.Nodes.Add(parentNode);
            this.PopulateTreeViewMove(rootInfo, parentNode);

            //TreeViewCopy.Nodes.Add(parentNode);
            //this.PopulateTreeViewCopy(rootInfo, parentNode);
        }
        #endregion
        private void PopulateTreeViewCopy(DirectoryInfo dirInfo, TreeNode treeNode)
        {
            try
            {
                foreach (DirectoryInfo directory in dirInfo.GetDirectories())
                {
                    TreeNode directoryNode = new TreeNode
                    {
                        Text = directory.Name,
                        Value = directory.FullName
                    };

                    if (treeNode == null)
                    {
                        //If Root Node, add to TreeView.
                        //    TreeView1.Nodes.Add(directoryNode);

                        TreeViewCopy.Nodes.Add(directoryNode);

                    }
                    else
                    {
                        //If Child Node, add to Parent Node.
                        treeNode.ChildNodes.Add(directoryNode);
                    }

                    //Get all files in the Directory.
                    //foreach (FileInfo file in directory.GetFiles())
                    //{
                    //    //Add each file as Child Node.
                    //    TreeNode fileNode = new TreeNode
                    //    {
                    //        Text = file.Name,
                    //        Value = file.FullName,
                    //        Target = "_blank",
                    //        NavigateUrl = (new Uri(Server.MapPath("~/"))).MakeRelativeUri(new Uri(file.FullName)).ToString()
                    //    };
                    //    directoryNode.ChildNodes.Add(fileNode);
                    //}

                    PopulateTreeViewCopy(directory, directoryNode);
                }

            }
            catch (Exception)
            {
            }
        }
        private void PopulateTreeViewMove(DirectoryInfo dirInfo, TreeNode treeNode)
        {
            try
            {
                foreach (DirectoryInfo directory in dirInfo.GetDirectories())
                {
                    TreeNode directoryNode = new TreeNode
                    {
                        Text = directory.Name,
                        Value = directory.FullName
                    };

                    if (treeNode == null)
                    {
                        //If Root Node, add to TreeView.
                        //    TreeView1.Nodes.Add(directoryNode);
                        TreeViewMove.Nodes.Add(directoryNode);


                    }
                    else
                    {
                        //If Child Node, add to Parent Node.
                        treeNode.ChildNodes.Add(directoryNode);
                    }

                    //Get all files in the Directory.
                    //foreach (FileInfo file in directory.GetFiles())
                    //{
                    //    //Add each file as Child Node.
                    //    TreeNode fileNode = new TreeNode
                    //    {
                    //        Text = file.Name,
                    //        Value = file.FullName,
                    //        Target = "_blank",
                    //        NavigateUrl = (new Uri(Server.MapPath("~/"))).MakeRelativeUri(new Uri(file.FullName)).ToString()
                    //    };
                    //    directoryNode.ChildNodes.Add(fileNode);
                    //}

                    PopulateTreeViewMove(directory, directoryNode);
                }

            }
            catch (Exception)
            {
            }
        }




        protected void LoadSiteMap(String UserId)
        {
            Object[] o = { UserId };
            dtSiteMap.Rows.Add(o);
            ViewState["VSdtSiteMap"] = dtSiteMap;
            rptbreadcrumps.DataSource = dtSiteMap;
            rptbreadcrumps.DataBind();
        }
        protected void btnmoveok_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string path = TreeViewMove.SelectedValue.ToString();

                if (path == "Dashboard")
                {
                    path = Server.MapPath("~//Users//" + Session["id"].ToString());
                }
                int x = CheckRepeaterCount();
                if (x <= 0)
                {
                    Response.Write("<Script>alert('Select file')</Script>");
                }
                else
                {
                    string username = Session["id"].ToString();
                    foreach (RepeaterItem ri in Repeater2.Items)
                    {
                        HtmlInputCheckBox chk = (HtmlInputCheckBox)ri.FindControl("CheckBox1");
                        System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label)ri.FindControl("mylable");
                        if (chk.Checked)
                        {
                            string name = lbl.Text;
                            string Path2 = GetCurrentPath();
                            DirectoryInfo d = new DirectoryInfo(Server.MapPath(@Path2));//Assuming Test is your Folder
                            FileInfo[] Files = d.GetFiles();
                            foreach (FileInfo file in Files)
                            {
                                if (file.Name == name)
                                {
                                    string filepath = file.FullName;

                                    File.Move(@filepath, @path + "\\" + name);
                                }
                            }

                        }

                    }
                    loadDirectory();
                    loadFiles();
                    //Response.Redirect(Request.RawUrl);
                }
            }
            catch (Exception ex)
            {
                DAL.OnError(ex);
            }
        }
        protected void btnarchive_Click(object sender, EventArgs e)
        {
            string zipname = txtzipname.Value;
            string username = Session["id"].ToString();
            int x = CheckRepeaterCount();
            if (x <= 0)
            {
                Response.Write("<Script>alert('Select Folder to archive')</Script>");
            }
            else
            {
                try
                {
                    foreach (RepeaterItem ri in Repeater1.Items)
                    {
                        HtmlInputCheckBox chk = (HtmlInputCheckBox)ri.FindControl("CheckBox1");
                        System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label)ri.FindControl("mylable");
                        if (chk.Checked)
                        {
                            string name = lbl.Text;
                            string Path2 = GetCurrentPath();
                            DirectoryInfo d = new DirectoryInfo(Server.MapPath(@Path2));//Assuming Test is your Folder
                            DirectoryInfo[] Files = d.GetDirectories();
                            foreach (DirectoryInfo file in Files)
                            {
                                if (file.Name == name)
                                {
                                    string startPath = file.FullName;
                                    //string h = "E:\\MoilCloud\New folder\MoilCloud\onlineStorage\Users\9708942333\Mudassar Khan.vcf";
                                    //string v = "E:\\MoilCloud\New folder\MoilCloud\onlineStorage\Users\9708942333\wwwww.zip";
                                    string t = Path.GetDirectoryName(startPath);
                                    string zipPath = @t + "\\" + zipname + ".zip";


                                    //  string extractPath = @"c:\example\extract";

                                    ZipFile.CreateFromDirectory(@startPath, @zipPath, CompressionLevel.Fastest, true);
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }
                loadDirectory();
                loadFiles();
            }
        }
        protected void btncopyfile_ServerClick(object sender, EventArgs e)
        {
            string path = TreeViewCopy.SelectedValue.ToString();
            if (path == "Dashboard")// Session["id"].ToString())
            {
                path = MapPath(@"~//Users//" + Session["id"].ToString());
            }

            // string username = Session["id"].ToString();
            int x = CheckRepeaterCount();
            if (x <= 0)
            {
                Response.Write("<Script>alert('Select File')</Script>");
            }
            else
            {
                foreach (RepeaterItem ri in Repeater2.Items)
                {
                    HtmlInputCheckBox chk = (HtmlInputCheckBox)ri.FindControl("CheckBox1");
                    System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label)ri.FindControl("mylable");
                    if (chk.Checked)
                    {
                        string name = lbl.Text;
                        string Path2 = GetCurrentPath();
                        DirectoryInfo d = new DirectoryInfo(Server.MapPath(@Path2));//Assuming Test is your Folder
                        FileInfo[] Files = d.GetFiles();
                        foreach (FileInfo file in Files)
                        {
                            if (file.Name == name)
                            {
                                string filepath = file.FullName;
                                string DestinationPath = path + "\\" + name;
                                try
                                {
                                    File.Copy(@filepath, @DestinationPath, true);
                                    //  File.Copy(@filepath, @"D:\\Project\\"+name, true);
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }

                            }
                        }

                    }
                }

                //   Response.Redirect(Request.RawUrl);
            }
        }
        protected void CreateSiteMap()
        {
            dtSiteMap.Columns.Add("dir", typeof(String));

        }
        public void CreateTable()
        {
            dt_temp.Columns.Add("Image", typeof(string));
            dt_temp.Columns.Add("icon", typeof(string));
            dt_temp.Columns.Add("favicon", typeof(string));

            // dt_temp.Columns.Add("Folder", typeof(string));  
        }
        public void loadDirectory()
        {
            try
            {
                //string path2 = "~//Users//";
                //dtSiteMap = (DataTable)ViewState["VSdtSiteMap"];

                //for (int i = 0; i < dtSiteMap.Rows.Count; i++)
                //{
                //    path2 = path2 + dtSiteMap.Rows[i]["dir"].ToString() + "//";
                //}

                string path2 = GetCurrentPath();
                string name = Session["id"].ToString();
                DirectoryInfo d = new DirectoryInfo(Server.MapPath(@path2));

                DirectoryInfo[] Files = d.GetDirectories();
                string currentpath = d.FullName;
                string str = "", image = "", deficon = "", favicon = "";
                favicon = "~/UserPage/images/unfav.png";
                deficon = "~/UserPage/images/fav.png";
                string icon = "";
                object[] o = new object[3];
                foreach (DirectoryInfo file in Files)
                {
                    str = file.Name;
                    image = "~/UserPage/images/folder_PNG8771.png";

                    if (dticon != null && dticon.Rows.Count > 0)
                    {
                        int f = 1;
                        for (int i = 0; i < dticon.Rows.Count; i++)
                        {
                            string dtfavpath = dticon.Rows[i]["FavouriteItemPath"].ToString();
                            string itemname = dticon.Rows[i]["FavouriteItemName"].ToString();
                            if (currentpath == dtfavpath && str == itemname) { f = 0; break; }
                        }
                        if (f == 0) { icon = favicon; } else { icon = deficon; }

                        o[0] = str;
                        o[1] = image;
                        o[2] = icon;
                    }
                    else
                    {
                        o[0] = str;
                        o[1] = image;
                        o[2] = deficon;
                    }

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
                //string path2 = "~//Users//";
                //dtSiteMap = (DataTable)ViewState["VSdtSiteMap"];

                //for (int i = 0; i < dtSiteMap.Rows.Count; i++)
                //{
                //    path2 = path2 + dtSiteMap.Rows[i]["dir"].ToString() + "//";
                //}
                string path2 = GetCurrentPath();
                //DirectoryInfo d = new DirectoryInfo(Server.MapPath(@"~/Users/" + name));//Assuming Test is your Folder
                DirectoryInfo d = new DirectoryInfo(Server.MapPath(@path2));
                FileInfo[] Files = d.GetFiles(); //Getting Text files
                string currentpath = d.FullName;
                string str = "", image = "", deficon = "", favicon = "";
                favicon = "~/UserPage/images/unfav.png";
                deficon = "~/UserPage/images/fav.png";
                string icon = "";
                dt_temp.Rows.Clear();
                object[] o = new object[3];

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
                        image = "~/UserPage/images/document-626142_640.png";
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
                    if (dticon != null && dticon.Rows.Count > 0)
                    {
                        int f = 1;
                        for (int i = 0; i < dticon.Rows.Count; i++)
                        {
                            string dtfavpath = dticon.Rows[i]["FavouriteItemPath"].ToString();
                            string itemname = dticon.Rows[i]["FavouriteItemName"].ToString();
                            if (currentpath == dtfavpath && str == itemname) { f = 0; break; }
                        }
                        if (f == 0) { icon = favicon; } else { icon = deficon; }

                        o[0] = str;
                        o[1] = image;
                        o[2] = icon;
                    }
                    else
                    {
                        o[0] = str;
                        o[1] = image;
                        o[2] = deficon;
                    }

                    dt_temp.Rows.Add(o);
                    //object[] o = { str, image,favicon };
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
            string path2 = "~//Users//";
            dtSiteMap = (DataTable)ViewState["VSdtSiteMap"];

            for (int i = 0; i < dtSiteMap.Rows.Count; i++)
            {
                path2 = path2 + dtSiteMap.Rows[i]["dir"].ToString() + "//";
            }

            //string name = Session["id"].ToString();
            //string map = MapPath("~\\Users\\" + name + "\\" + folder);
            string map = Server.MapPath(path2 + folder);
            if (!System.IO.Directory.Exists(map))
            {
                //string mobile = txtmobile.Value;
                //string map=MapPath("~\\Users\\"+mobile);
                System.IO.Directory.CreateDirectory(map);

                loadDirectory();
                TreeViewMove.Nodes.Clear();
                TreeViewCopy.Nodes.Clear();
                treeFolder();

            }
        }
        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {
                string path2 = "~//Users//";
                dtSiteMap = (DataTable)ViewState["VSdtSiteMap"];

                for (int i = 0; i < dtSiteMap.Rows.Count; i++)
                {
                    path2 = path2 + dtSiteMap.Rows[i]["dir"].ToString() + "//";
                }
                string name = Session["id"].ToString();
                // get contenttype
                string type = AL.DocType(FileUpload1);

                if (type == "image/gif" || type == "image/png" || type == "image/jpeg" || type == "Image/jpg" || type == "text/plain" || type == "application/pdf" || type == "application/vnd.ms-excel" || type == "application/vnd.ms-excel" || type == "application/vnd.ms-word" || type == "application/vnd.ms-word")
                {
                    //Get the Input File Name and Extension.
                    string fileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName);
                    string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);

                    //Build the File Path for the original (input) and the encrypted (output) file.
                    //string input = Server.MapPath("~/Users/" + name + "/") + fileName + fileExtension;
                    //string output = Server.MapPath("~/Users/" + name + "/") + fileName + "_" + fileExtension;

                    ///Changed by Jamal
                    string input = Server.MapPath(path2) + fileName + fileExtension;
                    //string input = Server.MapPath(path2) + fileName + "_" + fileExtension;
                    //     string output = Server.MapPath(path2) + fileName + fileExtension;

                    //Save the Input File, Encrypt it and save the encrypted file in output path.
                    FileUpload1.SaveAs(input);
                    //this.AL.Encrypt(input, output);

                    //Download the Encrypted File.
                    //Response.ContentType = FileUpload1.PostedFile.ContentType;
                    //Response.Clear();
                    //Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(output));
                    //Response.WriteFile(output);
                    //Response.Flush();
                    //Delete the original (input) and the encrypted (output) file.

                    // File.Delete(input);
                    //File.Delete(output);

                    //Response.End();
                }
                else
                {
                    string filePath = string.Empty;
                    string contenttype = string.Empty;
                    string filename = string.Empty;
                    string filesize = string.Empty;

                    if (FileUpload1.HasFile)
                    {
                        filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                        // filePath = name + "/" + filename;
                        filePath = path2 + "/" + filename;
                        filesize = FileUpload1.FileBytes.Length.ToString();
                        FileUpload1.SaveAs(Server.MapPath(path2 + filename));
                    }
                    //img1.Style.Add("display", "none");
                }
                DAL.FunExecuteNonQuery("UPDATE UserDetails SET UsedSpace='" + AL.GetDirectorySize(Server.MapPath("~/Users/" + Session["id"].ToString()).ToString()) + "' WHERE UserId='" + Session["id"].ToString() + "'");
            }
            catch (Exception ex)
            { throw ex; }
            loadFiles();
        }

        //code to download files
        protected void btndownload_ServerClick(object sender, EventArgs e)
        {
            try
            {
                // string username = Session["id"].ToString();
                string folder = txtfolder.Value;
                //string path2 = "~//Users//";
                //dtSiteMap = (DataTable)ViewState["VSdtSiteMap"];

                //for (int i = 0; i < dtSiteMap.Rows.Count; i++)
                //{
                //    path2 = path2 + dtSiteMap.Rows[i]["dir"].ToString() + "//";
                //}
                string path2 = GetCurrentPath();
                int x = CheckRepeaterCount();
                if (x <= 0)
                {
                    Response.Write("<Script>alert('Select File');</script>");
                }
                else
                {
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
                                //string inputfilePath = Server.MapPath("~/Users/" + username + "/" + name);// map;
                                //string outputfilePath = Server.MapPath("~/Users/" + username + "/" + "1" + name);// map;

                                string inputfilePath = Server.MapPath(path2 + name);// map;
                                // string outputfilePath = Server.MapPath(path2 + "//1" + name);// map;
                                string ext = Path.GetExtension(inputfilePath);

                                if (ext == ".gif" || ext == ".png" || ext == ".jpeg" || ext == ".jpg" || ext == ".txt" || ext == ".pdf" || ext == ".xls" || ext == ".xlsx" || ext == ".doc" || ext == ".docx")
                                {   ///Exception Error in Decryption
                                    #region Removed Decrytion code Temporarily
                                    //////////////Removing Decrytion/////////////
                                    // this.AL.Decrypt(inputfilePath, outputfilePath);

                                    //response.Clear();
                                    //response.ClearContent();
                                    //response.ClearHeaders();
                                    //response.Buffer = true;
                                    //response.AddHeader("Content-Disposition", "attachment;filename=" + name);

                                    //byte[] data = req.DownloadData(outputfilePath);

                                    //response.BinaryWrite(data);
                                    //File.Delete(outputfilePath);
                                    //response.End();
                                    ///////////////////////////////////////////////
                                    #endregion

                                    #region Remove below codes when Encrytion and decrytion is applied
                                    WebClient req1 = new WebClient();
                                    HttpResponse response1 = HttpContext.Current.Response;
                                    string filePath = path2 + "/" + name;// map;
                                    response1.Clear();
                                    response1.ClearContent();
                                    response1.ClearHeaders();
                                    response1.Buffer = true;
                                    response1.AddHeader("Content-Disposition", "attachment;filename=" + name);
                                    byte[] data = req.DownloadData(Server.MapPath(filePath));
                                    response1.BinaryWrite(data);
                                    response1.End();
                                    #endregion
                                }
                                else
                                {
                                    WebClient req1 = new WebClient();
                                    HttpResponse response1 = HttpContext.Current.Response;
                                    string filePath = path2 + "/" + name;// map;
                                    response1.Clear();
                                    response1.ClearContent();
                                    response1.ClearHeaders();
                                    response1.Buffer = true;
                                    response1.AddHeader("Content-Disposition", "attachment;filename=" + name);
                                    byte[] data = req.DownloadData(Server.MapPath(filePath));
                                    response1.BinaryWrite(data);
                                    response1.End();
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception)
            { }

        }
        protected void btnrename_Click(object sender, EventArgs e)
        {
            //string path2 = "~//Users//";
            //dtSiteMap = (DataTable)ViewState["VSdtSiteMap"];

            //for (int i = 0; i < dtSiteMap.Rows.Count; i++)
            //{
            //    path2 = path2 + dtSiteMap.Rows[i]["dir"].ToString() + "//";
            //}

            //string rename = txtrename.Value;

            //int x = 0;
            //foreach (RepeaterItem ri in Repeater1.Items)
            //{
            //    HtmlInputCheckBox chk = (HtmlInputCheckBox)ri.FindControl("CheckBox1");
            //    System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label)ri.FindControl("mylable");
            //    if (chk.Checked) { x++; }
            //}
            //foreach (RepeaterItem ri in Repeater2.Items)
            //{
            //    HtmlInputCheckBox chk = (HtmlInputCheckBox)ri.FindControl("CheckBox1");
            //    System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label)ri.FindControl("mylable");
            //    if (chk.Checked) { x++; }
            //}

            string rename = txtrename.Value;
            string path2 = GetCurrentPath();
            string DefaultPath = "~//Users//" + Session["id"].ToString() + "//";
            int x = CheckRepeaterCount();
            if (x > 1)
            {
                Response.Write("<script>alert('Select single file.')</script>");
            }
            else if (x == 0)
            {
                Response.Write("<script>alert('Select file/folder to rename');</script>");
            }
            else
            {
                #region Code to Rename Folder and FIle
                #region Code to Rename Folder
                foreach (RepeaterItem ri in Repeater1.Items)
                {
                    HtmlInputCheckBox chk = (HtmlInputCheckBox)ri.FindControl("CheckBox1");
                    System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label)ri.FindControl("mylable");
                    if (chk.Checked)
                    {
                        string name = lbl.Text;
                        if ((path2 == DefaultPath) && (name == "Images" || name == "Files" || name == "Contact"))
                        {
                            Response.Write("<script>alert('Can not rename default direcroy.')</script>");
                        }
                        else
                        {
                            DirectoryInfo d = new DirectoryInfo(MapPath(@path2));//Assuming Test is your Folder
                            DirectoryInfo[] Files = d.GetDirectories();
                            //int F = 1;
                            //for(int i=0;i<Files.Length;i++)
                            //{
                            //    if (Files[i].ToString() == rename)
                            //    {
                            //        F = 0;
                            //        break;
                            //    }
                            //}

                            //if (F == 0)
                            //{
                            //    Response.Write("<Script>alert('Folder Already exists.');</Script>");
                            //}
                            //else
                            //{
                            foreach (DirectoryInfo file in Files)
                            {
                                if (file.Name == name)
                                {
                                    if (System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(@path2 + "//" + rename)) || System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(@path2 + "//" + rename)))
                                    {
                                        Response.Write("<Script>alert('Folder already exists');</Script>");
                                    }
                                    else
                                    {
                                        string startPath = file.FullName;

                                        string frompath = Path.GetDirectoryName(startPath);
                                        string topath = frompath + "\\" + rename;

                                        Directory.Move(@startPath, @topath);

                                        //  Directory.Delete(startPath);
                                    }
                                }

                            }
                            //}
                        }
                    }

                }
                #endregion
                #region Code to rename Files
                foreach (RepeaterItem ri in Repeater2.Items)
                {
                    HtmlInputCheckBox chk = (HtmlInputCheckBox)ri.FindControl("CheckBox1");
                    System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label)ri.FindControl("mylable");
                    if (chk.Checked)
                    {

                        string name = lbl.Text;
                        string ext = Path.GetExtension(name);

                        DirectoryInfo d = new DirectoryInfo(MapPath(@path2));//Assuming Test is your Folder
                        FileInfo[] Files = d.GetFiles();
                        foreach (FileInfo file in Files)
                        {
                            if (file.Name == name)
                            {
                                if (System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(@path2 + "//" + rename + ext)) || System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(@path2 + "//" + rename + ext)))
                                {
                                    Response.Write("<Script>alert('File already exists');</Script>");
                                }
                                else
                                {

                                    string startPath = file.FullName;
                                    string frompath = Path.GetDirectoryName(startPath);
                                    string topath = frompath + "\\" + rename + ext;

                                    File.Move(startPath, @topath);
                                }
                            }
                        }
                    }
                }
                #endregion
                #endregion

                loadDirectory();
                loadFiles();

                TreeViewMove.Nodes.Clear();
                TreeViewCopy.Nodes.Clear();
                treeFolder();
            }

            // Code to reload current page.
            //Response.Redirect(Request.RawUrl);
        }
        protected void btndel_ServerClick(object sender, EventArgs e)
        {
            //string username = Session["id"].ToString();

            string folder = txtfolder.Value;
            //string path2 = "~//Users//";
            //dtSiteMap = (DataTable)ViewState["VSdtSiteMap"];

            //for (int i = 0; i < dtSiteMap.Rows.Count; i++)
            //{
            //    path2 = path2 + dtSiteMap.Rows[i]["dir"].ToString() + "//";
            //}
            String path2 = GetCurrentPath();
            int x = CheckRepeaterCount();
            if (x <= 0)
            {
                Response.Write("<script>alert('Select file/folder to delete.')</script>");
            }
            else if (x > 0)
            {
                foreach (RepeaterItem ri in Repeater1.Items)
                {
                    HtmlInputCheckBox chk = (HtmlInputCheckBox)ri.FindControl("CheckBox1");
                    System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label)ri.FindControl("mylable");
                    if (chk.Checked)
                    {
                        string name = lbl.Text;

                        string DefaultPath = "~//Users//" + Session["id"].ToString() + "//";
                        if ((path2 == DefaultPath) && (name == "Images" || name == "Files" || name == "Contact"))
                        {
                            Response.Write("<script>alert('Can not delete default direcroy.')</script>");
                        }
                        else
                        {
                            DirectoryInfo d = new DirectoryInfo(MapPath(@path2));//Assuming Test is your Folder
                            DirectoryInfo[] Files = d.GetDirectories();
                            foreach (DirectoryInfo file in Files)
                            {
                                if (file.Name == name)
                                {
                                    string startPath = file.FullName;

                                    try
                                    {
                                        //DirectoryInfo d11 = new DirectoryInfo(MapPath(@path2+"//"+name));//Assuming Test is your Folder
                                        //DirectoryInfo[] Files1 = d11.GetDirectories();
                                        //if (Files1[0] == null)
                                        //{
                                        //    Directory.Delete(startPath);
                                        //}
                                        //else
                                        //{

                                        Directory.Delete(startPath, recursive: true);
                                        //}

                                    }
                                    catch (Exception ex)
                                    {
                                        Response.Write("<Script>alert('Directory is not Empty''" + ex.ToString() + "')</script>");
                                    }

                                }

                            }
                            TreeViewMove.Nodes.Clear();
                            TreeViewCopy.Nodes.Clear();
                            treeFolder();
                        }
                    }
                }

            }

            foreach (RepeaterItem ri in Repeater2.Items)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)ri.FindControl("CheckBox1");
                System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label)ri.FindControl("mylable");
                if (chk.Checked)
                {
                    string name = lbl.Text;
                    //string map = MapPath(@"~/Users/" + username + "/" + name);
                    string map = MapPath(@path2 + "/" + name);
                    FileInfo fi = new FileInfo(map);
                    Int64 ln = fi.Length;// (MapPath(@"~/Users/" + username + "/" + name)).Length;
                                         //     IncreaseSize(ln, username);
                    string delfromSharedList = "delete from [SharedFiles] where [FilePath]='" + map + "'";
                    int delcnt = DAL.FunExecuteNonQuery(delfromSharedList);
                    if (x > 0)
                    {
                        System.IO.File.Delete(map);
                    }


                    //File.Delete(@"~/Users/6354/" + name);
                }
            }
            DAL.FunExecuteNonQuery("UPDATE UserDetails SET UsedSpace='" + AL.GetDirectorySize(Server.MapPath("~/Users/" + Session["id"].ToString()).ToString()) + "' WHERE UserId='" + Session["id"].ToString() + "'");
            loadDirectory();
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

        protected void Image1_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string foldername = e.CommandArgument.ToString();
                //string path2 = "~//Users//";
                //dtSiteMap = (DataTable)ViewState["VSdtSiteMap"];
                //for (int i = 0; i < dtSiteMap.Rows.Count; i++)
                //{
                //    path2 = path2 + dtSiteMap.Rows[i]["dir"].ToString() + "//";
                //}
                string path2 = GetCurrentPath();
                String ContactRootPath = "~//Users//" + Session["id"].ToString() + "//";
                if (path2 == ContactRootPath && foldername == "Contact")
                {
                    LoadContactFolder(foldername);
                }
                else
                {
                    string path = Server.MapPath(@path2 + foldername);
                    ////////////////////////////////////////////////////////
                    // string name = Session["id"].ToString();
                    //DirectoryInfo d = new DirectoryInfo(path);//Assuming Test is your Folder
                    //DirectoryInfo[] dir = d.GetDirectories(); //Getting Text files
                    //string str = "", image = "";
                    //foreach (DirectoryInfo file in dir)
                    //{
                    //    str = file.Name;
                    //    image = "~/UserPage/images/folder_PNG8771.png";
                    //    object[] o = { str, image };
                    //    dt_temp.Rows.Add(o);
                    //}
                    //Repeater1.DataSource = dt_temp;
                    //Repeater1.DataBind();
                    LoadSiteMap(foldername);
                    LoadDtFavList();
                    loadDirectory();
                    loadFiles();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Coding to Load Contact Folder
        #endregion
        protected void LoadContactFolder(string FolderName)
        {
            LoadSiteMap(FolderName);
            LoadDtFavList();
            loadDirectory();

            #region Code to Load Files in Repeater2 except .vcf file

            string path2 = GetCurrentPath();
            DirectoryInfo d = new DirectoryInfo(Server.MapPath(@path2));
            FileInfo[] Files = d.GetFiles(); //Getting Text files
            string currentpath = d.FullName;
            string str = "", image = "", deficon = "", favicon = "", ext = "";
            favicon = "~/UserPage/images/unfav.png";
            deficon = "~/UserPage/images/fav.png";
            string icon = "";
            dt_temp.Rows.Clear();
            object[] o = new object[3];
            try
            {
                foreach (FileInfo file in Files)
                {
                    str = file.Name;
                    ext = file.Extension;
                    if (ext != ".vcf")
                    {
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
                            image = "~/UserPage/images/document-626142_640.png";
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

                        if (dticon != null && dticon.Rows.Count > 0)
                        {
                            int f = 1;
                            for (int i = 0; i < dticon.Rows.Count; i++)
                            {
                                string dtfavpath = dticon.Rows[i]["FavouriteItemPath"].ToString();
                                string itemname = dticon.Rows[i]["FavouriteItemName"].ToString();
                                if (currentpath == dtfavpath && str == itemname) { f = 0; break; }
                            }
                            if (f == 0) { icon = favicon; } else { icon = deficon; }

                            o[0] = str;
                            o[1] = image;
                            o[2] = icon;
                        }
                        else
                        {
                            o[0] = str;
                            o[1] = image;
                            o[2] = deficon;
                        }

                        dt_temp.Rows.Add(o);
                        //object[] o = { str, image,favicon };
                    }
                    Repeater2.DataSource = dt_temp;
                    Repeater2.DataBind();
                    //object[] o = { str, image };
                    //    dt_temp.Rows.Add(o);

                    //Repeater2.DataSource = dt_temp;
                    //Repeater2.DataBind();
                }
                #endregion

                #region LoadVCFFiles

                DataTable dtcontact = new DataTable();
                dtcontact.Columns.Add("Name", typeof(string));
                dtcontact.Columns.Add("Contact", typeof(string));
                dtcontact.Columns.Add("EMail", typeof(string));

                str = ""; ext = "";
                foreach (FileInfo file in Files)
                {
                    str = file.Name;
                    ext = file.Extension;
                    if (ext == ".vcf")
                    {
                        vCard card = new vCard(file.FullName);


                        string Cname, contatc = "", mail = "";
                        Cname = card.FormattedName;

                        if (card.Phones.GetFirstChoice(vCardPhoneTypes.Cellular) != null)
                        {
                            contatc = card.Phones.GetFirstChoice(vCardPhoneTypes.Cellular).FullNumber;
                        }
                        if (card.EmailAddresses.GetFirstChoice(vCardEmailAddressType.Internet) != null)
                        {
                            mail = card.EmailAddresses.GetFirstChoice(vCardEmailAddressType.Internet).Address;
                        }
                        // object[] o = { Cname, contatc, mail };
                        o[0] = Cname;
                        o[1] = contatc;
                        o[2] = mail;
                        dtcontact.Rows.Add(o);

                        GridView1.DataSource = dtcontact;
                        GridView1.DataBind();
                        divContact.Visible = true;
                    }
                }

                #endregion


            }
            catch (Exception)
            {
            }
        }
        protected void LoadContactFolder()
        {
            // LoadSiteMap(FolderName);
            LoadDtFavList();
            loadDirectory();

            #region Code to Load Files in Repeater2 except .vcf file

            string path2 = GetCurrentPath();
            DirectoryInfo d = new DirectoryInfo(Server.MapPath(@path2));
            FileInfo[] Files = d.GetFiles(); //Getting Text files
            string currentpath = d.FullName;
            string str = "", image = "", deficon = "", favicon = "", ext = "";
            favicon = "~/UserPage/images/unfav.png";
            deficon = "~/UserPage/images/fav.png";
            string icon = "";
            dt_temp.Rows.Clear();
            object[] o = new object[3];
            try
            {
                foreach (FileInfo file in Files)
                {
                    str = file.Name;
                    ext = file.Extension;
                    if (ext != ".vcf")
                    {
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
                            image = "~/UserPage/images/document-626142_640.png";
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

                        if (dticon != null && dticon.Rows.Count > 0)
                        {
                            int f = 1;
                            for (int i = 0; i < dticon.Rows.Count; i++)
                            {
                                string dtfavpath = dticon.Rows[i]["FavouriteItemPath"].ToString();
                                string itemname = dticon.Rows[i]["FavouriteItemName"].ToString();
                                if (currentpath == dtfavpath && str == itemname) { f = 0; break; }
                            }
                            if (f == 0) { icon = favicon; } else { icon = deficon; }

                            o[0] = str;
                            o[1] = image;
                            o[2] = icon;
                        }
                        else
                        {
                            o[0] = str;
                            o[1] = image;
                            o[2] = deficon;
                        }

                        dt_temp.Rows.Add(o);
                        //object[] o = { str, image,favicon };
                    }
                    Repeater2.DataSource = dt_temp;
                    Repeater2.DataBind();
                    //object[] o = { str, image };
                    //    dt_temp.Rows.Add(o);

                    //Repeater2.DataSource = dt_temp;
                    //Repeater2.DataBind();
                }
                #endregion

                #region LoadVCFFiles

                DataTable dtcontact = new DataTable();
                dtcontact.Columns.Add("Name", typeof(string));
                dtcontact.Columns.Add("Contact", typeof(string));
                dtcontact.Columns.Add("EMail", typeof(string));

                str = ""; ext = "";
                foreach (FileInfo file in Files)
                {
                    str = file.Name;
                    ext = file.Extension;
                    if (ext == ".vcf")
                    {
                        vCard card = new vCard(file.FullName);


                        string Cname, contatc = "", mail = "";
                        Cname = card.FormattedName;

                        if (card.Phones.GetFirstChoice(vCardPhoneTypes.Cellular) != null)
                        {
                            contatc = card.Phones.GetFirstChoice(vCardPhoneTypes.Cellular).FullNumber;
                        }
                        if (card.EmailAddresses.GetFirstChoice(vCardEmailAddressType.Internet) != null)
                        {
                            mail = card.EmailAddresses.GetFirstChoice(vCardEmailAddressType.Internet).Address;
                        }
                        // object[] o = { Cname, contatc, mail };
                        o[0] = Cname;
                        o[1] = contatc;
                        o[2] = mail;
                        dtcontact.Rows.Add(o);

                        GridView1.DataSource = dtcontact;
                        GridView1.DataBind();
                        divContact.Visible = true;
                    }
                }

                #endregion


            }
            catch (Exception)
            {
            }
        }
        // Move directly in the Folder Clicking on specific Link
        protected void lnkbtn_Command(object sender, CommandEventArgs e)
        {
            String FolderName = e.CommandArgument.ToString();
            dtSiteMap = (DataTable)ViewState["VSdtSiteMap"];
            int i = 0;
            while (dtSiteMap.Rows[i]["dir"].ToString() != FolderName)
            {
                i++;
            }

            int j = dtSiteMap.Rows.Count - 1;
            while (j > i)
            {
                dtSiteMap.Rows[j].Delete();
                j--;
            }
            rptbreadcrumps.DataSource = dtSiteMap;
            rptbreadcrumps.DataBind();
            loadDirectory();
            loadFiles();
        }


        //////////////////////////////////////////////////////////////////           
        //  Response.Redirect("FolderOpen1.aspx?folder=" + foldername);


        protected string GetCurrentPath()
        {
            string path2 = "~//Users//";
            dtSiteMap = (DataTable)ViewState["VSdtSiteMap"];

            for (int i = 0; i < dtSiteMap.Rows.Count; i++)
            {
                path2 = path2 + dtSiteMap.Rows[i]["dir"].ToString() + "//";
            }

            return path2;
        }

        protected int CheckRepeaterCount()
        {
            int x = 0;
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)ri.FindControl("CheckBox1");
                System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label)ri.FindControl("mylable");
                if (chk.Checked) { x++; }
            }
            foreach (RepeaterItem ri in Repeater2.Items)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)ri.FindControl("CheckBox1");
                System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label)ri.FindControl("mylable");
                if (chk.Checked) { x++; }
            }
            return x;
        }

        protected void btnextract_Click(object sender, EventArgs e)
        {

            string username = Session["id"].ToString();
            int x = CheckRepeaterCount();
            if (x <= 0)
            {
                Response.Write("<Script>alert('Select Folder to archive')</Script>");
            }
            else
            {
                foreach (RepeaterItem ri in Repeater2.Items)
                {
                    HtmlInputCheckBox chk = (HtmlInputCheckBox)ri.FindControl("CheckBox1");
                    System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label)ri.FindControl("mylable");
                    if (chk.Checked)
                    {
                        string name = lbl.Text;
                        string Path2 = GetCurrentPath();
                        DirectoryInfo d = new DirectoryInfo(Server.MapPath(@Path2));//Assuming Test is your Folder
                        FileInfo[] Files = d.GetFiles();
                        foreach (FileInfo file in Files)
                        {
                            if (file.Name == name)
                            {
                                string startPath = file.FullName;
                                string t = Path.GetDirectoryName(startPath);
                                string f = Path.GetFileNameWithoutExtension(startPath);




                                //  string extractPath = @"c:\example\extract";

                                try
                                {
                                    ZipFile.ExtractToDirectory(startPath, t + "\\" + f);
                                }
                                catch (Exception ex)
                                {
                                    Response.Write("<Script>alert('" + ex.ToString() + "');</Script>");
                                }
                            }
                        }
                    }
                }
                loadDirectory();
                loadFiles();
            }
        }

        //protected void btnfilefav_Command(object sender, CommandEventArgs e)
        //{
        //    string fav_File_Name = e.CommandArgument.ToString();
        //}

        protected void btnFav_Command1(object sender, CommandEventArgs e)
        {

            string name = e.CommandArgument.ToString();
            string path2 = GetCurrentPath();

            DirectoryInfo d = new DirectoryInfo(Server.MapPath(@path2));//Assuming Test is your Folder
            string fullpath = d.FullName;
            FileInfo[] Files = d.GetFiles();
            string type;
            FileAttributes f = File.GetAttributes(fullpath + name);
            try
            {
                if ((f & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    type = "folder";
                }
                else
                {
                    type = "file";
                }

                string qrycnt = "select Count(FavouriteItemName) from FavouriteList where UserId='" + Session["id"].ToString() + "' and FavouriteItemName='" + name + "' and FavouriteItemPath='" + fullpath + "' and ItemType='" + type + "'";
                object cnt = DAL.FunExecuteScalar(qrycnt);
                if (Convert.ToInt32(cnt.ToString()) > 0)
                {
                    string delqry = "Delete from FavouriteList where UserId='" + Session["id"].ToString() + "' and FavouriteItemName='" + name + "' and FavouriteItemPath='" + fullpath + "' and ItemType='" + type + "'";
                    int x = DAL.FunExecuteNonQuery(delqry);
                    if (x > 0)
                    {
                        Response.Write("<script>alert('Favourite removed!');</script>");
                        //ChangeIcon(Session["id"].ToString(), name, fullpath + name, type);
                    }
                }
                else
                {
                    string qry = "insert into [FavouriteList](UserId,FavouriteItemName,FavouriteItemPath,ItemType) values ('" + Session["id"].ToString() + "','" + name + "','" + fullpath + "','" + type + "')";
                    int x = DAL.FunExecuteNonQuery(qry);
                    if (x > 0)
                    {
                        Response.Write("<script>alert('Favourite added!');</script>");
                        //ChangeIcon(Session["id"].ToString(), name, fullpath + name, type);
                    }
                }
                if (path2 == "~//Users//9693495172//Contact//")
                {
                    LoadContactFolder();
                }
                else
                {
                    LoadDtFavList();
                    loadDirectory();
                    loadFiles();
                }
            }
            catch (Exception ex)
            {
                DAL.OnError(ex);
            }
            finally
            {

            }

            //foreach (RepeaterItem ri in Repeater1.Items)
            //{

            //    ImageButton btnfav = (ImageButton)ri.FindControl("btnFav");
            //    btnfav.ImageUrl = "~/UserPage/images/fav1.png";
            //}

            //string path2 = "/Users/";
            //dtSiteMap = (DataTable)ViewState["VSdtSiteMap"];

            //for (int i = 0; i < dtSiteMap.Rows.Count; i++)
            //{
            //    path2 = path2 + dtSiteMap.Rows[i]["dir"].ToString() + "/" + e.CommandArgument.ToString() + "/";
            //}

            //using (StreamWriter sw = new StreamWriter(Server.MapPath("test.txt"), append: true))
            //{
            //    sw.WriteLine(path2);
            //}

            //int x = DAL.FunExecuteNonQuery("INSERT INTO FavouriteList(UserId,FavouriteItemPath) VALUES('" + Session["id"].ToString() + "','" + path2 + "')");
            //    if (x > 0) 
            //    Response.Write("<script>alert('Fav added!');</script>");


            //        //string name = e.CommandArgument.ToString();
            //        string path2 = "/Users/";
            //        dtSiteMap = (DataTable)ViewState["VSdtSiteMap"];

            //        for (int i = 0; i < dtSiteMap.Rows.Count; i++)
            //        {
            //            path2 = path2 + dtSiteMap.Rows[i]["dir"].ToString() + "/" + e.CommandArgument.ToString() + "/";
            //        }

            //    using (StreamWriter sw = new StreamWriter(Server.MapPath("test.txt"), append: true))
            //    {
            //        sw.WriteLine(path2);
            //    }

            //    //int x = DAL.FunExecuteNonQuery("INSERT INTO FavouriteList(UserId,FavouriteItemPath) VALUES('" + Session["id"].ToString() + "','" + path2 + "')");
            //    //    if (x > 0) 
            //    //    Response.Write("<script>alert('Fav added!');</script>");

        }

        protected void ChangeIcon(string userid, string name, string fullpath, string type)
        {

        }

        protected void btnShare_Click(object sender, EventArgs e)
        {

            if (txtShare.Value != "")
            {
                lblShareError.Visible = false;
                object count = DAL.FunExecuteScalar("SELECT COUNT(UserId) FROM UserDetails WHERE UserId='" + txtShare.Value + "'");
                if (int.Parse(count.ToString()) > 0)
                {
                    string t = getpathoffile();
                    if (CheckRepeaterCount() <= 0)
                    {
                        Response.Write("<script>alert('Select a file');</script>");
                    }
                    else if (t == "|" || t == "|")
                    {
                        Response.Write("<script>alert('Folder Cannot Be Shared');</script>");
                    }
                    else
                    {
                        string[] o = t.Split('|');
                        object c = DAL.FunExecuteScalar("select count(*) From SharedFiles where SharedWith='" + txtShare.Value + "'and SharedBy='" + Session["id"].ToString() + "' and FilePath='" + o[0] + "'");
                        if (int.Parse(c.ToString()) > 0)
                        {
                            lblShareError.Visible = true;
                            lblShareError.Text = "Already Shared With " + txtShare.Value;
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                        }
                        else
                        {

                            SqlParameter[] param =
                                {
                            new SqlParameter("@SharedBy", Session["id"].ToString()),
                            new SqlParameter("@SharedWith", txtShare.Value),
                            new SqlParameter("@Date", DateTime.Now),
                            new SqlParameter("@FilleName", o[1]),
                            new SqlParameter("@FilePath", o[0]),
                        };
                            int x = DAL.FunExecuteNonQuerySP("ust_sharing", param);
                        }
                    }

                }
                else
                {
                    lblShareError.Visible = true;
                    lblShareError.Text = "MoilCloud account not found!";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                }

            }
            else
            {
                lblShareError.Visible = true;
                lblShareError.Text = "Enter MoilCloud Id";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            }
        }

        public string getpathoffile()
        {
            string filepath = "";
            string fname = "";
            string path2 = GetCurrentPath();
            //string f = Path.GetFileName(path2);
            //FileAttributes attr = File.GetAttributes(Server.MapPath(@path2));
            //if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            //{
            //    return ("folder");
            //}
            //else
            //{
            foreach (RepeaterItem ri in Repeater2.Items)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)ri.FindControl("CheckBox1");
                System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label)ri.FindControl("mylable");
                if (chk.Checked)
                {
                    string name = lbl.Text;

                    //FileAttributes attr = File.GetAttributes(@path2);
                    //if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                    //{
                    //    Response.Redirect("<script>alert('Folder Cannot Be Shared');</script>");
                    //    break;
                    //}
                    //else
                    //{

                    DirectoryInfo d = new DirectoryInfo(MapPath(@path2));
                    FileInfo[] Files = d.GetFiles();
                    foreach (FileInfo file in Files)
                    {
                        if (file.Name == name)
                        {
                            filepath = file.FullName;
                            fname = file.Name;
                        }
                    }
                    //}
                }
            }
            return filepath + "|" + fname;
            // }
        }

        protected void btnDownoad_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string ContactNo = e.CommandArgument.ToString();
                #region LoadVCFFiles

                string Path = "~//Users//" + Session["id"].ToString() + "//Contact//";
                string str = "", ext = "";
                DirectoryInfo d = new DirectoryInfo(Server.MapPath(Path));
                FileInfo[] Files = d.GetFiles(); //Getting Text files
                foreach (FileInfo file in Files)
                {
                    str = file.Name;
                    ext = file.Extension;
                    if (ext == ".vcf")
                    {
                        vCard card = new vCard(file.FullName);
                        string contact = "", contactname = "", DispName = "";
                        contactname = card.FormattedName;
                        DispName = card.Title;
                        if (card.Phones.GetFirstChoice(vCardPhoneTypes.Cellular) != null)
                        {
                            contact = card.Phones.GetFirstChoice(vCardPhoneTypes.Cellular).FullNumber;
                        }

                        if (ContactNo == contact)
                        {
                            //Code for Download Contact.
                            // Response.Write("aaa");
                            WebClient req = new WebClient();
                            HttpResponse response = HttpContext.Current.Response;
                            WebClient req1 = new WebClient();
                            HttpResponse response1 = HttpContext.Current.Response;
                            string filePath = Path + "/" + file.Name;// map;
                            response1.Clear();
                            response1.ClearContent();
                            response1.ClearHeaders();
                            response1.Buffer = true;
                            response1.AddHeader("Content-Disposition", "attachment;filename=" + file.Name);
                            byte[] data = req.DownloadData(Server.MapPath(filePath));
                            response1.BinaryWrite(data);
                            response1.End();
                        }
                    }
                }

                Response.Redirect("Dashboard.aspx?type=contact");
            }
            catch (Exception ex)
            {
                DAL.OnError(ex);
            }
            #endregion
        }

        protected void btnDel_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string ContactNo = e.CommandArgument.ToString();
                string Path = "~//Users//" + Session["id"].ToString() + "//Contact//";
                string str = "", ext = "";
                DirectoryInfo d = new DirectoryInfo(Server.MapPath(Path));
                FileInfo[] Files = d.GetFiles(); //Getting Text files
                foreach (FileInfo file in Files)
                {
                    str = file.Name;
                    ext = file.Extension;
                    if (ext == ".vcf")
                    {
                        vCard card = new vCard(file.FullName);
                        string contact = "", contactname = "", DispName = "";
                        contactname = card.FormattedName;
                        DispName = card.Title;
                        if (card.Phones.GetFirstChoice(vCardPhoneTypes.Cellular) != null)
                        {
                            contact = card.Phones.GetFirstChoice(vCardPhoneTypes.Cellular).FullNumber;
                        }

                        if (ContactNo == contact)
                        {
                            string startPath = file.FullName;
                            File.Delete(startPath);
                        }
                    }
                }

                Response.Redirect("Dashboard.aspx?type=contact");
            }
            catch (Exception ex)
            {
                DAL.OnError(ex);
            }
        }

    }
}