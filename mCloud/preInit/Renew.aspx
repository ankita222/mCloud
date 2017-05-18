<%@ Page Title="" Language="C#" MasterPageFile="~/preInit/Activity.Master" AutoEventWireup="true" CodeBehind="Renew.aspx.cs" Inherits="mCloud.preInit.Renew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Renew Plan</title>

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
    <link href="Login/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
		<link rel="stylesheet" href="../Login/assets/font-awesome/css/font-awesome.min.css"/>
		<link rel="stylesheet" href="../Login/assets/css/form-elements.css"/>
		<link rel="stylesheet" href="../Login/assets/css/style.css"/>
    <link href="modal/css/default.css" rel="stylesheet" />
	
	<link href="modal/css/component.css" rel="stylesheet" />
		
	<script src="modal/js/modernizr.custom.js"></script>
    <link href="../Login/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
  <section id="features" class="features"  style="background: linear-gradient(45deg, #7e67e5, #02cbdf);">
		<div class="container" style="background: none;">
		   <div class="row">
				<div class="col-lg-12 col-xs-12 col-sm-12 text-left">
					<div class="section-heading" style="margin-bottom:0px;float: left;">
						<h2 style="color: #fff;font-size: 30px;font-weight: 400;line-height: 20px;">Renew Your Plan</h2>
						<p class="text-muted" style="font-size: 18px;color: #fff;">Verify Number >> Select Plan >> Pay Now </p>
					</div>
				</div>
               <br />
                
			</div>
             
			

            <div class="row" runat="server" id="divverify"  ><hr/>
                <div class="col-lg-5 col-xs-12 col-sm-12 text-center"></div>
                <div class="col-lg-6 col-xs-12 col-sm-12 text-center">
					<div class="section-heading" style="margin-bottom:0px;float: left;">
						<p style="color: #fff;font-weight: 400;line-height: 20px;">Enter Your UserId</p>
                        
						<div style="display:inline-block;">
                        <input type="text" runat="server" id="txtcode" class="form-username form-control" style="height: 28px;font-size: 14px;border: 1px solid #0981e8;width: 190px;"/>
                           
                        &nbsp; <asp:Button runat="server" ID="btnverify" CssClass="btn btn-sm btn-info" Text="Verify" OnClick="btnverify_Click" />
                              &nbsp; &nbsp;     <asp:Button runat="server" ID="btnresend" CssClass="btn btn-sm btn-info" Text="Resend" />
                            </div>
                      
						<hr/>
					</div>
				</div><div class="col-lg-1 col-xs-12 col-sm-12 text-center"></div>
            </div>
            
           
              	  <div class="row" runat="server" id="divselectplan" visible="false">
                <hr />
                <div class="col-lg-12 text-center">
                    <div style="display: inline-flex; width: 50%;">
                        <table class="table table-responsive table-bordered" style="background-color: #f9f7fc;">
                            <tr>
                                <td>Plan Name
                                </td>
                                <td>
                                    <asp:Label ID="lblName" runat="server" Text="User Name"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Space
                                </td>
                                <td>
                                    <asp:Label ID="lblspace" runat="server" Text="Mobile"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Validity
                                </td>
                                <td>
                                   <asp:Label ID="lbldes" runat="server" Text="----"></asp:Label>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td>Price
                                </td>
                                <td>
                                    ₹<asp:Label ID="lblprice" runat="server" Text="0.0"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="btnrenew" CssClass="btn btn-sm btn-info" Text="Renew"  />
                                
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnupgrade" CssClass="btn btn-sm btn-info" Text="Upgrade" OnClick="btnupgrade_Click" />
                                    <asp:DropDownList ID="ddlupgrade" runat="server" Visible="false"></asp:DropDownList>
                                    <asp:Button runat="server" ID="btnpaynow" CssClass="btn btn-sm btn-info" Text="Pay Now"  Visible="false" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <hr />
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
