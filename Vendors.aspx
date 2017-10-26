<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Vendors.aspx.cs" Inherits="Vendors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">

        <div id="exTab3" class="container">	
            <ul  class="nav nav-pills">
			    <li class="active"><a  href="#1b" data-toggle="tab">New Vendor</a></li>
			    <li><a href="#2b" data-toggle="tab">Rokda</a></li>
		    </ul>

            <asp:Label runat="server" ID="l2">Hola</asp:Label>

			<div class="tab-content clearfix">
			    <div class="tab-pane active" id="1b">
                    <asp:Table runat="server" CssClass="table table-bordered">
                        <asp:TableRow>
                          <asp:TableCell Text="Vendor Name"></asp:TableCell>
                          <asp:TableCell><asp:TextBox style="color:black;" runat="server" ID="vendor_n"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                          <asp:TableCell Text="Address"></asp:TableCell>
                          <asp:TableCell><asp:TextBox style="color:black;" runat="server" ID="addr"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                          <asp:TableCell Text="Medicine List"></asp:TableCell>
                          <asp:TableCell>
                              <asp:DropDownList style="color:black; width:198px;font:14px;" runat="server" ID="medicine_list">
                              </asp:DropDownList>
                          </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                          <asp:TableCell></asp:TableCell>
                          <asp:TableCell><asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="Button1_Click"/></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
			    </div>
                <div class="tab-pane" id="2b" onclick="<% rokdaShow();%>">
                    <asp:Table runat="server" CssClass="table table-bordered" ID="vendorPaymentTable">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell Text="Vendor Code"></asp:TableHeaderCell>
                            <asp:TableHeaderCell Text="Price"></asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
				</div>
			</div>
        </div>
    </div>
</asp:Content>

