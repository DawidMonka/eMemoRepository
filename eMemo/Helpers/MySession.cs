using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eMemo.Helpers
{
    /// <summary>
    /// Klasa obsługująca sesję użytkownika wraz z danymi zawartymi w sesji
    /// </summary>
    public class MySession
    {
        public string LoginNick { get; set; }
        private PersonalData personalData;

        public PersonalData PersonalData
        {
            get { return personalData; }
        }

        private MySession()
        {
            LoginNick = String.Empty;
        }

        /// <summary>
        /// Klasa udostępniajaca aktualną sesję użytkownika
        /// </summary>
        public static MySession Current
        {
            get
            {
                MySession session = (MySession)HttpContext.Current.Session["__MySession__"];
                if (session == null)
                {
                    session = new MySession();
                    HttpContext.Current.Session["__MySession__"] = session;
                }
                return session;
            }
        }

        /// <summary>
        /// Metoda sprawdzająca, czy użytkownik jest zalogowany
        /// </summary>
        /// <returns></returns>
        public bool isUserLoggedIn()
        {
            return !LoginNick.Equals(String.Empty);
        }

        /// <summary>
        /// Metoda ustawiająca propertę LoginNick na pustą
        /// </summary>
        public void LoggOffUser()
        {
            LoginNick = String.Empty;
        }

        /// <summary>
        /// Metoda tworząca klase PersonalData dla zalogowane użytkownika
        /// </summary>
        public void CreateNewPersonalData()
        {
            personalData = new PersonalData(LoginNick); 
        }
    }
}