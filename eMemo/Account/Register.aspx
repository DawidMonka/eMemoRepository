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

        //warunek sprawdzający czy istnieje już podany nick w bazie danych
        if (!nickField.isEmpty(nick.Text) && nickField.checkIfNickInDataBase(nick.Text))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Rejestracja nie powiodła się. "
                + " Użytkownik o takim nicku jest już zarejestrowany.');", true);
            nick.Text = String.Empty;
            //Response.Write("Użytkownik o takim nicku jest już zarejestrowany");
        }
        else
        {
            //warunek sprawdzający czy nie przekroczono dopuszczlnej liczby znaków
            if (registrationEntity.valueLenghtIsRight(nick.Text) && registrationEntity.valueLenghtIsRight(pass.Text))
            {
                setRegistrationEntityValues(registrationEntity);

                //warunek sprawdzający, czy wszystkie pola sa zapełnione i czy prawidłowy jest format daty
                if (registrationEntity.noValueIsEmpty() && !registrationEntity.WrongDateFormat)
                {
                    registrationEntity.insertNewUser(dataBaseConnection);
                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Pomyślnie zarejestrowano nowego użytkownika.');", true);
                    Response.Redirect("Login.aspx");
                    //Response.Write("Pomyślnie zarejestrowano nowego użytkownika.");

                }
                else
                {
                    //komunikat gdy format daty jest niepoprawny
                    if (registrationEntity.WrongDateFormat)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Niepoprawny format daty urodzenia. Spróbuj ponownie.');", true);
                        registrationEntity.WrongDateFormat = false;
                        datepicker.Text = String.Empty;
                    }
                    else
                    {
                        //Response.Write("Bład rejestracji użytkownika. Spróbuj jeszcze raz.");
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('W celu zarejestrowania należy wypełnić wszystkie wymagane pola.');", true);
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Nieprawidłowa długość nicku lub hasła. Dopuszczalna długość 5-15 znaków.');", true);
            }
        }
    }

    /// <summary>
    /// Wprowadzenie danych do RegstrationEntity
    /// </summary>
    /// <param name="registrationEntity"></param>
    private void setRegistrationEntityValues(MemoGameSite.Helpers.RegistrationEntity registrationEntity)
    {
        registrationEntity.Nick = nick.Text;
        registrationEntity.Pass = pass.Text;
        registrationEntity.Name = name.Text;
        registrationEntity.Surname = surname.Text;

        if (acceptTerms2.Checked)
            registrationEntity.AcceptTerms = true;

        //if (datepicker.Text == String.Empty)
        //{
        //    registrationEntity.BirthDate = null;
        //}
        //else
        //    registrationEntity.BirthDate = datepicker.Text;

        if (datepicker.Text.Equals(String.Empty))
        {
            registrationEntity.BirthDate = DateTime.MinValue;
        }
        else
        {
            try
            {
                registrationEntity.BirthDate = Convert.ToDateTime(datepicker.Text);
            }
            catch (FormatException)
            {
                registrationEntity.WrongDateFormat = true;
            }
        }

        if (male.Checked)
            registrationEntity.Sex = "M";
        else
            registrationEntity.Sex = "K";

        registrationEntity.City = cityList.SelectedValue;
        registrationEntity.SignDate = DateTime.Now;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Wyświetlenie strony z Regulaminem 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void TermsSiteButtonClicked(object sender, EventArgs e)
    {
        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('REGULAMIN');", true);
        Response.Redirect("~/TermsSite.aspx");
    }

    protected void termsAccepted(object sender, EventArgs e)
    {
    }

    protected void CheckBoxRequired_ServerValidate(object sender, ServerValidateEventArgs e)
    {
        e.IsValid = acceptTerms2.Checked;
    }

</script>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
   <%-- <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>--%>

 <!--   <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
<script src="//code.jquery.com/jquery-1.10.2.js"></script>
<script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
<link rel="stylesheet" href="/resources/demos/style.css" />

    <script type="text/javascript">
    $(document).ready(function () {
        $(function () {
            $("#datepicker").datepicker();
        });
    });</script> -->



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
                .</div>
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
            <asp:Label runat="server" AssociatedControlID="datepicker" CssClass="col-md-2 control-label" Font-Bold="True">Data urodzenia:</asp:Label>
            <div class="col-md-10">
               <asp:TextBox ID="datepicker" runat="server" TextMode="Date" Defaul CssClass="form-control" ClientIdMode="static"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="True">Płeć:</asp:Label>
            <div class="col-md-10">
               <asp:RadioButton ID="male" runat="server" Checked="True" CssClass="radio" Text="Mężczyzna" GroupName="sexGroup" />
               <asp:RadioButton ID="female" runat="server" CssClass="radio" Text="Kobieta" GroupName="sexGroup" />
            </div>
        </div>

         <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="True">Miasto:</asp:Label>
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
            <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="True">*Czy akceptujesz regulamin?</asp:Label>
            <div class="col-md-10">
                <asp:CheckBox ID="acceptTerms2" runat="server" Checked="False" CssClass="radio" Text=" Tak" OnCheckedChanged="termsAccepted"/>
               <!--<asp:RadioButton ID="acceptTerms" runat="server" Checked="False" CssClass="radio" Text="Tak" CausesValidation="true" OnCheckedChanged="termsAccepted"/>-->
                <asp:LinkButton ID="TermsSiteButton" runat="server" OnClick="TermsSiteButtonClicked" CausesValidation="false">Regulamin serwisu eMemo</asp:LinkButton>
                <br />
                <asp:CustomValidator runat="server" ID="CheckBoxRequired"
                    OnServerValidate="CheckBoxRequired_ServerValidate"
                    ClientValidationFunction="CheckBoxRequired_ClientValidate">Musisz zaakceptować regulamin, żeby się zarejestrować.</asp:CustomValidator>
            </div>
        </div>


        <!--<div class="form-group">
            <asp:RadioButton ID="acceptReg" runat="server" />
            <div class="col-md-10">
            <asp:Label ID="Label2" CssClass="col-md-2" runat="server" Text="Akceptuję regulamin serwisu"></asp:Label>
            <asp:LinkButton ID="LinkButton1" CssClass="col-md-2" runat="server">Regulamin</asp:LinkButton>
            </div>
       </div>-->

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="Rejestruj" CssClass="btn btn-default" align ="left"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Text="* wymagane pole"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
