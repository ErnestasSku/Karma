
using MobileUI.Models;
using MvvmHelpers;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MobileUI.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {

        private ObservableRangeCollection<DataBase.Models.Item> _items;
        public ObservableRangeCollection<DataBase.Models.Item> Items 
        {
            get { return _items; }
            set { _items = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));

            } 
        }

        public HomeViewModel()
        {
            Items = App.Items;
       
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}