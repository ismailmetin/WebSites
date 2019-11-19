<%@ Page Title="" Language="C#" MasterPageFile="~/Temel.master" AutoEventWireup="true" CodeFile="WelcomePage.aspx.cs" Inherits="WelcomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div id="myCarousel" class="carousel slide" data-ride="carousel" style="width:1146px; height:350px">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
    <li data-target="#myCarousel" data-slide-to="1"></li>
    <li data-target="#myCarousel" data-slide-to="2"></li>
  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner">
    <div class="item active" style="width:1146px; height:400px">
      <img src="mercimek_corbasi.jpg" alt="Corba" style="width:1146px; height:400px"/>
    </div>

    <div class="item" style="width:1146px; height:400px">
      <img src="tavuk.jpg" alt="Yemek" style="width:1146px; height:400px"/>
    </div>

    <div class="item" style="width:1146px; height:400px">
      <img src="profiterol.jpg" alt="Tatli" style="width:1146px; height:400px"/>
    </div>
  </div>

  <!-- Left and right controls -->
  <a class="left carousel-control" href="#myCarousel" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#myCarousel" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right"></span>
    <span class="sr-only">Next</span>
  </a>
</div>













</asp:Content>

