<%@ Page Title="" Language="C#" MasterPageFile="Shop.Master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="ShoppingCart.Details" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BookSelection" runat="server">
    <br />
    <div class="container">
        <div class="row">
            <div class="col-lg-4 col-md-6 mb-4">
                <div class="card h-100">
                    <asp:Image ID="ImgBook" CssClass="card-img-top" runat="server" />
                    <div class="card-body">
                        <asp:Label ID="Query" runat="server" />
                        <asp:Label ID="Name" CssClass="card-title" runat="server"/><br />
                        <asp:Label ID="Author" CssClass="card-subtitle" runat="server"/><br />
                        <asp:Label ID="Price" CssClass="card-subtitle" runat="server"/><br />
                    </div>
                </div>
            </div>
            <div class="col-lg-8 col-md-6 mb-4">
                <div class="card h-100">
                    <div class="card-body">
                        <asp:Label ID="Summary" CssClass="card-text" runat="server"/>
                        <br />
                        <br />
                        <div class="row">
                            <div class="container">
                                <asp:Button ID="AddCart" CssClass="btn btn-primary" runat="server" Text="Add to Cart" OnClick="AddCart_Click"/>
                                <asp:Button ID="GoCart" CssClass="btn btn-secondary" runat="server" Text="Go to Cart" PostBackUrl="Cart.aspx" />
                            </div>
                        </div>
                    </div>
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
