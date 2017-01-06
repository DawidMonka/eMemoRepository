<%@ Page Title="Strona główna" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="eMemo.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p><asp:Image id="Image1" runat="server"
                    AlternateText="Image text"
                    ImageUrl="Images/logo.gif"/>  </p>
 <div class="row">
        <div class="col-md-4">
            <h2>eMemo</h2>
            <p>
                Gra typu memo z możliwością zapisania swoich osiągnięć 
                i porównania ich z wynikami innych graczy.
                Kilka poziomów trudności i trybów gry.          
            </p>
            <p>
                <asp:Image CssClass="imgClass" id="Image2" runat="server"
                    AlternateText="Image text"
                    ImageUrl="Images/prtScMemo1.png"/>  
            </p>
            
        </div>
        <div class="col-md-4">
            <h2>Pobierz grę</h2>
            <p>
               Kliknij, aby pobrać grę na urządzenie mobilne z systemem Android:
            </p>
            <p>
                <asp:Button ID="android" class="btn btn-default" runat="server" Text="Android" OnClick="androidClicked" />
            </p>
            <p>
                Kliknij, aby pobrać grę na PC z systemem Windows lub Mac:
            </p>
            <p>
                <asp:Button ID="windows" class="btn btn-default" runat="server" Text="WinPhone" OnClick="windowsClicked" />
                <asp:Button ID="mac" class="btn btn-default" runat="server" Text="MacOS" OnClick="macOsCLicked" />
            </p>
        </div>

             <div class="col-md-4">
            <h2>Regulamin</h2>
            <p> 
               Kliknij, aby wyświetlić regulamin serwisu eMemo.
            </p>
            <p>
                <asp:Button ID="TermsSiteButton" class="btn btn-default" runat="server" Text="Regulamin" OnClick="TermsSiteButtonClicked" />
            </p>

        </div>
    <!--    <div class="col-md-4">
            <h2>O nas</h2>
            <p>
               
            </p>
            
        </div>-->
    </div>   
</asp:Content>
