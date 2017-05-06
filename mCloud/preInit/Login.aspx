<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="mCloud.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="UTF-8"/>
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>

     <script type="text/javascript">
         function openModal() {
          alert("Invalid Login");
           //  $("#MyModal").modal({ backdrop: true });
         }
    </script>
    <title>Login| Moil Cloud</title>
    <!-- Favicon-->
    <link rel="icon" href="../../favicon.ico" type="image/x-icon"/>

    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,700&subset=latin,cyrillic-ext" rel="stylesheet" type="text/css"/>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" type="text/css"/>

    <!-- Bootstrap Core Css -->
    
    <link href="../UserPage/plugins/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <!-- Waves Effect Css -->
    <link href="../UserPage/plugins/node-waves/waves.css" rel="stylesheet" />

    <!-- Animation Css -->
    <link href="../UserPage/plugins/animate-css/animate.css" rel="stylesheet" />

    <!-- Custom Css -->
    <link href="../UserPage/css/style.css" rel="stylesheet"/>


    <link href="modal/css/default.css" rel="stylesheet" />
	
	<link href="modal/css/component.css" rel="stylesheet" />
		
	<script src="modal/js/modernizr.custom.js"></script>

</head>
<body  class="login-page ls-closed"  style="background: linear-gradient(45deg, #7e67e5, #02cbdf);">
    <form id="form1" runat="server">
    <div>
     <nav id="mainNav" class="navbar navbar-default navbar-fixed-top affix-top">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span> Menu <i class="fa fa-bars"></i>
                </button>
               <img src="img/MoilCloud Homepage logo top.png" class="img-responsive" width="150px" height=30%" alt="" style="padding-top:10px"/>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
             <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right" style="margin-top: 9px;">
                    <li>
                        <%--<a class="page-scroll" href="#" data-toggle="modal" data-target="#defaultModal">Sign up</a>--%>

                        <a class="md-trigger" data-modal="modal-4" href="../Default.aspx" data-toggle="modal" style="color: black;font-weight:700; ">Sign up</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="Login.aspx" style="color: black;font-weight:700;">Sign In</a>
                    </li>
                    <li>
                    <a class="page-scroll" href="../Default.aspx" style="font-weight:700;color: black;">Price & Plans</a>
                </li>
                <li>
                    <a class="page-scroll" href="ContactUs.aspx" style="font-weight:700;color: black;">Contact</a>
                </li>
                    <li>
                    <a class="page-scroll" href="AboutUs.aspx" style="font-weight:700;color: black;">About Us</a>
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
                    <div class="msg">Sign in to start your session</div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">phone</i>
                        </span>
                        <div class="form-line">
                            <input type="text" runat="server" id="txtmob" class="form-control" name="MobleNo" placeholder="Mobile No." required="" autofocus="" aria-required="true">
                        </div>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">lock</i>
                        </span>
                        <div class="form-line">
                            <input type="password" runat="server" id="txtpass" class="form-control" name="password" placeholder="Password" required="" aria-required="true">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-8 p-t-5">
                            <input type="checkbox" name="rememberme" id="rememberme" class="filled-in chk-col-pink">
                            <label for="rememberme">Remember Me</label>
                        </div>
                        <div class="col-xs-4">
                            <button class="btn btn-block bg-pink waves-effect" type="submit" runat="server" id="btnsign">SIGN IN</button>
                        </div>
                    </div>
                    <div class="row m-t-15 m-b--20">
                        <div class="col-xs-6">
                            <a class="page-scroll" href="Activity.aspx" data-toggle="modal" >Register Now!</a>
                        </div>
                        <div class="col-xs-6 align-right">
                            <a  href="#" >Forgot Password?</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

        <footer>
        <div class="container" style="background: none;">
            <p style="color: white; font-size: 14px;">&copy; 2017 MoilCloud. All Rights Reserved.</p>
            <ul class="list-inline">
                <li>
                    <a href="Disclaimer.aspx" style="color: white; font-size: 12px;">Disclaimer</a>
                </li>
                <li>
                    <a href="PrivacyPolicy.aspx" style="color: white; font-size: 12px;">Privacy Policy</a>
                </li>
                <li>
                    <a href="Terms.aspx" style="color: white; font-size: 12px;">Terms Of Use</a>
                </li>
            </ul>
        </div>
    </footer> 


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

       
    </div>
    </form>
</body>
</html>
