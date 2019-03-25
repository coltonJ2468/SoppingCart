<%@ Page Title="" Language="C#" MasterPageFile="Shop.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ShoppingCart.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BookSelection" runat="server">
    
    <div class="container">
        <div class="col-md-8">
            <div id="carouselExampleIndicators" class="carousel slide my-4" data-ride="carousel">
                <ol class="carousel-indicators">
                    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                </ol>
                <div class="carousel-inner" role="listbox">
                    <div class="carousel-item active">
                        <img class="d-block img-fluid" src="CarouselImgs/BadWithMoney.jpg" alt="First slide">
                    </div>
                    <div class="carousel-item">
                        <img class="d-block img-fluid" src="CarouselImgs/TheyBothDie.jpg" alt="Second slide">
                    </div>
                    <div class="carousel-item">
                        <img class="d-block img-fluid" src="CarouselImgs/Educated.jpg" alt="Third slide">
                    </div>
                </div>
                <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>
        <div class="row">

            <div class="col-lg-4 col-md-6 mb-4">
                <div class="card h-100">
                    <a onserverclick="GetDetails" runat="server" href="#" title="Bad With Money"><img class="card-img-top" src="CardImgs/BadWithMoney.jpg" alt=""></a>
                    <div class="card-body">
                        <h4 class="card-title">
                            <a onserverclick="GetDetails" runat="server" href="#" title="Bad With Money">Bad With Money</a>
                        </h4>
                        <p class="card-subtitle">Gaby Dunn</p>
                        <h5>$11.00</h5>
                    </div>
                </div>
            </div>

            <div class="col-lg-4 col-md-6 mb-4">
                <div class="card h-100">
                    <a onserverclick="GetDetails" runat="server" href="#" title="They Both Die at the End"><img class="card-img-top" src="CardImgs/TheyBothDie.jpg" alt=""></a>
                    <div class="card-body">
                        <h4 class="card-title">
                            <a onserverclick="GetDetails" runat="server" href="#" title="They Both Die at the End">They Both Die at the End</a>
                        </h4>
                        <p class="card-subtitle">Adam Silvera</p>
                        <h5>$12.59</h5>
                    </div>
                </div>
            </div>

            <div class="col-lg-4 col-md-6 mb-4">
                <div class="card h-100">
                    <a onserverclick="GetDetails" runat="server" href="#" title="Educated"><img class="card-img-top" src="CardImgs/Educated.jpg" alt=""></a>
                    <div class="card-body">
                        <h4 class="card-title">
                            <a onserverclick="GetDetails" runat="server" href="#" title="Educated">Educated</a>
                        </h4>
                        <p class="card-subtitle">Tara Westover</p>
                        <h5>$16.80</h5>
                    </div>
                </div>
            </div>

            <div class="col-lg-4 col-md-6 mb-4">
                <div class="card h-100">
                    <a onserverclick="GetDetails" runat="server" href="#" title="The Life-Changing Magic of Tidying Up"><img class="card-img-top" src="CardImgs/TidyingUp.jpg" alt=""></a>
                    <div class="card-body">
                        <h4 class="card-title">
                            <a onserverclick="GetDetails" runat="server" href="#" title ="The Life-Changing Magic of Tidying Up">The Life-Changing Magic of Tidying Up</a>
                        </h4>
                        <p class="card-subtitle">Marie Kondo</p>
                        <h5>$9.69</h5>
                    </div>
                </div>
            </div>

            <div class="col-lg-4 col-md-6 mb-4">
                <div class="card h-100">
                    <a onserverclick="GetDetails" runat="server" href="#" title="The Curious Incident of the Dog in the Night-Time"><img class="card-img-top" src="CardImgs/DogInTheNight.jpg" alt=""></a>
                    <div class="card-body">
                        <h4 class="card-title">
                            <a onserverclick="GetDetails" runat="server" href="#" title="The Curious Incident of the Dog in the Night-Time">The Curious Incident of the Dog in the Night-Time</a>
                        </h4>
                        <p class="card-subtitle">Mark Haddon</p>
                        <h5>$12.59</h5>
                    </div>
                </div>
            </div>

            <div class="col-lg-4 col-md-6 mb-4">
                <div class="card h-100">
                    <a onserverclick="GetDetails" runat="server" href="#" title="Becoming"><img class="card-img-top" src="CardImgs/Becoming.jpg" alt=""></a>
                    <div class="card-body">
                        <h4 class="card-title">
                            <a onserverclick="GetDetails" runat="server" href="#" title="Becoming">Becoming</a>
                        </h4>
                        <p class="card-subtitle">Michelle Obama</p>
                        <h5>$30.99</h5>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>