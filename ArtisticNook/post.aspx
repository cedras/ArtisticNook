<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="post.aspx.cs" Inherits="ArtisticNook.post" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
    <style type="text/css">
        .font-weight-bold {
            font-weight: bold;
        }
        .user-image {
        width: 20px; 
        height: auto; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <a href='<%# "viewprofile.aspx?user_id=" + Eval("user_id")  %>'>
                                    <asp:Label CssClass="form-control" ID="Label6" runat="server"></asp:Label>
                                        </a>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div id="dvPreview">
                                    <!-- Display the post image here -->
                                    <asp:Image ID="PostImage" runat="server" CssClass="img-fluid" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Post Details</h4>
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
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 p-2">
                                <label>Title</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:Label CssClass="form-control" ID="Label1" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 p-2">
                                <label>Description</label>
                                <div class="form-group">
                                    <asp:Label CssClass="form-control" ID="Label2" runat="server" TextMode="MultiLine"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 p-2">
                                <label>Art Category</label>
                                <div class="form-group">
                                    <asp:Label CssClass="form-control" ID="Label3" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6 p-2">
                                <label>Art Style</label>
                                <div class="form-group">
                                    <asp:Label CssClass="form-control" ID="Label4" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-12 p-2">
                                <label>Subject Matter</label>
                                <div class="form-group">
                                    <asp:Label CssClass="form-control" ID="Label5" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <asp:Button ID="LikeButton" runat="server" Text="Like" OnClick="LikeButton_Click" CssClass="btn btn-primary btn-lg btn-full-width" title="Like this artwork" />
                                </div>
                                <div class="col d-flex align-items-center">
                                    <asp:Label ID="LikeCountLabel1" runat="server" CssClass="like-count">
                                        <i class="far fa-thumbs-up fa-pad-right"></i> 
                                    </asp:Label>
                                    <asp:Label ID="LikeCountLabel" runat="server" CssClass="like-count">
                                        <i class="far fa-thumbs-up fa-pad-right"></i> Like
                                    </asp:Label>
                                </div>
                                
                            <div class="row mt-3">
                                <div class="col-md-12">
                                    <h4>Comments</h4>
                                    <asp:Repeater ID="CommentRepeater" runat="server" OnItemDataBound="CommentRepeater_ItemDataBound">
                                        <ItemTemplate>
                                            <div>
                                                <div class="d-flex justify-content-between">
                                                    <div>
                                                        <img src="images/generaluser.png" alt="User Image" class="user-image" />
                                                        <a href='<%# "viewprofile.aspx?user_id=" + Eval("user_id")  %>'>
                                                        <asp:Label ID="UsernameLabel" runat="server" Text='<%# Eval("username") %>' CssClass="font-weight-bold"></asp:Label>
                                                            </a>
                                                    </div>
                                                    <div>
                                                        <asp:Label ID="CommentDateLabel" runat="server" Text='<%# Eval("comment_date") %>' CssClass="text-right"></asp:Label>
                                                        <asp:Button ID="DeleteCommentButton" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm" OnClick="DeleteCommentButton_Click" CommandArgument='<%# Eval("id") %>' />
                                                    </div>
                                                </div>
                                                <p>
                                                    <asp:Label ID="CommentLabel" runat="server" Text='<%# Eval("comment_text") %>'></asp:Label>
                                                </p>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="col-md-12">
                                    <asp:TextBox ID="CommentTextBox" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" placeholder="Add a comment..."></asp:TextBox>
                                    <asp:Button ID="PostCommentButton" runat="server" Text="Post Comment" CssClass="btn btn-primary mt-2" OnClick="PostCommentButton_Click" />
                                </div>
                            </div>
                        </div>
                        
                    </div>
                </div>
                <br />
            </div>
        </div>
    </div>
        </div>
    </asp:Content>