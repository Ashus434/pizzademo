<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataView.aspx.cs" Inherits="PizzaDelivery.DataView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true">
   <%--OnPageIndexChanging="OnPageIndexChanging" PageSize="10">--%>
    <Columns>
        <asp:BoundField ItemStyle-Width="200px" DataField="Name" HeaderText="Name" />
        <asp:BoundField ItemStyle-Width="200px" DataField="Address" HeaderText="Address" />
        <asp:BoundField ItemStyle-Width="200px" DataField="Contact" HeaderText="Contact" />
        <asp:BoundField ItemStyle-Width="200px" DataField="PizzaType" HeaderText="PizzaType" />
        <asp:BoundField ItemStyle-Width="200px" DataField="Quantity" HeaderText="Quantity" />
        <asp:BoundField ItemStyle-Width="200px" DataField="PizzaSize" HeaderText="PizzaSize" />
    </Columns>
       </asp:GridView>
    </asp:Content>


    

