<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="card text-center">
          <div class="card-header">
            <ul class="nav nav-tabs card-header-tabs">
              <li class="nav-item">
                <a class="nav-link active" href="#">New Medicine</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="#">New Order</a>
              </li>
              <li class="nav-item">
                <a class="nav-link disabled" href="#">Inventory</a>
              </li>
            </ul>
          </div>
          <div class="card-block">
            <h4 class="card-title">Order new medicine</h4>
            <p class="card-text">Hola</p>
            <a href="#" class="btn btn-primary">Go somewhere</a>
          </div>
        </div>
    </div>
</asp:Content>

