<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage/Storage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="mCloud.UserPage.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function calldiv() {

            $("#sec_box").show();
        }
        function fadediv() {

            $("#sec_box").hide();
        }
        function movefile() {
            alert("gggg");

        }
        function hideul() {
            $("#myul1").hide();
        }
        function showul() {
            $("#myul1").show();
        }
        $("#Image1").draggable({ cursor: "pointer" });

       

        
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">    
           <form id="Form1" runat="server">

               <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card" style="background: linear-gradient(45deg, #ebe9f1, #b6e9ef);">

                        <div class="header" style="height: 56px; border-bottom: 1px solid rgba(6, 0, 0, 0.35);">
                            <div style="width: 94px; float: left;">
                                <h2 runat="server" id="h2">Dashboard
                                </h2>
                            </div>

                            <div class="myhov" id="attach_box" style="float: right; cursor: pointer; font-size: 24px; font-weight: 900;" onmouseover="calldiv();" onmouseout="fadediv();">
                                &#9776;
							   
							 <ul id="sec_box" style="float: right; margin-top: 53px; display: none; list-style: none; position: absolute; top: 0px; right: 8px; z-index: 1;" class="mryul">
                                 <li class="mymenu">
                                     <button type="button" class="btn btn-default waves-effect" data-toggle="modal" data-placement="bottom" title="Create Folder" data-target="#defaultModal">
                                         <i class="material-icons">create_new_folder</i>
                                     </button>
                                 </li>
                                 <li class="mymenu">
                                     <button type="button" class="btn btn-default waves-effect" data-toggle="modal" data-placement="bottom" title="File Upload" data-target="#uploadfiles">
                                         <i class="material-icons">file_upload</i>
                                     </button>
                                 </li>
                                 <li class="mymenu">
                                     <button type="button" class="btn btn-default waves-effect" data-toggle="modal" data-placement="bottom" title="File Download" runat="server" id="btndownload" >
                                         <i class="material-icons">file_download</i>
                                     </button>
                                 </li>
                              <li class="mymenu">
                                     <button type="button" class="btn btn-default waves-effect" data-toggle="modal" data-placement="bottom" title="Rename" data-target="#DivRename">
                                         <i class="material-icons">border_color</i>
                                     </button>
                                 </li>
                                 <li class="mymenu">
                                     <button runat="server" id="btndel" type="button" class="btn btn-default waves-effect" data-toggle="modal" data-placement="bottom" title="Delete" data-target="#deletefolder">
                                         <i class="material-icons">delete</i>
                                     </button>
                                 </li>
                             </ul>
                            </div>

                        </div>
                        <div class="body">
                        </div>
                    </div>
                </div>
            </div>

               </form>
    </div>

</asp:Content>
