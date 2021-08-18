using FinancialControl.ViewModels.Account;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinancialControl.Views.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountForm : ContentPage
    {
        public AccountForm(int AccountId)
        {
            InitializeComponent();
            this.BindingContext = new AccountFormVM(this.Navigation,AccountId);
        }
    }
}