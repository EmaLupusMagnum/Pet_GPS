using PetGPS.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGPS.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class VisualizePetViewModel
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public string OwnerName { get; set; }
        public string PetRace { get; set; }
        public string PetColors { get; set; }
        public string PetSex { get; set; }
        public string PetDesc { get; set; }
        public bool IsLost { get; set; }
        public string PetLastLocation { get; set; }
        public string ReportDesc { get; set; }


        public VisualizePetViewModel(string name, string desc)
        {
            PetName = name;
            PetDesc = desc;

            PetId = searchId(name,desc);

            fillInfo();
        }

        private int searchId(string name, string desc)
        {
            try
            {
                PetId =
                App.PetRepo.GetItems().Where(d => d.Description == desc)
                .FirstOrDefault(n => n.Name == name).Id;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                return -1;
            }

            return PetId;
        }

        public void fillInfo()
        {
            Pet pet = App.PetRepo.GetItem(PetId);
            
            PetRace = pet.Race;
            PetColors = pet.Colors;
            PetSex = pet.Sex;

            OwnerName = getOwnerName(pet);

            fillReportInfo();
        }

        private void fillReportInfo()
        {
            var reports = App.ReportRepo.GetItems();
            Report report = reports.Where(x => x.PetId == PetId).FirstOrDefault();

            if (report != null) 
            {
                IsLost = true;
                PetLastLocation = report.Location;
                ReportDesc = report.Description;
            }
            else
                IsLost = false;
        }

        public string getOwnerName(Pet pet)
        {
            int ownerid = pet.OwnerId;
            User user = App.UserRepo.GetItem(ownerid);
            
            return user.Name;
        }
    }

    
}
