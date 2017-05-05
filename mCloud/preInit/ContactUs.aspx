<%@ Page Title="" Language="C#" MasterPageFile="~/preInit/Activity.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="mCloud.preInit.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Contact Us</title>
    <style>
        body{
            overflow:hidden;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">

<section id="Section1" class="features" style="padding: 31px; background-color: rgba(232, 232, 232, 0.34); margin-top: 61px;">
<div class="container">
<div class="row">
<div class="col-lg-12 text-center">
    <div class="section-heading" style="margin-bottom: 20px;">
        <h1 style="color: black;">Get In Touch With Us! </h1>
        <div class="col-lg-12 text-center">
            <asp:Label ID="lblmsg" runat="server" Visible="false"></asp:Label>
        </div>

        <asp:Panel ID="pnldemo" Style="width: 10%;" CssClass="col-lg-4 text-center" runat="server"></asp:Panel>
        <asp:Panel ID="pnlContact" Style="width: 80%;" CssClass="col-lg-4 text-center" runat="server" GroupingText=" ">
            <div class="signup-box">
                <div class="logo">
                    <a href="javascript:void(0);"><b></b></a>
                    <small></small>
                </div>
                <div class="card" style="margin-top: 10px;">
                    <div class="body">
                        <div id="sign_up" method="POST">
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="fa fa-user" style="font-size: 18px;width: 14px;"></i>
                                </span>
                                <div class="form-line">
                                    <input type="text" class="form-control" name="namesurname" placeholder="Full Name" required autofocus/>
                                </div>
                            </div>
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="fa fa-envelope"></i>
                                </span>
                                <div class="form-line">
                                    <input type="email" class="form-control" name="email" placeholder="Email Address"/>
                                </div>
                            </div>

                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="fa fa-mobile" style="font-size: 17px;width: 14px;"></i>
                                </span>
                                <div class="form-line">
                                    <input type="text" class="form-control" name="number" placeholder="Mobile No." required />
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                               
                                <div class="form-line">
                                    <asp:TextBox ID="txtMsg" CssClass="form-control"  placeholder="Message" TextMode="MultiLine" runat="server"></asp:TextBox>
                                    <%--<textarea name="txtMsg" cols="40" placeholder="Message" required class="form-control" rows="5"></textarea>--%>
                                </div>
                            </div>

                            <asp:Button ID="btnSubmit" CssClass="btn btn-info" runat="server" Text="Submit" OnClick="btnSubmit_Click" style="border-radius: 5px;"/>


                        </div>
                    </div>
                </div>
            </div>

        </asp:Panel>
        <asp:Panel ID="pnlxdemo" Style="width: 10%;" CssClass="col-lg-4 text-center" runat="server"></asp:Panel>
    

        <%-- <hr style="max-width: 100%; border-color:#b9b7b7;"/>--%>
    </div>
</div>

<div class="row">
</div>
</div>
    </div>
</section>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooterScript" runat="server">
</asp:Content>
