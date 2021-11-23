using MvvmHelpers;
using MvvmHelpers.Commands;
using MobileUI.Models;
using MobileUI.Views;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;
using System.ComponentModel;

namespace MobileUI.ViewModels
{
    public class MarketPageViewModel : INotifyPropertyChanged
    {

        

        public event PropertyChangedEventHandler PropertyChanged;

        private bool isRefreshing = false;

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRefreshing"));
            }
        }
        public AsyncCommand RefreshCommand { get; }
        public ObservableRangeCollection<DataBase.Models.Item> Items { get; set; }
        public MarketPageViewModel()
        {
            
            Items = App.Items;
            RefreshCommand = new AsyncCommand(Refresh);
            
            
        }
        async Task Refresh()
        {
            IsRefreshing = true;
            await Task.Delay(50);
            Items.Clear();

            var items = await App.GetItemsAsync();
            Items.AddRange(items);

            IsRefreshing = false;
        }
    }
}
