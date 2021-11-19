using MobileUI.Models;
using MvvmHelpers;

namespace MobileUI.ViewModels
{
    public class HomeViewModel
    {
        public ObservableRangeCollection<Item> Items { get; set; }

        public HomeViewModel()
        {
            Items = Item.Items;
       
        }

    }
}