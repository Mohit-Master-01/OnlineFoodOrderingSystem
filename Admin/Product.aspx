<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="FOS.Admin.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        /* for disappearing alert messages*/
        window.onload = function () {
            var seconds = 5;
            setTimeout(function () {
                document.get ElementsById("<%=txtName.Text %>").style.display = "name";
            }, seconds * 1000);
        };
    </script>
    <script>
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader(0){
                    reader.onload = function (e) {
                        $('#<%=imgProduct.ClientID%>').prep('src', e.target.result)
                            .width(200)
                            .height(200);
                    };
                reader.readAsDataURL(input.files[0])
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pcoded-inner-content pt-0">
        <div class="align-align-self-end">
            <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
        </div>
        <div class="main-body">
            <div class="page-wrapper">

                <div class="page-body">
                    <div class="row">
                        <div class="col-sm-12 ">
                            <div class="card">
                                <div class="card-header">
                                </div>
                                <div class="card-block">
                                    <div class="row">
                                        <div class="col-sm-6 col-md-4 col-lg-4">
                                            <h4 class="sub-title">Product</h4>
                                            <div>
                                                <div class="form-group">
                                                    <label>Product Name</label>
                                                    <div>
                                                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"
                                                            placeholder="Enter Product Name"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server"
                                                            ErrorMessage="Name is Required" ForeColor="Red" Display="Dynamic"
                                                            SetFocusOnError="true" ControlToValidate="txtName" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                                        <div hidden="hidden">
                                                            <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                </div>

                                                <div class="form-group">
                                                    <label>Product Price(₹)</label>
                                                    <div>
                                                        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"
                                                            placeholder="Enter Product Price"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server"
                                                            ErrorMessage="Price is Required" ForeColor="Red" Display="Dynamic"
                                                            SetFocusOnError="true" ControlToValidate="txtPrice" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <label>Product Quantity</label>
                                                    <div>
                                                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"
                                                            placeholder="Enter Product Quantity"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server"
                                                            ErrorMessage="Quantity is Required" ForeColor="Red" Display="Dynamic"
                                                            SetFocusOnError="true" ControlToValidate="txtQuantity" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                            ErrorMessage="Quantity must be non negative" ForeColor="Red" Display="Dynamic"
                                                            SetFocusOnError="true" ControlToValidate="txtQuantity"
                                                            ValidationExpression="^([1-9]\d*|0)$" ValidationGroup="Add"></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <label>Product Image</label>
                                                    <div>
                                                        <asp:FileUpload ID="fuProductImage" runat="server" CssClass="form-control" onchange="ImagePreview(this);" />
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <label>Product Category</label>
                                                    <div>
                                                        <asp:DropDownList ID="ddlCategories" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">Select Category</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator runat="server"
                                                            ErrorMessage="Category is Required" ForeColor="Red" Display="Dynamic"
                                                            SetFocusOnError="true" ControlToValidate="ddlCategories" InitialValue="0" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <div class="pb-5">
                                                    <asp:Button ID="btnAddorUpdate" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAddorUpdate_Click" OnClientClick="return confirm('Do you want to insert the product data')" ValidationGroup="Add"/>
                                                    &nbsp;
                                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-primary" CausesValidation="false" OnClick="btnClear_Click" />
                                                    &nbsp;
                                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" CausesValidation="false" OnClick="btnUpdate_Click" OnClientClick="return confirm('Do you want to update this category? ');" />

                                                </div>
                                                <div>
                                                    <asp:Image ID="imgProduct" runat="server" CssClass="img-thumbnail" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-8 col-lg-8 mobile-inputs">
                                            <h4 class="sub-title">Product Lists</h4>
                                            <div class="card-block table-border-style">
                                                <div class="table-responsive">
                                                    <asp:Repeater ID="rProduct" runat="server" OnItemCommand="rProduct_ItemCommand">
                                                        <HeaderTemplate>
                                                            <table class="table data-table-export table-hover nowrap">
                                                                <thead>
                                                                    <tr>
                                                                        <th>Id</th>
                                                                        <th class="table-plus">Name</th>
                                                                        <th>Image</th>
                                                                        <th>Price(₹)</th>
                                                                        <th>Qty</th>
                                                                        <th>Category</th>
                                                                        <th>CreatedData</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody class="align-content-center">
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td class="align-content-center"><%# Eval("Id")%></td>
                                                                <td class="table-plus"><%# Eval("Name")%></td>
                                                                <td class="align-content-center">
                                                                    <asp:Image ID="image" Width="100px" Height="100px" runat="server" ImageUrl='<%# Eval("Image") %>' />
                                                                </td>
                                                                <td class="align-content-center"><%# Eval("Price") %></td>
                                                                <td class="align-content-center"><%# Eval("Quantity") %></td>
                                                                <td class="align-content-center"><%# Eval("C_Name") %></td>
                                                                <td class="align-content-center"><%# Eval("Date") %></td>
                                                                <td>
                                                                    <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" CssClass="badge badge-primary"
                                                                        CommandArgument='<%# Eval("Id") %>' CommandName="edit">
                                                                                <i class="ti-pencil"></i>
                                                                    </asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" CssClass="badge bg-danger"
                                                                        CommandArgument='<%# Eval("Id") %>' CommandName="delete" OnClientClick="return confirm('Do you want to delete this category? ');">
                                                                                <i class="ti-trash"></i>
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

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
