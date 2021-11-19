using MvvmHelpers;
using MobileUI.Models;
namespace MobileUI.ViewModels
{
    public class MarketPageViewModel
    {
        public ObservableRangeCollection<Item> Items { get; set; }
        public MarketPageViewModel()
        {
            Items = Item.Items;
            
        }
    }
}
