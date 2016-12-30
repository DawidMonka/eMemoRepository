using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using eMemo.Helpers;

namespace MemoGameSite.Helpers
{
    //Klasa obsługująca ranking uzytkownikow i moje wyniki
    public class Results
    {
        
        private DataBaseConnection connection;
        
        public Results()
        {
            connection = new DataBaseConnection();
        }
        /// <summary>
        /// metoda zwraca zbiór danych o wybranej wielkości planszy i trybie gry
        /// </summary>
        /// <param name="wielkosc"></param>
        /// <param name="tryb"></param>
        /// <returns></returns>
        public DataSet getResults(int wielkosc, string tryb)
        {
            string order;
            string sortOrder;
            if (tryb == DataBaseConstants.GameModeValue.TimeMode)
            {
                order = DataBaseConstants.PlaysTable.Time;
                sortOrder = "asc";
            }
            else
            {
                order = DataBaseConstants.PlaysTable.Points;
                sortOrder = "desc";
            }
            //string cmdtText = "SELECT gracz, dataRozgrywa, lPkt, czasTrwania, lRuchow  FROM rozgrywa where nrPlanszy =" + wielkosc + " and trybGry =" + tryb + " order by lPkt desc limit 10";
            string cmdtText = String.Format("SELECT {0}, {1}, {2}, {3}, lRuchow FROM {4} WHERE nrPlanszy = {5} and trybGry = '{6}' order by {7} {8} limit 10",
               DataBaseConstants.PlaysTable.Player,
               DataBaseConstants.PlaysTable.Date,
               DataBaseConstants.PlaysTable.Points,
               DataBaseConstants.PlaysTable.Time,
               DataBaseConstants.PlaysTableName,
               wielkosc,
               tryb,
               order,
               sortOrder);
            return connection.getDataSetFromDataBase(cmdtText);
        }


       /// <summary>
       /// metoda zwraca zbiór danych o wybranej wielkości planszy,trybie gry i nicku
       /// </summary>
       /// <param name="wielkosc"></param>
       /// <param name="tryb"></param>
       /// <param name="nick"></param>
       /// <returns></returns>
        public DataSet getResultsByNick(int wielkosc, string tryb, string nick)
        {
            string order;
            string sortOrder;
            if (tryb == DataBaseConstants.GameModeValue.TimeMode)
            {
                order = DataBaseConstants.PlaysTable.Time;
                sortOrder = "asc";
            }
            else
            {
                order = DataBaseConstants.PlaysTable.Points;
                sortOrder = "desc";
            }
            //string currentNick = MySession.Current.LoginNick;
            string cmdtText = String.Format("SELECT {0}, {1}, {2}, {3}, {4} FROM {5} WHERE {6} = '{7}' and nrPlanszy = {8} and trybGry = '{9}' order by {10} {11} limit 10",
                DataBaseConstants.PlaysTable.Player,
                DataBaseConstants.PlaysTable.Date,
                DataBaseConstants.PlaysTable.Points,
                DataBaseConstants.PlaysTable.Time,
                DataBaseConstants.PlaysTable.MovesNr,
                DataBaseConstants.PlaysTableName,
                DataBaseConstants.PlaysTable.Player,
                nick,
                wielkosc,
                tryb,
                order,
                sortOrder);
            return connection.getDataSetFromDataBase(cmdtText);
        }
        
    }
}