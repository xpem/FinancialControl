using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using FinancialControl.Utils;
using FinancialControl.Views.Account;
using ModelLayer;
using Xamarin.Forms;

namespace FinancialControl.ViewModels.Account
{
    public class AccountListVM : ObservableObject
    {

        private ObservableCollection<ModelLayer.Account> accountsList;
        private ModelLayer.Account account;

        public ObservableCollection<ModelLayer.Account> AccountsList { get => accountsList; set { accountsList = value; OnPropertyChanged(); } }

        public ModelLayer.Account Account
        {
            get => account;
            set
            {
                account = value;
                _ = navigation.PushAsync(new AccountForm(account.Id));
                account = null;
                OnPropertyChanged();
            }
        }

        public AccountListVM(INavigation _navigation)
        {
            navigation = _navigation;
            GetAccounts();
        }

        public async void GetAccounts()
        {
            AccountsList = new ObservableCollection<ModelLayer.Account>();

            foreach (ModelLayer.Account account in await new BusinessLayer.Accounts().GetAccounts())
            {
                account.Value = Convert.ToDecimal(account.Value).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
                AccountsList.Add(account);

            }
        }
    }
}
