<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RefSignUp.aspx.cs" Inherits="mCloud.RefSignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign up | Moil Cloud</title>

    <meta charset="utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<meta name="description" content="" />
<meta name="author" content="" />
<!-- Bootstrap Core CSS -->
	<link href="FrontPage/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
	
	<!-- Custom Fonts -->
	<link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet"/>
	<link href="https://fonts.googleapis.com/css?family=Catamaran:100,200,300,400,500,600,700,800,900" rel="stylesheet"/>
	<link href="https://fonts.googleapis.com/css?family=Muli" rel="stylesheet"/>

	<!-- Plugin CSS -->
    <link href="FrontPage/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="FrontPage/vendor/simple-line-icons/css/simple-line-icons.css" rel="stylesheet" />
    <link href="FrontPage/vendor/device-mockups/device-mockups.min.css" rel="stylesheet" />

	<!-- Theme CSS -->

    <link href="css/new-age.min.css" rel="stylesheet" />
    <link href="FrontPage/css/new-age.min.css" rel="stylesheet" />
	<!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
	<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
	<!--[if lt IE 9]>
		<script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
		<script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
	<![endif]-->
  <!--Login Part-->
	<link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500"/>
    <link href="Login/assets/bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Login/assets/bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Login/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
	<link rel="stylesheet" href="Login/assets/font-awesome/css/font-awesome.min.css"/>
	<link rel="stylesheet" href="Login/assets/css/form-elements.css"/>
	<link rel="stylesheet" href="Login/assets/css/style.css"/>
    <link href="modal/css/default.css" rel="stylesheet" />
    <link href="FrontPage/modal/css/default.css" rel="stylesheet" />
	<link href="FrontPage/modal/css/component.css" rel="stylesheet" />

	<script src="FrontPage/modal/js/modernizr.custom.js"></script>
    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,700&subset=latin,cyrillic-ext" rel="stylesheet" type="text/css"/>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" type="text/css"/>

    <!-- Bootstrap Core Css -->
    
    <link href="UserPage/plugins/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <!-- Waves Effect Css -->
    <link href="UserPage/plugins/node-waves/waves.css" rel="stylesheet" />

    <!-- Animation Css -->    
    <link href="UserPage/plugins/animate-css/animate.css" rel="stylesheet" />
    <!-- Custom Css -->
    <link href="UserPage/css/style.css" rel="stylesheet"/>
</head>
<body  class="login-page ls-closed" style="background: linear-gradient(45deg, #7e67e5, #02cbdf);overflow: hidden;">
    <form id="form1" runat="server">
    <div>
    
         <nav id="mainNav" class="navbar navbar-default navbar-fixed-top" style="background: white;margin-top: -15px;">
         <div class="container" style="background: none;">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span> Menu <i class="fa fa-bars"></i>
                </button>


               <a href="./"> <img src="FrontPage/img/MoilCloud Homepage logo top.png" class="img-responsive" width="150px" height="30%" alt="" style="padding-top: 10px" /></a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right" style="margin-top: 9px;">
                    <li>
                        <%--<a class="page-scroll" href="#" data-toggle="modal" data-target="#defaultModal">Sign up</a>--%>

                        <a class="md-trigger" data-modal="modal-4" href="Default.aspx" data-toggle="modal" style="color: black;font-weight:700; ">Sign up</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="Default.aspx" style="color: black;font-weight:700;">Sign In</a>
                    </li>
                    <li>
                    <a class="page-scroll" href="Default.aspx" style="font-weight:700;color: black;">Price & Plans</a>
                </li>
                <li>
                    <a class="page-scroll" href="preInit/AboutUs.aspx" style="font-weight:700;color: black;">About Us</a>
                </li>
                    <li>
                        <a class="page-scroll" href="preInit/ContactUs.aspx" style="color: black;font-weight:700;">Contact</a>
                    </li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </nav>
            
   <div class="login-box">
        <div class="logo">
            <a href="javascript:void(0);"><b></b></a>
            <small></small>
        </div>
        <div class="card" style="margin-top: 161px;">

            <div class="body">
                <div id="sign_in" method="POST" novalidate="novalidate">
                    <div class="msg" style="margin-bottom: 13px;font-size: 24px;">Create Account</div>
                    <div class="input-group">
                        <span class="input-group-addon"  style="padding: 6px;background: rgba(130, 128, 126, 0.2);border: 1px solid #cec5c5;">
                            <i class="fa fa-user"></i>
                        </span>
                        <div class="form-line">
                            <input runat="server" id="txtEmail" class="form-control" name="MobleNo" placeholder="Email Address" required="required" style="font-size: 14px;border: 1px solid rgba(128, 128, 128, 0.38);margin-bottom: -7px;padding: 5px;"/>
                        </div>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon" style="padding: 6px;background: rgba(130, 128, 126, 0.2);border: 1px solid #cec5c5;">
                                    <i class="fa fa-phone-square"></i>
                                </span>
                        <div class="form-line">
                               <asp:DropDownList ID="ddlIsdCode" runat="server" CssClass="form-control" style="border: 1px solid rgba(128, 128, 128, 0.53);">
                                        <asp:ListItem>+91 - India</asp:ListItem>
                                        <asp:ListItem>Others</asp:ListItem>
                                    </asp:DropDownList>
                            <input runat="server" id="txtMob" class="form-control" name="password" type="password" placeholder="Mobile No." required="" aria-required="true" maxlength="10" style="font-size: 14px;border: 1px solid rgba(128, 128, 128, 0.38);margin-bottom: -7px;padding: 5px;"/>
                        </div>
                    </div>

                      <div class="input-group">
                        <span class="input-group-addon" style="padding: 6px;background: rgba(130, 128, 126, 0.2);border: 1px solid #cec5c5;">
                                    <i class="fa fa-bookmark"></i>
                                </span>
                        <div class="form-line">
                            
                            <input type="text" runat="server" id="txtRefCode" class="form-control" name="password" placeholder="Refernce Code"  aria-required="true" maxlength="10" style="font-size: 14px;border: 1px solid rgba(128, 128, 128, 0.38);margin-bottom: -7px;padding: 5px;"/>
                        </div>
                    </div>
                </div>
            </div>

                <div class="modal-footer" style="padding: 9px;">
                <asp:Button class="btn btn-success" runat="server" ID="btnSignUp" Style="float: right;" Text="Sign Up" OnClick="btnSignUp_Click" />

            </div>
        </div>
    </div>

        <footer style="background: none;">
        <div class="container" style="background: none;width: 281px;">
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
<!-- Plugin JavaScript -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.3/jquery.easing.min.js"></script>
<!-- Theme JavaScript -->
<script src="FrontPage/js/new-age.min.js"></script>
<script src="FrontPage/modal/js/classie.js"></script>
<script src="FrontPage/modal/js/modalEffects.js"></script>
<!-- for the blur effect -->
<!-- by @derSchepp https://github.com/Schepp/CSS-Filters-Polyfill -->
<script>
    // this is important for IEs
    var polyfilter_scriptpath = '/js/';
</script>
<script src="FrontPage/modal/js/cssParser.js"></script>
<script src="FrontPage/js/css-filters-polyfill.js"></script>
<script src="FrontPage/modal/js/css-filters-polyfill.js"></script>


    </div>
    </form>
</body>
</html>
