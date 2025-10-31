using CommunityToolkit.Mvvm.ComponentModel;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    internal partial class LoginPageViewModel:ViewModelBase
    {
        [ObservableProperty] string login;
        [ObservableProperty] string password;
        [ObservableProperty] string message;

        private LoginTable currentUser;

        public void Enter()
        {
            currentUser = db.LoginTables.Include(x => x.IdUserNavigation).FirstOrDefault(x => x.Login == Login && x.Password == Password);
            if ( currentUser == null)
            {
                Message = "The user is missing";
            }
            else
            {
                switch (currentUser.IdRole)
                {
                    case 1:
                        MainWindowViewModel.Instance.PageSwither = new AdminViewModel();
                        break;
                    case 2:
                        MainWindowViewModel.Instance.PageSwither = new DoctorViewModel();
                        break;
                    case 3:
                        MainWindowViewModel.Instance.PageSwither = new UserViewModel(currentUser);
                        break;
                }
            }
        }
    }
}
