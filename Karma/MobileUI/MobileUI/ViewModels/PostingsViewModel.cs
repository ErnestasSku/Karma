using MvvmHelpers;
using MobileUI.Models;
namespace MobileUI.ViewModels
{
    public class PostingsViewModel
    {
        public ObservableRangeCollection<Item> Items { get; set; }
        public PostingsViewModel()
        {
            Items = Item.Items;

        }
    }
}