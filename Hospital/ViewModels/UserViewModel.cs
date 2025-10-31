using CommunityToolkit.Mvvm.ComponentModel;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hospital.ViewModels
{
    public partial class UserViewModel : ViewModelBase
    {
        private readonly SheronovContext db = new SheronovContext();

        [ObservableProperty]
        private LoginTable logined;


        public UserViewModel(LoginTable currentUser)
        {
            logined = currentUser;
            
        }
    }
}