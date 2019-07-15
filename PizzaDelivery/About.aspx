<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PizzaDelivery.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
     
    <asp:Label runat="server" Visible="false" ID="lblError"></asp:Label>
	<div class="container">
		<div class="row">
			<div class="col-md-4">Id:</div>
			<div class="col-md-8">
				<asp:TextBox runat="server" ID="txtName" CssClass=""></asp:TextBox>
			</div>
		</div>
		
		<div class="row">
			<div class="col-md-4">Password:</div>
			<div class="col-md-8">
				<asp:TextBox runat="server" ID="txtPassword"></asp:TextBox>
			</div>
		</div>
         <p>
        <asp:CheckBox ID="RememberMe" runat="server" Text="Remember Me" />
    </p>
		<div class="row">
			<div class="col-md-4"></div>
		</div>
		<div class="row">
			<div class="col-md-4">
				<asp:Button ID="btnLoginIn" runat="server" Text="Login In" OnClick="btnLoginIn_Click"/>
			</div>

		</div>
		

	
	</div>
</asp:Content>
