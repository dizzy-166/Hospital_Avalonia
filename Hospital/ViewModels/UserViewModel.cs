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

        public int? Age
        {
            get
            {
                if (logined?.IdUserNavigation?.BirthDate != null)
                {
                    var birthDate = logined.IdUserNavigation.BirthDate.Value;
                    var today = DateOnly.FromDateTime(DateTime.Today);
                    var age = today.Year - birthDate.Year;
                    if (birthDate > today.AddYears(-age)) age--;
                    return age;
                }
                return null;
            }
        }

        public UserViewModel(LoginTable currentUser)
        {
            logined = currentUser;
            
        }

    }
}