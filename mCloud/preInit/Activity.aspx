<%@ Page Title="" Language="C#" MasterPageFile="~/preInit/Activity.Master" AutoEventWireup="true" CodeBehind="Activity.aspx.cs" Inherits="mCloud.preInit.WebForm1" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Complete Sign Up</title>
    <script type="text/javascript">
      function ShowProgressBar() {
        document.getElementById('dvProgressBar').style.visibility = 'visible';
      }

      function HideProgressBar() {
        document.getElementById('dvProgressBar').style.visibility = "hidden";
      }
    </script>
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
    </style>

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
<asp:ScriptManager ID="SrcripManager" runat="server"></asp:ScriptManager>
   <!-- <section id="features" class="features" style="background: url(img/bg-pattern.png), linear-gradient(to left,#4e1d0d,rgba(232, 60, 61, 0.81));">-->
		 <section id="features" class="features"  style="background: linear-gradient(45deg, #7e67e5, #02cbdf);">
		<div class="container" style="background: none;">
		   <div class="row">
				<div class="col-lg-12 col-xs-12 col-sm-12 text-left">
					<div class="section-heading" style="margin-bottom:0px;float: left;">
						<h2 style="color: #fff;font-size: 30px;font-weight: 400;line-height: 20px;">Activate Your Account</h2>
						<p class="text-muted" style="font-size: 18px;color: #fff;">Verify Number >> Select Plan >> Pay Now </p>
					</div>
				</div>
               <br />
                
			</div>
             
			

            <div class="row" runat="server" id="divverify" ><hr/>
                <div class="col-lg-3 col-xs-12 col-sm-12 text-center"></div>
                <div class="col-lg-6 col-xs-12 col-sm-12 text-center">
					<div class="section-heading" style="margin-bottom:0px;float: left;">
						<p style="color: #fff;font-weight: 400;line-height: 20px;">A verification code has been sent to your mobile number, please enter the verification code to proceed.</p>
                        <div class="clearfix">&nbsp;</div>
						<div style="display:inline-block;">
                        <input type="text" runat="server" id="txtcode" class="form-username form-control" style="height: 28px;font-size: 14px;border: 1px solid #0981e8;width: 190px;text-align:center;"/>
                             <div class="clearfix">&nbsp;</div>
                        &nbsp; <asp:Button runat="server" ID="btnverify" CssClass="btn btn-sm btn-info" Text="Verify" OnClick="btnverify_Click" />
                              &nbsp; &nbsp;     <asp:Button runat="server" ID="btnresend" CssClass="btn btn-sm btn-info" Text="Resend" OnClick="btnresend_Click"/>
                            </div>
                         <div class="clearfix">&nbsp;</div>
						<hr/>
					</div>
				</div><div class="col-lg-3 col-xs-12 col-sm-12 text-center"></div>
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
                              <div class="clearfix">&nbsp;</div>
								<div class="form-bottom" style="background:none;padding:0px;"> 
                                    <asp:Repeater runat="server" ID="rptselectplan"  >
                                        <ItemTemplate>
                                            <div class="chooseplan">
                                        <div class="col-lg-2 col-md-3 col-sm-3 col-xs-3" style="padding-right: 0px;">
                                            <div runat="server" id="divprice" >₹ <%#Eval("Price") %></div>
                                           
                                        </div>

                                          <div class="col-lg-5 col-md-4 col-sm-4 col-xs-4" style="padding-right: 0px;">
                                               <span runat="server" id="planandduration"><%#Eval("Detail") %></span>
                                        </div>

                                        
                                          <div class="col-lg-5 col-md-5 col-sm-5 col-xs-5">
                                              <asp:Button CommandArgument='<%#Eval("PlanDetails") %>' OnCommand="btnselect_Command" runat="server" ID="btnselect" CssClass="btn btn-success" Text='<%#Eval("Name") %>' Width="100%" style="padding-left: 7px;" />
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
                        
								<div class="form-bottom" style="background:none;padding: 18px 25px 30px 25px; width:100%;">
                                    <h4 runat="server" visible="false" id="h3showplan" style="border: 1px solid #f0f0f0;border-radius: 4px;color: #fff;line-height: 20px;background: #5cb85c; text-align:center; padding: 5px;" >
                                    <asp:Label ID="lblSelectedPlan" Visible="false" runat="server"></asp:Label>
                                    </h4>

                                       <%--<h4 style="border: 1px solid #f0f0f0;border-radius: 4px;color: #fff;line-height: 20px;background: #5cb85c; text-align:center; padding: 5px;" runat="server" id="h3showplan" id="h3showplan" visible="false"id="h3showplan" visible="false"id="h3showplan" visible="false"></h4>--%>

									<div role="form" action="" method="post" class="login-form">
										<div class="form-group" style="margin-bottom: 6px;">
											<label class="sr-only" for="form-username">Email</label>
											<input type="text" name="form-username" runat="server" id="txtEmail" placeholder="Email..." class="form-username form-control"  style="height: 28px;font-size: 14px;border: 1px solid #0981e8;"/>
										</div>
										
										<div class="form-group" style="margin-bottom: 6px;">
											<label class="sr-only" for="form-username">Mobile Number</label>
										<input type="text" name="form-username" runat="server" id="txtIsdCode" placeholder="ISD Code" style="height: 28px;font-size: 12px;border: 1px solid #0981e8;width:25%; float:left;padding: 9px;"/>
										<input type="text" name="form-username" runat="server" id="txtMob" placeholder="Mobile Number ..." readonly="readonly" class="form-username form-control"  style="height: 28px;font-size: 14px;border: 1px solid #0981e8; width:75%;"/>
										</div>

										<div class="form-group" style="margin-bottom: 6px;">
											<label class="sr-only" for="form-username">Name</label>
											<input type="text" name="form-username" runat="server" id="txtName" placeholder="Full Name..." class="form-username form-control"  style="height: 28px;font-size: 14px;border: 1px solid #0981e8;"/>
										</div>
                                        
                                        
										                <div class="form-group" style="margin-bottom: 6px;">
				 						
                                            <label class="sr-only" for="form-password">Password</label>
											
                                            <input type="password"  runat="server" id="txtPassword" placeholder="Password..." class="form-password form-control"  style="height: 28px;font-size: 14px;border: 1px solid #0981e8; width:50%; float:left;"/>
											<input type="password"  runat="server" id="txtCPassword" placeholder="Confirm Password..."  class="form-password form-control" onblur="return comparePassword();"  style="height: 28px; width:50%;border: 1px solid #0981e8; padding-left: 9px;font-size: 13px;padding-right: 9px;" />
                                         
										</div>
                                        <!-- Using Updatepanel on agree Checkbox-->
                                        <asp:UpdatePanel ID="UpdatePanel" runat="server">
                                        <ContentTemplate>
                                        <asp:CheckBox ID="chbxAgree" Checked="false" OnCheckedChanged="chbxAgree_CheckedChanged" AutoPostBack="true" runat="server" />
                                        
                                     <span>I agree to the Moil Cloud <a href="Terms.aspx" style="color: #555;">Terms of Use</a>  and <a href="PrivacyPolicy.aspx" style="color: #555;">Privacy Policy</a></span>
                                        <asp:Button ID="btnPay" Enabled="false" runat="server" CssClass="btn btn-block btn-default btn-lg" Text="Proceed" OnClick="btnPay_Click" OnClientClick="javascript:ShowProgressBar()" />
                         <div id="dvProgressBar" style="visibility: hidden;">
                         <img src="Loading_icon.gif" width="5%" />Loading...</div>
										<%--<button type="submit" class="" runat="server" id="btncfrm" disabled="disabled">Proceed To Pay</button>--%>
                                            <label id="lblPaymentSelect" runat="server" visible="false" style="color:red" >Please select a plan.</label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
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
                <a href="https://www.facebook.com/profile.php?id=100017338337261"><i class="fa fa-facebook"></i></a>
            </li>
            <li class="social-google-plus">
                <a href="https://plus.google.com/116086851234154634324"><i class="fa fa-google-plus"></i></a>
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


        function IsNumeric(e) {
            var keyCode = e.which ? e.which : e.keyCode
            var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
            //alert('Invalid input.');
            return ret;
        }
    </script>
	
}

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

    <script type="text/javascript">
        function comparePassword() {
            
            
            
            var pwd1 = document.getElementById("ContentPlaceHolderContent_txtPassword").value;
            var pwd2 = document.getElementById("ContentPlaceHolderContent_txtCPassword").value;
           // alert("Msg=" + pwd1 + "---" + pwd2);
           //alert("Passwords do not match!");
             if (pwd1!= pwd2) {
                 alert("Passwords do not match!");
                 ContentPlaceHolderContent_txtCPassword.value = "";
                return false;  }
            else {  return true;   }
        }
       
        </script>

</asp:Content>
