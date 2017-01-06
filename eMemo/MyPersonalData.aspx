<%@ Page Title="Moje dane" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyPersonalData.aspx.cs" Inherits="eMemo.MyPersonalData" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="row">
        <div class="col-md-4">
    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="nick" CssClass="col-md-2 control-label" ID="nickLabel">Nick:</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="nick" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="pass" CssClass="col-md-2 control-label" ID="passLabel">Hasło:</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="pass" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox>      
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="name" CssClass="col-md-2 control-label">Imię:</asp:Label>
            <div class="col-md-10">
                 <asp:TextBox ID="name" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="surname" CssClass="col-md-2 control-label" ID="surnameLabel">Nazwisko:</asp:Label>
            <div class="col-md-10">
                 <asp:TextBox ID="surname" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                 
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="datepicker" CssClass="col-md-2 control-label" ID="birthLabel">Data urodzenia:</asp:Label>
            <div class="col-md-10">
               <asp:TextBox ID="datepicker" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" ID="sexLabel" Font-Bold="True">Płeć:</asp:Label>
            <div class="col-md-10">
               <asp:RadioButton ID="male" runat="server" Checked="True" CssClass="radio" Text="Mężczyzna" GroupName="sexGroup" ReadOnly="true"/>
               <asp:RadioButton ID="female" runat="server" CssClass="radio" Text="Kobieta   " GroupName="sexGroup" ReadOnly="true"/>
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" ID="cityLabel" Font-Bold="True">Miasto:</asp:Label>
            <div class="col-md-10">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cityList" runat="server" AutoPostBack="True" CssClass="form-control" ReadOnly="true">
                                <asp:ListItem>Gdańsk</asp:ListItem>
                                <asp:ListItem>Białystok</asp:ListItem>
                                <asp:ListItem>Kraków</asp:ListItem>
                                <asp:ListItem>Katowice</asp:ListItem>
                                <asp:ListItem>Poznań</asp:ListItem>
                                <asp:ListItem>Łódź</asp:ListItem>
                                <asp:ListItem>Szczecin</asp:ListItem>
                                <asp:ListItem>Przemyśl</asp:ListItem>
                                <asp:ListItem>Warszawa</asp:ListItem>
                                <asp:ListItem>Tarnów</asp:ListItem>
                                <asp:ListItem>Wrocław</asp:ListItem>
                                <asp:ListItem>Inne</asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
            </div>
        </div>
        <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                         <!--    <asp:Button ID="updateButton" runat="server" OnClick="updateButton_Click" 
                                 Text="Aktualizuj"  CssClass="btn btn-default"/> -->
                            <asp:Button ID="showPass" runat="server" OnClick="showPass_Click"
                                Text="Pokaż hasło" CssClass="btn btn-default" />
                        </div>
                    </div>
        </div>

         <div class="col-md-4">
             </div>
 </div>      
    </div>
</asp:Content>

