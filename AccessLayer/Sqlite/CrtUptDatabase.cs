using Microsoft.Data.Sqlite;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccessLayer.Sqlite
{
    public class CrtUptDatabase : Sqlite
    {

        /// <summary>
        /// to recreate a table up his version
        /// </summary>
        public static VersionDb ActualVersionDb = new VersionDb() { Account = 5 };

        /// <summary>
        /// Create or update the local database
        /// </summary>
        public void CreateDatabase()
        {
            OpenIfClosed();

            VerifyDbVersions();

            //dbVersion
            _ = RunSqliteCommand("CREATE TABLE IF NOT EXISTS DbVersion(Key INTEGER, Account INTEGER)");

            //account
            _ = RunSqliteCommand("CREATE TABLE IF NOT EXISTS Account(Id INTEGER PRIMARY KEY AUTOINCREMENT, Key TEXT,UserKey TEXT, LastUpdate DATETIME,Name TEXT, Value TEXT, Description TEXT)");

            CloseIfOpen();
        }

        /// <summary>
        /// delete tables of old versions and recreate it
        /// </summary>
        public void VerifyDbVersions()
        {
            VersionDb versionDb;

            using (SqliteDataReader Retorno = Task.Run(async () => await RunSqliteCommand("select ACCOUNT from DbVersion")).Result)
            {
                _ = Retorno.Read();

                if (Retorno.HasRows)
                {
                    versionDb = new VersionDb()
                    {
                        Account = Retorno.GetWithNullableInt(0)
                    };
                }
                else
                {
                    versionDb = new VersionDb()
                    {
                        Account = 0
                    };
                    CrtorUptVersionDb(false, versionDb);
                }
            }

            bool atualizarVersaoDb = false;

            if (versionDb.Account < ActualVersionDb.Account)
            {
                _ = RunSqliteCommand("drop table if exists Account");

                atualizarVersaoDb = true;
            }


            if (atualizarVersaoDb)
                CrtorUptVersionDb(true, ActualVersionDb);
        }


        public void CrtorUptVersionDb(bool isUpdate, VersionDb versionDb)
        {
            string command;

            if (!isUpdate)
            {
                command = "insert into DbVersion(Key,Account) values ('1',@Account)";
            }
            else
            {
                command = "update DbVersion set Account = @Account where key = '1'";
            }


            List<SqliteParameter> parameters = new List<SqliteParameter>() { new SqliteParameter("@Account", versionDb.Account) };

            _ = RunSqliteCommand(command, parameters);
        }
    }
}
