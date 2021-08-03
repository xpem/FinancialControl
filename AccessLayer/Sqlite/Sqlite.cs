using Microsoft.Data.Sqlite;
using System;

namespace AccessLayer
{
    public class Sqlite
    {
        public readonly SqliteConnection db = new SqliteConnection($"Filename={System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FinancialControl.db3")}");

    }
}
