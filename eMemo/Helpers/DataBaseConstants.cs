using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eMemo.Helpers
{
    /// <summary>
    /// Klasa udostępniająca nazwy tabel, kolumn i możliwych wartości atrybutów w bazie danych
    /// </summary>
    public static class DataBaseConstants
    {
        /// <summary>
        /// Nick Admina w bazie danych
        /// </summary>
        public static string AdminNick = "Admin";

        /// <summary>
        /// Nazwy tabel
        /// </summary>
        public static string UserTableName = "Uzytkownik";
        public static string GameTableName = "Gra";
        public static string PlaysTableName = "Rozgrywa";

        /// <summary>
        /// Nazwy kolumn w tabeli Uzytkownik
        /// </summary>
        public static class UserTable
        {
            public const string Nick = "nick";
            public const string Pass = "haslo";
            public const string Name = "imie";
            public const string Surname = "nazwisko";
            public const string BirthDate = "dataUr";
            public const string Sex = "plec";
            public const string City = "miasto";
            public const string RegDate = "dataRej";
        }

        /// <summary>
        /// Nazwy kolumn w tabeli Gra
        /// </summary>
        public class GameTable
        {
            public const string BoardNo = "nrPlanszy";
            public const string GameMod = "trybGry";
        }

        /// <summary>
        /// Nazwy kolumn w tabeli Rozgrywa
        /// </summary>
        public class PlaysTable
        {
            public const string Id = "idRozgrywa";
            public const string Time = "czasTrwania";
            public const string Points = "lPkt";
            public const string Date = "dataRozgrywa";
            public const string Player = "gracz";
            public const string BoardNo = "nrPlanszy";
            public const string GameMod = "trybGry";
            public const string MovesNr = "lRuchow";
        }

        /// <summary>
        /// Możliwe wartości w kolumnie plec w tabeli Uzytkownik
        /// </summary>
        public class SexValue
        {
            public const string Male = "M";
            public const string Female = "F";
        }

        /// <summary>
        /// Możliwe wartości w kolumnie nrPlanszy w tabeli Gra i Rozgrywa
        /// </summary>
        public class BoardNoValue
        {
            public const int FourFour = 44;
            public const int FourFive = 45;
            public const int FourSix = 46;
        }

        /// <summary>
        /// Możliwe wartości w kolumnie trybGry w tabeli Gra i Rozgrywa
        /// </summary>
        public class GameModeValue
        {
            public const string TimeMode = "na czas";
            public const string PointsMode = "na punkty";
        }
    }
}