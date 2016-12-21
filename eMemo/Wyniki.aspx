<%@  Page Title="Wyniki" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wyniki.aspx.cs" Inherits="eMemo.Wyniki" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="row">
        <div class="col-md-8">

             <h2>Ranking</h2>
            
            <hr/>
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

      

           <%-- <div class="row">
                <div class="col-md-6">
                    

                    <div class="dropdown">
                        <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">Wielkość planszy
                        <span class="caret"></span></button>
                        <ul class="dropdown-menu">
                            <li><a href="#">4x3</a></li>
                            <li><a href="#">4x4</a></li>
                            <li><a href="#">4x5</a></li>
                        </ul>
                    
                    </div>
                </div>

               <div class="col-md-6">
                    <div class="dropdown">
                        <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">Tryb gry
                        <span class="caret"></span></button>
                        <ul class="dropdown-menu">
                            <li><a href="#">Na czas</a></li>
                            <li><a href="#">Na punkty</a></li>
                            
                        </ul> 
                    </div>
              </div>

         </div>--%>

<div>
     <hr/>
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
                <asp:BoundField DataField="dataRozgrywa" HeaderText="data" />
                <asp:BoundField DataField="lPkt" HeaderText="liczba punktow" />
                <asp:BoundField DataField="czasTrwania" HeaderText="czas" />
                <asp:BoundField DataField="lRuchow" HeaderText="liczba ruchow" />
                
                
            </Columns>
            <RowStyle CssClass="cursor-pointer" />
            </asp:GridView>

      </div>      
        </div>

       <%-- <div class="col-md-4">
             <h2>Ranking</h2>
            <div class="row">
                <div class="col-md-6">
                    <div class="dropdown">
                        <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">Wielkość planszy
                        <span class="caret"></span></button>
                        <ul class="dropdown-menu">
                            <li><a href="#">4x3</a></li>
                            <li><a href="#">4x4</a></li>
                            <li><a href="#">4x5</a></li>
                        </ul>
                    
                    </div>
                </div>

               <div class="col-md-6">
                    <div class="dropdown">
                        <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">Tryb gry
                        <span class="caret"></span></button>
                        <ul class="dropdown-menu">
                            <li><a href="#">Na czas</a></li>
                            <li><a href="#">Na liczbę ruchów</a></li>
                            <li><a href="#">Na liczbę punktów</a></li>
                        </ul> 
                    </div>
              </div>
         </div>

           
             <ul class="list-group">
                <li class="list-group-item">Pierwszy</li>
                <li class="list-group-item">Drugi</li>
                <li class="list-group-item">Trzeci</li>
                <li class="list-group-item">Czwarty</li>
                <li class="list-group-item">Piąty</li>
            </ul>
      </div>--%>
      
 </div>      
</asp:Content>

