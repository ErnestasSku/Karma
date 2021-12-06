using DataBase.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MobileUI.ViewModels
{
    public class PostingsViewModel : INotifyPropertyChanged
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
        public ObservableRangeCollection<Item> Items { get; set; }
        public PostingsViewModel()
        {
            Items = App.GetUserItems(App.CurrentUser.Username);
            RefreshCommand = new AsyncCommand(Refresh);
        }
        async Task Refresh()
        {
            IsRefreshing = true;
            await Task.Delay(50);
            Items.Clear();

            var items = App.GetUserItems(App.CurrentUser.Username);
            Items.AddRange(items);

            IsRefreshing = false;
        }
    }
}