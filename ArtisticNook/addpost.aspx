<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="addpost.aspx.cs" Inherits="ArtisticNook.addpost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
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
                           <h4>Upload your post</h4>
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
                              <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
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

                                <asp:ListItem Value="PA">Painting</asp:ListItem>
                                <asp:ListItem Value="DR">Drawing</asp:ListItem>
                                <asp:ListItem Value="PH">Photography</asp:ListItem>
                                <asp:ListItem Value="DA">Digital Art</asp:ListItem>
                                <asp:ListItem Value="MA">Mixed Media</asp:ListItem>
                                <asp:ListItem Value="SC">Sculpture</asp:ListItem>

                            </asp:DropDownList>
                        </div>
                     </div>
                     <div class="col-md-6 p-2">
                        <label>Art Style</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">

                                <asp:ListItem Value="AB">Abstract</asp:ListItem>
                                <asp:ListItem Value="DR">Realism</asp:ListItem>
                                <asp:ListItem Value="IM">Impressionism</asp:ListItem>
                                <asp:ListItem Value="CU">Cubism</asp:ListItem>
                                <asp:ListItem Value="SU">Surrealism</asp:ListItem>
                                <asp:ListItem Value="EX">Expressionism</asp:ListItem>
                                <asp:ListItem Value="MI">Minimalism</asp:ListItem>
                                <asp:ListItem Value="PO">Pop-Art</asp:ListItem>

                            </asp:DropDownList>
                        </div>
                     </div>
                     <div class="col-md-12 p-2">
                        <label>Subject Matter</label>
                        <div class="form-group">
                            <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple">

                                <asp:ListItem Value="PT">Portrait</asp:ListItem>
                                <asp:ListItem Value="LA">Landscape</asp:ListItem>
                                <asp:ListItem Value="ST">Still Life</asp:ListItem>
                                <asp:ListItem Value="AN">Animals</asp:ListItem>
                                <asp:ListItem Value="AR">Architecture</asp:ListItem>
                                <asp:ListItem Value="NA">Nature</asp:ListItem>
                                <asp:ListItem Value="FA">Fantasy</asp:ListItem>
                                <asp:ListItem Value="SF">Science Fiction</asp:ListItem>
                                <asp:ListItem Value="GA">Game Art</asp:ListItem>
                                <asp:ListItem Value="IL">Illustration</asp:ListItem>

                            </asp:ListBox>
                        </div>
                     </div>
                  </div>
                  
                  
                  <div class="row">
                     <div class="col-8 mx-auto">
                         <asp:Button ID="Button2" class="btn btn-lg btn-block btn-primary w-100 m-2" runat="server" Text="Upload Post" OnClick="Button2_Click" />
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
                         <div id="dvPreview"></div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>


</asp:Content>
