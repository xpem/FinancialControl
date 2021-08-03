using FinancialControl.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinancialControl.Views.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountForm : ContentPage
    {
        public AccountForm()
        {
            InitializeComponent();
            this.BindingContext = new AccountFormVM(this.Navigation); ;
        }
    }
}