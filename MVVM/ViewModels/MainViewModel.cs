using PetGPS.MVVM.Models;
using System.Diagnostics;

namespace PetGPS.MVVM.ViewModels
{
    public class MainViewModel
    {
        public List<Report> Reports { get; set; }
        public Location Location { get; set; }

        public MainViewModel()
        {
            UpdateReports();
        }

        public string GetPetName(int id)
        {
            return App.PetRepo.GetItem(id).Name;
        }

        public string GetPetDesc(int id)
        {
            return App.PetRepo.GetItem(id).Description;
        }

        public void UpdateReports()
        {
            Reports = App.ReportRepo.GetItems();
        }
    }
}
