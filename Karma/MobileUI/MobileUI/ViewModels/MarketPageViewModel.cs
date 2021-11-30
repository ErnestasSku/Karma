using MvvmHelpers;
using MvvmHelpers.Commands;
using MobileUI.Models;
using MobileUI.Views;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;
using System.ComponentModel;
using System.Collections.Generic;

namespace MobileUI.ViewModels
{
    public class MarketPageViewModel : INotifyPropertyChanged
    {

        
        public List<string> SortTypes { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isRefreshing = false;

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRefreshing"));
            }
        }

        public AsyncCommand RefreshCommand { get; }

        private static ObservableRangeCollection<DataBase.Models.Item> _items;
        private static ObservableRangeCollection<DataBase.Models.Item> _itemsDup = new ObservableRangeCollection<DataBase.Models.Item>();
        public ObservableRangeCollection<DataBase.Models.Item> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
            }
        }

        public MarketPageViewModel()
        {
            
            _items = App.Items;
            _itemsDup.AddRange(_items);

            SortTypes = GetSortTypes();
            //_items = new ObservableRangeCollection<DataBase.Models.Item>(Items.OrderBy(i => i.Name));
            RefreshCommand = new AsyncCommand(Refresh);
            
            
        }
        public static void Sort(int type)
        {
            ObservableRangeCollection<DataBase.Models.Item> sorted;
            switch (type)
            {
                
                case 0:
                    sorted = new ObservableRangeCollection<DataBase.Models.Item>(_items.OrderBy(i => i.Name));
                    break;
                case 1:
                    sorted = new ObservableRangeCollection<DataBase.Models.Item>(_items.OrderByDescending(i => i.Name));
                    break;
                case 2:
                    sorted = new ObservableRangeCollection<DataBase.Models.Item>(_items.OrderByDescending(i => i.ItemId));
                    break;
                case 3:
                    sorted = new ObservableRangeCollection<DataBase.Models.Item>(_items.OrderBy(i => i.ItemId));
                    break;
                case 4:
                    sorted = new ObservableRangeCollection<DataBase.Models.Item>(_items.OrderBy(i => i.City));
                    break; 
                case 5:
                    sorted = new ObservableRangeCollection<DataBase.Models.Item>(_items.OrderByDescending(i => i.City));
                    break;
                default:
                    sorted = _items;
                    break;
            }
            _items.Clear();
           
            _items.AddRange(sorted);
        }
        public static void Filter(string filter)
        {
            ObservableRangeCollection<DataBase.Models.Item> filtered;
            var old = _itemsDup;
            
            filtered = new ObservableRangeCollection<DataBase.Models.Item>(_itemsDup.Where((item) => item.Name.ToLower().Contains(filter)));
            _itemsDup = old;
            _items.Clear();
            _items.AddRange(filtered);
        }
        async Task Refresh()
        {
            IsRefreshing = true;
            await Task.Delay(50);
            _items.Clear();

            var items = await App.GetItemsAsync();
           _items.AddRange(items);
            _itemsDup = items;

            IsRefreshing = false;
        }
        public List<string> GetSortTypes()
        {
            var s = new List<string>()
            {
                new string ("Name A-Z"),
                new string ("Name Z-A"),
                new string ("Newest"),
                new string ("Oldest"),
                new string ("City A-Z"),
                new string ("City Z-A")
            };
            return s;
        }
    }
}
