using CommunityToolkit.Mvvm.ComponentModel;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using SkiaSharp;
using System.Linq;

namespace Hospital.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty] ViewModelBase pageSwither = new LoginPageViewModel();
        public static MainWindowViewModel Instance { get; set; }
        public MainWindowViewModel()
        {
            Instance = this;
        }
    }
}
