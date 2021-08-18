using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FinancialControl.ViewModels.Account;

namespace FinancialControl.Views.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountList : ContentPage
    {
        public AccountList()
        {
            InitializeComponent();

            BindingContext = new AccountListVM(Navigation);
        }

        private void BtnAddAccount_Clicked(object sender, EventArgs e)
        {
            _ = Navigation.PushAsync(new AccountForm(0));
        }
    }
}