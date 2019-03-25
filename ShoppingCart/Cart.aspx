<%@ Page Title="" Language="C#" MasterPageFile="Shop.Master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="ShoppingCart.Cart" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BookSelection" runat="server">
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="lblStatus" runat="server" Text="Your cart is empty" Visible="False"></asp:Label>
                <asp:Panel ID="panel" runat="server" Visible="False"></asp:Panel>
                <br />
                <asp:Button ID="submit" CssClass="btn btn-primary" runat="server" OnClick="Submit_Click" Text="Checkout" Visible="False"/>
            </div>
            <div id="formCheck" class="col-md-6" runat="server" Visible="false">
                <div class="container card h-100">
                    <br />
                    <div class="row">
                        <div class="align-text-end col-sm-3">
                            <asp:Label runat="server" Text="Price: "></asp:Label><br />
                            <asp:Label runat="server" Text="Shipping: "></asp:Label><br />
                            <asp:Label runat="server" Text="Total: "></asp:Label><br />
                        </div>
                        <div>
                            <asp:Label ID="lblPrice" runat="server"></asp:Label><br />
                            <asp:Label ID="lblShip" runat="server"></asp:Label><br />
                            <asp:Label ID="lblTotal" runat="server"></asp:Label><br />
                        </div>
                    </div>
                    <br />
                    <b>Billing Info</b>
                    <div class="form-group">
                        <asp:Label ID="lblName" AssociatedControlID="txtName" CssClass="col-sm-12 control-label" runat="server">Name:</asp:Label>
                        <div class="col-sm-12">
                            <input id="txtName" class="form-control" runat="server" required>
                        </div>
                        <asp:Label ID="lblStreet" AssociatedControlID="txtStreet" CssClass="col-sm-12 control-label" runat="server">Street:</asp:Label>
                        <div class="col-sm-12">
                            <input id="txtStreet" class="form-control" runat="server" required>
                        </div>
                        <asp:Label ID="lblCity" AssociatedControlID="txtCity" CssClass="col-sm-12 control-label" runat="server">City:</asp:Label>
                        <div class="col-sm-12">
                            <input id="txtCity" class="form-control" runat="server" required>
                        </div>
                        <asp:Label ID="lblState" AssociatedControlID="txtState" CssClass="col-sm-12 control-label" runat="server">State:</asp:Label>
                        <div class="col-sm-12">
                            <input id="txtState" class="form-control" runat="server" required>
                        </div>
                        <asp:Label ID="lblZip" AssociatedControlID="txtZip" CssClass="col-sm-12 control-label" runat="server">Zip:</asp:Label>
                        <div class="col-sm-12">
                            <input id="txtZip" class="form-control" runat="server" required>
                        </div>
                        <asp:Label ID="lblEmail" AssociatedControlID="txtEmail" CssClass="col-sm-12 control-label" runat="server">Email:</asp:Label>
                        <div class="col-sm-12">
                            <input ID="txtEmail" class="form-control" runat="server" required>
                        </div>
                        <br />
                        <div class="col-sm-10">
                            <asp:Button ID="order" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="Order_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
