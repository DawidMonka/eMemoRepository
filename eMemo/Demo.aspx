<%@ Page Title="Gra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="eMemo.Gra" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <iframe src="Resources/index.html" 
        style="border:0px #000000 none;" name="Game name" scrolling="no" frameborder="1" marginheight="1px" marginwidth="1px" height="650px" width="960px"></iframe>
</asp:Content><%--  --%>