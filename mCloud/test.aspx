<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="mCloud.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="TEST"></asp:Label>
    <div>
    <input type="text" id="someID" runat="server" />
 <br />
        <br />
        <a  id="paybtn" href="#" rel="im-checkout" onclick="document.getElementById('someID').value='link2';" data-behaviour="remote" data-style="flat" data-text="Pay Now"></a>
                                    <script src="https://d2xwmjc4uy2hr5.cloudfront.net/im-embed/im-embed.min.js"></script>
      <a  runat="server" href="#" onclick="document.getElementById('someID').onserverclick=Fill();">link1</a>  
  <a href="#" onclick="document.getElementById('someID').value='link2';">link2</a>
    </div>
    </form>
</body>
</html>
