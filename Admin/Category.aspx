<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="FOS.Admin.Category" %>

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
    <script>
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgCategory.ClientID %>').prop('src', e.target.result)
                        .width(200)
                        .height(200);
                };
                reader.readAsDataURL(input.files[0]);
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
                        <div class="col-sm-12">
                            <div class="card">
                                <div class="card-holder">
                                    <div class="card-block">
                                        <div class="row">

                                            <div class="col-sm-6 col-md-4 col-lg-4">
                                                <h4 class="sub-title">Category</h4>
                                                <div>
                                                    <div class="form-group">
                                                        <div hidden="hidden">

                                                            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>

                                                        </div>
                                                        <div>
                                                            <label>Category Name</label>
                                                            <div>
                                                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter Category Name" required="True" CausesValidation="True" ValidationGroup="Add"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfv_Name" runat="server" ErrorMessage="*Name is required" ControlToValidate="txtName" Font-Bold="True" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>Category Image<br />
                                                            <asp:RequiredFieldValidator ID="rfv_Image" runat="server" ErrorMessage="*Enter Image File" ControlToValidate="fuCategoryImage" Font-Bold="True" ForeColor="Red" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                                            
                                                            </label>
                                                            &nbsp;<div>
                                                                <asp:FileUpload ID="fuCategoryImage" runat="server" CssClass="form-control" onchange="ImagePreview(this);" />
                                                            </div>
                                                        </div>

                                                        <div class="pb-5">
                                                            <asp:Button ID="btnAddorUpdate" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAddorUpdate_Click" OnClientClick="return confirm('Do you want to add this category? ')" ValidationGroup="Add" />
                                                            &nbsp; &nbsp;
                                                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-primary" CausesValidation="false" OnClick="btnClear_Click" />
                                                            &nbsp; &nbsp;
                                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" CausesValidation="false" OnClick="btnUpdate_Click" OnClientClick="return confirm('Do you want to update this category? ');" ValidationGroup="Add" />
                                                        </div>
                                                        <div>
                                                            <asp:Image ID="imgCategory" runat="server" CssClass="img-thumbnail" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-6 col-md-8 col-lg-8 mobile-inputs">
                                                <h4 class="sub-title">Category Lists</h4>
                                                <div class="card-block table-border-style">
                                                    <div class="table-responsive">
                                                        <asp:Repeater ID="rCategory" runat="server" OnItemCommand="rCategory_ItemCommand">
                                                            <HeaderTemplate>
                                                                <table class="table data-table-export table-hover nowrap">
                                                                    <thead>
                                                                        <tr>
                                                                            <th class="table-plus">Id</th>
                                                                            <th>Name</th>
                                                                            <th>Image</th>
                                                                            <th>Date</th>
                                                                            <th class="datatable-nosort">Action</th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td class="table-plus"><%# Eval("Id") %></td>
                                                                    <td><%# Eval("Name") %></td>
                                                                    <td class="align-content-center">
                                                                        <asp:Image ID="image" Width="100px" Height="100px" runat="server" ImageUrl='<%# Eval("Image") %>' />
                                                                    </td>
                                                                    <td><%# Eval("Date") %></td>
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
    </div>
</asp:Content>
