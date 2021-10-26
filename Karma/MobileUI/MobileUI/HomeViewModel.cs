
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MobileUI
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Item> Items;

        public ObservableCollection<Item> items
        {
            get { return Items; }
            set { Items = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("items"));
            }
        }
            

        public HomeViewModel()
        {
            items = new ObservableCollection<Item>();
            AddData();
        }
        private void AddData()
        {
            items.Add(new Item
            {
                Name = "Table",
                Location = "Vilnius",
                ImgSource = "https://images.pexels.com/photos/279626/pexels-photo-279626.jpeg"
            });

            items.Add(new Item
            {
                Name = "Chair",
                Location = "Kaunas",
                ImgSource = "https://images.pexels.com/photos/2258083/pexels-photo-2258083.jpeg"
            });
            items.Add(new Item
            {
                Name = "Lamp",
                Location = "Vievis",
                ImgSource = "https://images.pexels.com/photos/1112598/pexels-photo-1112598.jpeg"
            });
        }

    }
}
