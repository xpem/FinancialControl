using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinancialControl
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Current.MainPage = new MainPage();
            Current.MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
