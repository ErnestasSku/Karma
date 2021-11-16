using MobileUI.Models;
using MobileUI.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MobileUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //FOR DEBUGING VARIOUS PAGES, CHANGE < new ...Page(); > into required page to view it
            Item.Items = new MvvmHelpers.ObservableRangeCollection<Item>();
            Item.AddData(Item.Items);
            MainPage = new StartPage();
            
            //Current.MainPage = new NavigationPage(FirstPage);
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
