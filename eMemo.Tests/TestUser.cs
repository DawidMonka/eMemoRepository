using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMemo.Tests
{
    /// <summary>
    /// Klasa pomocnicza do testów danych użytkownika.
    /// Testowanie tych danych wymaga, by taki użytkownik był w bazie danych.
    /// </summary>
    public static class TestUser
    {
        public const string Nick = "TestUserNick";
        public const string Password = "TestUserPass";
        public const string Name = "TestUserName";
        public const string Surname = "TestUserSurname";
        public const string Sex = "M";
        public const string City = "TestUserCity";
        public const string BirthDate = "1980-12-12 00:00:00";
        public const string RegDate = "2014-01-01 00:00:00";
    }
}
