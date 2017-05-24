<%@ Page Title="" Language="C#" MasterPageFile="~/preInit/Activity.Master" AutoEventWireup="true" CodeBehind="OnPaymentFailure.aspx.cs" Inherits="mCloud.preInit.OnPaymentFailure" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Payment Failure</title>
    <!-- Bootstrap Core CSS -->
	<link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
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
						<h2 style="color: #fff;font-size: 30px;font-weight: 400;line-height: 20px;">Oops! Something went wrong.</h2>
						<p class="text-muted" style="font-size: 18px;color: #fff;">Retry or Contact Support</p>
					</div>
				</div>
               <br />
                
			</div>

            <div class="row" runat="server" id="divverify" >
                <div class="col-lg-3 col-xs-12 col-sm-12 text-center"></div>
                <div class="col-lg-6 col-xs-12 col-sm-12 text-center">
					<div class="section-heading" style="margin-top:40px;">

                         <table class="table table-responsive" style="background-color: #f9f7fc; height:148px;">

                              <tr>
                                 <td colspan="2">
                                 </td>
                             </tr>

                             <tr>
                                 <td colspan="2">
                                     <asp:Label ID="Label1" runat="server" Text="Payment Failure!" ForeColor="#FF3300" Font-Size="Large"></asp:Label><br />
                                     <a href="#">Retry or Contact Support</a>
                                 </td>

                             </tr>
                             <tr>
                                 <td colspan="2">
                                 </td>
                             </tr>

                          
                        </table>

						
                        
						
					</div>
				</div>
                <div class="col-lg-3 col-xs-12 col-sm-12 text-center"></div>
            </div>
            
           
              	
	</div>
	</section>
    

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooterScript" runat="server">
</asp:Content>
