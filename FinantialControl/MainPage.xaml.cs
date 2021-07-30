using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinancialControl
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _ = Navigation.PushAsync(new Views.CategoryList());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            _ = Navigation.PushAsync(new Views.Account.AccountList());
        }
    }
}
