using MvvmHelpers;
using MobileUI.Models;
using System.Linq;


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
