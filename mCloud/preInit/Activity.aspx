﻿<%@ Page Title="" Language="C#" MasterPageFile="~/preInit/Activity.Master" AutoEventWireup="true" CodeBehind="Activity.aspx.cs" Inherits="mCloud.preInit.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Activity</title>

    <!-- Bootstrap Core CSS -->
	<link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
	
	<!-- Custom Fonts -->
	<link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet"/>
	<link href="https://fonts.googleapis.com/css?family=Catamaran:100,200,300,400,500,600,700,800,900" rel="stylesheet"/>
	<link href="https://fonts.googleapis.com/css?family=Muli" rel="stylesheet"/>

	<!-- Plugin CSS -->

    <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" />	
    <link href="vendor/simple-line-icons/css/simple-line-icons.css" rel="stylesheet" />
    <link href="vendor/device-mockups/device-mockups.min.css" rel="stylesheet" />

	<!-- Theme CSS -->

    <link href="css/new-age.min.css" rel="stylesheet" />
	<!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
	<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
	<!--[if lt IE 9]>
		<script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
		<script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
	<![endif]-->


  <!--Login Part-->
	  <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500"/>
    <link href="../Login/assets/bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Login/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
		<link rel="stylesheet" href="../Login/assets/font-awesome/css/font-awesome.min.css"/>
		<link rel="stylesheet" href="../Login/assets/css/form-elements.css"/>
		<link rel="stylesheet" href="../Login/assets/css/style.css"/>
    <link href="modal/css/default.css" rel="stylesheet" />
	
	<link href="modal/css/component.css" rel="stylesheet" />
		
	<script src="modal/js/modernizr.custom.js"></script>


    <style>
        .chooseplan
        {
            box-shadow: 2px 2px 2px 2px rgba(78, 7, 7, 0.27);
            border-top-left-radius: 29px;
            border-bottom-left-radius: 28px;
            padding-top: 10px;
            color: black;
            font-weight: 700;
            height:57px;
            background: rgb(234, 243, 231);  /* fallback for old browsers */
           
        }
        .selectedplan {
            color: #fff;
            line-height: 25px;
            font-weight: 700;
            background: rgba(67, 156, 67, 0.76);
            padding: 5px;
            text-align: center;
        }
    </style>

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
 
   <!-- <section id="features" class="features" style="background: url(img/bg-pattern.png), linear-gradient(to left,#4e1d0d,rgba(232, 60, 61, 0.81));">-->
		 <section id="features" class="features"  style="background: linear-gradient(45deg, #7e67e5, #02cbdf);">
		<div class="container" style="background: none;">
		   <div class="row">
				<div class="col-lg-12 text-center">
					<div class="section-heading" style="margin-bottom:0px;float: left;">
						<h2 style="color: #fff;font-size: 30px;font-weight: 400;line-height: 20px;">Activate Your Account</h2>
						<p class="text-muted" style="font-size: 18px;color: #fff;">Never Loose Your Stuffs Again ! </p>
						<hr/>
					</div>
				</div>
			</div>
			 

            <div class="row" runat="server" id="divverify" >
                <div class="col-lg-12 text-center">
					<div class="section-heading" style="margin-bottom:0px;float: left;">
						<p style="color: #fff;font-weight: 400;line-height: 20px;">A verification code has been sent to your email account, please enter the verification code and verify to procees</p>
						<div style="display:inline-flex;">
                        <input type="text" runat="server" id="txtcode" class="form-username form-control" style="height: 28px;font-size: 14px;border: 1px solid #0981e8;width: 190px;"/>
                        &nbsp; <asp:Button runat="server" ID="btnverify" CssClass="btn btn-sm btn-info" Text="Verify" OnClick="btnverify_Click" />
                              &nbsp; &nbsp;     <asp:Button runat="server" ID="btnresend" CssClass="btn btn-sm btn-info" Text="Resend" OnClick="btnresend_Click"/>
                            </div>
						<hr/>
					</div>
				</div>
            </div>

           
              	<div class="row" id="divregister" style="padding: 23px; background-size:cover;background:rgba(226, 226, 226, 0.28);" runat="server" visible="false">
                      <div class="col-lg-6">
                          <div class="form-box" style="margin-top:0px;">
								<!--<div class="form-top" style="height: 54px;background: rgba(210, 91, 91, 0.72);">
									<div class="form-top-left" style="padding-top: 11px;">
										<h3 style="color: #fff;line-height: 20px;">Choose Plans</h3>
									</div>
									
								</div>-->
                           
                              <h3 style="color: #fff;line-height: 20px;font-weight: 700;">Choose Plan </h3>
								<div class="form-bottom" style="background:none;padding:0px;"> 
                                    <asp:Repeater runat="server" ID="rptselectplan"  >
                                        <ItemTemplate>
                                            <div class="chooseplan">
                                        <div class="col-lg-2 col-md-3 col-sm-3 col-xs-3" style="padding-right: 0px;">
                                            <div runat="server" id="divprice" >₹: <%#Eval("Amount") %></div>
                                           
                                        </div>

                                          <div class="col-lg-5 col-md-4 col-sm-4 col-xs-4" style="padding-right: 0px;">
                                               <span runat="server" id="planandduration"><%#Eval("Detail") %></span>
                                        </div>

                                          <div class="col-lg-5 col-md-5 col-sm-5 col-xs-5">
                                              <asp:Button CommandArgument='<%#Eval("Detail") %>' OnCommand="btnselect_Command" runat="server" ID="btnselect" CssClass="btn btn-success" Text="Select" Width="100%" style="padding-left: 7px;" />
                                        </div>

									</div>
                                         <div style="height:9px;"></div>
                                        </ItemTemplate>
                                    </asp:Repeater>
									
								</div>
                                      
							</div>

                      </div>

                 <div class="col-sm-6">
                    <div class="form-box" style="margin-top:0px;">
								<!--<div class="form-top" style="height: 54px;background: rgba(210, 91, 91, 0.72);">
									<div class="form-top-left" style="padding-top: 11px;">
										<h3 style="color: #fff;line-height: 20px;">Account Information</h3>
										
									</div>
									
								</div>-->
                        <h3 style="color: #fff;line-height: 20px;font-weight: 700;">Account Information</h3>
                        
								<div class="form-bottom" style="background:none;padding: 18px 25px 30px 25px;"> 
                                       <h3 class="selectedplan" runat="server" id="h3showplan" visible="false"></h3>
									<div role="form" action="" method="post" class="login-form">
										<div class="form-group" style="margin-bottom: 6px;">
											<label class="sr-only" for="form-username">Email</label>
											<input type="text" name="form-username" runat="server" id="Text1" placeholder="Email..." class="form-username form-control"  style="height: 28px;font-size: 14px;border: 1px solid #0981e8;"/>
										</div>
										
										<div class="form-group" style="margin-bottom: 6px;">
											<label class="sr-only" for="form-username">Mobile Number</label>
										<input type="text" name="form-username" runat="server" id="Text2" placeholder="ISD Code" style="height: 28px;font-size: 12px;border: 1px solid #0981e8;width:25%; float:left;padding: 9px;"/>
										<input type="text" name="form-username" runat="server" id="Text3" placeholder="Mobile Number ..." class="form-username form-control"  style="height: 28px;font-size: 14px;border: 1px solid #0981e8; width:75%;"/>
										</div>

										<div class="form-group" style="margin-bottom: 6px;">
											<label class="sr-only" for="form-username">Name</label>
											<input type="text" name="form-username" runat="server" id="Text4" placeholder="First Name..." class="form-username form-control"  style="height: 28px;font-size: 14px;border: 1px solid #0981e8;"/>
										</div>
										<div class="form-group" style="margin-bottom: 6px;">
											<label class="sr-only" for="form-password">Password</label>
											<input type="password"  runat="server" id="Password1" placeholder="Password..." class="form-password form-control"  style="height: 28px;font-size: 14px;border: 1px solid #0981e8; width:49%; float:left;"/>
											<input type="password"  runat="server" id="Password2" placeholder="Confirm Password..." class="form-password form-control"  style="height: 28px; width:49%;border: 1px solid #0981e8; padding-left: 9px;font-size: 13px;padding-right: 9px;" />
										</div>
                                     <input type="checkbox" id="chk" />&nbsp; <span>I agree to the Moil Cloud <a href="Terms.aspx" style="color: #1200ff;">Terms of Use</a>  and <a href="PrivacyPolicy.aspx" style="color: #1200ff;">Privacy Policy</a></span> 
										<button type="submit" class="btn" runat="server" id="btncfrm" disabled="disabled" style="    background: #31b159;color: #fff;" onserverclick="btncfrm_ServerClick">Proceed To Pay</button>
									</div>
								</div>
							</div>
                </div>
        </div>
	</div>
	</section>

    <section id="contact" class="contact bg-primary">
		<div class="container" style="background: none;">
			<h2>We <i class="fa fa-heart"></i> new friends!</h2>
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooterScript" runat="server">

     <script type="text/javascript">
       var checker = document.getElementById('chk');
        var sendbtn = document.getElementById('ContentPlaceHolderContent_btncfrm');
         checker.onchange = function() {
          
          sendbtn.removeAttribute('disabled')
           
        };

     </script>
     <!-- Javascript -->
		<script src="../Login/assets/js/jquery-1.11.1.min.js"></script>
		<script src="../Login/assets/bootstrap/js/bootstrap.min.js"></script>
		<script src="../Login/assets/js/scripts.js"></script>
	
		<!--[if lt IE 10]>
			<script src="assets/js/placeholder.js"></script>
		<![endif]-->

    <script type="text/javascript">
        function openModal()
        {
            alert("eeeee");
            $("#modal-4").modal({ backdrop: true });
        }

    </script>
	
		<script src="modal/js/classie.js"></script>
	<%--<script src="modal/js/modalEffects.js"></script>--%>
		<!-- for the blur effect -->
		<!-- by @derSchepp https://github.com/Schepp/CSS-Filters-Polyfill -->
		<script>
			// this is important for IEs
			var polyfilter_scriptpath = '/js/';
		</script>
	<script src="modal/js/cssParser.js"></script>
		<script src="js/css-filters-polyfill.js"></script>
	<script src="modal/js/css-filters-polyfill.js"></script>
     <script src="//getbootstrap.com/2.3.2/assets/js/bootstrap-modal.js"></script>

</asp:Content>
