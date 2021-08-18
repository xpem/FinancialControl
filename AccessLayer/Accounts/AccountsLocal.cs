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
            _ = await RunSqliteCommand("INSERT INTO account(key,UserKey,LastUpdate,Name,Value,Description) values (@Key,@UserKey,@LastUpdate,@Name,@Value,@Description)",
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

        public async Task UpdateAccount(ModelLayer.Account account)
        {
            OpenIfClosed();
            _ = await RunSqliteCommand("UPDATE account SET LastUpdate = @LastUpdate,Name = @Name,Value = @Value,Description = @Description WHERE  Id = @Id",
                 // AND UserKey = @UserKey",
                 new List<SqliteParameter>() {
                     new SqliteParameter("@Id", account.Id),
                     new SqliteParameter("@UserKey", account.UserKey),
                     new SqliteParameter("@LastUpdate", account.LastUpdate),
                     new SqliteParameter("@Name", account.Name),
                     new SqliteParameter("@Value", account.Value),
                     new SqliteParameter("@Description", account.Description),
                 });
            CloseIfOpen();
        }

        /// <summary>
        /// List of Accounts
        /// </summary>
        /// <returns></returns>
        public async Task<List<ModelLayer.Account>> GetAccounts()
        {
            OpenIfClosed();
            SqliteDataReader response = await RunSqliteCommand("select id,key,UserKey,LastUpdate,Name,Value,Description from account");

            List<ModelLayer.Account> list = new List<ModelLayer.Account>();

            while (response.Read())
            {
                list.Add(new ModelLayer.Account()
                {
                    Id = response.GetInt32(0),
                    Key = response.GetWithNullableString(1),
                    UserKey = response.GetWithNullableString(2),
                    LastUpdate = Convert.ToDateTime(response.GetWithNullableString(3)),
                    Name = response.GetWithNullableString(4),
                    Value = response.GetWithNullableString(5),
                    Description = response.GetWithNullableString(6)
                });
            }
            CloseIfOpen();

            return list;
        }

        /// <summary>
        /// Account Object
        /// </summary>
        /// <returns></returns>
        public async Task<ModelLayer.Account> GetAccount(int id)
        {
            OpenIfClosed();

            SqliteDataReader response = await RunSqliteCommand("select id,key,UserKey,LastUpdate,Name,Value,Description from account where id = @id",
                new List<SqliteParameter>() { new SqliteParameter("@id", id) });

            _ = response.Read();

            ModelLayer.Account account = new ModelLayer.Account()
            {
                Id = response.GetInt32(0),
                Key = response.GetWithNullableString(1),
                UserKey = response.GetWithNullableString(2),
                LastUpdate = Convert.ToDateTime(response.GetWithNullableString(3)),
                Name = response.GetWithNullableString(4),
                Value = response.GetWithNullableString(5),
                Description = response.GetWithNullableString(6)
            };

            CloseIfOpen();

            return account;
        }

        /// <summary>
        /// Veriry if exists a account whith this name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<bool> VerifyAccountByName(string name)
        {
            OpenIfClosed();

            SqliteDataReader response = await RunSqliteCommand("select id from account where Name = @Name",
                new List<SqliteParameter>() { new SqliteParameter("@Name", name) });

            bool exist = response.Read();

            CloseIfOpen();

            return exist;
        }
    }
}
