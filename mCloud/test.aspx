<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="mCloud.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
      function ShowProgressBar() {
        document.getElementById('dvProgressBar').style.visibility = 'visible';
      }

      function HideProgressBar() {
        document.getElementById('dvProgressBar').style.visibility = "hidden";
      }
    </script>
</head>
<body >
    <form id="form1" runat="server">
     <div>
  <div style="float:left;">
      <asp:Button ID="btn_createlink" runat="server" Text="Create link" OnClick="btn_createlink_Click" OnClientClick="javascript:ShowProgressBar()" />
  </div>
  <div ID="dvProgressBar" style="float:left;visibility: hidden;" >
        <br />
        <img src="Loading_icon.gif" /> resolving address, please wait...
  </div>
  <br style="clear:both" />
</div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

    </form>
</body>
</html>