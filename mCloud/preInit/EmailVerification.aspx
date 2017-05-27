<%@ Page Title="" Language="C#" MasterPageFile="~/preInit/Activity.Master" AutoEventWireup="true" CodeBehind="EmailVerification.aspx.cs" Inherits="mCloud.preInit.EmailVerification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>MoilCloud Email Verification</title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
     <section id="Section1" class="features" style="padding: 31px;background-color: rgba(232, 232, 232, 0.34);margin-top: 61px;">
          <hr style="max-width: 100%; border-color:#b9b7b7;"/>
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <div class="section-heading" style="margin-bottom:50px;">
                        <h1 style="color:black;">
                            <asp:Label ID="lblVerifyMsg" runat="server" Text=""></asp:Label> </h1>
                        
                    </div>
                </div>
            </div>
          
    </div>
         <hr style="max-width: 100%; border-color:#b9b7b7;"/>
         <div style="margin-bottom:300px;"></div>
     </section>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooterScript" runat="server">
</asp:Content>
