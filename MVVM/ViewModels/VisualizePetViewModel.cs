using PetGPS.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
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


        public VisualizePetViewModel(int petid)
        {
            PetId = petid;
            fillInfo(petid);
        }

        public void fillInfo(int id)
        {
            Pet pet = App.PetRepo.GetItem(id);
            
            PetName = pet.Name;
            PetRace = pet.Race;
            PetColors = pet.Colors;
            PetSex = pet.Sex;
            PetDesc = pet.Description;

            OwnerName = getOwnerName(pet);

            fillReportInfo(id);
        }

        private void fillReportInfo(int petid)
        {
            var reports = App.ReportRepo.GetItems();
            Report report = reports.Where(x => x.PetId == petid).FirstOrDefault();

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
