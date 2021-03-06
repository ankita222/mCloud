﻿<%@ Page Title="" Language="C#" MasterPageFile="~/preInit/Activity.Master" AutoEventWireup="true" CodeBehind="Pay.aspx.cs" Inherits="mCloud.preInit.Pay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Pay Now</title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <section>
        <div style="background: linear-gradient(45deg, #7e67e5, #02cbdf);width:100%;">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-left">
                    <div class="section-heading" style="margin-bottom: 0px; float: left;">
                        <h2 style="color: #fff; font-size: 30px; font-weight: 400; line-height: 20px;">Make payment</h2>
                        <p class="text-muted" style="font-size: 18px; color: #fff;">Review Order >> Pay Now</p>
                    </div>
                </div>
                <br />
            </div>

            <div class="row" runat="server" id="divverify">
                <hr />
                <div class="col-lg-12 text-center">
                    <div style="display: inline-flex; width: 50%;">
                        <table class="table table-responsive table-bordered" style="background-color: #f9f7fc;">
                            <tr>
                                <td>Name
                                </td>
                                <td>
                                    <asp:Label ID="lblName" runat="server" Text="User Name"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Mobile
                                </td>
                                <td>
                                    <asp:Label ID="lblMob" runat="server" Text="Mobile"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Description
                                </td>
                                <td>
                                   <asp:Label ID="lblpalDescription" runat="server" Text="----"></asp:Label>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td>Amount
                                </td>
                                <td>
                                    ₹<asp:Label ID="lblAmount" runat="server" Text="0.0"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style=" text-align:right;">
                                    <a runat="server" id="paybtn" href="#" rel="im-checkout" data-behaviour="remote" data-style="flat" data-text="Pay Now"></a>
                                    <script src="https://d2xwmjc4uy2hr5.cloudfront.net/im-embed/im-embed.min.js"></script>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <hr />
                </div>
            </div>
        </div>
        </div>
    </section>
</asp:Content>


