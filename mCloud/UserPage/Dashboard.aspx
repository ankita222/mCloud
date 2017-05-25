<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage/Storage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="mCloud.UserPage.Dashboard" %>
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


  function  BtndwnClick()
        {
            document.getElementById('<%= btndownload.ClientID %>').click();
        }

        function BtnClick() {
            //alert('Welcome');
            document.getElementById('<%= btnextract.ClientID %>').click();
        }
     
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
                    
                    /*border-left: 4px solid transparent;*/
                    cursor: pointer;
                }

                .context-menu ul li :hover {
                    background: #eee;
                    /*border-left: 4px solid #666;*/
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


             .breadcrumb-bg-white li + li:before {
    color: #000;
}
    </style>

    <script type="text/javascript">
        function ShowPopup() {
            $("#btnShowPopup").click();
        }
    </script> 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <button type="button" style="display: none;" id="btnShowPopup" class="md-trigger" data-target="#DivShare" data-toggle="modal">
    </button>
 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>   
       <asp:Button runat="server" ID="btnextract" OnClick="btnextract_Click" style="visibility:hidden"/>  

    <div class="container-fluid">    
                 <div class="bvv" oncontextmenu="return showcontextmenu(event);">    
               <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card" style="background: linear-gradient(45deg, #f3f5f5, #f3f5f5);">

                        <div class="header" style="height: 56px; border-bottom: 1px solid rgba(6, 0, 0, 0.35);">
                            <div style="width: 94px; float: left; display:none">
                                <h2 runat="server" id="h2">Dashboard
                                </h2>
                            </div>
                              <div>
                               <ol class="breadcrumb breadcrumb-bg-white" style="background-color: #f3f5f5 !important;">
                                    <asp:Repeater runat="server" ID="rptbreadcrumps">
                                        <ItemTemplate>
                                          <!--   <li style="color: #130000;"><a href="#" style="color: #130000;"><%#Eval("dir") %></a></li>-->
                                            <li style="color: #130000;">
                                                <asp:LinkButton ID="lnkbtn" runat="server" style="color: #130000;" CommandArgument='<%#Eval("dir") %>' OnCommand="lnkbtn_Command" Text='<%#Eval("dir") %>'></asp:LinkButton></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                            </ol>
                            </div>

                            <div class="myhov" id="attach_box" style="float: right; cursor: pointer; font-size: 24px; font-weight: 900;" onmouseover="calldiv();" onmouseout="fadediv();">
                                &#9776;
							   
							 <ul id="sec_box" style="float: right; margin-top: 85px; display: none; list-style: none; position: absolute; top: 0px; right: 8px; z-index: 1;" class="mryul">
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
                                <%--For Folder--%>
                            <asp:Repeater ID="Repeater1" runat="server">
                                 <ItemTemplate>
                                        <div class="col-lg-2 col-md-4 col-sm-6 col-xs-12" oncontextmenu="return filecontextmenu(event);">
                                        <%--  <div class="col-lg-2 col-md-4 col-sm-6 col-xs-12">--%>
                                            <div id="filediv" class="filediv" style="background-color: rgba(226, 226, 226, 0.47); padding-left: 25px; border-radius: 3px; box-shadow: 1px 1px 2px 1px   #9b9c9e;">
                             <input type="checkbox" id="CheckBox1" runat="server" style="opacity: 1; position: static; margin-left: -20px; width:16px;height:16px;" />

                     <span style="float:right;text-align: end;padding:3px 3px;">
                            <asp:ImageButton ID="btnFav" runat="server" ImageUrl="~/UserPage/images/fav.png" Width="16%"   CommandArgument='<%#Eval("Image") %>' OnCommand="btnFav_Command1"  />
                        </span>
                                                <asp:ImageButton ID="Image1" runat="server" CommandArgument='<%#Eval("Image") %>' OnCommand="Image1_Command" ImageUrl='<%#Eval("icon") %>' Width="111px" CssClass="img-responsive" />
                                            </div>
                                             <div style="background: #e2dbdb;padding: 2px;text-align: center;border-radius: -1px;margin-top: 1px;box-shadow: 1px 1px 1px 1px #888874;border-bottom-left-radius: 3px;border-bottom-right-radius:3px;font-weight: 600;color: black;overflow: hidden;text-overflow: ellipsis;">
                                                <asp:Label runat="server" Text='<%#Eval("Image") %>' ID="mylable"></asp:Label>
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
                                                <input type="checkbox" id="CheckBox1" runat="server" style="opacity: 1; position: static; margin-left: -20px;width:16px;height:16px;" />
                         
                        <span style="float:right;text-align: end;padding:3px 3px;">
                            <asp:ImageButton ID="btnfilefav" runat="server" ImageUrl="~/UserPage/images/fav.png" Width="16%" OnCommand="btnFav_Command1" CommandArgument='<%#Eval("Image") %>' />
                        </span>
                                                <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("icon") %>' Width="70px" CssClass="img-responsive" ondragenter="movefile();" draggable="true" />
                                                
                                            </div>
                                             <div style="background: #e2dbdb;padding: 2px;text-align: center;border-radius: -1px;margin-top: 1px;box-shadow: 1px 1px 1px 1px #888874;border-bottom-left-radius: 3px;border-bottom-right-radius:3px;font-weight: 600;color: black;overflow: hidden;text-overflow: ellipsis;">
                                                <asp:Label runat="server" Text='<%#Eval("Image") %>' ID="mylable" Style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;color:black;"></asp:Label>
                                                </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </ItemTemplate>

                                </asp:Repeater>
                            </div>

                            <div id="divContact" runat="server" class="row" style="padding: 10px;" visible="false">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <%-- <div class="header">
                                         <asp:Button ID="btnnewContact" runat="server" CssClass="btn btn-info waves-effect" Text="New" OnClick="btnnewContact_Click"/>
                                     </div>--%>
                                    <div class="card">

                                        <div class="body table-responsive" style="overflow-x: auto;">
                                            <asp:GridView ID="GridView1" runat="server" class="table table-hover" AutoGenerateColumns="false" GridLines="None" HeaderStyle-BackColor="Azure" BorderStyle="Solid" RowStyle-BorderStyle="Solid">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label type="label" id="label" runat="server" style="opacity: 1; position: static; margin-left: -20px;" Text=" <%# Container.DataItemIndex + 1 %>"/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                                    <asp:BoundField DataField="Contact" HeaderText="Contact" />
                                                    <asp:BoundField DataField="EMail" HeaderText="E-mail" />

                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Button id="btnDownoad" CssClass="btn" runat="server" style="opacity: 1; position: static; margin-left: -20px;" Text="Download"  CommandArgument='<%#Eval("Contact") %>' OnCommand="btnDownoad_Command" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField ItemStyle-HorizontalAlign="Center" >
                                                        <ItemTemplate>
                                                            <asp:Button id="btnDel" CssClass="btn" runat="server" style="opacity: 1; position: static; margin-left: -20px;" Text="Del"  CommandArgument='<%#Eval("Contact") %>' OnCommand="btnDel_Command" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="E-Mail">
                                <ItemTemplate>
                                  <label>ankitaverma.av222@gmail.com</label>
                                </ItemTemplate>
                                </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </div>

                                    </div>
                                </div>
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
                                    <label for="txtfolder" style="color:#4a4a4a; float:left;">Folder Name</label>
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
                                            <%--<input runat="server" width="100%" type="file" size="50" name="pdf"                          id="FileUpload1" />--%>
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

        
        <div class="modal fade in" id="DivShare" tabindex="-1" role="dialog">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header" style="background: linear-gradient(45deg, #7e67e5, #02cbdf); color: white;">
                            <h4 class="modal-title" id="H9" style="margin-top: -5px;text-align:center;">Share With</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row clearfix">
                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 form-control-label">
                                    <label for="txtShare" style="color: #4a4a4a;float:left;">MoilCloud UserId</label>
                                </div>
                                <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">
                                    <div class="form-group" style="margin-bottom:0px;">
                                        <div class="form-line">
                                            <input type="text" runat="server" id="txtShare" class="form-control" style="border: 1px solid #e2d9d9; border-radius: 4px;" />

                                        </div>
                                         <div class="form">
                                             <asp:Label ID="lblShareError" ForeColor="Red" runat="server" Visible="false" Font-Size="Small"></asp:Label>
                                         </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="color: white;">
                          <div class="row clearfix">
                                  <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 form-control-label">
                            <asp:Button runat="server" ID="btnShare" CssClass="btn btn-info waves-effect" OnClick="btnShare_Click" Text="Share" style="float: left;width: 100%;" />
                          </div>
                                   <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 form-control-label">
                                        <button type="button" class="btn btn-danger waves-effect" data-dismiss="modal" style="color: white;width: 100%;" >Close</button>
                        </div>
                              </div></div>
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

        <div class="modal fade in" id="DivArchive" tabindex="-1" role="dialog">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header" style="background: linear-gradient(to left, #585027 , #34545d); color: white;">
                            <h4 class="modal-title" id="H8" style="margin-top: -5px;text-align:center;">Archive File</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row clearfix">
                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 form-control-label">
                                    <label for="txtfolder" style="color: #4a4a4a;float:left;">Name</label>
                                </div>
                                <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">
                                    <div class="form-group" style="margin-bottom:0px;">
                                        <div class="form-line">
                                            <input type="text" runat="server" id="txtzipname" class="form-control" style="border: 1px solid #e2d9d9; border-radius: 4px;" />

                                            <%--<input type="file" id="FileUpload" onchange="selectFolder(event)" webkitdirectory mozdirectory msdirectory odirectory directory multiple />--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="color: white;">
                     <div class="row clearfix">
                                  <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 form-control-label">
                            <asp:Button runat="server" ID="btnarchive" CssClass="btn btn-info waves-effect" OnClick="btnarchive_Click" Text="Create" style="float: left;width: 100%;" />
                          </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 form-control-label">
                           <button type="button" class="btn btn-danger waves-effect" data-dismiss="modal" style="color: white;width: 100%;">Close</button>
                                </div>
                         </div><
                        </div>
                    </div>
                </div>

            </div>
        <!-- Modal To copy-->
        <div class="modal fade in" id="DivCopyFiles" tabindex="-1" role="dialog" style="top: 136px;">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header" style="background: linear-gradient(to left, #585027 , #34545d); color: white;">
                            <h4 class="modal-title" id="H7" style="margin-top: -5px;text-align:center;">Select Destination Folder</h4>
                        </div>
                        <div class="modal-body" style="overflow: auto;height: 180px;">
                            <div class="row clearfix">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-control-label">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
                                  <asp:TreeView ID="TreeViewCopy" runat="server" Target="_self" NodeIndent="15" CollapseImageUrl="~/UserPage/images/reddowntri1.png" ExpandImageUrl="~/UserPage/images/righttri.png">
                                         <HoverNodeStyle  ForeColor="BurlyWood" />
                                            <NodeStyle Font-Names="Tahoma" Font-Size="12pt" ForeColor="Black" HorizontalPadding="2px" NodeSpacing="5px" VerticalPadding="2px" ImageUrl="~/UserPage/images/blue_32x32.png" >

                                            </NodeStyle>
                                     
                                            <ParentNodeStyle Font-Bold="False" ImageUrl="~/UserPage/images/blue_32x32.png" ChildNodesPadding="5px" />
                                            <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="5px"
                                                VerticalPadding="5px" />
                                  </asp:TreeView>
            </ContentTemplate>
        </asp:UpdatePanel>

                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="color: white;">
                           <div class="row clearfix">
                                  <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 form-control-label">
                            <button type="button" runat="server" id="btncopyfile" value="MOVE" class="btn btn-info waves-effect" onserverclick="btncopyfile_ServerClick"  style="float: left;width: 100%;">Copy</button>
                                      </div>
                                  <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 form-control-label">
                             <button type="button" class="btn btn-danger waves-effect" data-dismiss="modal" style="color: white;width: 100%;">Cancel</button>
                                      </div>
                               </div>
                        </div>
                    </div>
                </div>

            </div>

        <!--    Modal to Move-->
        <div class="modal fade in" id="DivMoveFiles" tabindex="-1" role="dialog">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header" style="background: linear-gradient(to left, #585027 , #34545d); color: white;">
                            <h4 class="modal-title" id="H6" style="margin-top: -5px;text-align:center;">Select Destination Folder</h4>
                        </div>
                        <div class="modal-body" style="overflow: auto;height: 180px;">
                            <div class="row clearfix">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-control-label">
                               
                                   
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                                  <asp:TreeView ID="TreeViewMove" runat="server" Target="_self"  NodeIndent="15" CollapseImageUrl="~/UserPage/images/reddowntri1.png" ExpandImageUrl="~/UserPage/images/righttri.png">
                                         <HoverNodeStyle  ForeColor="BurlyWood" />
                                            <NodeStyle Font-Names="Tahoma" Font-Size="12pt" ForeColor="Black" HorizontalPadding="2px" NodeSpacing="5px" VerticalPadding="2px" ImageUrl="~/UserPage/images/blue_32x32.png" >

                                            </NodeStyle>
                                     
                                            <ParentNodeStyle Font-Bold="False" ImageUrl="~/UserPage/images/blue_32x32.png" ChildNodesPadding="5px" />
                                            <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="5px"
                                                VerticalPadding="5px" />
                                  </asp:TreeView>
            </ContentTemplate>
        </asp:UpdatePanel>

                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="color: white;">
                                <div class="row clearfix">
                                  <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 form-control-label">
                            <button type="button" runat="server" id="btnmoveok" value="MOVE" class="btn btn-info waves-effect" onserverclick="btnmoveok_ServerClick" style="float: left;width:  100%;">Move</button>
                           </div>
                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 form-control-label">
                                        <button type="button" class="btn btn-danger waves-effect" data-dismiss="modal" style="color: white;width:  100%;">Cancel</button>
                      </div>
                                              </div></div>
                    </div>
                </div>

            </div>           
    </div>
    <div class="container222">
        <div id="contextMenu" class="context-menu">
            <ul>
                <li><div data-target="#defaultModal" data-toggle="modal"> 
                    <i class="material-icons" style="color: black; font-size: 17px;">create_new_folder</i><span>New Folder</span></div></li>
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
               <%-- <li>
                    <div data-target="#DivRename" data-toogle="modal" onclick="divshow();">
                        <i class="material-icons" style="color: black; font-size: 17px;">star</i>
                        <span>Fav/Unfav</span>
                    </div>
                </li>--%>
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
