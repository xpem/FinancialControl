using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccessLayer.Accounts
{

    public class AccountsLocal : Sqlite.Sqlite
    {
        public async Task CreateAccount(ModelLayer.Account account)
        {
            _ = await RunSqliteCommand("INSERT INTO account(key,UserKey,LastUpdate,Name,Value,Description) value (@key,@UserKey,@LastUpdate,@Name,@Value,@Description)",
                 new List<SqliteParameter>() { 
                     new SqliteParameter("@Key", account.Key),
                     new SqliteParameter("@UserKey", account.UserKey),
                     new SqliteParameter("@LastUpdate", account.LastUpdate),
                     new SqliteParameter("@Name", account.Name),
                     new SqliteParameter("@Value", account.Value),
                     new SqliteParameter("@Description", account.Description),
                 });
        }
    }
}
