<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="mCloud.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
<meta charset="utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<meta name="description" content="" />
<meta name="author" content="" />
<!-- Bootstrap Core CSS -->
	<link href="FrontPage/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
	<link rel="icon" href="favicon.png" type="image/png" sizes="16x16" />
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
    <link href="Login/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
	<link rel="stylesheet" href="Login/assets/font-awesome/css/font-awesome.min.css"/>
	<link rel="stylesheet" href="Login/assets/css/form-elements.css"/>
	<link rel="stylesheet" href="Login/assets/css/style.css"/>

</head>
<body >
    <form id="form1" runat="server">
    <div>
        <nav id="mainNav" class="navbar navbar-default navbar-fixed-top" style="background: white;">
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

                        <a class="md-trigger" data-modal="modal-4" href="Signup.aspx" data-toggle="modal" style="color: black;font-weight:700; ">Sign up</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="Signin.aspx" style="color: black;font-weight:700;">Sign In</a>
                    </li>
                    <li>
                    <a class="page-scroll" href="Default.aspx#features" style="font-weight:700;color: black;">Price & Plans</a>
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

        <section id="features" class="features"  style="background: linear-gradient(45deg, #7e67e5, #02cbdf);">
		<div class="container" style="background: none;min-height:0px;" >
		   <div class="row">
				<div class="col-lg-12 col-xs-12 col-sm-12 text-left">
					<div class="section-heading" style="margin-bottom:0px;float: left;">
						<h2 style="color: #fff;font-size: 30px;font-weight: 400;line-height: 20px;">Reset Password</h2>
						<!--<p class="text-muted" style="font-size: 18px;color: #fff;">Verify Number >> Select Plan >> Pay Now </p>-->
					</div>
				</div>
               <br />
                
			</div>
             
			
            <div runat="server" id="divverify"  >
            <div class="row"  ><hr style="max-width:500px;"/>
                <div class="col-lg-4 col-xs-12 col-sm-12 text-center"></div>
                <div class="col-lg-6 col-xs-12 col-sm-12 text-center">
					<div class="section-heading" style="margin-bottom:0px;float: left;">
						<p style="color: #fff;font-weight: 400;line-height: 20px;">Enter Your User ID/ Mobile Number</p><br />
						<div style="display:inline-block;">
                        <input type="number" runat="server" id="txtcode" maxlength="10" class="form-username form-control" style="height: 28px;font-size: 14px; text-align:center; border: 1px solid #0981e8;width: 190px;"/><br />
                        &nbsp; <asp:Button runat="server" ID="btnnext" CssClass="btn btn-sm btn-info" Text="Next" OnClick="btnnext_Click" /><br />
                               &nbsp; <p style="color:#fdcb4d;font-weight: 400;line-height: 20px;" runat="server" id="p_warn" visible="false">This User ID Doesn't Exist</p>
                            </div>						
					       </div>

				</div>
                <div class="col-lg-4 col-xs-12 col-sm-12 text-center"></div>
            </div>
            <hr style="max-width:500px;"/>
            </div>

            <div runat="server" id="divchoose" visible="false"  >
            <div class="row" ><hr style="max-width:500px;"/>
                <div class="col-lg-5 col-xs-12 col-sm-12 text-center"></div>
                <div class="col-lg-5 col-xs-12 col-sm-12 text-center">
					<div class="section-heading" style="margin-bottom:0px;float: left;">
						<p style="color: #fff;font-weight: 400;line-height: 20px;">Send OTP To......</p>
						<div style="display:inline-block;text-align: left;" class="demo-radio-button"> 
                            <div runat="server" id="divmobile">
                            <input name="group5" runat="server" type="radio" id="rbtmobile" class="with-gap radio-col-cyan"/>
                             <label for="radio_36" runat="server" id="lblmobile">Send OTP To Mobile Number</label>
                                </div>
                            
                            <div  runat="server" id="divemail">
                            <input name="group5" runat="server" type="radio" id="rbtmail" class="with-gap radio-col-cyan"/>
                             <label for="radio_36" runat="server" id="lblmail">Send OTP To Email</label>
                            </div>
                        &nbsp;     &nbsp;     &nbsp;     &nbsp;     &nbsp;     &nbsp;     &nbsp;     &nbsp;     &nbsp;     &nbsp;     &nbsp;
                             <asp:Button runat="server" ID="btnsend" CssClass="btn btn-sm btn-info" Text="Send" OnClick="btnsend_Click"  />
                          
                            </div>						
					       </div>

				</div>
                <div class="col-lg-4 col-xs-12 col-sm-12 text-center"></div>
            </div>
            <hr style="max-width:500px;"/>
            </div>
            
           <div runat="server" id="divOTP" visible="false">
            <div class="row"><hr style="max-width:500px;"/>
                <div class="col-lg-4 col-xs-12 col-sm-12 text-center"></div>
                <div class="col-lg-5 col-xs-12 col-sm-12 text-center">
					<div class="section-heading" style="margin-bottom:0px;float: left;">
                         <p style="font-weight: 400;line-height: 20px;" >OTP has been sent to your mail/ mobile </p>
						<p style="color: #fff;font-weight: 400;line-height: 20px;">Enter OTP Below</p>
						<div style="display:inline-block;">
                        <input type="text" runat="server" id="txtotp" class="form-username form-control" style="height: 28px;font-size: 14px;border: 1px solid #0981e8;width: 190px;"/>
                        &nbsp; <asp:Button runat="server" ID="btnverify" CssClass="btn btn-sm btn-info" Text="Verify" OnClick="btnverify_Click" />
                            &nbsp; <asp:Button runat="server" ID="btnResend" CssClass="btn btn-sm btn-info" Text="Resend" OnClick="btnsend_Click" />
                               &nbsp; <p style="color:#650202;font-weight: 400;line-height: 20px;" runat="server" id="p1" visible="false">Wrong OTP</p>
                            </div>						
					       </div>
				</div>
                <div class="col-lg-4 col-xs-12 col-sm-12 text-center"></div>
            </div>
            <hr style="max-width:500px;"/>
            </div>

            <div runat="server" id="divChnage" visible="false" >
            <div class="row"><hr style="max-width:500px;"/>
                <div class="col-lg-4 col-xs-12 col-sm-12 text-center"></div>
                <div class="col-lg-4 col-xs-12 col-sm-12 text-center">
					<div class="section-heading" style="margin-bottom:0px;">
                   <div class="row clearfix">
                                    <div class="col-lg-6 col-md-2 col-sm-4 col-xs-5 form-control-label" style="padding: 0px;">
                                        <label >New Password</label>
                                    </div>
                                    <div class="col-lg-5 col-md-10 col-sm-8 col-xs-7" style="padding: 0px;">
                                        <div class="form-group">
                                            <div class="form-line">
                                                <input runat="server" type="text" id="txtnewpass" class="form-control" style="height: 29px;padding: 10px;border: none;font-size: 13px;"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>		
                        <div class="row clearfix">
                                    <div class="col-lg-6 col-md-2 col-sm-4 col-xs-5 form-control-label" style="padding: 0px;">
                                        <label>Confirm Password</label>
                                    </div>
                                    <div class="col-lg-5 col-md-10 col-sm-8 col-xs-7" style="padding: 0px;">
                                        <div class="form-group">
                                            <div class="form-line">
                                                <input runat="server" type="text" id="txtcnfrmpass" class="form-control"  style="height: 29px;padding: 10px;border: none;font-size: 13px;"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>		
                                  <div class="col-lg-offset-2 col-md-offset-2 col-sm-offset-4 col-xs-offset-5">
                                      <asp:Button runat="server" ID="btnreset" CssClass="btn btn-sm btn-info" Text="Reset Password" OnClick="btnreset_Click"/>
                                    </div>
					       </div>
				</div>
                <div class="col-lg-4 col-xs-12 col-sm-12 text-center"></div>
            </div>
            <hr style="max-width:500px;"/>
            </div>
              	
	</div>
	</section>

        <section id="contact" class="contact bg-primary">
		<div class="container" style="background: none;">
			<h2>We <i class="fa fa-heart" style="color:#3963dd"></i> new friends!</h2>
			<ul class="list-inline list-social">
				<li class="social-twitter">
					<a href="#"><i class="fa fa-twitter"></i></a>
				</li>
				<li class="social-facebook">
					<a href="#"><i class="fa fa-facebook"></i></a>
				</li>
				<li class="social-google-plus">
					<a href="#"><i class="fa fa-google-plus"></i></a>
				</li>
			</ul>
		</div>
	</section>

        <footer>
        <div class="container" style="background: none;">
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
