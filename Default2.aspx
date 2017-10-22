<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">

        <div id="exTab3" class="container">	
            <ul  class="nav nav-pills">
			    <li class="active"><a  href="#1b" data-toggle="tab">New Medicine</a></li>
			    <li><a href="#2b" data-toggle="tab">Reorder Medicine</a></li>
			    <li><a href="#3b" data-toggle="tab">Inventory</a></li>
		    </ul>

			<div class="tab-content clearfix">
			    <div class="tab-pane active" id="1b">
                    <h3>Hola</h3>
                    <asp:Table runat="server">
                        <asp:TableRow>
                          <asp:TableCell Text="Trade Name"></asp:TableCell>
                          <asp:TableCell><asp:TextBox runat="server" ID="trade_name"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                          <asp:TableCell Text="Generic Name"></asp:TableCell>
                          <asp:TableCell><asp:TextBox runat="server" ID="gen_name"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                          <asp:TableCell Text="Vendor List"></asp:TableCell>
                          <asp:TableCell>
                              <asp:DropDownList runat="server" ID="vendor_list">
                                <asp:ListItem Text="A">A</asp:ListItem>
                                <asp:ListItem Text="B">B</asp:ListItem>
                              </asp:DropDownList>
                          </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                          <asp:TableCell Text="Selling Price"></asp:TableCell>
                          <asp:TableCell><asp:TextBox runat="server" ID="sp"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                          <asp:TableCell Text="Purchasing price"></asp:TableCell>
                          <asp:TableCell><asp:TextBox runat="server" ID="pp"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
			    </div>
                <div class="tab-pane" id="2b">
                    <h3>No</h3>

				</div>
                <div class="tab-pane" id="3b">
                    <h3>Yes</h3>
		        </div>
			</div>
        </div>

    </div>
</asp:Content>

