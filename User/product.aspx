<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="FOS.User.product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="align-self-lg-end">
        <asp:Label Text="Label" Visible="false" ID="lblmsg" runat="server" />
    </div>
    <asp:DataList ID="rProduct" runat="server" RepeatDirection="Horizontal" CellPadding="10" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" OnItemCommand="rProduct_ItemCommand">
        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
        <ItemTemplate>
            <div class="food-card">
                <div class="food-card_img">
                    <asp:Image ImageUrl='<%#Eval("Image") %>' runat="server" />
                </div>
                <div class="food-card_content">
                    <div class="food-card_title-section">
                        <asp:LinkButton ID="lbproduct" runat="server" class="food-card_author" CommandName="addToCart" CommandArgument='<%#Eval("Id") %>'><b><em><%#Eval("Name") %></em></b></asp:LinkButton>
                    </div>
                    <div class="food-card_price">
                        <span><%#Eval("Price") %></span>
                    </div>

                    <div class="food-card_price">
                        <span><%#Eval("C_Name") %></span>
                    </div>
                </div>
            </div>

        </ItemTemplate>
    </asp:DataList>
</asp:Content>
