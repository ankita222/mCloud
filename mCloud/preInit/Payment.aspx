<%@ Page Title="" Language="C#" MasterPageFile="~/preInit/Activity.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="mCloud.preInit.Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Payment</title>
<script type="text/javascript">
function CheckControls() {
//var email = document.getElementById("txtemail").value;
//var mobile = document.getElementById("txtmobile").value;
//var frst = document.getElementById("txtfrst").value;
//var postalcode = document.getElementById("txtpostalcode").value;
var confmpswd = document.getElementById("txtconfmpswd").value;
var pass = document.getElementById("txtpass").value;

//alert(pass + "-" + confmpswd);
if (pass != confmpswd) {
//alert("Confirm password mismatch.");

$("#defaultModal").slideDown(1500);

return false
}
return true;
}

function CloseModal() {
$("#defaultModal").hide();

}
</script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
<section id="features" class="features" style="background: url(img/bg-pattern.png), linear-gradient(to left,#3e597b,rgb(51, 190, 195));">
<div class="container">
<div class="row">
<div class="col-lg-12 text-center">
<div class="section-heading" style="margin-bottom: 0px;">
<h2 style="color: #fff; font-size: 41px; font-weight: 400;">Activate Your Account</h2>
<p class="text-muted" style="font-size: 22px; color: #fff;">Never Loose Your Stuffs Again ! </p>
<hr />
</div>
</div>
</div>
<%--<div class="row">
<h3>Personal Information</h3>
<div class="col-md-4">
<div class="form-group form-float">
			<div class="input-group">
			<span class="input-group-addon">
				<i class="fa fa-user"></i>
			</span>
			<div class="form-line">
				<input type="text" class="form-control date" placeholder="Email Address">
			</div>
		</div>
		</div>
					
<div class="form-group form-float">
	<div class="input-group">
		<span class="input-group-addon">
				<i class="fa fa-user"></i>
			</span>
			<div class="form-line">
				<input type="text" class="form-control date" placeholder="Confirm Email Address">
			</div>
		</div>
		</div>
						 
		<div class="form-group form-float">
			<div class="input-group">
			<span class="input-group-addon">
				<i class="fa fa-lock"></i>
			</span>
			<div class="form-line">
				<input type="text" class="form-control date" placeholder="Password">
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

<div class="row">
<div class="col-sm-5">
<div class="form-box">
<div class="form-top" style="height: 77px;">
<div class="form-top-left">
    <h3>Account Information</h3>

</div>

</div>
<div class="form-bottom">
<div role="form" action="" method="post" class="login-form">
    <div class="form-group">
        <label class="sr-only" for="form-username">Email</label>
        <input type="text" name="form-username" runat="server" id="txtemail" placeholder="Email..." class="form-username form-control" style="height: 36px;" required />
    </div>

    <div class="form-group">
        <label class="sr-only" for="form-username">Mobile Number</label>
        <input type="text" name="form-username" runat="server" id="txtIsdCode" placeholder="ISD Code" style="height: 36px; width: 25%; float: left" />
        <input type="text" name="form-username" runat="server" id="txtmobile" placeholder="Mobile Number ..." class="form-username form-control" style="height: 36px; width: 75%;" required />
    </div>

    <div class="form-group">
        <label class="sr-only" for="form-username">First Name</label>
        <input type="text" name="form-username" runat="server" id="txtfrst" placeholder="First Name..." class="form-username form-control" style="height: 36px;" required />
    </div>
    <div class="form-group">
        <label class="sr-only" for="form-username">Last Name</label>
        <input type="text" name="form-username" runat="server" id="txtlast" placeholder="Last Name..." class="form-username form-control" style="height: 36px;" />
    </div>

    <div class="form-group">
        <label class="sr-only" for="form-username">Postal Code</label>
        <input type="text" runat="server" id="txtpostalcode" placeholder="Postal Code..." class="form-username form-control" style="height: 36px;" required />
    </div>

    <div class="form-group">
        <label class="sr-only" for="form-username">Country</label>
        <select runat="server" id="getcountry" class="form-control">
            <option>Select Country----</option>
            <option>India</option>
            <option>Pakistan</option>
            <option>China</option>
            <option>Russia</option>
            <option>Bhutan</option>
            <option>America</option>
            <option>London</option>
            <option>England</option>
        </select>
    </div>

    <div class="form-group">
        <label class="sr-only" for="form-password">Password</label>
        <input type="password" runat="server" id="txtconfmpswd" placeholder="Password..." class="form-password form-control" style="height: 36px; width: 49%; float: left;" required />
        <input type="password" runat="server" id="txtpass" placeholder="Confirm Password..." class="form-password form-control" style="height: 36px; width: 49%" required />
    </div>
    <%--<button type="submit" class="btn" runat="server" id="btncfrm" onserverclick="btncfrm_ServerClick">Confirm</button>--%>
</div>
</div>
</div>

<%--<div class="social-login">
	<h3>...or login with:</h3>
	<div class="social-login-buttons">
		<a class="btn btn-link-1 btn-link-1-facebook" href="#">
			<i class="fa fa-facebook"></i> Facebook
		</a>
		<a class="btn btn-link-1 btn-link-1-twitter" href="#">
			<i class="fa fa-twitter"></i> Twitter
		</a>
		<a class="btn btn-link-1 btn-link-1-google-plus" href="#">
			<i class="fa fa-google-plus"></i> Google Plus
		</a>
	</div>
</div>--%>
</div>

<div class="col-sm-1 middle-border"></div>
<div class="col-sm-1"></div>

<div class="col-sm-5">

<div class="form-box">
<div class="form-top" style="height: 77px;">
<div class="form-top-left">
    <h3>Choose your plan!</h3>

</div>

</div>
<div class="form-bottom">
<div role="form" action="" method="post" class="registration-form">
    <div class="form-group">
        <label style="font-family: 'Times New Roman'; float: left; padding-right: 25px;">Select Plan</label>
        <asp:DropDownList ID="ddlPlan" runat="server" class="form-control" Style="width: 75%;" AutoPostBack="true">
            <asp:ListItem>select</asp:ListItem>
            <asp:ListItem>100 Mb</asp:ListItem>
            <asp:ListItem>500 Mb</asp:ListItem>
            <asp:ListItem>1 Gb</asp:ListItem>
        </asp:DropDownList>

    </div>
    <div class="form-group">
        <asp:Label ID="lblprice" runat="server" CssClass="form-control" Style="background-color: blue; color: white;">Choose plan from above list.</asp:Label>
        <%--<input type="text" name="form-first-name" placeholder="Card Number..." class="form-first-name form-control" id="form-first-name" style="height: 36px;">--%>
    </div>

    <asp:Button ID="btnSave" runat="server" Text="Save and Continue" class="btn" OnClientClick="return CheckControls()"></asp:Button>
    <br />
    By creating an account you are agreeing to the Moil Cloud Terms of Use and Privacy Policy.
</div>
</div>
</div>

</div>
</div>
</div>
</section>

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooterScript" runat="server">
</asp:Content>
