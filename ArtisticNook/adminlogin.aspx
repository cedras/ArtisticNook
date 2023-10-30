<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="ArtisticNook.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="images/generaluser.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Admin Login</h3>
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
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control m-1" ID="TextBox1" runat="server" placeholder="Username"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control m-1" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:Button ID="Button1" class="btn btn-success w-100 m-1 btn-lg" runat="server" Text="Login" OnClick="Button1_Click" />

                                </div>
                               

                            </div>
                        </div>

                    </div>
                </div>

                <a href="homepage.aspx" ><< Home Page</a><br><br>

            </div>
        </div>
    </div>


</asp:Content>
