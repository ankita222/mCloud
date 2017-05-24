<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS.aspx.cs" Inherits="mCloud.SMS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 26px;
        }
    </style>
</head>
<body style="padding:50px; margin:20px; background-color:#f3ecec;">
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>Mobile No</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" required="required" Width="500px" Height="30px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Message</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" required="required" Height="60px" Width="499px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style2">
                    <asp:Button ID="Button1" runat="server" BackColor="#0099FF" BorderStyle="None" ForeColor="White" OnClick="Button1_Click" Text="Send" Width="505px" Height="35px" Font-Bold="True" Font-Names="Above DEMO" Font-Size="Large" style="cursor:pointer;" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
