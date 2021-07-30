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

        private ObservableCollection<ModelLayer.Account> accounts;
        public ObservableCollection<ModelLayer.Account> Accounts { get { return accounts; } set { accounts = value; Notify(); } }

        public AccountListVM()
        {
            Accounts = new ObservableCollection<ModelLayer.Account>()
            {
                new ModelLayer.Account(){ Id=0,Name="teste a", Value= "R$ 1,00"},
                new ModelLayer.Account(){ Id=1,Name="teste b", Value= "R$ 2,00"},
                new ModelLayer.Account(){ Id=2,Name="teste c", Value= "R$ 3,00"},
                new ModelLayer.Account(){ Id=3,Name="teste d", Value= "R$ 4,00"},
            };
        }
    }
}
