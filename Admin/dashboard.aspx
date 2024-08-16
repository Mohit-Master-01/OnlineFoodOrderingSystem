<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="FOS.Admin.dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="pcoded-inner-content">
        <div class="main-body">
            <div class="page-wrapper">
                <div class="page-body">
                    <div class="row">

                        <div class="col-md-6 col-xl-3">
                            <div class="card widget-card-1">
                                <div class="card-block-small">
                                    <i class="icofont icofont-lunch bg-c-blue card1-icon"></i>
                                    <span class="text-c-blue f-w-600">Categories</span>
                                    
                                        <h4 class="text-c-blue f-w-600"><%Response.Write(Session["Category"]); %></h4>
                                    
                                    <div>
                                        <span class="f-left m-t-10 text-muted ">
                                            <a href="category.aspx"><i class="text-c-blue f-16  icofont icofont-eye-alt m-r-10"></i>View Details</a>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6 col-xl-3">
                            <div class="card widget-card-1">
                                <div class="card-block-small">
                                    <i class="icofont icofont-fast-food bg-c-pink card1-icon"></i>
                                    <span class="text-c-pink f-w-600">Products</span>
                                    
                                        <h4 class="text-c-pink f-w-600"><%Response.Write(Session["Product"]); %></h4>
                                    
                                    <div>
                                        <div>
                                            <span class="f-left m-t-10 text-muted ">
                                                <a href="Product.aspx"><i class="text-c-blue f-16  icofont icofont-eye-alt m-r-10"></i>View Details</a>
                                            </span>
                                        </div>
                                    </div>
                                    </div>
                            </div>
                        </div>

                        <div class="col-md-6 col-xl-3">
                            <div class="card widget-card-1">
                                <div class="card-block-small">
                                    <i class="icofont icofont-spoon-and-fork bg-c-green card1-icon"></i>
                                    <span class="text-c-green f-w-600">Total Orders</span>

                                    <h4 class="text-c-green f-w-600"><%Response.Write(Session["TotalOrders"]); %></h4>
                                    <div>
                                        <span class="f-left m-t-10 text-muted ">
                                            <a href="#"><i class="text-c-blue f-16  icofont icofont-eye-alt m-r-10"></i>View Details</a>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6 col-xl-3">
                            <div class="card widget-card-1">
                                <div class="card-block-small">
                                    <i class="icofont icofont-fast-delivery bg-c-orenge card1-icon"></i>
                                    <span class="text-c-orenge f-w-600">delivered Item</span>

                                    <h4 class="text-c-orenge f-w-600"><%Response.Write(Session["Delivered"]); %></h4>
                                    <div>
                                        <span class="f-left m-t-10 text-muted ">
                                            <a href="OrderStatus.aspx"><i class="text-c-blue f-16  icofont icofont-eye-alt m-r-10"></i>View Details</a>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="row">

                        <div class="col-md-6 col-xl-3">
                            <div class="card widget-card-1">
                                <div class="card-block-small">
                                    <i class="icofont icofont-delivery-time bg-c-yellow card1-icon"></i>
                                    <span class="text-c-yellow f-w-600">Pending Item</span>

                                    <h4 class="text-c-yellow f-w-600"><%Response.Write(Session["Pending"]); %></h4>
                                    <div>
                                        <span class="f-left m-t-10 text-muted ">
                                            <a href="OrderStatus.aspx"><i class="text-c-blue f-16  icofont icofont-eye-alt m-r-10"></i>View Details</a>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6 col-xl-3">
                            <div class="card widget-card-1">
                                <div class="card-block-small">
                                    <i class="icofont icofont-users-social bg-c-lite-green card1-icon"></i>
                                    <span class="text-c-lite-green f-w-600">Users</span>

                                    <h4 class="text-c-lite-green f-w-600"><%Response.Write(Session["User"]); %></h4>
                                    <div>
                                        <span class="f-left m-t-10 text-muted ">
                                            <a href="UserFeedback.aspx"><i class="text-c-blue f-16  icofont icofont-eye-alt m-r-10"></i>View Details</a>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6 col-xl-3">
                            <div class="card widget-card-1">
                                <div class="card-block-small">
                                    <i class="icofont icofont-money-bag bg-c-green card1-icon"></i>
                                    <span class="text-c-green f-w-600">Sold Amount</span>

                                    <h4 class="text-c-green f-w-600"><%Response.Write(Session["Amount"]); %></h4>
                                    <div>
                                        <span class="f-left m-t-10 text-muted ">
                                            <a href="Report.aspx"><i class="text-c-blue f-16  icofont icofont-eye-alt m-r-10"></i>View Details</a>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6 col-xl-3">
                            <div class="card widget-card-1">
                                <div class="card-block-small">
                                    <i class="icofont icofont-support-faq bg-c-lite-green card1-icon"></i>
                                    <span class="text-c-lite-green f-w-600">Feedbacks</span>

                                    <h4 class="text-c-lite-green f-w-600"><%Response.Write(Session["Feedback"]); %></h4>
                                    <div>
                                        <span class="f-left m-t-10 text-muted ">
                                            <a href="UserFeedback.aspx"><i class="text-c-blue f-16  icofont icofont-eye-alt m-r-10"></i>View Details</a>
                                        </span>
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
