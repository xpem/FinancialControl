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
            await new AccessLayer.Accounts.AccountsLocal().CreateAccount(account);
        }
    }
}
