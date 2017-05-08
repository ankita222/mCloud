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

    <style>
         body.modal-open .bvv{
            -webkit-filter: blur(4px);
            -moz-filter:  blur(4px);
            -o-filter:  blur(4px);
           
            filter: blur(4px);
            
        }
            body.modal-open .navbar{
            -webkit-filter: blur(4px);
            -moz-filter: blur(4px);
            -o-filter: blur(4px);
           
            filter: blur(4px);
            
        }
      
             body.modal-open .sidebar{
            -webkit-filter: blur(4px);
            -moz-filter: blur(4px);
            -o-filter: blur(4px);
           
            filter: blur(4px);
            
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">    
           <form id="Form1" runat="server">
                 <div class="bvv" >    
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
        </div>

               <div class="modal fade in" id="defaultModal" tabindex="-1" role="dialog">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header" style="background:linear-gradient(45deg, #7e67e5, #02cbdf); color: white;">
                            <h4 class="modal-title" id="defaultModalLabel" style="margin-top: -5px;text-align:center;">Create Folder</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row clearfix">
                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 form-control-label">
                                    <label for="txtfolder" style="color: #4a4a4a;float:left;">Folder Name</label>
                                </div>
                                <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">
                                    <div class="form-group" style="margin-bottom:0px;">
                                        <div class="form-line">
                                            <input type="text" runat="server" id="txtfolder" class="form-control" style="border: 1px solid #e2d9d9; border-radius: 4px;" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="color: white;">
                           <div class="row clearfix">
                                  <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 form-control-label">

                            <asp:Button runat="server" ID="btnfolder" CssClass="btn btn-info waves-effect" Text="Create" style="float: left;width:100%" />
                            </div>
                               <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 form-control-label">
                                      <button type="button" class="btn btn-danger waves-effect" data-dismiss="modal" style="color: white;width: 100%;">Close</button>
                                   </div>
                               </div>
                        </div>
                    </div>
                </div>

            </div>

               <div class="modal fade in" id="uploadfiles" tabindex="-1" role="dialog">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header" style="background:linear-gradient(45deg, #7e67e5, #02cbdf);color: white;">
                            <h4 class="modal-title" id="H1" style="margin-top: -5px;text-align:center;">Upload Files</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row clearfix">
                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 form-control-label">
                                    <label for="email_address" style="color: #4a4a4a;float:left;">Upload Files</label>
                                </div>
                                <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">
                                    <div class="form-group" style="margin-bottom:0px;">
                                        <div class="form-line">
                                            <asp:FileUpload ID="FileUpload1" runat="server" name="pdf" />
                                            <%--<input runat="server" width="100%" type="file" size="50" name="pdf" id="FileUpload1" />--%>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="color: white;">
                        <div class="row clearfix">
                                  <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 form-control-label">
                            <asp:Button runat="server" ID="btnupload" CssClass="btn btn-info waves-effect"  Text="Upload" style="float: left;width:  100%;"/>
                        </div>
                               <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 form-control-label">
                                          <button type="button" class="btn btn-danger waves-effect" data-dismiss="modal" style="color: white;width:  100%;">Cancel</button>
                           </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

               <div class="modal fade in" id="DivRename" tabindex="-1" role="dialog">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header" style="background: linear-gradient(45deg, #7e67e5, #02cbdf); color: white;">
                            <h4 class="modal-title" id="H9" style="margin-top: -5px;text-align:center;">Rename</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row clearfix">
                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 form-control-label">
                                    <label for="txtfolder" style="color: #4a4a4a;float:left;">Enter Name</label>
                                </div>
                                <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">
                                    <div class="form-group" style="margin-bottom:0px;">
                                        <div class="form-line">
                                            <input type="text" runat="server" id="txtrename" class="form-control" style="border: 1px solid #e2d9d9; border-radius: 4px;" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="color: white;">
                          <div class="row clearfix">
                                  <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 form-control-label">
                            <asp:Button runat="server" ID="btnrename" CssClass="btn btn-info waves-effect"  Text="Rename" style="float: left;width: 100%;" />
                          </div>
                                   <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 form-control-label">
                                        <button type="button" class="btn btn-danger waves-effect" data-dismiss="modal" style="color: white;width: 100%;" >Close</button>
                        </div>
                              </div></div>
                    </div>
                </div>

            </div>

               <div class="modal fade in" id="deletefolder" tabindex="-1" role="dialog">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header" style="background: linear-gradient(45deg, #7e67e5, #02cbdf); color: white;">
                            <h4 class="modal-title" id="H4" style="margin-top: -5px;text-align:center;">Confirm Delete</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row clearfix">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-control-label" style="text-align: center;">
                                    <label for="txtfolder" style="color: #ff0d0d;font-size: 23px;">Are you sure you want to delete !! </label>
                                </div>

                            </div>
                        </div>
                        <div class="modal-footer" style="color: white;">
                          <div class="row clearfix">
                                  <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 form-control-label">
                            <asp:Button runat="server" ID="Button4" CssClass="btn btn-danger waves-effect" Text="Delete"  style="float: left;width: 100%;"/>
                                      </div>
                                 <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 form-control-label">
                            <button type="button" class="btn btn-warning waves-effect" data-dismiss="modal" style="color: white;width: 100%;">Cancel</button>
                                     </div>
                              </div>
                        </div>
                    </div>
                </div>

            </div>

               </form>
    </div>

  <script type="text/javascript">
        window.onclick = hideContextMenu;
        window.onkeydown = listenKeys;
        var contextMenu = document.getElementById('contextMenu');
        var filemenu = document.getElementById('filecontextmenu');
        var chk = document.getElementById('CheckBox1');

        function showcontextmenu(event) {
            
            contextMenu.style.display = 'block';
            contextMenu.style.left = event.pageX + 'px';
            contextMenu.style.top = event.pageY + 'px';
            return false;
        }

        function filecontextmenu(event) {

            filemenu.style.display = 'block';

            filemenu.style.left = event.pageX + 'px';
            filemenu.style.top = event.pageY + 'px';
            contextMenu.style.display = 'none';

            return false;
        }

        function hideContextMenu(event) {

            contextMenu.style.display = 'none';
            filemenu.style.display = 'none';

        }

        function listenKeys(event) {
            var keycode = event.which || event.keyCode;
            if (keycode == 27 || keycode == 93) {
                contextMenu.style.display = 'none';
                filemenu.style.display = 'none';
            }
        }

    </script>

</asp:Content>
