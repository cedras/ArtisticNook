<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="editpost.aspx.cs" Inherits="ArtisticNook.editpost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
    $(function () {
        $("#<%= FileUpload1.ClientID %>").change(function () {
            var input = this;
            var file = input.files[0]; 
            if (file) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $("#dvPreview").html(""); 
                    $("#dvPreview").show();

                    $("<img />", {
                        "src": e.target.result,
                        "class": "img-thumbnail"
                    }).appendTo("#dvPreview");
                };

                reader.readAsDataURL(file);
            }
        });
    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container-fluid">
      <div class="row">
         <div class="col-md-5">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Edit your post</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="images/digital-drawing.png" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                   <div class="row">
                     <div class="col p-2">
                         <label>Choose a file for the post</label>
                         <asp:FileUpload class="form-control" ID="FileUpload1" runat="server" />
                     </div>
                  </div>


                  <div class="row">
                     <div class="col-md-12 p-2">
                        <label>Post title</label>
                        <div class="form-group">
                           <div class="input-group">
                               <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                     <div class="col-md-12 p-2">
                        <label>Description</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                     </div>
                     
                  </div>
                  <div class="row">
                     <div class="col-md-6 p-2">
                        <label>Art Category</label>
                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">

                                <asp:ListItem Value="Painting">Painting</asp:ListItem>
                                <asp:ListItem Value="Drawing">Drawing</asp:ListItem>
                                <asp:ListItem Value="Photography">Photography</asp:ListItem>
                                <asp:ListItem Value="Digital Art">Digital Art</asp:ListItem>
                                <asp:ListItem Value="Mixed Media">Mixed Media</asp:ListItem>
                                <asp:ListItem Value="Sculpture">Sculpture</asp:ListItem>

                            </asp:DropDownList>
                        </div>
                     </div>
                     <div class="col-md-6 p-2">
                        <label>Art Style</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">

                                <asp:ListItem Value="Abstract">Abstract</asp:ListItem>
                                <asp:ListItem Value="Realism">Realism</asp:ListItem>
                                <asp:ListItem Value="Impressionism">Impressionism</asp:ListItem>
                                <asp:ListItem Value="Cubism">Cubism</asp:ListItem>
                                <asp:ListItem Value="Surrealism">Surrealism</asp:ListItem>
                                <asp:ListItem Value="Expressionism">Expressionism</asp:ListItem>
                                <asp:ListItem Value="Minimalism">Minimalism</asp:ListItem>
                                <asp:ListItem Value="Pop-Art">Pop-Art</asp:ListItem>

                            </asp:DropDownList>
                        </div>
                     </div>
                     <div class="col-md-12 p-2">
                        <label>Subject Matter</label>
                        <div class="form-group">
                            <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple">

                                <asp:ListItem Value="Portrait">Portrait</asp:ListItem>
                                <asp:ListItem Value="Landscape">Landscape</asp:ListItem>
                                <asp:ListItem Value="Still Life">Still Life</asp:ListItem>
                                <asp:ListItem Value="Animals">Animals</asp:ListItem>
                                <asp:ListItem Value="Architecture">Architecture</asp:ListItem>
                                <asp:ListItem Value="Nature">Nature</asp:ListItem>
                                <asp:ListItem Value="Fantasy">Fantasy</asp:ListItem>
                                <asp:ListItem Value="Science Fiction">Science Fiction</asp:ListItem>
                                <asp:ListItem Value="Game Art">Game Art</asp:ListItem>
                                <asp:ListItem Value="Illustration">Illustration</asp:ListItem>

                            </asp:ListBox>
                        </div>
                     </div>
                  </div>
                  
                  
                  <div class="row">
                     <div class="col-4 mx-auto">
                         <asp:Button ID="Button2" class="btn btn-lg btn-block btn-primary w-100 m-1" runat="server" Text="Edit Post" OnClick="Button2_Click" />
                         <asp:Button ID="Button1" class="btn btn-lg btn-danger w-100 m-1" runat="server" Text="Delete" OnClick="Button3_Click" CommandArgument='<%# Eval("id") %>' />
                     </div>
                  </div>

               </div>
            </div>
            
            <br>
         </div>
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Photo preview</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                      <asp:SqlDataSource runat="server"></asp:SqlDataSource>
                     <div class="col">
                         <div id="dvPreview">
                             <asp:Image ID="PostImage" runat="server" CssClass="img-fluid" />
                         </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>
</asp:Content>
