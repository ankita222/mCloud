<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sitemap.aspx.cs" Inherits="mCloud.sitemap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

.check {
  width: 60px;
  height: 60px;
  position: absolute;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  margin: auto;
}
.check input {
  display: none;
}
.check input:checked + .box {
  background-color: #b3ffb7;
}
.check input:checked + .box:after {
  top: 0;
}
.check .box {
  width: 100%;
  height: 100%;
  transition: all 1.1s cubic-bezier(0.19, 1, 0.22, 1);
  border: 2px solid transparent;
  background-color: #929292;
  position: relative;
  overflow: hidden;
  cursor: pointer;
  box-shadow: 0 5px rgba(0, 0, 0, 0.2);
}
.check .box:after {
  width: 50%;
  height: 20%;
  content: '';
  position: absolute;
  border-left: 7.5px solid;
  border-bottom: 7.5px solid;
  border-color: #40c540;
  transform: rotate(-45deg) translate3d(0, 0, 0);
  transform-origin: center center;
  transition: all 1.1s cubic-bezier(0.19, 1, 0.22, 1);
  left: 0;
  right: 0;
  top: 200%;
  bottom: 5%;
  margin: auto;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-bottom:600px;">
        <label class="check">
  <input type="checkbox"/>
  <div class="box"></div>
</label>
            </div>
        <br />
       Mob <asp:TextBox ID="txtMob" runat="server"></asp:TextBox>
       Email <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="SIZE" Width="74px" />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Button" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        Remote
        <a href="https://www.instamojo.com/@moilcloud/" rel="im-checkout" data-behaviour="remote" data-style="flat" data-text="Pay Now"></a>
<script src="https://d2xwmjc4uy2hr5.cloudfront.net/im-embed/im-embed.min.js"></script>


        Redirect
        <a href="https://www.instamojo.com/@moilcloud/" rel="im-checkout" data-behaviour="link" data-style="flat" data-text="Pay Now"></a>
<script src="https://d2xwmjc4uy2hr5.cloudfront.net/im-embed/im-embed.min.js"></script>
    <div>

        <a href="https://www.instamojo.com/moilcloud/moil-premium-package/" rel="im-checkout" data-behaviour="link" data-style="flat" data-text="Pay Now"></a>
<script src="https://d2xwmjc4uy2hr5.cloudfront.net/im-embed/im-embed.min.js"></script>
    <h3>
    Folder Details</h3>
<hr />

        <asp:TextBox ID="TextBox1" runat="server" Height="87px" Width="248px"></asp:TextBox><asp:Label ID="Label1" runat="server" Text="₹20 - 256974 GB - 90 Days"></asp:Label><asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
        <br />
<asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15">
    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
        NodeSpacing="0px" VerticalPadding="2px"></NodeStyle>
    <ParentNodeStyle Font-Bold="False" />
    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
        VerticalPadding="0px" />
</asp:TreeView>

        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

        <br />
        <br />
    </div>
    </form>
</body>
</html>
