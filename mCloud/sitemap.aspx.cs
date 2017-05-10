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

namespace mCloud
{
    public partial class sitemap : System.Web.UI.Page
    {
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
            create();
        }
    }
}