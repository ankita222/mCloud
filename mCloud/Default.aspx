<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="mCloud.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<meta name="description" content="" />
<meta name="author" content="" />
<script src="../Validation.js"></script>
<title>MoilCloud - Online Storage Solution</title>

<!-- Bootstrap Core CSS -->

<link href="FrontPage/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
<!-- Custom Fonts -->
<link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet" />
<link href="https://fonts.googleapis.com/css?family=Catamaran:100,200,300,400,500,600,700,800,900" rel="stylesheet" />
<link href="https://fonts.googleapis.com/css?family=Muli" rel="stylesheet" />

<!-- Plugin CSS -->
<link rel="stylesheet" href="FrontPage/vendor/font-awesome/css/font-awesome.min.css" />
<link rel="stylesheet" href="FrontPage/vendor/simple-line-icons/css/simple-line-icons.css" />
<link rel="stylesheet" href="FrontPage/vendor/device-mockups/device-mockups.min.css" />

<!-- Theme CSS -->
<link href="FrontPage/css/new-age.min.css" rel="stylesheet" />

<!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
<!--[if lt IE 9]>
<script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
<script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->


<!--Pricing Tables -->
<link rel="stylesheet" type="text/css" href="Pricing/bootstrap/css/bootstrap.min.css" />
<link href="FrontPage/Pricing/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="FrontPage/Pricing/font-awesome/css/font-awesome.min.css" />

<script type="text/javascript" src="FrontPage/Pricing/js/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="FrontPage/Pricing/bootstrap/js/bootstrap.min.js"></script>

<link href="FrontPage/modal/css/default.css" rel="stylesheet" />
<link href="FrontPage/modal/css/default.css" rel="stylesheet" />
<link href="FrontPage/modal/css/component.css" rel="stylesheet" />

<script src="FrontPage/modal/js/modernizr.custom.js"></script>

</head>
<body id="page-top" style="overflow: visible;">
<form id="form1" runat="server">
<div>
<nav id="mainNav" class="navbar navbar-default navbar-fixed-top">
    <div class="container" style="background: none;">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                <span class="sr-only">Toggle navigation</span> Menu <i class="fa fa-bars"></i>
            </button>
            <%--<img src="img/MoilCloud Homepage logo top.png" class="navbar-brand page-scroll img-responsive" style="height:15%; width:20%; float:left;" />--%>
            <%--<a class="navbar-brand page-scroll" href="Default.aspx" style="font-size: 35px;color:#c33b3b;">Moil Cloud</a>--%>

            <a href="./"><img src="FrontPage/img/MoilCloud Homepage logo top.png" class="img-responsive" width="150px" height="30%" alt="" style="padding-top: 10px" /></a>
        </div>

        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav navbar-right" style="margin-top: 9px;">
                <li>
                    <%--<a class="page-scroll" href="#" data-toggle="modal" data-target="#defaultModal">Sign up</a>--%>

                    <a class="md-trigger" data-modal="modal-4" href="#" data-toggle="modal">Sign up</a>
                </li>
                <li>
                    <a class="page-scroll" href="FrontPage/Login.aspx">Sign In</a>
                </li>
                <li>
                    <a class="page-scroll" href="#features">Price & Plans</a>
                </li>
                <li>
                    <a class="page-scroll" href="FrontPage/Contact_Us.aspx">Contact</a>
                </li>
                <li>
                    <a class="page-scroll" href="FrontPage/About_Us.aspx">About Us</a>
                </li>
            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </div>
    <!-- /.container-fluid -->
</nav>

<header style="background: url(FrontPage/img/bg-pattern.png), linear-gradient(to left,#4e1d0d,rgba(232, 60, 61, 0.81));">
    <div class="container" style="background: none;">
        <div class="row">
            <div class="col-sm-7">
                <div class="header-content">
                    <div class="header-content-inner">
                        <img src="FrontPage/img/MOIL CLOUD.png" class="img-responsive" width="70%" alt="" />
                        <h1>All-In-One Online Cloud Storage , Easy and Secure Backups</h1>
                        <a href="#" class="btn btn-outline btn-xl page-scroll">Start Now</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-5">
                <div class="header-content">
                    <div class="device-container" style="background: none;">
                        <div class="device-mockup iphone6_plus portrait white">
                            <div class="device">
                                <div class="screen">
                                    <!-- Demo image for screen mockup, you can put an image here, some HTML, an animation, video, or anything else! -->
                                    <img src="FrontPage/img/moil_cloud1.png" class="img-responsive" alt="" />
                                </div>
                                <div class="button">
                                    <!-- You can hook the "home button" to some JavaScript events or just remove it -->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</header>

<section id="Section1" class="features" style="padding: 31px; background-color: rgba(232, 232, 232, 0.34);">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 text-center">
                <div class="section-heading" style="margin-bottom: 50px;">
                    <h2 style="color: black; font-size: 35px;">A Powerfull, Cloud Storage Accessible from Anywhere</h2>
                    <%--<p class="text-muted">Check out what you can do with this app theme!</p>--%>
                    <hr style="max-width: 1067px; border-color: #b9b7b7;" />
                </div>
            </div>
        </div>
        <div class="row">

            <div class="col-md-12">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="feature-item">
                                <i class="icon-lock text-primary" style="font-size: 50px;"></i>
                                <h3 style="color: black; font-size: 17px;">End-To-End Encryption</h3>
                                <p style="font-size: 16px;" class="text-muted">Unlike with other cloud storage providers, your data is encrypted &amp; decrypted during transfer by your client devices only and never by us.</p>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="feature-item">
                                <i class="icon-globe text-primary" style="font-size: 50px;"></i>
                                <h3 style="color: black; font-size: 17px;">Secure Global Access</h3>
                                <p style="font-size: 16px;" class="text-muted">Your data is accessible any time, from any<br /> 
                                    device, anywhere. Only you control the
                                    <br />
                                    keys to your files.</p>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="feature-item">
                                <i class="icon-user text-primary" style="font-size: 50px;"></i>
                                <h3 style="color: black; font-size: 17px;">Easy Sharing</h3>
                                <p style="font-size: 16px;" class="text-muted">Share folders with your contacts and see their<br />
                                    updates in real time. Online collaboration has<br>
                                    never been more private and secure.</p>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</section>

<section id="features" class="features" style="padding: 18px 0; background-color: #dad2d2;">
    <div class="container" style="background: none;">
        <div class="row">
            <div class="col-lg-12 text-center">
                <div class="section-heading" style="margin-bottom: 0px;">
                    <h2 style="color: black;">Take your stuff anywhere, Never loose file again</h2>
                    <p class="text-muted">Check out what plans suits your requirement</p>
                    <hr style="max-width: 1237px;" />
                </div>
            </div>
        </div>
        <%--<div class="row">
	<div class="col-md-4">
		<div class="device-container">
			<div class="device-mockup iphone6_plus portrait white">
				<div class="device">
					<div class="screen">
						<!-- Demo image for screen mockup, you can put an image here, some HTML, an animation, video, or anything else! -->
						<img src="img/demo-screen-1.jpg" class="img-responsive" alt=""> </div>
					<div class="button">
						<!-- You can hook the "home button" to some JavaScript events or just remove it -->
					</div>
				</div>
			</div>
		</div>
	</div>
	<div class="col-md-8">
		<div class="container-fluid">
			<div class="row">
				<div class="col-md-6">
					<div class="feature-item">
						<i class="icon-screen-smartphone text-primary"></i>
						<h3>Device Mockups</h3>
						<p class="text-muted">Ready to use HTML/CSS device mockups, no Photoshop required!</p>
					</div>
				</div>
				<div class="col-md-6">
					<div class="feature-item">
						<i class="icon-camera text-primary"></i>
						<h3>Flexible Use</h3>
						<p class="text-muted">Put an image, video, animation, or anything else in the screen!</p>
					</div>
				</div>
			</div>
			<div class="row">
				<div class="col-md-6">
					<div class="feature-item">
						<i class="icon-present text-primary"></i>
						<h3>Free to Use</h3>
						<p class="text-muted">As always, this theme is free to download and use for any purpose!</p>
					</div>
				</div>
				<div class="col-md-6">
					<div class="feature-item">
						<i class="icon-lock-open text-primary"></i>
						<h3>Open Source</h3>
						<p class="text-muted">Since this theme is MIT licensed, you can use it commercially!</p>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>--%>

        <div class="container" style="background: none;">
            <div class="row">
                <div class="col-md-4">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h4 class="text-center">Moil Lite Package</h4>
                        </div>
                        <div class="panel-body text-center">
                            <p class="lead" style="color: black;">
                                <strong>₹ 20 For 3 Month</strong>
                            </p>
                        </div>
                        <ul class="list-group list-group-flush text-center">
                            <li class="list-group-item" style="color: black;">
                                <strong>400 MB Storage Space</strong>
                                <span class="glyphicon glyphicon-ok pull-right"></span>
                            </li>
                            <li class="list-group-item" style="color: black;">Complete Data Security
			<span class="glyphicon glyphicon-ok pull-right"></span>
                            </li>
                            <li class="list-group-item" style="color: black;">Data Sharing With Other Users
			<span class="glyphicon glyphicon-ok pull-right"></span>
                            </li>
                            <li class="list-group-item" style="color: black;">Technical Support
			<span class="glyphicon glyphicon-ok pull-right"></span>
                            </li>
                        </ul>
                        <div class="panel-footer">
                            <a class="btn btn-lg btn-block btn-success md-trigger" data-modal="modal-4" href="#" data-toggle="modal">Purchase</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <h4 class="text-center">Moil Standard Package</h4>
                        </div>
                        <div class="panel-body text-center">
                            <p class="lead" style="color: black;">
                                <strong>₹ 50 For 3 Month</strong>
                            </p>
                        </div>
                        <ul class="list-group list-group-flush text-center">
                            <li class="list-group-item" style="color: black;">
                                <strong>1 GB Storage Space</strong>
                                <span class="glyphicon glyphicon-ok pull-right"></span>
                            </li>
                            <li class="list-group-item" style="color: black;">Complete Data Security
			<span class="glyphicon glyphicon-ok pull-right"></span>
                            </li>
                            <li class="list-group-item" style="color: black;">Data Sharing With Other Users
			<span class="glyphicon glyphicon-ok pull-right"></span>
                            </li>
                            <li class="list-group-item" style="color: black;">Technical Support
			<span class="glyphicon glyphicon-ok pull-right"></span>
                            </li>
                        </ul>
                        <div class="panel-footer">
                            <a class="btn btn-lg btn-block btn-success md-trigger" data-modal="modal-4" href="#" data-toggle="modal">Purchase</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="text-center">Moil Premium Package</h4>
                        </div>
                        <div class="panel-body text-center">
                            <p class="lead" style="color: black;">
                                <strong>₹ 100   For 3 Month</strong>
                            </p>
                        </div>
                        <ul class="list-group list-group-flush text-center">
                            <li class="list-group-item" style="color: black;">
                                <strong>2 GB Storage Space</strong>
                                <span class="glyphicon glyphicon-ok pull-right"></span>
                            </li>
                            <li class="list-group-item" style="color: black;">Complete Data Security
			<span class="glyphicon glyphicon-ok pull-right"></span>
                            </li>
                            <li class="list-group-item" style="color: black;">Data Sharing With Other Users
			<span class="glyphicon glyphicon-ok pull-right"></span>
                            </li>
                            <li class="list-group-item" style="color: black;">Technical Support
			<span class="glyphicon glyphicon-ok pull-right"></span>
                            </li>
                        </ul>
                        <div class="panel-footer">
                            <a class="btn btn-lg btn-block btn-success md-trigger" data-modal="modal-4" href="#" data-toggle="modal">Purchase</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</section>

<section class="cta" style="background-image: url(FrontPage/img/cloud-storage.jpg)">
    <div class="cta-content">
        <div class="container" style="background: none;">
            <h2>Stop waiting.<br />
                Start uploading.</h2>
            <a href="#contact" class="btn btn-outline btn-xl page-scroll">Let's Get Started!</a>
        </div>
    </div>
    <div class="overlay"></div>
</section>

<section id="contact" class="contact bg-primary">
    <div class="container" style="background: none;">
        <h2>We <i class="fa fa-heart"></i>new friends!</h2>
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
        <p style="color: white; font-size: 14px;">&copy; 2017 Techizas Infotech. All Rights Reserved.</p>
        <ul class="list-inline">
            <li>
                <a href="FrontPage/Disclaimer.aspx" style="color: white; font-size: 12px;">Disclaimer</a>
            </li>
            <li>
                <a href="FrontPage/Privacy Policy.aspx" style="color: white; font-size: 12px;">Privacy Policy</a>
            </li>
            <li>
                <a href="FrontPage/Terms Of Uses.aspx" style="color: white; font-size: 12px;">Terms Of Use</a>
            </li>
        </ul>
    </div>
</footer>

<div class="md-modal md-effect-4" id="modal-4" tabindex="-1" role="dialog" style="padding: 0px; width: 39%;">
    <div class="md-content" role="document" style="padding: 11px;">
        <div class="md-content" style="padding: 0px;">
            <div class="modal-header" style="padding: 9px;">
                <h4 class="modal-title" id="defaultModalLabel">Create Account</h4>
            </div>
            <div class="modal-body">
                <div class="row clearfix">
                    <div class="col-sm-12">
                        <div class="form-group form-float">
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="fa fa-user"></i>
                                </span>
                                <div class="form-line">
                                    <input id="txtEmail" runat="server" type="email" class="form-control" name="email" placeholder="Email Address" required />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group form-float">
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="fa fa-phone-square"></i>
                                </span>
                                <div class="form-line">
                                    <select id="IsdCode" runat="server" class="form-control">
                                        <option>+91 - India</option>
                                        <%--<option>+92 - Pakistan</option>
									<option>+93 - China</option>
									<option>+93 - Russia</option>
									<option>+94 - Bhutan</option>
									<option>+95 - America</option>
									<option>+96 - London</option>
									<option>+97 - England</option>--%>
                                    </select>
                                    <input id="txtMob" runat="server" type="text" class="form-control" placeholder="Mobile No." maxlength="10" required />
                                </div>
                            </div>
                        </div>
                    </div>


                </div>
            </div>
            <div class="modal-footer" style="padding: 9px;">
                <asp:Button type="button" class="btn btn-success" runat="server" ID="btncreate" Style="float: left;" OnClick="btncreate_ServerClick" Text="Create Account" />
                <button type="button" class="md-close" style="padding: 5px; float: right;">CLOSE</button>
            </div>
        </div>
    </div>
</div>


<!-- jQuery -->
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
