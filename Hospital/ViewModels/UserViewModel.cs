using CommunityToolkit.Mvvm.ComponentModel;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Hospital.ViewModels
{
    public partial class UserViewModel : ViewModelBase
    {
        private readonly SheronovContext db = new SheronovContext();

        [ObservableProperty]
        private LoginTable logined;

        [ObservableProperty]
        private ObservableCollection<VisitsTable> medicalHistory = new();

        [ObservableProperty]
        private ObservableCollection<PatientAllergy> allergies = new();

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
            LoadMedicalCardData();
        }

        private void LoadMedicalCardData()
        {
            try
            {
                // Загружаем основные данные пациента
                logined = db.LoginTables
                    .Include(x => x.IdUserNavigation)
                    .ThenInclude(u => u.IdGenderNavigation)
                    .FirstOrDefault(x => x.IdUser == logined.IdUser);

                Debug.WriteLine($"Loaded patient: {logined?.IdUserNavigation?.Name} (ID: {logined?.IdUser})");

                // Загружаем медицинскую историю (диагнозы)
                var history = db.VisitsTables
                    .Include(v => v.IdDiagnosisNavigation)
                    .Where(v => v.IdUser == logined.IdUser)
                    .OrderByDescending(v => v.VisitDate)
                    .ToList();

                MedicalHistory = new ObservableCollection<VisitsTable>(history);
                Debug.WriteLine($"Loaded {MedicalHistory.Count} medical history records");

                // Загружаем аллергии с отладкой
                var patientAllergies = db.PatientAllergies
                    .Where(a => a.IdPatient == logined.IdUser)
                    .ToList();

                Debug.WriteLine($"Found {patientAllergies.Count} allergies for patient ID: {logined.IdUser}");

                // Выведем все аллергии в отладку
                foreach (var allergy in patientAllergies)
                {
                    Debug.WriteLine($"Allergy: {allergy.AllergyName}, Severity: {allergy.Severity}");
                }

                Allergies = new ObservableCollection<PatientAllergy>(patientAllergies);

               
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading medical card data: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Error loading medical card data: {ex.Message}");
            }
        }
    }
}