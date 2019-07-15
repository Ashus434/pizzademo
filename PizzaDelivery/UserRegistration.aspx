<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="PizzaDelivery.UserRegistration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <%--<h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>--%>
    <asp:Label runat="server" Visible="false" ID="lblError"></asp:Label>
    <div class="container">
        <div class="row">
            <div class="col-md-4">Name:</div>
            <div class="col-md-8">
                <asp:TextBox runat="server" MaxLength="20" ID="txtName"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ErrorMessage="&laquo; (Required)"
                    ControlToValidate="txtName"
                    CssClass="ValidationError"
                    ToolTip="Name is a REQUIRED field"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator1"
                    runat="server"
                    ErrorMessage="only characters allowed"
                    ControlToValidate="txtName"
                    ValidationExpression="^[A-Za-z]*$"></asp:RegularExpressionValidator>

            </div>
        </div>
        <div class="row">
            <div class="col-md-4">Email Id:</div>
            <div class="col-md-8">
                <asp:TextBox runat="server" MaxLength="40" ID="txtEmail" AutoPostBack="true" OnTextChanged="onEmailCheck"></asp:TextBox>
                <asp:RegularExpressionValidator ID="remail" runat="server"
                    ControlToValidate="txtemail" ErrorMessage="Enter right your email"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">Contact No:</div>
            <div class="col-md-8">
                <asp:TextBox runat="server" MaxLength="13" ID="txtContactNo"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ErrorMessage="&laquo; (Required)"
                    ControlToValidate="txtContactNo"
                    CssClass="ValidationError"
                    ToolTip="Contact is a REQUIRED field"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                    runat="server" ErrorMessage="Enter valid Phone number"
                    ControlToValidate="txtContactNo"
                    ValidationExpression="^([0-9\(\)\/\+ \-]*)$"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">Address:</div>
            <div class="col-md-8">
                <asp:TextBox runat="server" MaxLength="50" ID="txtAddress"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                    ErrorMessage="&laquo; (Required)"
                    ControlToValidate="txtAddress"
                    CssClass="ValidationError"
                    ValidationExpression="^[a-zA-Z0-9'&.\s]{7,10}$"
                    ToolTip="Contact is a REQUIRED field"></asp:RequiredFieldValidator>
               
            </div>
        </div>

        <div class="row">
            <div class="col-md-4">Password:</div>
            <div class="col-md-8">
                <asp:TextBox runat="server" TextMode="Password" MaxLength="15" MinLength="8" ID="txtPassword"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="&laquo; (Required)"
                    ControlToValidate="txtPassword"
                    CssClass="ValidationError"
                    ValidationExpression="^[a-zA-Z0-9'@&#.\s]{7,10}$"
                    ToolTip="Password is a REQUIRED field"></asp:RequiredFieldValidator>

            </div>
        </div>
        <div class="row">
            <div class="col-md-4">Confirm Password:</div>
            <div class="col-md-8">
                <asp:TextBox runat="server" TextMode="Password" MaxLength="15" MinLength="8" ID="txtCofirmPasssword"></asp:TextBox>
                <asp:CompareValidator runat="server" ID="Comp1" ControlToValidate="txtPassword" ControlToCompare="txtCofirmPasssword" Font-Size="11px" ForeColor="Red"
                    ValidationExpression="^[a-zA-Z0-9'@&#.\s]{7,10}$" />

            </div>
        </div>
       
            <div class="row">
                <div class="col-md-4">
                    <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_Click" />
                </div>

            </div>
        </div>
    </div>
</asp:Content>
