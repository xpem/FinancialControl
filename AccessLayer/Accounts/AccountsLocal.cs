using AccessLayer.Sqlite;
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
            OpenIfClosed();
            _ = await RunSqliteCommand("INSERT INTO account(key,UserKey,LastUpdate,Name,Value,Description) values (@key,@UserKey,@LastUpdate,@Name,@Value,@Description)",
                 new List<SqliteParameter>() {
                     new SqliteParameter("@Key", account.Key),
                     new SqliteParameter("@UserKey", account.UserKey),
                     new SqliteParameter("@LastUpdate", account.LastUpdate),
                     new SqliteParameter("@Name", account.Name),
                     new SqliteParameter("@Value", account.Value),
                     new SqliteParameter("@Description", account.Description),
                 });
            CloseIfOpen();
        }

        public async Task<List<ModelLayer.Account>> GetAccounts()
        {
            OpenIfClosed();
            SqliteDataReader response = await RunSqliteCommand("select key,UserKey,LastUpdate,Name,Value,Description from account");

            List<ModelLayer.Account> list = new List<ModelLayer.Account>();

            while (response.Read())
            {
                list.Add(new ModelLayer.Account()
                {
                    Key = response.GetWithNullableString(0),
                    UserKey = response.GetWithNullableString(1),
                    LastUpdate = Convert.ToDateTime(response.GetWithNullableString(2)),
                    Name = response.GetWithNullableString(3),
                    Value = response.GetWithNullableString(4),
                    Description = response.GetWithNullableString(5)
                });
            }
            CloseIfOpen();

            return list;
        }
    }
}
