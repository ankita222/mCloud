using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using System.Security;
using System.Security.Permissions;
using mCloud.App_Code;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;

namespace mCloud
{
    public partial class sitemap : System.Web.UI.Page
    {
        mCloudAL al = new mCloudAL();
        mCloudDAL dal = new mCloudDAL();

        public object Assert { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DirectoryInfo rootInfo = new DirectoryInfo(Server.MapPath("~/FrontPage/"));
                this.PopulateTreeView(rootInfo, null);
            }
        }

        private void PopulateTreeView(DirectoryInfo dirInfo, TreeNode treeNode)
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
                    TreeView1.Nodes.Add(directoryNode);
                }
                else
                {
                    //If Child Node, add to Parent Node.
                    treeNode.ChildNodes.Add(directoryNode);
                }

                //Get all files in the Directory.
                foreach (FileInfo file in directory.GetFiles())
                {
                    //Add each file as Child Node.
                    TreeNode fileNode = new TreeNode
                    {
                        Text = file.Name,
                        Value = file.FullName,
                        Target = "_blank",
                        NavigateUrl = (new Uri(Server.MapPath("~/"))).MakeRelativeUri(new Uri(file.FullName)).ToString()
                    };
                    directoryNode.ChildNodes.Add(fileNode);
                }

                PopulateTreeView(directory, directoryNode);
            }
        }

        private void create()
        {

            XmlDocument docConfig = new XmlDocument();
            XmlNode xmlNode = docConfig.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            XmlElement rootElement = docConfig.CreateElement("HEDDERS");
            docConfig.AppendChild(rootElement);

            for (int i = 10; i < 20; i++)
            {
                XmlElement hedder = docConfig.CreateElement("HEDDER");
                docConfig.DocumentElement.PrependChild(hedder);
                docConfig.ChildNodes.Item(0).AppendChild(hedder);
                // Create <installationid> Node
                XmlElement installationElement = docConfig.CreateElement("ID");
                XmlText installationIdText = docConfig.CreateTextNode(Convert.ToString(i));
                installationElement.AppendChild(installationIdText);
                hedder.PrependChild(installationElement);
                // Create <environment> Node
                XmlElement environmentElement = docConfig.CreateElement("NAME");
                XmlText environText = docConfig.CreateTextNode("ABC" + i);
                environmentElement.AppendChild(environText);

                hedder.PrependChild(environmentElement);

            }
            //string filename = @"C:\";
            var permissionSet = new PermissionSet(PermissionState.None);
            var writePermission = new FileIOPermission(FileIOPermissionAccess.Write, @"C:\Program Files (x86)\IIS Express\sample.xml");
            permissionSet.AddPermission(writePermission);

            if (permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet))
            {

                // Save xml document to the specified folder path.
                //  string filename= @"C:\MyNewFile.xml";
                docConfig.Save("sample.xml");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // create();

            //SUBMIT_SUCCESS | 7e5bab20 - 8da9 - 1ee9 - bcc3 - 9009233e728e
            string[] SplitOTP = "SUBMIT_SUCCESS | 7e5bab20 - 8da9 - 1ee9 - bcc3 - 9009233e728e".Split('|');
            TextBox1.Text = SplitOTP[0];

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Label1.Text = al.PassHash(TextBox1.Text);
            // string[] tokens = Label1.Text.Split('-');
            //TextBox1.Text = tokens[0] + " == " + tokens[1] + " == " + tokens[2];
            // TextBox1.Text = Label1.Text.Split('-')[0];

            //TextBox1.Text = DateTime.Now.ToString() +" ___ "+ DateTime.Now.AddDays(90).ToString();

            //TextBox1.Text = al.GenId().ToString();

            //DateTime dt = DateTime.ParseExact("2017-05-13 12:33:26.310", "MMMM d, yyyy h:mm tt", null);
            //TextBox1.Text = dt.ToString();


            //string dt = "2016-04-14 00:00:00.000";
            //string[] planarray = dt.Split(' ');

            //DateTime time = DateTime.Parse(dt);
            //System.TimeSpan diffResult = time - System.DateTime.Today;
            //if (diffResult.Days >= 0F)
            //    Response.Write("IF");
            //else
            //    Response.Write("ELSE");

            Label1.Text = ConvertBytesToGigabytes(long.Parse(TextBox1.Text)).ToString();

            //  Label1.Text= ConvertGigabytesToBytes(long.Parse(TextBox1.Text)).ToString();
        }

        static double ConvertBytesToGigabytes(long bytes)
        {
            return ((bytes / 1024f) / 1024f) / 1024f;
        }

        static double ConvertGigabytesToBytes(long bytes)
        {
            return ((bytes * 1024f) * 1024f) * 1024f;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //SqlParameter[] param =
            //{
            //    new SqlParameter("@Mobile", txtMob.Text),
            //    new SqlParameter("@Email", txtEmail.Text)
            //};
            //object x0 = dal.FunExecuteScalarSP("ust_beginregcheck", param);
            //Label2.Text = x0.ToString();
            string otp = "12fg4";
            Button3.Text = al.SendOTP(txtMob.Text,
                            "MoilCloud OTP: " + otp + " OTP is confidential and not to be disclosed to anyone.");
        }

        private static long GetDirectorySize(string folderPath)
        {
            DirectoryInfo di = new DirectoryInfo(folderPath);
            return di.EnumerateFiles("*", SearchOption.AllDirectories).Sum(fi => fi.Length);
        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            Label3.Text = GetDirectorySize(Server.MapPath("~/FrontPage/")).ToString();
        }


        protected void Button5_Click(object sender, EventArgs e)
        {
            System.IO.File.Move(Server.MapPath("From.txt"), Server.MapPath("TO.txt"));
        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {


            // string[] names = new string[] { "AZara Ali", "ANuha Ali"} ;
            string s = "TEXT";
            using (StreamWriter sw = new StreamWriter(Server.MapPath("test.txt"),append:true))
            {

                //foreach (string s in names)
                //{
                    sw.WriteLine(s);
               // }
            }

            string line = "";
            using (StreamReader sr = new StreamReader(Server.MapPath("test.txt")))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Response.Write(line);
                }
            }


            //XmlWriterSettings settings = new XmlWriterSettings();
            //settings.Indent = true;
            //settings.NewLineOnAttributes = true;
            //settings.IndentChars = "\t";

            //settings.OmitXmlDeclaration = true;
            //StringBuilder sb = new StringBuilder();

            //XmlWriter writer = XmlWriter.Create(sb, settings);

            //writer.WriteStartDocument();

            //writer.WriteStartElement("FavPath");
            //writer.WriteElementString("path", "/User1/SK6Z0");
            //writer.WriteEndElement();
            //writer.WriteEndDocument();
            //writer.Flush();
            //writer.Close();

            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(Server.MapPath("FavPath.xml"), true))
            //{
            //    file.Write(sb.ToString());
            //}


            //XmlTextWriter xWriter = new XmlTextWriter(Server.MapPath("FavPath.xml"), Encoding.UTF8);


            //xWriter.WriteStartDocument();

            //xWriter.WriteStartElement("FavPath");
            //xWriter.WriteElementString("path", "/User/ZZ0");
            //xWriter.WriteEndElement();

            //xWriter.WriteEndDocument();
            //xWriter.Close();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Write(
                    "<div style='padding:80px 80px; margin:100px;'>" +
                    "<img src='img/error.png' alt='error' width = '10%' /><br>" +
                    "<h1>Oops!</h1>" +
                    "<h2>I'm afraid, something went wrong.</h2>" +
                    "<h4><a href='./'>Take me home</a></h4></div><div style='display:none;'>"
                    );
        }
    }
}