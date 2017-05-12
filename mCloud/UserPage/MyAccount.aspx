<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage/Storage.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="mCloud.UserPage.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <script>
          function selectFile() {
              $('#ContentPlaceHolder1_imgupload').click();
          }


          function show() {
          
              $("#ContentPlaceHolder1_upgradeDIV").show();
          }
    </script>

    <style>
        .div1 :hover > parent{
            box-shadow: 2px 2px 2px 2px rgba(0, 0, 0, 0.22);
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container-fluid">
		  <form id="Form1" runat="server">
              <%--   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
			<div class="row clearfix">
			 
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card" style="background: #f3f5f5;">
                        <div class="header" style="border-bottom: 1px solid rgba(0, 0, 0, 0.39);">
                            <h2>
                             Edit Account
                            </h2>
                            
                        </div>
                        <div class="body" style="color:#1e6498">
                            <!-- Nav tabs -->
                            <ul class="nav nav-tabs" role="tablist" style="border-bottom: 2px solid #9e8282;">
                                <li role="presentation" class="active">
                                    <a href="#home_with_icon_title" data-toggle="tab">
                                        <i class="material-icons" title="Profile">face</i> 
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="#profile_with_icon_title" data-toggle="tab">
                                        <i class="material-icons" title="Account">account_circle</i> 
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="#messages_with_icon_title" data-toggle="tab">
                                        <i class="material-icons" title="Used Space">cloud_queue</i>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="#settings_with_icon_title" data-toggle="tab">
                                        <i class="material-icons" title="Recent Activity">settings</i> 
                                    </a>
                                </li>
                            </ul>

                            <!-- Tab panes -->
                            <div class="tab-content">
                                <div role="tabpanel" class="tab-pane fade in active" id="home_with_icon_title">
                                    <h4>Personal Info</h4>
                                   <div class="row">
                                       <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">
                                         <div class="form-horizontal"> 
                                           <div class="row clearfix">
                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 form-control-label" style="margin-bottom: 10px;">
                                        <label style="float: left;">Name</label>
                                    </div>
                                    <div class="col-lg-8 col-md-8 col-sm-10 col-xs-10">
                                        <div class="form-group">
                                            <div class="form-line">
                                                <asp:TextBox  EnableViewState="true" runat="server" type="text" id="txtFirstname" class="form-control" placeholder="" style="border: 1px solid #3e89ca;border-radius: 7px; padding: 8px;    box-shadow: 0px 0px 0px 1px #bddbe4;"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                           <div class="row clearfix">
                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 form-control-label" style="margin-bottom: 10px;">
                                        <label style="float: left;">Mobile Number</label>
                                    </div>
                                    <div class="col-lg-8 col-md-8 col-sm-10 col-xs-10">
                                        <div class="form-group">
                                            <div class="form-line">
                                                <input type="text" runat="server" id="txtmob" class="form-control" placeholder=""  style="border: 1px solid #3e89ca;border-radius: 7px; padding: 8px; box-shadow: 0px 0px 0px 1px #bddbe4;" disabled=""/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                           <div class="row clearfix">
                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 form-control-label" style="margin-bottom: 10px;">
                                        <label style="float: left;">Email Address</label>
                                    </div>
                                    <div class="col-lg-8 col-md-8 col-sm-10 col-xs-10">
                                        <div class="form-group">
                                            <div class="form-line">
                                                <input type="text" id="txtmail" runat="server" class="form-control" placeholder=""  style="border: 1px solid #3e89ca;border-radius: 7px;padding: 8px;box-shadow: 0px 0px 0px 1px #bddbe4;"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                             <div class="row clearfix">
                                               <asp:Button ID="btnsave" runat="server" Text="Save" type="button" class="btn bg-brown   waves-effect" style="float: right;"  OnClick="btnsave_Click"/>
                                             </div>
                                             <br />

                                             <div >
                                             <h4>Change Password</h4>

                                               <div class="row clearfix">
                                        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 form-control-label" style="margin-bottom: 10px;">
                                            <label style="float: left;">Old Password</label>
                                        </div>
                                        <div class="col-lg-8 col-md-8 col-sm-10 col-xs-10">
                                            <div class="form-group">
                                                <div class="form-line">
                                                    <input type="password" id="txtoldpass" runat="server" class="form-control" placeholder=""  style="border: 1px solid #3e89ca;border-radius: 7px;padding: 8px;box-shadow: 0px 0px 0px 1px #bddbe4;"/>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                               <div class="row clearfix">
                                        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 form-control-label" style="margin-bottom: 10px;">
                                            <label style="float: left;">New Password</label>
                                        </div>
                                        <div class="col-lg-8 col-md-8 col-sm-10 col-xs-10">
                                            <div class="form-group">
                                                <div class="form-line">
                                                    <input type="password" id="txtnewpass" runat="server" class="form-control" placeholder=""  style="border: 1px solid #3e89ca;border-radius: 7px;padding: 8px;box-shadow: 0px 0px 0px 1px #bddbe4;"/>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row clearfix">
                                        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 form-control-label" style="margin-bottom: 10px;">
                                            <label style="float: left;">Confirm Password</label>
                                        </div>
                                        <div class="col-lg-8 col-md-8 col-sm-10 col-xs-10">
                                            <div class="form-group">
                                                <div class="form-line">
                                                    <input type="password" id="txtcnfrmpass" runat="server" class="form-control" placeholder=""  style="border: 1px solid #3e89ca;border-radius: 7px;padding: 8px;box-shadow: 0px 0px 0px 1px #bddbe4;"/>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                             <asp:Button  ID="btnchangepass" runat="server" Text="Change Password" OnClick="btnchangepass_Click" type="button" class="btn bg-brown waves-effect" style="float: right;" />
                                                 </div>
                                      </div>
                                    </div>
                                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                              <%--<asp:Image  runat="server" ImageUrl="images/child_boy-512.png" style="height: 167px;float: right;border: 1px solid white;border-radius: 15px;" id="img1" onclick="selectFile(); return false;"" />--%>
                                           <asp:Image runat="server" ImageUrl="images/child_boy-512.png" style="height: 167px;float: right;border: 1px solid white;border-radius: 15px;" id="img1" onclick="selectFile(); return false;"/>
                                             <asp:FileUpload EnableViewState="true" runat="server" CssClass="hidden" ID="imgupload" onchange="document.getElementById('ContentPlaceHolder1_img1').src = window.URL.createObjectURL(this.files[0])"/>
                                         
                                       </div>
                                       </div>
                                       </div>
                                      <div role="tabpanel" class="tab-pane fade" id="profile_with_icon_title">
                                    <h4>Account Information</h4>
                                    <div class="row clearfix">
                                    <div class="col-lg-6 col-md-6 col-sm-4 col-xs-5 form-control-label">
                                        <label style="float: left;font-size: 16px;">Plan</label>
                                    </div>
                                     <div class="col-lg-6 col-md-6 col-sm-4 col-xs-5 form-control-label">
                                        <label runat="server" id="lblplan" style="float: left;color: #1de01b;font-size: 23px;">Free</label>
                                    </div>
                                </div>
                                    <div class="row clearfix">
                                    <div class="col-lg-6 col-md-6 col-sm-4 col-xs-5 form-control-label">
                                        <label style="float: left;font-size: 16px;">Storage Space</label>
                                    </div>
                                     <div class="col-lg-6 col-md-6 col-sm-4 col-xs-5 form-control-label">
                                        <label runat="server" id="lbltotal" style="float: left;font-size: 16px;">100 GB</label>
                                    </div>
                                </div>

                                          <%--<div class="row clearfix">
                                    <div class="col-lg-6 col-md-6 col-sm-4 col-xs-5 form-control-label">
                                        <label style="float: left;font-size: 16px;">Space Available</label>
                                    </div>
                                     <div class="col-lg-6 col-md-6 col-sm-4 col-xs-5 form-control-label">
                                        <label runat="server" id="lblavail" style="float: left;font-size: 16px;">100 GB</label>
                                    </div>
                                </div>--%>
                                    <div class="row clearfix">
                                    <div class="col-lg-6 col-md-6 col-sm-4 col-xs-5 form-control-label">
                                        <label style="float: left;font-size: 16px;">Expiry Date</label>
                                    </div>
                                     <div class="col-lg-6 col-md-6 col-sm-4 col-xs-5 form-control-label">
                                        <label runat="server" id="lblexp" style="float: left;font-size: 16px;">Date    </label>
                                    </div>
                                </div>
                                    <div class="row clearfix">
                                   
                             <asp:Button ID="btnupgrade" runat="server" Text="Upgrade Account" type="button" class="btn bg-brown waves-effect" style="margin-left: 15px;"/>
                                </div>
                                          <br />
                                    <div class="row clearfix">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-control-label">
                                        <label style="float: left;font-size: 19px;font-weight: 100;color: #8f8e90;">Delete Account</label>
                                        <br />
                                                <br />
                                          <label style="float: left;text-align:justify;">
                                     <span style="color:rgb(245, 24, 24);">Warning:</span> You will not be able to access your account data, your MoilCloud contacts or files after you confirm this action.
                                    </label>
                                    </div>
                                     <div class="col-lg-3 col-md-3 col-sm-4 col-xs-5 form-control-label">
                                         <asp:Button ID="Button2" runat="server" Text="Delete Account" type="button" class="btn bg-red waves-effect" style="float: left;"/>
                                    </div>
                                </div>
                                          
                                </div>
                                <div role="tabpanel" class="tab-pane fade" id="messages_with_icon_title">
                                    <b>Cloud Space</b>
                                       <div class="row clearfix">
                                    <div class="col-lg-6 col-md-6 col-sm-4 col-xs-5 form-control-label">
                                        <label style="float: left;font-size: 16px;">Space Available</label>
                                    </div>
                                     <div class="col-lg-6 col-md-6 col-sm-4 col-xs-5 form-control-label">
                                        <label runat="server" id="lblavailspace" style="float: left;color: #1de01b;font-size: 23px;">100 GB</label>
                                    </div>
                                </div>
                                    <div class="row clearfix">
                                    <div class="col-lg-6 col-md-6 col-sm-4 col-xs-5 form-control-label">
                                        <label style="float: left;font-size: 16px;">Used Space </label>
                                    </div>
                                     <div class="col-lg-6 col-md-6 col-sm-4 col-xs-5 form-control-label">
                                        <label style="float: left;font-size: 16px;" runat="server" id="lblusedspace">50 GB</label>
                                    </div>
                                </div>
                                    <div class="row clearfix">
                                    <div class="col-lg-6 col-md-6 col-sm-4 col-xs-5 form-control-label">
                                        <label style="float: left;font-size: 16px;">Junk Files</label>
                                    </div>
                                     <div class="col-lg-6 col-md-6 col-sm-4 col-xs-5 form-control-label">
                                        <label style="float: left;font-size: 16px;">25 GB</label>
                                    </div>
                                </div>
                                    <div class="row clearfix">

                                   <asp:Button ID="Button3" runat="server" Text="Clear Space" type="button" class="btn bg-brown waves-effect" style="margin-left: 15px;" />
                                          <label style="text-align:justify;">
                                     <span style="color:rgb(245, 24, 24);">Warning:</span> Are you sure, You want to <span style="color:rgb(245, 24, 24);"> CLEAR ALL CONTENTS.</span> You will loose all your <span style="color:rgb(245, 24, 24);">IMPORTANT FILES.</span>
                                    </label>

                                </div>
                                </div>
                                <div role="tabpanel" class="tab-pane fade" id="settings_with_icon_title">
                                    <b>Recent Activity</b>
                                   
                                </div> 
                                   
                                </div>
                               
                            </div>
                        </div>
                    </div>
                </div>

		<%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
			  </form>
		</div>
   
</asp:Content>
