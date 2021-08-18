using FinancialControl.Utils;
using FinancialControl.Views.Account;
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
        private readonly int id;
        private readonly string nameOri;

        #region ui objects

        private string name, value, description;
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public string Value { get => value; set { this.value = value; OnPropertyChanged(); } }
        public string Description { get => description; set { description = value; OnPropertyChanged(); } }

        #endregion

        public ICommand CreateEditAccountCommand
        {
            get
            {
                return new Command(async (e) =>
                {
                    if (await ValidateInputs())
                    {
                        if (id == 0)
                        {
                            ModelLayer.Account account = new ModelLayer.Account() { Name = Name, Value = Value, Description = Description };
                            _ = new BusinessLayer.Accounts().CreateAccount(account);
                        }
                        else
                        {
                            ModelLayer.Account account = new ModelLayer.Account() { Id = id, Name = Name, Value = Value, Description = Description };
                            _ = new BusinessLayer.Accounts().UpdateAccount(account);
                        }
                        Application.Current.MainPage = new NavigationPage(new AccountList());
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
            else
            {
                if (((id == 0) || (nameOri != name)) && await new BusinessLayer.Accounts().VerifyAccountByName(Name))
                {
                    await Application.Current.MainPage.DisplayAlert("Aviso", "Já existe uma conta cadastrada com este nome", "Voltar");
                    return false;
                }
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

        public AccountFormVM(INavigation navigation, int _id)
        {
            if (_id > 0)
            {
                ModelLayer.Account account = Task.Run(async () => await new BusinessLayer.Accounts().GetAccount(_id)).Result;
                id = account.Id;
               nameOri = Name = account.Name;
                Value = account.Value;
                Description = account.Description;
            }
        }
    }
}
