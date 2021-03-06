using Microsoft.Data.Sqlite;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessLayer.Sqlite
{
    public class Sqlite
    {
        public readonly SqliteConnection db = new SqliteConnection($"Filename={System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FinancialControl.db3")}");


        public void OpenIfClosed() { if (db.State == System.Data.ConnectionState.Closed) { db.Open(); } }

        public void CloseIfOpen() { if (db.State == System.Data.ConnectionState.Open) { db.Close(); } }

        public async Task<SqliteDataReader> RunSqliteCommand(string command, List<SqliteParameter> parameters = null)
        {
            try
            {
                SqliteCommand sqliteCommand = new SqliteCommand(command, db);

#if DEBUG
                string resultCommand = command;
#endif

                if (parameters != null)
                {
                    foreach (SqliteParameter parameter in parameters)
                    {
#if DEBUG
                        if (parameter.Value is null)
                        {
                            resultCommand = resultCommand.Replace(parameter.ParameterName.ToString(), null);
                        }
                        else
                        {
                            resultCommand = resultCommand.Replace(parameter.ParameterName.ToString(), parameter.Value.ToString());
                        }
#endif


                        _ = sqliteCommand.Parameters.AddWithNullableValue(parameter.ParameterName, parameter.Value);
                    }
                }

                SqliteDataReader response = await sqliteCommand.ExecuteReaderAsync();

                return response;
            }
            catch (Exception ex) { throw ex; }

        }
    }
}
