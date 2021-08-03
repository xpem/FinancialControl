using FinancialControl.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FinancialControl.ViewModels.Account
{
   public class AccountFormVM : ObservableObject
    {
        private INavigation _navigation;

        private decimal numbertoMoney { get; set; }
        public decimal NumbertoMoney
        {
            get { return numbertoMoney; }
            set
            {
                numbertoMoney = value;
                OnPropertyChanged();
            }
        }

        public ICommand TransferMoneyCommand { get; set; }


        public AccountFormVM(INavigation navigation)
        {

        }
    }
}
