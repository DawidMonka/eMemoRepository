<%@ Page Title="Rejestracja" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs"  %>

<script runat="server">

    protected void cityList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        var nickField = new MemoGameSite.Helpers.NickField();
        var passField = new MemoGameSite.Helpers.PassField();
        var dataBaseConnection = new MemoGameSite.Helpers.DataBaseConnection();
        var registrationEntity = new MemoGameSite.Helpers.RegistrationEntity(true);

        if (!nickField.isEmpty(nick.Text) && nickField.checkIfNickInDataBase(nick.Text))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Rejestracja nie powiodła się. "
                + " Użytkownik o takim nicku jest już zarejestrowany.');", true);
            nick.Text = String.Empty;
            //Response.Write("Użytkownik o takim nicku jest już zarejestrowany");
        }
        else
        {
            setRegistrationEntityValues(registrationEntity);

            if (registrationEntity.noValueIsEmpty())
            {
                registrationEntity.insertNewUser(dataBaseConnection);
                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Pomyślnie zarejestrowano nowego użytkownika.');", true);
                Response.Redirect("Login.aspx");
                //Response.Write("Pomyślnie zarejestrowano nowego użytkownika.");
                
            }
            else
            {
                //Response.Write("Bład rejestracji użytkownika. Spróbuj jeszcze raz.");
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Bład rejestracji użytkownika. Spróbuj jeszcze raz.');", true);
            }
        }

    }

    private void setRegistrationEntityValues(MemoGameSite.Helpers.RegistrationEntity registrationEntity)
    {
        registrationEntity.Nick = nick.Text;
        registrationEntity.Pass = pass.Text;
        registrationEntity.Name = name.Text;
        registrationEntity.Surname = surname.Text;
        
        if (datepicker.Text == String.Empty)
        {
            registrationEntity.BirthDate = null;
        }
        else
            registrationEntity.BirthDate = datepicker.Text;

        if (male.Checked)
            registrationEntity.Sex = "M";
        else
            registrationEntity.Sex = "K";

        registrationEntity.City = cityList.SelectedValue;
        registrationEntity.SignDate = DateTime.Now;
    }
    
</script>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
   <%-- <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>--%>

    <div class="form-horizontal">
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="nick" CssClass="col-md-2 control-label">*Nick:</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="nick" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nick" 
                    ErrorMessage="Podaj nick." CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="pass" CssClass="col-md-2 control-label">*Hasło:</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="pass" runat="server" TextMode="Password" CssClass="form-control" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="pass"
                     ErrorMessage="Podaj hasło"  CssClass="text-danger"></asp:RequiredFieldValidator>       
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="conf" CssClass="col-md-2 control-label">*Potwierdź hasło:</asp:Label>
            <div class="col-md-10">
                 <asp:TextBox ID="conf" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="conf" 
                     ErrorMessage="Potwierdź hasło."  CssClass="text-danger" ></asp:RequiredFieldValidator>
                 <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="pass" ControlToValidate="conf" 
                     ErrorMessage="Hasło nie zostało poprawnie potwierdzone."  CssClass="text-danger" ></asp:CompareValidator>         
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="name" CssClass="col-md-2 control-label">Imię:</asp:Label>
            <div class="col-md-10">
                 <asp:TextBox ID="name" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="surname" CssClass="col-md-2 control-label">Nazwisko:</asp:Label>
            <div class="col-md-10">
                 <asp:TextBox ID="surname" runat="server" CssClass="form-control"></asp:TextBox>
                 
            </div>
        </div>
        

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="datepicker" CssClass="col-md-2 control-label">Data urodzenia:</asp:Label>
            <div class="col-md-10">
               <asp:TextBox ID="datepicker" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Płeć:</asp:Label>
            <div class="col-md-10">
               <asp:RadioButton ID="male" runat="server" Checked="True" CssClass="radio" Text="Mężczyzna" GroupName="sexGroup" />
               <asp:RadioButton ID="female" runat="server" CssClass="radio" Text="Kobieta" GroupName="sexGroup" />
            </div>
        </div>

         <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Miasto:</asp:Label>
            <div class="col-md-10">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cityList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cityList_SelectedIndexChanged" CssClass="form-control" >
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
                                <asp:ListItem Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="Rejestruj" CssClass="btn btn-default" align ="left"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Text="* wymagane pole"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
