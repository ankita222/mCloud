<%@ Page Title="" Language="C#" MasterPageFile="~/preInit/Activity.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="mCloud.preInit.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Login</title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
   
<div class="col-lg-12 text-center">
    <div class="col-lg-4 text-center"></div>
    <div class="col-lg-4 text-center">
        <div class="login-box">
            <div class="card" style="margin-top: 161px;">
                <div class="body">
                    <div id="sign_in" method="POST" novalidate="novalidate">
                        <div class="msg"><h2>Sign in to start your session</h2></div>
                        <div class="clearfix">&nbsp;</div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <i class="fa fa-user"></i>
                            </span>
                            <div class="form-line">
                                <input type="text" runat="server" id="txtmob" class="form-control" name="MobleNo" placeholder="Mobile No." required="" autofocus="" aria-required="true">
                            </div>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <i class="fa fa-lock"></i>
                            </span>
                            <div class="form-line">
                                <input type="password" runat="server" id="txtpass" class="form-control" name="password" placeholder="Password" required="" aria-required="true">
                            </div>
                        </div>
                        <div class="clearfix">&nbsp;</div>
                        <div class="row">
                            <div class="col-xs-8 p-t-5">
                                <input type="checkbox" name="rememberme" id="rememberme" class="filled-in chk-col-pink">
                                <label for="rememberme">Remember Me</label>
                            </div>
                            <div class="col-xs-4">
                                <button class="btn btn-block bg-pink waves-effect" type="submit" runat="server" id="btnsign" onserverclick="btnsign_ServerClick">SIGN IN</button>
                            </div>
                        </div>
                        <div class="clearfix">&nbsp;</div>
                        <div class="row m-t-15 m-b--20">
                            <div class="col-xs-6">
                                <a class="page-scroll" href="Activity.aspx" data-toggle="modal">Register Now!</a>
                            </div>
                            <div class="col-xs-6 align-right">
                                <a href="#">Forgot Password?</a>
                            </div>
                        </div>
                        <div class="clearfix">&nbsp;</div><div class="clearfix">&nbsp;</div><div class="clearfix">&nbsp;</div><div class="clearfix">&nbsp;</div><div class="clearfix">&nbsp;</div><div class="clearfix">&nbsp;</div><div class="clearfix">&nbsp;</div><div class="clearfix">&nbsp;</div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-4 text-center"></div>
</div>
        
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooterScript" runat="server">
<script src="modal/js/classie.js"></script>
<script src="modal/js/modalEffects.js"></script>
<!-- for the blur effect -->
<!-- by @derSchepp https://github.com/Schepp/CSS-Filters-Polyfill -->
<script>
    // this is important for IEs
    var polyfilter_scriptpath = '/js/';
</script>
<script src="modal/js/cssParser.js"></script>
<script src="modal/js/css-filters-polyfill.js"></script>
<script src="modal/js/css-filters-polyfill.js"></script>
</asp:Content>
