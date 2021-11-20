using DataBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MobileUI.ViewModels
{
    class AccountViewModel : INotifyPropertyChanged
    {
        private User _user;

        public event PropertyChangedEventHandler PropertyChanged;

        public AccountViewModel()
        {
            _user = App.currentUser;
        }
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
            }
        }
    }
}
