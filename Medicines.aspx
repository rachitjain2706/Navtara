<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Medicines.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">

        <div class="exTab3 container">	
            <ul  class="nav nav-pills">
			    <li class="active"><a  href="#1b" data-toggle="tab">New Medicine</a></li>
			    <li><a href="#2b" data-toggle="tab">Reorder Medicine</a></li>
			    <li><a href="#3b" data-toggle="tab">Inventory</a></li>
                <li><a href="#4b" data-toggle="tab">Expiry</a></li>
		    </ul>

            <asp:Label runat="server" ID="l2"></asp:Label>

			<div class="tab-content clearfix">
			    <div class="tab-pane active" id="1b">
                    <asp:Table runat="server" CssClass="table table-bordered">
                        <asp:TableRow>
                          <asp:TableCell Text="Trade Name"></asp:TableCell>
                          <asp:TableCell><asp:TextBox style="color:black;" runat="server" ID="trade_name"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                          <asp:TableCell Text="Generic Name"></asp:TableCell>
                          <asp:TableCell><asp:TextBox style="color:black;" runat="server" ID="gen_name"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                          <asp:TableCell Text="Medicine Description"></asp:TableCell>
                          <asp:TableCell><asp:TextBox style="color:black;" runat="server" ID="med_desc"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                          <asp:TableCell Text="Vendor List"></asp:TableCell>
                          <asp:TableCell>
                              <asp:DropDownList style="color:black; font-size:14px; width:182px;" runat="server" ID="vendor_list">                              </asp:DropDownList>
                          </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                          <asp:TableCell Text="Selling Price"></asp:TableCell>
                          <asp:TableCell><asp:TextBox style="color:black;" runat="server" ID="sp"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                          <asp:TableCell Text="Purchasing price"></asp:TableCell>
                          <asp:TableCell><asp:TextBox style="color:black;" runat="server" ID="pp"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                          <asp:TableCell></asp:TableCell>
                          <asp:TableCell><asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="Button1_Click"/></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
			    </div>
                <div class="tab-pane" id="2b">
                    <asp:Table runat="server" CssClass="table table-bordered">
                        <asp:TableRow>
                          <asp:TableCell Text="Medicine Name"></asp:TableCell>
                          <asp:TableCell><asp:TextBox style="color:black;" runat="server" ID="TextBox1"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                          <asp:TableCell Text="Vendor List"></asp:TableCell>
                          <asp:TableCell>
                              <asp:DropDownList style="color:black; font-size:14px; width:182px;" runat="server" ID="DropDownList1">
                              </asp:DropDownList>
                          </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                          <asp:TableCell Text="Quantity"></asp:TableCell>
                          <asp:TableCell><asp:TextBox style="color:black;" runat="server" ID="TextBox3"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                          <asp:TableCell Text="Expiry Date"></asp:TableCell>
                          <asp:TableCell><asp:TextBox style="color:black;" runat="server" ID="TextBox2"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                          <asp:TableCell></asp:TableCell>
                          <asp:TableCell><asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="Button2_Click"/></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:Label runat="server" ID="l9"></asp:Label>
                    <h4>Reorder list</h4>
                    <asp:Table runat="server" ID="t9" CssClass="table table-bordered">
                        <asp:TableHeaderRow>
                            <asp:TableCell Text="Medicine Code"></asp:TableCell>
                            <asp:TableCell Text="Vendor Code"></asp:TableCell>
                            <asp:TableCell Text="Remaining"></asp:TableCell>
                            <asp:TableCell Text="Batch Number"></asp:TableCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
				</div>
                <div class="tab-pane" id="3b" onclick="<% inventory_diplay();%>">
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
                <div class="tab-pane" id="4b" onclick="<% show();%>">
                    <asp:Label runat="server" ID="l7"></asp:Label>
                    <asp:Table runat="server" CssClass="table table-bordered" ID="t4">
                        <asp:TableHeaderRow>
                          <asp:TableHeaderCell Text="Medicine Code"></asp:TableHeaderCell>
                          <asp:TableHeaderCell Text="Batch Number"></asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </div>
			</div>
        </div>

    </div>
</asp:Content>

