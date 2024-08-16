<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FOS.User._default" %>
<%@ Import Namespace="FOS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!--Slider-->
    <div id="home" class="carousel slide" data-bs-ride="carousel">
        <div class="carousel-inner">
            <div class="carousel-item text-center  vh-100 active slide-1">
                <div class="container h-100 d-flex align-items-center justify-content-center">
                    <div class="row justify-content-center">
                        <div class="col-lg-8">
                            <h6 class="text-white">Welcome to QuickEats</h6>
                            <h1 class="display-1 text-white">Filled with Flavor</h1>
                            <asp:Button runat="server" ID="btn_order" CssClass="btn btn-brand" Text="Order Now" OnClick="order_click"/>
                        </div>
                    </div>
                </div>
            </div>
            <div class="carousel-item b vh-100 text-center slide-2">
                <div class="container h-100 d-flex align-items-center justify-content-center">
                    <div class="row justify-content-center">
                        <div class="col-lg-8">
                            <h6 class="text-white">Welcome to QuickEats</h6>
                            <h1 class="display-1 text-white">Fresh and Tasty</h1>
                            <asp:Button runat="server" ID="btn_order2" CssClass="btn btn-brand" Text="Order Now" OnClick="order_click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleAutoplaying"
            data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleAutoplaying"
            data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>
    <!--Menu-->
    <section class="main-content" id="menu">
        <div class="container">
            <h1 class="text-center text-uppercase">Our Menu</h1>
            <br />
            <br />
            <div class="row grid">
                <%--   <div class="col-sm-6 col-md-6 col-lg-4">
                <div class="food-card">
                    <div class="food-card_img">
                        <img src="https://i.imgur.com/eFWRUuR.jpg" alt="">
                        <a href="#!"><i class="far fa-heart"></i></a>
                    </div>
                    <div class="food-card_content">
                        <div class="food-card_title-section">
                            <a href="#!" class="food-card_title">Double Cheese Potato Burger</a>
                            <a href="#!" class="food-card_author">Burger</a>
                        </div>
                        <div class="food-card_bottom-section">
                            <div class="space-between">
                                <div>
                                    <span class="fa fa-fire"></span> 220 - 280 Kcal
                                </div>
                                <div class="pull-right">
                                    <span class="badge badge-success">Veg</span>
                                </div>
                            </div>
                            <hr>
                            <div class="space-between">
                                <div class="food-card_price">
                                    <span>5.99$</span>
                                </div>
                                <div class="food-card_order-count">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <button class="btn btn-outline-secondary minus-btn" type="button" id="button-addon1"><i class="fa fa-minus"></i></button>
                                        </div>
                                        <input type="text" class="form-control input-manulator" placeholder="" aria-label="Example text with button addon" aria-describedby="button-addon1" value="0">
                                        <div class="input-group-append">
                                            <button class="btn btn-outline-secondary add-btn" type="button" id="button-addon1"><i class="fa fa-plus"></i></button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>--%>
                <div class="col-lg-12">
                    <asp:DataList ID="rorderItem" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" CellPadding="10" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" OnItemCommand="rorderItem_ItemCommand">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <div class="food-card">
                                <div class="food-card_img">
                                    <asp:Image ImageUrl='<%#Eval("Image") %>' runat="server" />
                                </div>
                                <div class="food-card_content">
                                    <div class="food-card_title-section">
                                        <asp:LinkButton runat="server" ID="lbaddToProduct" CommandName="addToProduct" CssClass="food-card_author" 
                                            CommandArgument='<%#Eval("Id")%>'><b><em><%#Eval("Name") %></em></b></asp:LinkButton>
                                    </div>
                                    <div class="food-card_price">
                                        <span><%#Eval("Type") %></span>
                                    </div>
                                </div>
                            </div>

                        </ItemTemplate>
                        <SelectedItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                        <SeparatorStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                    </asp:DataList>
                </div>
            </div>
        </div>
    </section>

    <!--about us-->
    <section id="about">
        <div class="container">
            <div class="row">
                <div class="col-lg-4">
                    <img src="../assests/Images/about.jpg" alt="" />
                </div>
            </div>
        </div>
    </section>
    <!-- Order now -->
    <section id="order">
        <div>
            <div class="container">
                <div class="row">
                    <div class="col-12 intro-text justify-content-center">
                        <h1>Treat Yourself to a Feast - Order Now!</h1>
                    </div>
                </div>

                <div class="col-lg-8">
                    <div class="row justify-content-center">
                        <div class="form-group col-md-6">
                            <input type="text" class="form-control" placeholder="Full Name" />
                        </div>
                        <div class="form-group col-md-6">
                            <input type="text" class="form-control" placeholder="Last Name" />
                        </div>
                        <div class="form-group col-md-6">
                            <input type="text" class="form-control" placeholder="E-mail" />
                        </div>
                        <div class="form-group col-md-6">
                            <input type="text" class="form-control" placeholder="Mobile No." />
                        </div>

                        <div class="form-group col-md-2">
                            <asp:Button runat="server" ID="btnorder" Text="Order Now" OnClick="order_click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>


    <!--Feedback-->
    <section id="feedback" class="bg-cover">
        <div class="container-fluid">
            <div class="row intro-text">
                <div class="col-12 justify-content-center">

                    <h3 class="text-white">
                        <b class=" logo-text">"</b>See why others are raving about our delicious food and
                        exceptional service!<b>"</b>
                    </h3>
                    &nbsp;
                </div>
            </div>
        </div>
        <div id="feedbackSlider" class="carousel slide">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#feedbackSlider" data-bs-slide-to="0" class="active"
                    aria-current="true" aria-label="Slide 1">
                </button>
                <button type="button" data-bs-target="#feedbackSlider" data-bs-slide-to="1"
                    aria-label="Slide 2">
                </button>
            </div>

            <div class="carousel-inner">

                <div class="carousel-item active">
                    <div class="container-fluid">
                        <div class="row justify-content-center">
                            <div class="col-lg-8">
                                <div class="feedback bg-white p-5 text-center">

                                    <p class="mb-0">
                                        “This is always our breakfast stop before heading home from
                                            vacation. Always delicious. Always great service. Always worth the stop.” –
                                            Kristine R.
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="carousel-item">
                    <div class="container-fluid">
                        <div class="row justify-content-center">
                            <div class="col-lg-8">
                                <div class="feedback bg-white p-5 text-center">
                                    <p class="mb-0">
                                        “This is always our breakfast stop before heading home from
                                            vacation. Always delicious. Always great service. Always worth the stop.” –
                                            Kristine R.
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


            </div>
        </div>

    </section>

</asp:Content>
