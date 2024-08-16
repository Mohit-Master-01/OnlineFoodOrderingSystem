<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="FOS.User.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        window.onload = function () {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=lblMsg.ClientID %>").style.display = "none";
            }, seconds = 1000);
        };
    </script>
    <%--    <script>
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%# imgProduct.ClientID%>').prop('src', e.target.result)
                        .width(200)
                        .height(200);
                };
                reader.raedAsDataURL(input.files[0]);
            }
        }
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="book_section layout_padding">
        <div class="container">
            <div class="heading_container">
                <div class="align-self-end">
                    <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
                </div>
                <asp:Label ID="blHeaderMsg" runat="server" Text="<h2>User Registration<?h2>"></asp:Label>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form_container">
                        <div>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Name Is required" ControlToValidate="txtName"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revName" runat="server" ErrorMessage="Name must be in character only"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^[a-zA-Z\s]+$"
                                ControlToValidate="txtName"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter Full Name"
                                ToolTip="Full Name"></asp:TextBox>
                        </div>
                        <div>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvusername" runat="server" ErrorMessage="username Is required" ControlToValidate="txtusername"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtusername" runat="server" CssClass="form-control" placeholder="Enter Username"
                                ToolTip="username"></asp:TextBox>

                        </div>

                        <div>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvemail" runat="server" ErrorMessage="Email Is required" ControlToValidate="txtusername"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" placeholder="Enter Email"
                                ToolTip="email"></asp:TextBox>

                        </div>

                        <div>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvmobile" runat="server" ErrorMessage="mobile no. Is required" ControlToValidate="txtName"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revmobile" runat="server" ErrorMessage="mobile no. must be have 10 digits"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^[0-9]{10}$"
                                ControlToValidate="txtmobile"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txtmobile" runat="server" CssClass="form-control" placeholder="Enter mobile number"
                                ToolTip="mobile number"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form_container">
                        <div>
                            <asp:RequiredFieldValidator ID="rfvaddress" runat="server" ErrorMessage="Address Is required" ControlToValidate="txtaddress"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control" placeholder="Enter Address"
                                ToolTip="Address" TextMode="MultiLine"></asp:TextBox>

                        </div>
                        <div>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvpostcode" runat="server" ErrorMessage="post/zip code Is required" ControlToValidate="txtpostcode"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revpostcode" runat="server" ErrorMessage="post/zip code must be of 6 digits"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^[0-9]{6}$"
                                ControlToValidate="txtpostcode"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txtpostcode" runat="server" CssClass="form-control" placeholder="Enter post/zip code"
                                ToolTip="post/zip code"></asp:TextBox>
                        </div>

                        <div>
                            <br />
                            <asp:FileUpload ID="fuuserimage" runat="server" CssClass="form-control" ToolTip="User Image" Onchange="ImagePreview(this);" />
                        </div>


                        <div>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="mobile no. Is required" ControlToValidate="txtPassword"
                                ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password"
                                ToolTip="Password" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row pl-4">
                    <div class="btn_box">
                        <br />
                        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-success rounded-pill pl-4 pr-4 text-white" OnClick="btnRegister_Click" />

                        <asp:Label ID="lblAlreadyUser" runat="server" CssClass="pl-3 text-black-100" Text="Already registered?"> 
                            <a href="Login.aspx" class='badge badge-info text-dark'>Login Here..</a>
                        </asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
