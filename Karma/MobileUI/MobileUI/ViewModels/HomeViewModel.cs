
using MobileUI.Models;
using MvvmHelpers;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MobileUI.ViewModels
{
    public class HomeViewModel
    {
        public ObservableRangeCollection<DataBase.Models.Item> Items { get; set; }

        public HomeViewModel()
        {
            Items = App.Items;
       
        }

    }
}