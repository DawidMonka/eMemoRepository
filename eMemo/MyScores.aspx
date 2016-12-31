<%@  Page Title="Moje wyniki" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyScores.aspx.cs" Inherits="eMemo.MojeWyniki" %>


    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
        <h2><%: Title %></h2>

    <div class ="container-fluid" > 
   
            <div class="row">
               
                <div class="col-md-4">
                    <label class="control-label">Wielkosc planszy</label>
                    <asp:DropDownList id="Wielkosc"       
                        runat="server">

                      <asp:ListItem Value="44"> 4x4 </asp:ListItem>
                      <asp:ListItem Value="45"> 4x5</asp:ListItem>
                      <asp:ListItem Value="46"> 4x6 </asp:ListItem>
                  
                   </asp:DropDownList>
                </div>
               
                <div class="col-md-4">
                    <label class="control-label">Tryb gry</label>
                    <asp:DropDownList id="Tryb"            
                        runat="server">

                      <asp:ListItem Selected="True" Value="na czas"> Na czas </asp:ListItem>
                      <asp:ListItem Value="na punkty"> Na punkty </asp:ListItem>
                 

                   </asp:DropDownList>
                </div>
                
            
        
             <div class="col-md-4" >
                
                <asp:Button ID="btnApply" runat="server" Text="Zatwierdź" onclick="btnApply_Click"  class="btn btn-default" />
            </div>
        </div>
<br />
<br /> 
<br />

 <div class="row" >

            <asp:GridView ID="gridview1" runat="server" UseAccessibleHeader="true"
            CssClass="table table-hover table-striped" GridLines="None" 
            AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText = "Miejsce " ItemStyle-Width="100">
                <ItemTemplate>
                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="gracz" HeaderText="gracz"/>
                <asp:BoundField DataField="dataRozgrywa" HeaderText="data" DataFormatString="{0:d}" />
                <asp:BoundField DataField="lPkt" HeaderText="liczba punktow" />
                <asp:BoundField DataField="czasTrwania" HeaderText="czas" />
                <asp:BoundField DataField="lRuchow" HeaderText="liczba ruchow" />
                
                
            </Columns>
            <RowStyle CssClass="cursor-pointer" />
            </asp:GridView>

      </div>      
        

   </div>      
</asp:Content>
    