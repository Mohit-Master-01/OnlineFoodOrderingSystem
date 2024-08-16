<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="OrderStatus.aspx.cs" Inherits="FOS.Admin.OrderStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="book_section Layout_padding">
        <div class="container">
            <div class="heading_container">
                <div class="align-self—end">
                    <asp:Label ID="LbIMsg" runat="server" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
        <div class="container">
            <asp:Repeater ID="r0rderItem" runat="server">
                <HeaderTemplate>
                    <table class="table table-responsive-sm table-bordered table-hover" id="tblInvoice">
                        <thead class="bg-dark text-white">
                            <tr>
                                <th>Sr.No</th>
                                <th>Order Number</th>
                                <th>Item Name</th>
                                <th>Unit Price</th>
                                <th>Quantity</th>
                                <th>Total Price</th>
                            </tr>
                        </thead>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("srno") %>
                        </td>
                        <td>
                            <%# Eval("OrderNo") %>
                        </td>
                        <td>
                            <%# Eval("Name") %>
                        </td>
                        <td>
                            <%# string.IsNullOrEmpty( Eval("Price").ToString() ) ? "" : "Rs." + Eval("Price") %>
                        </td>
                        <td>
                            <%# Eval("Quantity") %>
                        </td>
                        <td>Rs.<%# Eval("TotalPrice") %>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <table>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </section>
</asp:Content>
