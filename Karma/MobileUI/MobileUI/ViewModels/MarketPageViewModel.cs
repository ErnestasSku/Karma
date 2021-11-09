using MvvmHelpers;
using MvvmHelpers.Commands;
using MobileUI.Models;
using MobileUI.Views;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace MobileUI.ViewModels
{
    public class MarketPageViewModel
    {
        public ObservableRangeCollection<Item> Items { get; set; }
        public ObservableRangeCollection<Grouping<string, Item>> ItemGroups { get; }

        public MarketPageViewModel()
        {
            Items = new ObservableRangeCollection<Item>();
            ItemGroups = new ObservableRangeCollection<Grouping<string, Item>>();
            AddData();

        }
        private void AddData()
        {
            Items.Add(new Item
            {
                Name = "Table",
                Location = "Vilnius",
                ImgSource = "https://images.pexels.com/photos/279626/pexels-photo-279626.jpeg"
            });

            Items.Add(new Item
            {
                Name = "Chair",
                Location = "Kaunas",
                ImgSource = "https://images.pexels.com/photos/2258083/pexels-photo-2258083.jpeg"
            });
            Items.Add(new Item
            {
                Name = "Lamp",
                Location = "Vievis",
                ImgSource = "https://images.pexels.com/photos/1112598/pexels-photo-1112598.jpeg"
            });
            Items.Add(new Item
            {
                Name = "Lamp",
                Location = "Vievis",
                ImgSource = "https://images.pexels.com/photos/1112598/pexels-photo-1112598.jpeg"
            });
            Items.Add(new Item
            {
                Name = "Lamp",
                Location = "Vievis",
                ImgSource = "https://images.pexels.com/photos/1112598/pexels-photo-1112598.jpeg"
            });
            Items.Add(new Item
            {
                Name = "Lamp",
                Location = "Vievis",
                ImgSource = "https://images.pexels.com/photos/1112598/pexels-photo-1112598.jpeg"
            });
            Items.Add(new Item
            {
                Name = "Lamp",
                Location = "Vievis",
                ImgSource = "https://images.pexels.com/photos/1112598/pexels-photo-1112598.jpeg"
            });

            ItemGroups.Add(new Grouping<string, Item>("Furniture", Items.Take(2)));
            ItemGroups.Add(new Grouping<string, Item>("Appliances", Items.Take(1)));
        }
    }
}
