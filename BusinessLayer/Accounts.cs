using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Accounts
    {
        public async Task CreateAccount(Account account)
        {
            //gera um id local temporário único
            account.Key = Guid.NewGuid().ToString();

            await new AccessLayer.Accounts.AccountsLocal().CreateAccount(account);
        }

        public async Task UpdateAccount(Account account)
        {
            await new AccessLayer.Accounts.AccountsLocal().UpdateAccount(account);
        }

        public async Task<List<Account>> GetAccounts()
        {
            return await new AccessLayer.Accounts.AccountsLocal().GetAccounts();
        }

        public async Task<Account> GetAccount(int id)
        {
            return await new AccessLayer.Accounts.AccountsLocal().GetAccount(id);
        }

        public async Task<bool> VerifyAccountByName(string name)
        {
            return await new AccessLayer.Accounts.AccountsLocal().VerifyAccountByName(name);
        }
    }
}