using MobileUI.ViewModels;
using Xamarin.Forms;

namespace MobileUI.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        public string Name
        {
            get => ItemDetailPageViewModel.Name;
        }
        public string Description
        {
            get => ItemDetailPageViewModel.Description;
        }
        public string Img
        {
            get => ItemDetailPageViewModel.Img;
        }
    }
}