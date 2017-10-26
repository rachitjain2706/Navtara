<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Sales.aspx.cs" Inherits="Sales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="exTab3 container">	
            <ul  class="nav nav-pills">
			    <li class="active"><a  href="#1b" data-toggle="tab">New Sale</a></li>
			    <li><a href="#2b" data-toggle="tab">Graphs</a></li>
			    <li><a href="#3b" data-toggle="tab">Total Monthly Sale</a></li>
		    </ul>

			<div class="tab-content clearfix">
			    <div class="tab-pane active" id="1b">
                    <asp:Table runat="server" CssClass="table table-bordered" id="new_row">                        
                        <asp:TableRow>
                          <asp:TableCell Text="Medicine"></asp:TableCell>
                          <asp:TableCell>
                              <asp:DropDownList style="color:black;" runat="server" ID="DropDownList1">
                              </asp:DropDownList>
                          </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                          <asp:TableCell Text="Quantity"></asp:TableCell>
                          <asp:TableCell><asp:TextBox style="color:black;" runat="server" ID="TextBox1"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                          <asp:TableCell Text="Cost"></asp:TableCell>
                          <asp:TableCell><asp:TextBox style="color:black;" runat="server" ID="TextBox2"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" Text="New Item" OnClick="Button2_Click" />
                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="Button3_Click" /><br /><br /><br />
                    <h3>Receipt</h3><br /><asp:Table runat="server" ID="show_receipt" CssClass="table table-bordered"></asp:Table>
			    </div>
                <div class="tab-pane" id="2b">
                    
				</div>

                <asp:Label runat="server" ID="l4"></asp:Label>

                <div class="tab-pane" id="3b" onclick="<% monthly_sale(); %>">
                    <asp:Table runat="server" CssClass="table table-bordered" ID="t3">
                        <asp:TableHeaderRow>
                          <asp:TableHeaderCell Text="Medicine Name"></asp:TableHeaderCell>
                          <asp:TableHeaderCell Text="Quantity"></asp:TableHeaderCell>
                          <asp:TableHeaderCell Text="Purchase Date"></asp:TableHeaderCell>
                          <asp:TableHeaderCell Text="Expiry Date"></asp:TableHeaderCell>
                          <asp:TableHeaderCell Text="Batch Number"></asp:TableHeaderCell>
                          <asp:TableHeaderCell Text="Vendor Name"></asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
		        </div>
			</div>
        </div>



</asp:Content>

