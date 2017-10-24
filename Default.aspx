<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 text-center">
                <div id="banner">
                    <h1>We heal you.</h1>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="registrationform">
                    <div class="form-horizontal">
                        <fieldset>
                            <legend>Login<i class="fa fa-pencil pull-right"></i></legend>
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="Email" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="TextBox1" runat="server" placeholder="Email" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="Password" CssClass="col-lg-2 control-label"></asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="TextBox2" runat="server" placeholder="Password" CssClass="form-control"
                                        TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click"/>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

