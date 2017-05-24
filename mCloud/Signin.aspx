<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="mCloud.Signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign in | Moil Cloud</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <!-- Bootstrap Core CSS -->
    <link href="FrontPage/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="icon" href="favicon.png" type="image/png" sizes="16x16" />
    <!-- Plugin CSS -->
    <link href="FrontPage/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" />

    <!-- Custom Css -->
    <link href="UserPage/css/style.css" rel="stylesheet" />
</head>
<body class="login-page ls-closed" style="background: linear-gradient(45deg, #7e67e5, #02cbdf); overflow: hidden;">
    <form id="form1" runat="server">
        <div>

            <nav id="mainNav" class="navbar navbar-default navbar-fixed-top" style="background: white; margin-top: -15px;">
                <div class="container" style="background: none;">
                    <!-- Brand and toggle get grouped for better mobile display -->
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                            <span class="sr-only">Toggle navigation</span> Menu <i class="fa fa-bars"></i>
                        </button>


                        <a href="./">
                            <img src="FrontPage/img/MoilCloud Homepage logo top.png" class="img-responsive" width="150px" height="30%" alt="" style="padding-top: 10px" /></a>
                    </div>

                    <!-- Collect the nav links, forms, and other content for toggling -->
                    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                        <ul class="nav navbar-nav navbar-right" style="margin-top: 9px;">
                            <li>
                                <%--<a class="page-scroll" href="#" data-toggle="modal" data-target="#defaultModal">Sign up</a>--%>

                                <a class="md-trigger" data-modal="modal-4" href="Signup.aspx" data-toggle="modal" style="color: black; font-weight: 700;">Sign up</a>
                            </li>
                            <li>
                                <a class="page-scroll" href="Signin.aspx" style="color: black; font-weight: 700;">Sign In</a>
                            </li>
                            <li>
                                <a class="page-scroll" href="Default.aspx#features" style="font-weight: 700; color: black;">Price & Plans</a>
                            </li>
                            <li>
                                <a class="page-scroll" href="preInit/AboutUs.aspx" style="font-weight: 700; color: black;">About Us</a>
                            </li>
                            <li>
                                <a class="page-scroll" href="preInit/ContactUs.aspx" style="color: black; font-weight: 700;">Contact</a>
                            </li>
                        </ul>
                    </div>
                    <!-- /.navbar-collapse -->
                </div>
                <!-- /.container-fluid -->
            </nav>
            <div class="login-box">

                <div class="card" style="margin-top: 40%;">

                    <div class="md-content" style="padding: 0px; background: linear-gradient(70deg, #f5f5f5, #f9f9f9);">
                        <div class="modal-header" style="padding: 9px;">
                            <span style="float: left; color: #808080;" class="modal-title" id="defaultModalLabellogin">Sign in to start your session</span>

                        </div>
                        <div class="modal-body" style="margin-bottom: 0px; padding-bottom: 0px;">
                            <div class="row clearfix">
                                <div class="col-sm-12">
                                    <div class="form-group form-float">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-user"></i>
                                            </span>
                                            <div class="form-line">
                                                <input id="txtUserName" runat="server" type="text" class="form-control" required="required"  name="username" placeholder="Username (eg: 99XXXXXX99)" maxlength="10" onkeypress="return IsNumeric(event);"  />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group form-float">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-lock"></i>
                                            </span>
                                            <div class="form-line">
                                                <input id="txtPassword" runat="server" type="password" class="form-control" required="required" placeholder="Password" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group form-float">
                                        <div class="input-group">

                                            <div>
                                                <asp:CheckBox ID="CheckBoxPersist" Style="color: #555555; font-weight: normal; font-size: small;" CssClass="checkbox-inline" Checked="false" Text="Remember me" runat="server" />
                                                <span style="float:right;">
                                                 <a href="ForgotPassword.aspx" style="font-weight:normal;font-size:small;color:#555555;">Forgot Password </a>
                                                  
                                                <i class="fa fa-history"></i>
                                           
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group form-float">
                                        <div class="input-group">
                                            <div>
                                                <asp:Label ID="lblErrorMsg" Style="font-weight: normal; font-size: small; color: red;" runat="server" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="modal-footer" style="padding: 9px;">
                            <span style="float: left;"><a class="btn" href="preInit/Renew.aspx">Renew</a></span>
                            <asp:Button class="btn btn-success" runat="server" ID="btnSignIn" Style="float: right;" Text="Sign In" OnClick="btnSignIn_Click" />

                        </div>
                    </div>

                </div>
            </div>

            <footer style="background: none;">
                <div class="container" style="background: none; width: 281px;">
                    <p style="color: white; font-size: 14px;">&copy; 2017 MoilCloud. All Rights Reserved.</p>
                    <ul class="list-inline">
                        <li>
                            <a href="preInit/Disclaimer.aspx" style="color: white; font-size: 12px;">Disclaimer</a>
                        </li>
                        <li>
                            <a href="preInit/PrivacyPolicy.aspx" style="color: white; font-size: 12px;">Privacy Policy</a>
                        </li>
                        <li>
                            <a href="preInit/Terms.aspx" style="color: white; font-size: 12px;">Terms Of Use</a>
                        </li>
                    </ul>
                </div>
            </footer>

            <script src="FrontPage/vendor/jquery/jquery.min.js"></script>
            <!-- Bootstrap Core JavaScript -->
            <script src="FrontPage/vendor/bootstrap/js/bootstrap.min.js"></script>
            <script src="Validation.js"></script>

            <script>

                function IsNumeric(e) {
                    var keyCode = e.which ? e.which : e.keyCode
                    var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
                    //alert('Invalid input.');
                    return ret;
                }

            </script>

        </div>
    </form>
</body>
</html>
