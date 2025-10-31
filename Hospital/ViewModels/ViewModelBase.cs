using CommunityToolkit.Mvvm.ComponentModel;
using Hospital.Models;

namespace Hospital.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
       public static SheronovContext db = new SheronovContext();
       public LoginTable? currentUser; 
    }
}
