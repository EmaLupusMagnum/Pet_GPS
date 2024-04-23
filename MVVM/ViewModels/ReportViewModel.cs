using PetGPS.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetGPS.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ReportViewModel
    {
        public string Location {  get; set; } 
        private int UserId { get; set; }
        public ObservableCollection<Pet> Pets { get; set; }
        private string Description { get; set; }
        public Pet Pet { get; set; }

        public ReportViewModel()
        {
            UpdateData();
        }

        public async Task<string> ValidateReport(Pet pet, string location, string description)
        {
            if (pet == null)
                return "Debe seleccionar una mascota para reportar su perdida, si no la ve agreguela";

            Location = await IsValidLocation(location);
            if (Location == "Not Found")
                return "Ubicación invalida, por favor trate de ser mas preciso";

            if (!CheckReportDescription(description))
                return "Debes agregar una descripcion y no puede contener numeros ni caracteres especiales";

            Pet = pet;
            return "Valid";
        }

        private async Task<string> IsValidLocation(string location)
        {
            try 
            {
                var locations = await Geocoding.GetLocationsAsync(location);
                if (locations.Count() > 0)
                    return location;
            } 
            catch (Exception ex)
            { 
                Debug.WriteLine(ex);
                
            }
            return "Not Found";
        }

        private bool CheckReportDescription(string description)
        {
            // Expresión regular para validar que la cadena contiene solo letras, comas, puntos, punto y comas, y espacios
            string pattern = @"^[a-zA-Z,.;\s]*$";

            if (string.IsNullOrEmpty(description)) return false;

            if (!Regex.IsMatch(description, pattern)) return false;

            Description = description;
            return true;
        }

        public void UploadReport()
        {
            Report report = new Report()
            {
                UserId = UserId,
                Location = Location,
                Description = Description,
                PetId = Pet.Id
            };
            App.ReportRepo.SaveItem(report);
            Debug.WriteLine(App.ReportRepo.StatusMessage);
        }

        public void UpdateData()
        {
            Pets = new ObservableCollection<Pet>(App.PetRepo.GetItems());
            UserId = App.UserRepo.GetItems().FirstOrDefault().Id;
        }
    }
}
