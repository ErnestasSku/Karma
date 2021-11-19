using MvvmHelpers;
using MobileUI.Models;
using System.Linq;


namespace MobileUI.ViewModels
{
    public class MarketPageViewModel
    {

        public ObservableRangeCollection<DataBase.Models.Item> Items { get; set; }
        public MarketPageViewModel()
        {
            Items = App.Items;
            
        }
    }
}
