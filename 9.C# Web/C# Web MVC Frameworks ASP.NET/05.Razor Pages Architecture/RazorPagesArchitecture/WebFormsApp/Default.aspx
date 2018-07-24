<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br /><br />
    <!--Here is our body-->

    <!--Inut fields-->
    <asp:TextBox ID="FirstNumber" runat="server"></asp:TextBox><br /><br />

    <asp:TextBox ID="SecondNumber" runat="server"></asp:TextBox><br /><br />

    <!--submit button-->
    <asp:Button ID="SumNumbers" OnClick="SumNumbers_Click" runat="server" text="Sum"/><br /><br />

    Sum: <asp:Label ID="Result" runat="server"></asp:Label>

</asp:Content>
