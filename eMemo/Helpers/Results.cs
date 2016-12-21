using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using eMemo.Helpers;

namespace MemoGameSite.Helpers
{
    //Klasa obsługująca ranking uzytkownikow
    public class Results
    {
        private int wielkosc;
        private string tryb;
        private DataBaseConnection connection;
        string currentNick;

        public Results(int _wielkosc)
        {
            connection = new DataBaseConnection();
            wielkosc = _wielkosc;
            currentNick = MySession.Current.LoginNick;
        }


        /// <summary>
        /// metoda zwraca zbiór danych, dla których wielkość planszy jest równa zmiennej składowej wielkość, zbiór uporządkowany malejąco po lPkt (liczbie punktów uzyskanych przez gracza w trybie 'na punkty')
        /// </summary>
        /// <returns></returns>
        public DataSet getResultsByPoints()
        {
            string cmdtText = "SELECT gracz, dataRozgrywa, lPkt, czasTrwania, lRuchow  FROM rozgrywa where nrPlanszy =" + wielkosc + " and trybGry = 'na punkty' order by lPkt desc limit 10";
            return getDataSet(cmdtText);
        }


        /// <summary>
        /// metoda zwraca zbiór danych, dla których wielkość planszy jest równa zmiennej składowej wielkość, zbiór uporządkowany rosnąco po czasieTrwania (w trybie 'na czas')
        /// </summary>
        /// <returns></returns>
        public DataSet getResultsByTime()
        {

            string cmdtText = "SELECT gracz, dataRozgrywa, lPkt, czasTrwania, lRuchow FROM rozgrywa where nrPlanszy =" + wielkosc + " and trybGry = 'na czas' order by czasTrwania asc limit 10";
            return getDataSet(cmdtText);
            
        }
        /// <summary>
        /// metoda zwraca zbiór danych dla użytkownika aktualnie zalogowanego
        /// </summary>
        /// <returns></returns>
        public DataSet getResultByNick()
        {
            //string currentNick = MySession.Current.LoginNick;
            string cmdtText = "SELECT gracz, dataRozgrywa, lPkt, czasTrwania, lRuchow  FROM rozgrywa WHERE gracz='" + currentNick + "' order by dataRozgrywa desc limit 10";
            return getDataSet(cmdtText);
        }

        public DataSet getResultsByTimeByNick()
        {
            //string currentNick = MySession.Current.LoginNick;
            string cmdtText = "SELECT gracz, dataRozgrywa, lPkt, czasTrwania, lRuchow FROM rozgrywa where nrPlanszy =" + wielkosc + " and trybGry = 'na czas' and gracz='" + currentNick + "' order by czasTrwania asc limit 10";
            return getDataSet(cmdtText);

        }

        public DataSet getResultsByPointsByNick()
        {
            string cmdtText = "SELECT gracz, dataRozgrywa, lPkt, czasTrwania, lRuchow  FROM rozgrywa where nrPlanszy =" + wielkosc + " and trybGry = 'na punkty' and gracz='" + currentNick + "' order by lPkt desc limit 10";
            return getDataSet(cmdtText);
        }
        /// <summary>
        /// metoda pomocnicza zwracająca zbiór danych
        /// </summary>
        /// <param name="cmdtText"></param> zapytanie
        /// <returns></returns>
        private DataSet getDataSet(string cmdtText)
        {
            connection.openConnection();
            //cmdtText = "SELECT gracz, dataRozgrywa, lPkt, czasTrwania, lRuchow  FROM rozgrywa where nrPlanszy =" + wielkosc + " and trybGry = 'na punkty' order by lPkt desc limit 10";
            MySqlCommand cmde = new MySqlCommand(cmdtText, connection.Connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmde);
            DataSet ds = new DataSet();
            da.Fill(ds);
            connection.closeConnection();

            return ds;
        }
    }
}