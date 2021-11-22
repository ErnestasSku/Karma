
using DataBase.Models;
using MobileUI.ViewModels;
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
    public partial class AddItemPage : ContentPage
    {

        string image;
        string category;
        string title;
        string description;
        string contactInfo;

        public AddItemPage()
        {
            InitializeComponent();
        }

        private void Image_TextChanged(object sender, TextChangedEventArgs e)
        {
            image = ((Entry)sender).Text;
        }

        private void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            Models.Category categ = (Models.Category)categoryPicker.SelectedItem;
            category = categ.Value;
        }

        private void ContactInfo_TextChanged(object sender, TextChangedEventArgs e)
        {
            contactInfo = ((Entry)sender).Text;
        }

        private void Description_TextChanged(object sender, TextChangedEventArgs e)
        {
            description = ((Editor)sender).Text;
        }

        private void Title_TextChanged(object sender, TextChangedEventArgs e)
        {
            title = ((Entry)sender).Text;
        }

        private void AddItem_Clicked(object sender, EventArgs e)
        {
            Item item = new Item();
            item.Name = title;
            item.Category = category;
            item.Description = description;
            item.ContactInfo = contactInfo;
            item.Image = image;
            item.Poster = App.CurrentUser;

            App.PostItem(item);

            Navigation.PopAsync();
        }
    }
}