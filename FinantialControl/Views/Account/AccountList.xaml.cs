using FinancialControl.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinancialControl.Views.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountList : ContentPage
    {
        public AccountList()
        {
            InitializeComponent();

            BindingContext = new AccountListViewModel();
        }
    }
}