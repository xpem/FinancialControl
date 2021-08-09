using FinancialControl.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FinancialControl.ViewModels.Account
{
    public class AccountFormVM : ObservableObject
    {
        private INavigation _navigation;

        #region ui objects

        private string name, value, description;
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public string Value { get => value; set { this.value = value; OnPropertyChanged(); } }
        public string Description { get => description; set { description = value; OnPropertyChanged(); } }


        #endregion

        public ICommand CreateAccountCommand
        {
            get
            {
                return new Command(async (e) =>
                {
                    if (await ValidateInputs())
                    {
                        ModelLayer.Account account = new ModelLayer.Account() { Name = Name, Value = Value, Description = Description };
                        _ = new BusinessLayer.Accounts().CreateAccount(account);
                    }
                });
            }
        }

        private async Task<bool> ValidateInputs()
        {
            if (string.IsNullOrEmpty(Name))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso", "Insira um nome para sua conta", "Voltar");
                return false;

            }
            if (string.IsNullOrEmpty(value))
            {
                if (!decimal.TryParse(Value, out _))
                {
                    await Application.Current.MainPage.DisplayAlert("Confirmação", "Este valor inicial da conta não é valido.", "Voltar");
                    return false;
                }
            }

            return true;
        }

        public AccountFormVM(INavigation navigation)
        {

        }
    }
}
