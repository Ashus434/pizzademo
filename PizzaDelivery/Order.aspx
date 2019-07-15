
   <%@ Page Title="Order" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="PizzaDelivery.Order" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
	<%--<h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>--%>
	<asp:Label runat="server" Visible="false" ID="lblError"></asp:Label>
	<div class="container">
		<div class="row">
			<div class="col-md-4">Name:</div>
			<div class="col-md-8">
				<asp:TextBox runat="server" ID="txtName" CssClass=""></asp:TextBox>
			</div>
		</div>
		<div class="row">
			<div class="col-md-4">Address:</div>
			<div class="col-md-8">
				<asp:TextBox runat="server" ID="txtAddress"></asp:TextBox>
			</div>
		</div>
		<div class="row">
			<div class="col-md-4">Contact No:</div>
			<div class="col-md-8">
				<asp:TextBox runat="server" ID="txtContactNo"></asp:TextBox>
			</div>
		</div>
		<div class="row">
			<div class="col-md-4">Pizza Type:</div>
			<div class="col-md-8">
				<asp:DropDownList ID="ddlPizzaType" runat="server" ></asp:DropDownList>
			</div>
		</div>
		<div class="row">
			<div class="col-md-4">Quantity:</div>
			<div class="col-md-8">
				<asp:TextBox ID="ListBox2" runat="server" type="number"></asp:TextBox>
			    <br />
			</div>
		</div>
        <div class="row">
			<div class="col-md-4">Pizza Size:</div>
			<div class="col-md-8">
				
			    <asp:DropDownList ID="ddlPizzaSize" runat="server"></asp:DropDownList>
			    <br />
			</div>
		</div>
		<div class="row">
			<div class="col-md-4">
				<asp:Button ID="btnOrder" runat="server" Text="Order" OnClick="btnOrder_Click" /> 
			</div>

		</div>
        <div class="row">
			<div class="col-md-4">
				<asp:Button ID="btnLogOut" runat="server" Text="Log Out" OnClick="btnLogOut_Click" /> 
			</div>

		</div>
	</div>
</asp:Content>