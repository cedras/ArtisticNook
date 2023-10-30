<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="viewprofile.aspx.cs" Inherits="ArtisticNook.viewprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                <img width="100px" src="images/generaluser.png" />
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <asp:Label CssClass="form-control" ID="Label9" runat="server"></asp:Label>
                                <span>Account status - </span>
                                <asp:Label class="badge rounded-pill bg-info text-dark" ID="Label1" runat="server" Text="Status"></asp:Label>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <label>Full name</label>
                            <div class="form-group">
                                <asp:Label CssClass="form-control" ID="Label2" runat="server"></asp:Label>
                            </div>

                        </div>
                        <div class="col-md-6">
                            <label>Date of birth</label>
                            <div class="form-group">
                                <asp:Label CssClass="form-control" ID="Label3" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        
                        <div class="col-md-6">
                            <label>Email address</label>
                            <div class="form-group">
                                <asp:Label CssClass="form-control" ID="Label5" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <label>State</label>
                            <div class="form-group">
                                <asp:Label CssClass="form-control" ID="Label6" runat="server"></asp:Label>
                            </div>

                        </div>
                    </div>


                    <div class="row">
                        
                        <div class="col-md-6">
                            <label>City</label>
                            <div class="form-group">
                                <asp:Label CssClass="form-control" ID="Label7" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Zip code</label>
                            <div class="form-group">
                                <asp:Label CssClass="form-control" ID="Label8" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <hr />

                    

                    
                    



                    

                </div>
            </div>

            <a href="homepage.aspx" ><< Home Page</a><br><br>

        </div>

        <div class="col-md-7">

            <div class="card">
                <div class="card-body">

                    <div class="row">
                        <div class="col">
                            <center>
                                <img width="100px" src="images/digital-drawing.png" />
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <asp:Label CssClass="form-control" ID="Label4" runat="server"></asp:Label>
                                
                                
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <asp:SqlDataSource runat="server" ConnectionString="<%$ ConnectionStrings:artisticnookDBConnectionString %>" SelectCommand="SELECT * FROM [addpost_master_table]" ID="ctl02"></asp:SqlDataSource>
                            <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" InsertVisible="False" SortExpression="id">
                                        <ItemStyle Font-Bold="True"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div class="container-fluid">
                                                <div class="row">
                                                    <div class="col-lg-2">
                                                        <a href='<%# "post.aspx?id=" + Eval("id") + "&img=" + Eval("post_img_link") %>'>
                                                        <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<% #Eval("post_img_link") %>' />
                                                            </a>
                                                    </div>
                                                    <div class="col-lg-10">
                                                        <div class ="row">
                                                            <div class="col-12">
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("title") %>' Font-Bold="True" Font-Size="Large"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class ="row">
                                                            <div class="col-12">
                                                                <span>Date: </span>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("date") %>' Font-Bold="True"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class ="row">
                                                            <div class="col-12">
                                                                <span>Description: </span>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("description") %>' Font-Bold="True"></asp:Label>
                                                            </div>
                                                        </div>
                                                      
                                                    </div>
                                
                                                </div>
                                            </div>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                                       

                </div>
            </div>

        </div>

    </div>
</div>

</asp:Content>
