<%@ Page Title="Strona logowania" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void loginButton_Click(object sender, EventArgs e)
    {
        var nickField = new MemoGameSite.Helpers.NickField();
        var passField = new MemoGameSite.Helpers.PassField();
        var dataBaseConnection = new MemoGameSite.Helpers.DataBaseConnection();
        
        if (!nickField.isEmpty(nick.Text) && !passField.isEmpty(pass.Text) && nickField.checkIfNickInDataBase(nick.Text))
        {
            dataBaseConnection.openConnection();

            if (dataBaseConnection.isConnectionOpen())
                checkPassword(nick.Text, pass.Text, nickField, passField);

            dataBaseConnection.closeConnection();
        }
        else
        {
            Response.Write("Nie ma takiego użytkownika");
        }
    }

    private void checkPassword(string nick, string pass, MemoGameSite.Helpers.NickField nickField, MemoGameSite.Helpers.PassField passField)
    {
        if (passField.isPasswordCorrect(nick, pass))
        {
            eMemo.Helpers.MySession.Current.LoginNick = nick;
            eMemo.Helpers.MySession.Current.CreateNewPersonalData();
            
            Response.Write("Hasło jest prawidłowe");

            if (nickField.isAdminNick(nick))
            {
                Response.Redirect("~Account/AdminSite.aspx");
            }
            else
            {
                //FormsAuthentication.SetAuthCookie(nick, true);
                Response.Redirect("~/Home.aspx");
            }
        }
        else
        {
            Response.Write("Hasło jest nieprawidłowe");
        }
    }

    protected void createNewButton_Click(object sender, EventArgs e)
    {
        MemoGameSite.Helpers.RegistrationEntity regEntity = new MemoGameSite.Helpers.RegistrationEntity(true);
        Session["RegistrationEntity"] = regEntity;

        Response.Redirect("Register.aspx");
    }
</script>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">   
                     
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="nick" CssClass="col-md-2 control-label">Nick:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox ID="nick" runat="server" CausesValidation="True" ValidateRequestMode="Disabled" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nick" 
                                ErrorMessage="Wprowadź swój nick." CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="pass" CssClass="col-md-2 control-label">Hasło:</asp:Label>
                        <div class="col-md-10">
                              <asp:TextBox ID="pass" runat="server" CausesValidation="True" TextMode="Password" CssClass="form-control"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="pass" 
                                    ErrorMessage="Wprowadź hasło." CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                   
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                             <asp:Button ID="loginButton" runat="server" OnClick="loginButton_Click" Text="Loguj" align="left" CssClass="btn btn-default"/>
                            
                        </div>
                    </div>
                </div>
                <%--<p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Zarejestruj się</asp:HyperLink>
                    jeśli nie masz jeszcze konta.
                </p>--%>
            </section>
        </div>

       
    </div>
</asp:Content>
