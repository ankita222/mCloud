<%@ Page Title="" Language="C#" MasterPageFile="~/preInit/Activity.Master" AutoEventWireup="true" CodeBehind="Verification.aspx.cs" Inherits="mCloud.Verification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>MoilCloud Email Verification</title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
     <section id="Section1" class="features" style="padding: 31px;background-color: rgba(232, 232, 232, 0.34);margin-top: 61px;">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <div class="section-heading" style="margin-bottom:50px;">
                        <h1 style="color:black;">
                            <asp:Label ID="lblVerifyMsg" runat="server" Text=""></asp:Label> </h1>
                       

                     

                        <hr style="max-width: 100%; border-color:#b9b7b7;"/>
                    </div>
                </div>
            </div>
          
    </div></section>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooterScript" runat="server">
</asp:Content>
