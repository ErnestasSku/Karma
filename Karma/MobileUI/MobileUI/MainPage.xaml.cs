using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void Item_Tapped(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new ItemDetailPage());

            //throw new Exception();
        }
    }
}
