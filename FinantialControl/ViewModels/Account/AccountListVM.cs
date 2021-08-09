using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using ModelLayer;

namespace FinancialControl.ViewModels.Account
{
    public class AccountListVM
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private ObservableCollection<ModelLayer.Account> accountsList;
        public ObservableCollection<ModelLayer.Account> AccountsList { get { return accountsList; } set { accountsList = value; Notify(); } }

        public AccountListVM()
        {
            GetAccounts();
        }


        public async void GetAccounts()
        {
            AccountsList = new ObservableCollection<ModelLayer.Account>();

            foreach (ModelLayer.Account account in await new BusinessLayer.Accounts().GetAccounts())
            {
                AccountsList.Add(account);
            }
        }
    }
}
