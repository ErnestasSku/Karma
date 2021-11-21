using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostingsPage : ContentPage
    {
        public PostingsPage()
        {
            InitializeComponent();
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {

        }

        private void AddNewItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddItemPage());
        }
    }
}