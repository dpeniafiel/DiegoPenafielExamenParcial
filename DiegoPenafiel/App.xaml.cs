using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiegoPenafiel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Registro("dp"));
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
