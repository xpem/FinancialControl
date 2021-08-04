using Microsoft.Data.Sqlite;
using ModelLayer;
using System;
using System.Collections.Generic;

namespace AccessLayer.Sqlite
{
    public class Sqlite
    {
        public readonly SqliteConnection db = new SqliteConnection($"Filename={System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FinancialControl.db3")}");

        /// <summary>
        /// to recreate a table up his version
        /// </summary>
        public static VersionDb ActualVersionDb = new VersionDb() { Account = 1 };


        public void OpenIfClosed() { if (db.State == System.Data.ConnectionState.Closed) { db.Open(); } }

        public void CloseIfOpen() { if (db.State == System.Data.ConnectionState.Open) { db.Close(); } }

        public SqliteDataReader RunSqliteCommand(string command, List<SqliteParameter> parameters = null)
        {
            SqliteCommand sqliteCommand = new SqliteCommand(command, db);

            if (parameters != null)
            {
                foreach (SqliteParameter parameter in parameters)
                {
                    _ = sqliteCommand.Parameters.Add(parameter);
                }
            }

            return sqliteCommand.ExecuteReader();
        }
    }
}
