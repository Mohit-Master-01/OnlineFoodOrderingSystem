<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="FOS.Admin.OrderHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        //For disappearing alert message
        window.onload = function () {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=lblMsg.ClientID %>").style.display = "none";
            }, seconds * 1000);
        };
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <div class="pcoded-inner-content pt-0">
            <div class="align-align-self-end">
                <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
            </div>
            <div class="main-body">
                <div class="page-wrapper">
                    <div class="page-body">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="card">
                                    <div class="card-holder">
                                        <div class="card-block">
                                            <div class="row">

                                                <div class="col-sm-6 col-md-8 col-lg-8">
                                                    <h4 class="sub-title">Order List</h4>

                                                    <div class="card-block table-border-style">
                                                        <div class="table-responsive">

                                                            <asp:Repeater ID="rOrderStatus" runat="server" OnItemCommand="rOrderStatus_ItemCommand">
                                                                <HeaderTemplate>
                                                                    <table class="table data-table-export table-hover nowrap">
                                                                        <thead>
                                                                            <tr>
                                                                                <th class="table-plus">Order No.</th>
                                                                                <th>Order Date</th>
                                                                                <th>Status</th>
                                                                                <th>Product Name</th>
                                                                                <th>Total Price</th>
                                                                                <th>Payment Mode</th>
                                                                                <th class="datatable-nosort">Edit</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td class="table-plus"><%# Eval("Id") %></td>
                                                                        <td><%# Eval("OrderDate") %></td>
                                                                        <td>
                                                                             <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>' CssClass='<%# Eval("Status").ToString() == "Delivered" ? "badge badge-success" : "badge badge-warning" %>'></asp:Label></td>
                                                                        <td><%# Eval("Name") %></td>
                                                                        <td><%# Eval("TotalPrice") %></td>
                                                                        <td> <%# Eval("Type").ToString() == "cod" ? "Cash On Delivery" : Eval("Type").ToString().ToUpper() %></td>
                                                                        <td>
                                                                            <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" CssClass="badge badge-primary"
                                                                                CommandArgument='<%# Eval("Id") %>' CommandName="edit">
                                                                            <i class="ti-pencil"></i>
                                                                            </asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    </tbody>
                </table>
                                                                </FooterTemplate>
                                                            </asp:Repeater>

                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="col-sm-6 col-md-4 col-lg-4 mobile-inputs">

                                                    <asp:Panel ID="pUpdateOrderStatus" runat="server">
                                                        <h4 class="sub-title">Update Status</h4>
                                                        <div>
                                                            <div class="form-group">
                                                                <div hidden="hidden">

                                                                    <asp:TextBox ID="txtId" runat="server"></asp:TextBox>

                                                                </div>
                                                                <div>
                                                                    <label>Order Status</label>
                                                                    <div>
                                                                        <asp:DropDownList ID="ddlOrderStatus" runat="server" CssClass="form-control">
                                                                            <asp:ListItem Value="0">Select Status</asp:ListItem>
                                                                            <asp:ListItem>Ongoing</asp:ListItem>
                                                                            <asp:ListItem>Delivered</asp:ListItem>
                                                                            <asp:ListItem>Cancelled</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="rfvDdlOrderStatus" runat="server" ForeColor="Red" ControlToValidate="ddlOrderStatus" ErrorMessage="Order status is required" SetFocusOnError="true" dsiplay="dynamic">
                                                                        </asp:RequiredFieldValidator>
                                                                    <asp:HiddenField ID="hdhId" runat="server" Value="0"/>
                                                                    </div>
                                                                </div>


                                                                <div class="pb-5">

                                                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary"
                                                                        CausesValidation="false" OnClientClick="btnUpdate_Click" OnClick="btnUpdate_Click" />

                                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-primary"
                                                                        OnClientClick="btnCancel_Click"  OnClick="btnCancel_Click"/>

                                                                    &nbsp; &nbsp;
                                                                
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
</asp:Content>
