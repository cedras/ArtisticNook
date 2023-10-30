<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="posts.aspx.cs" Inherits="ArtisticNook.posts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/stylesheet1.css" rel="stylesheet" />
    <style type="text/css">
        .container {
            display: grid;
            grid-template-columns: repeat(3, 1fr);
            gap: 10px;
        }

        .post {
            border: 1px solid #ddd;
            padding: 20px;
            text-align: center;
            position: relative;
        }

        .post-image {
            max-width: 100%;
            height: 200px;
            display: block;
            width: 100%;
        }

        .post-overlay {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0.5);
            opacity: 0;
            transition: opacity 0.3s;
        }

        .post-info {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            text-align: center;
            color: white;
            display: none;
        }

        .post:hover .post-overlay {
            opacity: 1;
        }

        .post:hover .post-info {
            display: block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center"> 
        <div class="filter-controls">
            <asp:DropDownList ID="ddlFilter" runat="server">
                <asp:ListItem Text="Newest Posts" Value="newest"></asp:ListItem>
                <asp:ListItem Text="Oldest Posts" Value="oldest"></asp:ListItem>
                <asp:ListItem Text="Most Liked" Value="mostliked"></asp:ListItem>
            </asp:DropDownList>
                <asp:DropDownList ID="ddlCategoryFilter" runat="server">
                <asp:ListItem Text="All Categories" Value=""></asp:ListItem>
                <asp:ListItem Text="Painting" Value="Painting"></asp:ListItem>
                <asp:ListItem Text="Drawing" Value="Drawing"></asp:ListItem>
                <asp:ListItem Text="Photography" Value="Photography"></asp:ListItem>
                <asp:ListItem Text="Digital Art" Value="Digital Art"></asp:ListItem>
                <asp:ListItem Text="Mixed Media" Value="Mixed Media"></asp:ListItem>
                <asp:ListItem Text="Sculpture" Value="Sculpture"></asp:ListItem>
            </asp:DropDownList>

            <asp:DropDownList ID="ddlArtStyleFilter" runat="server">
                <asp:ListItem Text="All Styles" Value=""></asp:ListItem>
                <asp:ListItem Text="Abstract" Value="Abstract"></asp:ListItem>
                <asp:ListItem Text="Realism" Value="Realism"></asp:ListItem>
            </asp:DropDownList>

            <asp:DropDownList ID="ddlSubjectMatterFilter" runat="server">
                <asp:ListItem Text="All Subjects" Value=""></asp:ListItem>
                <asp:ListItem Text="Portrait" Value="PT"></asp:ListItem>
                <asp:ListItem Text="Landscape" Value="LA"></asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnApplyFilter" runat="server" Text="Apply Filter" OnClick="btnApplyFilter_Click" />
        </div>
    </div>
    <br />

    <div class="container">
        <asp:Repeater ID="PostRepeater" runat="server">
            <ItemTemplate>
                <div class="post">
                    <a href='<%# "post.aspx?id=" + Eval("id") + "&img=" + Eval("post_img_link") %>'>
                        <div class="post-image-container">
                            <asp:Image class="post-image" ID="Image1" runat="server" ImageUrl='<%# Eval("post_img_link").ToString() %>' />
                            <div class="post-overlay">
                                <div class="post-info">
                                    <p>Artist: <%# Eval("username") %></p>
                                    <p class="post-date">Date: <%# Eval("date") %></p>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>






