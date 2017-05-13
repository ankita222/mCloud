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
        * {
            margin: 0;
            padding: 0;
        }

        html, body, .container {
            height: 100%;
        }

        .container222 {
            background: #f6f6f6;
        }

        .context-menu {
            width: 125px;
            height: auto;
            box-shadow: 0px 2px 10px 0px rgba(3, 26, 29, 0.88);
            position: absolute;
            display: none;
            background: white;
            border-radius: 5px;
            font-size: 12px;
        }

            .context-menu ul {
                list-style: none;
                padding: 5px 0px 5px 0px;
            }

                .context-menu ul li:not(.seperator) {
                    padding: 10px 5px 10px 5px;
                    border-left: 4px solid transparent;
                    cursor: pointer;
                }

                .context-menu ul li :hover {
                    background: #eee;
                    border-left: 4px solid #666;
                }

        .seperator {
            height: 1px;
            background: #dedede;
            margin: 2px 0px 2px 0px;
        }

        #ContentPlaceHolder1_TreeView1 table tbody tr td {
            padding:2px;
        }
    </style>

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
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                 <div class="bvv" oncontextmenu="return showcontextmenu(event);">    
               <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card" style="background: linear-gradient(45deg, #f3f5f5, #f3f5f5);">

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
                                     <button type="button" class="btn btn-default waves-effect" data-toggle="modal" data-placement="bottom" title="File Download" runat="server" id="btndownload" onserverclick="btndownload_ServerClick" >
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
                            <div class="row" style="padding: 10px;">
                            <asp:Repeater ID="Repeater1" runat="server">
                                 <ItemTemplate>
                                        <div class="col-lg-2 col-md-4 col-sm-6 col-xs-12" oncontextmenu="return filecontextmenu(event);">
                                        <%--  <div class="col-lg-2 col-md-4 col-sm-6 col-xs-12">--%>
                                            <div id="filediv" class="filediv" style="background-color: rgba(226, 226, 226, 0.47); padding-left: 25px; border-radius: 3px; box-shadow: 1px 1px 2px 1px   #9b9c9e;">
                                                <input type="checkbox" id="CheckBox1" runat="server" style="opacity: 1; position: static; margin-left: -20px;" />
                                                <asp:ImageButton ID="Image1" runat="server" CommandArgument='<%#Eval("Image") %>' OnCommand="Image1_Command" ImageUrl='<%#Eval("icon") %>' Width="111px" CssClass="img-responsive" />
                                                
                                            </div>
                                             <div style="background: #e2dbdb;padding: 2px;text-align: center;border-radius: -1px;margin-top: 1px;box-shadow: 1px 1px 1px 1px #888874;border-bottom-left-radius: 3px;border-bottom-right-radius:3px;font-weight: 600;color: black;">
                                                <asp:Label runat="server" Text='<%#Eval("Image") %>' ID="Label2"></asp:Label>
                                              </div>
                                        </div>
                                    </ItemTemplate>
                            </asp:Repeater>
                        </div>
                            <div class="row" style="padding: 10px;">
                                <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>

                                        <div class="col-lg-2 col-md-3 col-sm-4 col-xs-12" id="divfiles" oncontextmenu="return filecontextmenu(event);">
                                      <%--   <div class="col-lg-2 col-md-3 col-sm-4 col-xs-12" id="divfiles">--%>
                                            <asp:Panel ID="thumbnails" runat="server" />

                                            <div class="filediv" style="background-color: rgba(226, 226, 226, 0.47); padding-left: 25px; border-radius: 3px; box-shadow: 1px 1px 2px 1px   #9b9c9e;">
                                                <input type="checkbox" id="CheckBox1" runat="server" style="opacity: 1; position: static; margin-left: -20px;" />
                                                <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("icon") %>' Width="70px" CssClass="img-responsive" ondragenter="movefile();" draggable="true" />
                                                 <div style="background: #e2dbdb;padding: 2px;text-align: center;border-radius: -1px;margin-top: 1px;box-shadow: 1px 1px 1px 1px #888874;border-bottom-left-radius: 3px;border-bottom-right-radius:3px;font-weight: 600;color: black;">
                                                <asp:Label runat="server" Text='<%#Eval("Image") %>' ID="mylable" Style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;color:black;"></asp:Label>
                                                </div>
                                            </div>


                                            <div class="clearfix"></div>
                                        </div>
                                    </ItemTemplate>

                                </asp:Repeater>
                            </div>
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

                            <asp:Button runat="server" ID="btnfolder" CssClass="btn btn-info waves-effect" Text="Create" OnClick="btnfolder_Click" style="float: left;width:100%" />
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
                            <asp:Button runat="server" ID="btnupload" CssClass="btn btn-info waves-effect" onclick="btnupload_Click"  Text="Upload" style="float: left;width:  100%;"/>
                        </div>
                               <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 form-control-label">
                                          <button type="button" class="btn btn-danger waves-effect" data-dismiss="modal"  style="color: white;width:  100%;">Cancel</button>
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
                            <asp:Button runat="server" ID="btnrename" CssClass="btn btn-info waves-effect" OnClick="btnrename_Click"  Text="Rename" style="float: left;width: 100%;" />
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
                            <asp:Button runat="server" ID="button4" CssClass="btn btn-danger waves-effect" Text="Delete" OnClick="btndel_ServerClick"  style="float: left;width: 100%;"/>
                                      </div>
                                 <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 form-control-label">
                            <button type="button" class="btn btn-warning waves-effect" data-dismiss="modal" style="color: white;width: 100%;">Cancel</button>
                                     </div>
                              </div>
                        </div>
                    </div>
                </div>

            </div>

              
    </div>
    <div class="container222">
        <div id="contextMenu" class="context-menu">
            <ul>
                <li><div data-target="#defaultModal" data-toggle="modal"> <i class="material-icons" style="color: black; font-size: 17px;">create_new_folder</i><span>New Folder</span></div></li>
                <li class="seperator"></li>
                 <li><div data-target="#uploadfiles" data-toggle="modal"> <i class="material-icons" style="color: black; font-size: 17px;">file_upload</i><span>File Upload</span></div></li>
               

            </ul>
        </div>

        <div id="filecontextmenu" class="context-menu">
            <ul>
                 <li>
                    <div data-target="#DivShare" data-toggle="modal">
                        <i class="material-icons" style="color: black; font-size: 17px;">folder_shared</i>
                        <span>Share</span>
                    </div>
                </li>
                <li class="seperator"></li>
                <li>
                    <div onclick="BtndwnClick();">
                        <i class="material-icons" style="color: black; font-size: 17px;">file_download</i>
                        <span>Download</span>
                    </div>
                </li>
                <li>
                    <div data-target="#DivArchive" data-toggle="modal">
                        <i class="material-icons" style="color: black; font-size: 17px;">archive</i>
                        <span>Archive</span>
                    </div>
                </li>
                 <li>
                    <div onclick="BtnClick();">
                        <i class="material-icons" style="color: black; font-size: 17px;">unarchive</i>
                        <span>Unarchive</span>
                    </div>
                </li>
                <li class="seperator"></li>
                <li>
                    <div data-target="#DivRename" data-toogle="modal" onclick="divshow();">
                        <i class="material-icons" style="color: black; font-size: 17px;">border_color</i>
                        <span>Rename</span>
                    </div>
                </li>
                <li>
                    <div data-target="#DivMoveFiles" data-toggle="modal">
                        <i class="material-icons" style="color: black; font-size: 17px;">zoom_out_map</i>
                        <span>Move</span>
                      
                    </div>
                </li>

                 <li>
                    <div data-target="#DivCopyFiles" data-toggle="modal">
                        <i class="material-icons" style="color: black; font-size: 17px;">content_copy</i>
                        <span>Copy</span>
                    </div>
                </li>
                <li class="seperator"></li>
                <li>
                    <div data-target="#deletefolder" data-toggle="modal" >
                        <i class="material-icons" style="color: black; font-size: 17px;">delete</i>
                        <span>Remove</span>
                    </div>
                </li>

            </ul>
        </div>


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
