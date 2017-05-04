<%@ Page Title="" Language="C#" MasterPageFile="~/preInit/Activity.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="mCloud.preInit.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="col-lg-12 text-center">
        <div class="col-lg-4 text-center"></div>

        <div class="col-lg-4 text-center">
    <div class="signup-box">
        <div class="logo">
            <a href="javascript:void(0);"><b></b></a>
            <small></small>
        </div>
        <div class="card" style="margin-top: 150px;">
            <div class="body">
                <div id="sign_up" method="POST">
                    <div class="msg"><h3>Register a new membership</h3></div>
                    <div class="clearfix">&nbsp;</div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons"></i>
                        </span>
                        <div class="form-line">
                            <input type="text" class="form-control" name="namesurname" placeholder="Full Name" required autofocus>
                        </div>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons"></i>
                        </span>
                        <div class="form-line">
                            <input type="email" class="form-control" name="email" placeholder="Email Address">
                        </div>
                    </div>

                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons"></i>
                        </span>
                        <div class="form-line">
                            <input type="text" class="form-control" name="number" placeholder="Mobile No." required>
                        </div>
                    </div>

                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons"></i>
                        </span>
                        <div class="form-line">
                            <input type="password" class="form-control" name="password" minlength="6" placeholder="Password" required>
                        </div>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons"></i>
                        </span>
                        <div class="form-line">
                            <input type="password" class="form-control" name="confirm" minlength="6" placeholder="Confirm Password" required>
                        </div>
                    </div>
                    <div class="clearfix">&nbsp;</div>
                    <div class="form-group">
                        <input type="checkbox" name="terms" id="terms" class="filled-in chk-col-pink">
                        
                        <label for="terms">I read and agree to the <a href="javascript:void(0);">terms of usage</a>.</label>
                    </div>

                    <button class="btn btn-block btn-lg bg-pink waves-effect" type="submit">SIGN UP</button>

                    <div class="m-t-25 m-b--5 align-center">
                        <a href="Login.aspx">You already have a membership?</a>
                    </div>
                </div>
            </div>
        </div><div class="clearfix">&nbsp;</div><div class="clearfix">&nbsp;</div>
    </div></div>

        <div class="col-lg-4 text-center"></div>
        </div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooterScript" runat="server">
     <!-- Jquery Core Js -->
    <script src="../UserPage/plugins/jquery/jquery.min.js"></script>
    <!-- Bootstrap Core Js -->
    <script src="../UserPage/plugins/bootstrap/js/bootstrap.js"></script>

    <!-- Waves Effect Plugin Js -->
    <script src="../UserPage/plugins/node-waves/waves.js"></script>

    <!-- Validation Plugin Js -->
    <script src="../UserPage/plugins/jquery-validation/jquery.validate.js"></script>

    <!-- Custom Js -->
    <script src="../UserPage/js/admin.js"></script>
    <script src="../UserPage/js/pages/examples/sign-up.js"></script>
</asp:Content>
