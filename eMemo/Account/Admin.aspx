<%@ Page Title="Zarządzanie kontami" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="eMemo.Account.Admin" %>
    


    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <script type = "text/javascript">
            function confirmDelete() {
                return confirm("Czy jesteś pewien, że chcesz usunąć użytkownika?");
            }
        </script>

    <h2><%: Title %></h2>
    
        <div class="row">
             <asp:GridView ID="gridview1" runat="server" UseAccessibleHeader="true"
            CssClass="table" GridLines="None" 
            AutoGenerateColumns="False" AllowPaging="true" PageSize="10" OnPageIndexChanging="OnPageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText = "Numer" ItemStyle-Width="100">
                <ItemTemplate>
                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="nick" HeaderText="nick"/>
                <asp:BoundField DataField="dataRej" HeaderText="data" DataFormatString="{0:d}"/>
                <asp:TemplateField>
                  <ItemTemplate>
                     <asp:Button ID="DeleteButton" runat="server" Text="Usuń" 
                         OnCommand="OnConfirm" CommandName="User" CommandArgument='<%# Eval("nick") %>'
                        OnClientClick="return confirmDelete();" />
                  </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
           <%-- <RowStyle CssClass="cursor-pointer" />--%>
            </asp:GridView>
        </div>


    </asp:Content>